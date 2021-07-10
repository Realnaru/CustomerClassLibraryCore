using CustomerClassLibraryCore;
using CustomerClassLibraryCore.Common;
using CustomerClassLibraryCore.Data.Repositories;
using CustomerClassLibraryCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerClassLibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IEntityRepository<Customer> _customerRepository;

        public CustomersController(IEntityRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_customerRepository.ReadAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_customerRepository.Read(id));
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            int customerId =_customerRepository.Create(customer);

            if (customerId == 0)
            {
                throw new Exception("Server error");
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            var customerToUpdate = _customerRepository.Read(id);

            if (customerToUpdate != null)
            {
                _customerRepository.Update(customer);
            } else
            {
                throw new NotFoundException($"Customer with {id} not found");
            };
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customer = _customerRepository.Read(id);

            if (customer != null)
            {
                _customerRepository.Delete(id);
            } else
            {
                throw new NotFoundException($"Customer with {id} not found");
            };
        }
    }
}
