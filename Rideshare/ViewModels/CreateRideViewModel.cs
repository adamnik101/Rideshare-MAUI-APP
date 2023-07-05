using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Rideshare.Business.DTOs;
using Rideshare.Business.Services;
using Rideshare.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rideshare.ViewModels
{
    public class CreateRideViewModel : BaseViewModel
    {
        private CityService _cityService;
        private CarService _carService;
        private RideService _rideService;
        public ObservableCollection<CityDto> Cities { get; set; }
        public ObservableCollection<CarDto> Cars { get; set; }
        public ICommand CreateRideCommand { get; set; }
        public DateTime Today => DateTime.Now;
        public CityDto StartCity { get; set; }
        public CityDto DestinationCity { get; set; }
        public CarDto Car { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; } 
        public CreateRideViewModel() 
        {
            _cityService = new CityService();
            _carService = new CarService();
            _rideService = new RideService();
            GetCars();
            CreateRideCommand = new Command(CreateRide);
            GetCities();
        }
        public async void CreateRide()
        {
            CreateRideDto rideRequest = new CreateRideDto()
            {
                CarId = Car.Id,
                 DestinationCity = DestinationCity.Id,
                 StartCity = StartCity.Id,
                 StartTime = Date,
                 Price = Price
            };
            _rideService.CreateRide(rideRequest);

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.LawnGreen,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10)
            };
            string text = "You have successfuly created new ride!";
            string actionButtonText = "Click here to dismiss";
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show();
        }
        public async void GetCars()
        {
           var cars = await _carService.GetCars();
            if(cars != null)
            {
                Cars = new ObservableCollection<CarDto>(cars);
                OnPropertyChanged(nameof(Cars));
            }
          

            
        }

        private void GetCities()
        {
            var cities = _cityService.GetCities();
            Cities = new ObservableCollection<CityDto>(cities.Items.ToList());

            OnPropertyChanged(nameof(Cities));
        }
    }
}
