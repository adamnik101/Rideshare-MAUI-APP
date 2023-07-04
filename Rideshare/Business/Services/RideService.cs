using RestSharp;
using Rideshare.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.Services
{
    public class RideService : BaseService
    {
        public RideService() { }

        public async Task<PagedResponse<RideDto>> GetRides(PagedReponseDto pagedResponse, SearchRide searchRequest)
        {
            var endpoint = "rides";
            var request = new RestRequest(endpoint);
            if(pagedResponse != null)
            {
                request.AddQueryParameter("PerPage", pagedResponse.ItemsPerPage); 
                request.AddQueryParameter("Page", pagedResponse.CurrentPage);
            }
            
            request.AddQueryParameter("StartCity", searchRequest.StartCity);
            request.AddQueryParameter("DestinationCity", searchRequest.DestinationCity);
            request.AddQueryParameter("RideDate", searchRequest.RideDate);

            return Client.Get<PagedResponse<RideDto>>(request);
      
        }
        public async Task GetRide(int id)
        {

        }
        public async void CreateRide(CreateRideDto requestData)
        {
            var endpoint = "rides";
            var request = new RestRequest(endpoint);
            var actor = await SecureStorage.Default.GetActor();

            request.AddHeader("Authorization", $"Bearer {actor.Token}");
            request.AddJsonBody(requestData);

            Client.Post<CreateRideDto>(request);

        }
    }
}
