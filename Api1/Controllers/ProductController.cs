using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Models;

namespace Api1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IActionResult GetProduct()
        {
            return Ok(new Product()
            {
                Id = 10,
                Name = "Product name",
                Price = 100,
                Stock = 500
            });
        }
    }
}
