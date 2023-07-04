using Newtonsoft.Json;
using RestSharp;
using Rideshare.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.Services
{
    public class CarService : BaseService
    {
        public CarService() 
        {

        }
        public async Task<List<CarDto>> GetCars()
        {
            var actor = await SecureStorage.Default.GetActor();

            var endpoint = $"users/{actor.Id}/cars";

            var request = new RestRequest(endpoint);

            request.AddHeader("Authorization","Bearer " + actor.Token);
            
            var response = Client.Get<List<CarDto>>(request);

            return response;
        }
        public async void AddCar(AddCarDto requestData)
        {
            var actor = await SecureStorage.Default.GetActor();

            var endpoint = $"cars";
            var request = new RestRequest(endpoint);
            request.AddHeader("Authorization", "Bearer " + actor.Token);

        }
    }
}
