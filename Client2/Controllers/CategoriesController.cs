using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client2.Configurations;
using Client2.Models;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Client2.Controllers
{
    public class CategoriesController : Controller
    {
        private Client clientOptions { get; set; }

        public CategoriesController(IOptions<Client> client)
        {
            clientOptions=client.Value;
        }
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var discoEndPoint= await client.GetDiscoveryDocumentAsync("https://localhost:5000");

            if (discoEndPoint.IsError)
            {
                //log
            }

            ClientCredentialsTokenRequest request = new ClientCredentialsTokenRequest()
            {
                ClientId = clientOptions.ClientId,
                ClientSecret = clientOptions.ClientSecret,
                Address = discoEndPoint.TokenEndpoint
            };
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(request);

            if (tokenResponse.IsError)
            {
                //log
            }

            client.SetBearerToken(tokenResponse.AccessToken);
            var response = await client.GetAsync("https://localhost:5011/api/categories");
            var messageString =await response.Content.ReadAsStringAsync();
            var category = JsonConvert.DeserializeObject<Categories>(messageString);


            return View(category);
        }
    }
}
