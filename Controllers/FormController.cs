using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using System;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            Console.WriteLine(value);
            return null;
        }
    }
}