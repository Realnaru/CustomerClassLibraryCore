using CustomerClassLibraryCore;
using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Data.EFData;
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
    public class AddressesController : ControllerBase
    {
        private readonly IEntityRepository<Customer> _customerRepository;
        private readonly IEntityRepository<Address> _addressRepository;

        public AddressesController()
        {
            _customerRepository = new EFCustomerRepository();
            _addressRepository = new EFAddressRepository();
        }
        public AddressesController(IEntityRepository<Address> addressRepository, IEntityRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        // GET: api/<AddressesController>
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            return _addressRepository.ReadAll();
        }

        [HttpGet]
        public IEnumerable<Address> GetAll(int id)
        {
            return _addressRepository.ReadAll(id);
        }

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public Address Get(int id)
        {
            return _addressRepository.Read(id);
        }

        // POST api/<AddressesController>
        [HttpPost]
        public void Post([FromBody] Address address)
        {
            if (_customerRepository.Read(address.CustomerId) != null)
            {
                _addressRepository.Create(address);
            }           
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Address address)
        {
            if (_addressRepository.Read(id) != null)
            {
                _addressRepository.Update(address);
            }
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_addressRepository.Read(id) != null)
            {
                _addressRepository.Delete(id);
            }
            
        }
    }
}
