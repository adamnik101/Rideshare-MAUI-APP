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
    public class AddCarViewModel : BaseViewModel
    {
        private BrandDto _selectedBrand;
        private BrandService _brandService;
        private ColorService _colorService;
        private RestrictionService _restrictionService;
        private TypeService _typeService;
        private List<int> _years;
        public ObservableCollection<BrandDto> Brands { get; set; }
        public ObservableCollection<BaseDto> Colors { get; set; }
        public ObservableCollection<Restriction> Restrictions { get; set; }
        public ObservableCollection<BaseDto> Types { get; set; }
        public IEnumerable<BaseDto> Models { get; set; }
        public List<int> NumberOfSeats => new List<int> { 1, 2, 3, 4, 5, 6 };
        public MProp<int> SelectedNumberOfSeats { get; set; } = new MProp<int>();
        public MProp<string> LicencePlate { get; set; } = new MProp<string>();
        public MProp<int> SelectedYear { get; set; } = new MProp<int>();
        public MProp<BaseDto> SelectedColor { get; set; } = new MProp<BaseDto>();
        public MProp<BaseDto> SelectedType { get; set; } = new MProp<BaseDto>();
        public MProp<IEnumerable<BaseDto>> SelectedRestrictions { get; set; } = new MProp<IEnumerable<BaseDto>>();
        public List<int> Years 
        {
            get
            {
                if (_years == null)
                {
                    _years = GenerateYears();
                }
                return _years;
            }
            set
            {
                _years = value;
                OnPropertyChanged(nameof(Years));
            }
                
        }
        
        public ICommand AddCarCommand { get; set; }
        public BrandDto SelectedBrand
        {
            get {
                return _selectedBrand; }
            set 
            {
                _selectedBrand = value;
                OnPropertyChanged(nameof(SelectedBrand));
                OnPropertyChanged(nameof(IsBrandSelected));
                FindBrandModels();
            }
        }
        private List<int> GenerateYears()
        {
            var years = new List<int>();
            var maxYear = 25;
            var currentYear = DateTime.Now.Year;

            for (var i = 0; i <= maxYear; i++)
            {
                years.Add(currentYear - i);
            }

            return years;
        }

        public BaseDto SelectedModel { get; set; }
        public bool IsBrandSelected => SelectedBrand != null;

        public AddCarViewModel()
        {
            InitializeServices();
            GetInitialPageData();
            AddCarCommand = new Command(AddCar);
        }

        private void GetInitialPageData()
        {
            GetBrands();
            GetColors();
            GetTypes();
            GetRestrictions();
        }

        private async void GetRestrictions()
        {
            var restrictions = await _restrictionService.GetRestrictions();
            Restrictions = new ObservableCollection<Restriction>(restrictions.Items.ToList());
            OnPropertyChanged(nameof(Restrictions));
        }

        private void InitializeServices()
        {
            _brandService = new BrandService();
            _colorService = new ColorService();
            _typeService = new TypeService();
            _restrictionService = new RestrictionService();
        }

        private async void GetColors()
        {
            var colors = await _colorService.GetColors();
            Colors = new ObservableCollection<BaseDto>(colors.Items.ToList());
            OnPropertyChanged(nameof(Colors));
        }

        private async void GetTypes()
        {
            var types = await _typeService.GetTypes();
            Types = new ObservableCollection<BaseDto>(types.Items.ToList());
            OnPropertyChanged(nameof(Types));
        }

        private void AddCar()
        {
            var all = new List<string>();
            foreach (var restriction in Restrictions)
            {
                if (restriction.IsChecked)
                {
                    all.Add(restriction.Name);
                }
            }
            var selectedBrand = SelectedBrand;
            var selectedModel = SelectedModel;
            var selectedDate = SelectedYear;
            var selectednumber = SelectedNumberOfSeats;
            var color = SelectedColor;
            var type = SelectedType;
            var licence = LicencePlate;

            var addCarRequest = new AddCarDto
            {
                BrandId = SelectedBrand.Id,
                ModelId = SelectedModel.Id,
                FirstRegistration = SelectedYear.Value,
                LicencePlate = LicencePlate.Value,
                ColorId = SelectedColor.Value.Id,
                TypeId = SelectedType.Value.Id
            };

            
            
        }
        public async void GetBrands()
        {
            var brands = await _brandService.GetBrands();
            Brands = new ObservableCollection<BrandDto>(brands.Items.ToList());
            OnPropertyChanged(nameof(Brands));
        }
        public void FindBrandModels()
        {
            Models = new ObservableCollection<BaseDto>(SelectedBrand.Models);
            OnPropertyChanged(nameof(Models));
        }
    }
}
