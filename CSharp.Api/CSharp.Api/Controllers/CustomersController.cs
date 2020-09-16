using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp.Api.Models;
using CSharp.Data.Services;
using CSharp.Data.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSharp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {        

        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                return Ok(_service.GetAll().ToArray());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Customer customer)
        {
            try
            {
                return Ok(_service.Add(customer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
