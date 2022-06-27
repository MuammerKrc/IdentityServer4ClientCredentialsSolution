using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [Authorize(policy: "Read")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(new
            {
                Id = 10,
                Name = "Computer",
            });
        }
    }
}
