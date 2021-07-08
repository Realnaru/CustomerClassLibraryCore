using CustomerClassLibraryCore.BusinessEntities;
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
    public class AddressesController : ControllerBase
    {
        private readonly IEntityRepository<Address> _addressRepository;

        public AddressesController(IEntityRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: api/<AddressesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddressesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
