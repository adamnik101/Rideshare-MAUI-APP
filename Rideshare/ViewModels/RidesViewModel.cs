using FluentValidation.Results;
using Rideshare.Business;
using Rideshare.Business.DTOs;
using Rideshare.Business.Services;
using Rideshare.Common;
using Rideshare.Pages;
using Rideshare.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rideshare.ViewModels
{
    public class RidesViewModel : BaseViewModel
    {
        private RideService _rideService;
        private CityService _cityService;

        public ICommand SearchCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }
        public ICommand NavigateToDetailPageCommand { get; set; }
        public RideDto SelectedRide { get; set; }
        public ObservableCollection<RideDto> Rides { get; set; }
        public ObservableCollection<CityDto> Cities { get; set; }
        public PagedReponseDto PagedResponse { get; set; }
        public bool IsNextPageButtonEnabled { get; set; }
        public bool IsPreviousButtonEnabled { get; set; }
        public bool IsSearchButtonEnabled => !StartCity.HasError && !DestinationCity.HasError && !Date.HasError;
        public bool HasRides { get; set; }
        public bool NoItemsToShow { get; set; }
        public DateTime Today => DateTime.Now;
        public MProp<DateTime> Date { get; set; } = new MProp<DateTime>();
        public MProp<CityDto> StartCity { get; set; } = new MProp<CityDto>();
        public MProp<CityDto> DestinationCity { get; set; } = new MProp<CityDto>();
        public string SelectedDateFormat { get; set; }
        public string SelectedStartCity { get; set; }
        public string SelectedDestinationCity { get; set; }
        public string ImagePath { get; set; }

        public RidesViewModel()
        {
            _rideService = new RideService();
            _cityService = new CityService();
            GetCities();
            Validate();
            SearchCommand = new Command(GetRides);
            NextPageCommand = new Command(NextPage);
            NavigateToDetailPageCommand = new Command(NavigateToDetailPage);
            PreviousPageCommand = new Command(PreviousPage);
            StartCity.OnValueChange = Validate;
            DestinationCity.OnValueChange = Validate;
            Date.OnValueChange = Validate;
        }

        private async void NavigateToDetailPage()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new DetailsPage(SelectedRide));
        }

        private void Validate()
        {
            var validator = new SearchRideViewModelValidator();

            ValidationResult result = validator.Validate(this);

            StartCity.Error = string.Empty;
            DestinationCity.Error = string.Empty;
            Date.Error = string.Empty;

            if(!result.IsValid)
            {
                var startCityError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("StartCity"));
                if(startCityError != null) StartCity.Error = startCityError.ErrorMessage;

                var destinationCityError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("DestinationCity"));
                if (destinationCityError != null) DestinationCity.Error = destinationCityError.ErrorMessage;

                var dateError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Date"));
                if(dateError != null) Date.Error = dateError.ErrorMessage;
            }

            OnPropertyChanged(nameof(IsSearchButtonEnabled));
        }
        private void GetCities()
        {
            var cities = _cityService.GetCities();

            Cities = new ObservableCollection<CityDto>(cities.Items.ToList());

            OnPropertyChanged(nameof(Cities));
        }
        private async void GetRides()
        {
            Validate();

            var searchRequest = new SearchRide()

            {
                StartCity = this.StartCity.Value.Id,
                DestinationCity = this.DestinationCity.Value.Id,
                RideDate = this.Date.Value
            };
            var rides = await _rideService.GetRides(PagedResponse, searchRequest);
            
            PagedResponse = new PagedReponseDto
            {
                TotalCount = rides.TotalCount,
                CurrentPage = rides.CurrentPage,
                ItemsPerPage = rides.ItemsPerPage,
                PageCount = rides.PageCount
            };
            IsNextPageButtonEnabled = PagedResponse.CurrentPage < PagedResponse.PageCount;
            IsPreviousButtonEnabled = PagedResponse.CurrentPage > 1;
            
            Rides = new ObservableCollection<RideDto>(rides.Items.ToList());
            if(rides.Items.Count() > 0)
            {
                HasRides = true;
                NoItemsToShow = false;
            }
            else
            {
                HasRides = false;
                NoItemsToShow = true;
                bool tempNoItems = NoItemsToShow;
                NoItemsToShow = !tempNoItems;

                SelectedDateFormat = this.Date.Value.HumanizeDateTime();
                SelectedStartCity = this.StartCity.Value.Name;
                SelectedDestinationCity = this.DestinationCity.Value.Name;

                OnPropertyChanged(nameof(SelectedDateFormat));
                OnPropertyChanged(nameof(SelectedStartCity));
                OnPropertyChanged(nameof(SelectedDestinationCity));
                NoItemsToShow = tempNoItems;
            }
            OnPropertyChanged(nameof(PagedResponse));
            OnPropertyChanged(nameof(HasRides));
            OnPropertyChanged(nameof(NoItemsToShow));
            OnPropertyChanged(nameof(Rides));
            
            OnPropertyChanged(nameof(IsNextPageButtonEnabled));
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
        }
        private void NextPage()
        {
            PagedResponse.CurrentPage++;
            GetRides();
            OnPropertyChanged(nameof(IsNextPageButtonEnabled));
        }
        private void PreviousPage()
        {
            PagedResponse.CurrentPage--;
            GetRides();
            OnPropertyChanged(nameof(IsPreviousButtonEnabled));
        }
    }
}
