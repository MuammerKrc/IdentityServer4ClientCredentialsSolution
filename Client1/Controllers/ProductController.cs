using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Client1.Configurations;
using Client1.Models;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Client1.Controllers
{
    public class ProductController : Controller
    {
        private Client clientSettings { get; set; }

        public ProductController(IOptions<Client> _clientOptions)
        {
            clientSettings = _clientOptions.Value;
        }
        public async Task<IActionResult> Index()
        {

            using HttpClient client = new HttpClient();
            var discoveryPoint = await client.GetDiscoveryDocumentAsync("https://localhost:5000");

            if (discoveryPoint.IsError)
            {
                //log
            }

            ClientCredentialsTokenRequest request = new ClientCredentialsTokenRequest()
            {
                ClientId = clientSettings.ClientId,
                ClientSecret = clientSettings.ClientSecret,
                Address = discoveryPoint.TokenEndpoint
            };
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(request);

            if (tokenResponse.IsError)
            {
                //log
            }

            client.SetBearerToken(tokenResponse.AccessToken);
            var response=await client.GetAsync("https://localhost:5010/api/product/getproduct");
            var contentString=await response.Content.ReadAsStringAsync();


            var product=JsonConvert.DeserializeObject<Product>(contentString);


            return View(product);
        }
    }
}
