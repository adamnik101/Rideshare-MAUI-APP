using RestSharp;
using Rideshare.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.Services
{
    public class CityService : BaseService
    {
        public CityService() { }
        public PagedResponse<CityDto> GetCities()
        {
            var endpoint = "cities";
            var request = new RestRequest(endpoint);
            request.AddQueryParameter("PerPage", 200);

            return Client.Get<PagedResponse<CityDto>>(request); 
        }
    }
}
