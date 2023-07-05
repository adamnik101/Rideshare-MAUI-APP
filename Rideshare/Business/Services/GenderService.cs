using RestSharp;
using Rideshare.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.Services
{
    public class GenderService : BaseService
    {
        public GenderService() { }
        public IEnumerable<BaseDto> GetGenders()
        {
            var endpoint = "genders";
            var request = new RestRequest(endpoint);
            return Client.Get<IEnumerable<BaseDto>>(request);
        }
    }
}
