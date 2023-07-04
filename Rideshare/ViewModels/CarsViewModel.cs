using Newtonsoft.Json;
using Rideshare.Business;
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
    public class CarsViewModel : BaseViewModel
    {
        private CarService _carService;
        private Actor _actor;
        
        public ObservableCollection<CarDto> Cars { get; set; } = new ObservableCollection<CarDto>();
        public CarsViewModel()
        {
            _carService = new CarService();
            InitializeActor();
        }


        private async void InitializeActor()
        {
            _actor = await SecureStorage.Default.GetActor();
            await GetCars();
        }
        private async Task GetCars()
        {

            var cars = await _carService.GetCars();

            Cars = new ObservableCollection<CarDto>(cars);

            OnPropertyChanged(nameof(Cars));
        }
    }
}
