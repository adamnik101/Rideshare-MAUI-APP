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
        
        public ObservableCollection<CarDto> Cars { get; set; }
        public bool HasCars { get; set; }
        public bool DoesntHaveCars { get; set; }
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
        public async Task GetCars()
        {

            var cars = await _carService.GetCars();

            if(cars != null)
            {
                Cars = new ObservableCollection<CarDto>(cars);
                OnPropertyChanged(nameof(Cars));
                HasCars = true;
                DoesntHaveCars = false;
            }
            else
            {
                HasCars = false;
                DoesntHaveCars = true;
            }
            OnPropertyChanged(nameof(HasCars));
            OnPropertyChanged(nameof(DoesntHaveCars));
            
        }
    }
}
