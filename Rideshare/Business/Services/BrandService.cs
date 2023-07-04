using RestSharp;
using Rideshare.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rideshare.Business.Services
{
    public class BrandService : BaseService
    {
        public async Task<PagedResponse<BrandDto>> GetBrands()
        {
            var actor = await SecureStorage.Default.GetActor();

            var endpoint = "brands";
            var request = new RestRequest(endpoint);
            request.AddQueryParameter("PerPage", 200);
            request.AddHeader("Authorization", "Bearer " + actor.Token);

            return Client.Get<PagedResponse<BrandDto>>(request);
        }
        public async Task<PagedResponse<BaseDto>> GetBrandModels(int brandId)
        {
            var actor = await SecureStorage.Default.GetActor();

            var endpoint = $"brands/{brandId}/models";
            var request = new RestRequest(endpoint);
            request.AddQueryParameter("PerPage", 200);
            request.AddHeader("Authorization", "Bearer " + actor.Token);

            return Client.Get<PagedResponse<BaseDto>>(request);
        }
    }
}
