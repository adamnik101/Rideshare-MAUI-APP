using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Rest;
using Newtonsoft.Json;
using RestSharp;
using Rideshare.Business;
using Rideshare.Business.DTOs;

namespace Rideshare.Business.Services
{
    public class AuthService : BaseService
    {
        private class TokenResponse
        {
            public string Token { get; set; }
        }

        public AuthService() { }
        public Actor Auth(string email, string password)
        {
            RestRequest request = new RestRequest("auth");

            request.AddJsonBody(new { email = email, password = password});

            try
            {
                var response = Client.Post<TokenResponse>(request);

                var claims = new JwtSecurityTokenHandler().ReadJwtToken(response.Token);

                var mail = claims.Claims.FirstOrDefault(x => x.Type == "Email").Value;
                var userId = claims.Claims.FirstOrDefault(x => x.Type == "Id").Value;
                var fullname = claims.Claims.FirstOrDefault(x => x.Type == "Fullname").Value;
                var exp = claims.Claims.FirstOrDefault(x => x.Type == "exp").Value;

                DateTime expirationDate = double.Parse(exp).ToDateTime();

                return new Actor
                {
                    Id = Int32.Parse(userId),
                    Fullname = fullname,
                    Email = mail,
                    LoginExpiration = expirationDate,
                    Token = response.Token
                };
            }
            catch (Exception ex)
            {
                var response = ex.Message;
                return new Actor();
            }
             // baca izuzetak, uhvati ga
            
            /*if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }*/

            
        }
        public bool Register(RegisterData data)
        {
            var endpoint = "users";
            var request = new RestRequest(endpoint);
            request.AddJsonBody(data);

            try
            {
                var response = Client.Post(request);

                if(response.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                var exs = ex;
                return false;
            }
        }
    }
}
