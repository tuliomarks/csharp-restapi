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
    public class OrdersController : ControllerBase
    {        

        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }        

        [HttpPost]
        public IActionResult Add([FromBody] Order order)
        {
            try
            {
                return Ok(_service.Add(order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
