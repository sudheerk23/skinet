using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class BuggyController : Controller
    {
        [HttpGet]
        [Route("internalerror")]
        public IActionResult InternalServerError()
        {
            throw new Exception("this is a test exception");
        }

        [HttpGet]
        [Route("unauthorised")]

        public IActionResult UnAuthorisedRequest()
        {
            return Unauthorized();
        }
        [HttpGet]
        [Route("badrequest")]

        public IActionResult BadRequestGet()
        {
            return BadRequest("Not a good request");
        }
        [HttpPost]
        [Route("validationerror")]

        public IActionResult ValidationError(CreateProductDto product)
        {
            return Ok();
        }
    }
}