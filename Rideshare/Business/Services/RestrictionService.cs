using RestSharp;
using Rideshare.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.Services
{
    public class RestrictionService : BaseService
    {
        public async Task<PagedResponse<Restriction>> GetRestrictions()
        {
            var actor = await SecureStorage.Default.GetActor();

            var endpoint = "restrictions";
            var request = new RestRequest(endpoint);
            request.AddQueryParameter("PerPage", 200);
            request.AddHeader("Authorization", "Bearer " + actor.Token);

            return Client.Get<PagedResponse<Restriction>>(request);
        }

    }
}
