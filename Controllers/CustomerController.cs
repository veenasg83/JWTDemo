using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _CustomerService;

        public CustomerController(CustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [HttpGet]

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<Customer>> Get() =>
            _CustomerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var Customer = _CustomerService.Get(id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Customer;
        }

        [HttpPost("createCustomers")]
        public ActionResult<Customer> Create([FromBody]Customer Customer)
        {
            _CustomerService.Create(Customer);

            return CreatedAtRoute("GetCustomer", new { id = Customer.Id.ToString() }, Customer);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Customer CustomerIn)
        {
            var Customer = _CustomerService.Get(id);

            if (Customer == null)
            {
                return NotFound();
            }

            _CustomerService.Update(id, CustomerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Customer = _CustomerService.Get(id);

            if (Customer == null)
            {
                return NotFound();
            }

            _CustomerService.Remove(Customer.Id);

            return NoContent();
        }
    }
}
