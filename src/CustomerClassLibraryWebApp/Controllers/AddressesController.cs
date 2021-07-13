using CustomerClassLibraryCore;
using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Common;
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

        public AddressesController(IEntityRepository<Address> addressRepository, IEntityRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        //// GET: api/<AddressesController>
        //[HttpGet]
        //public ActionResult Get()
        //{
        //    var addresses = _addressRepository.ReadAll();
        //    if (addresses != null)
        //    {
        //        return Ok(addresses);
        //    } else
        //    {
        //        throw new Exception("Server error");
        //    }   
        //}

        // GET api/<AddressesController>/?customerId=5
        [HttpGet]
        public ActionResult GetAll(int customerId)
        {
            var addresses = _addressRepository.ReadAll(customerId);
            if (addresses.Count != 0)
            {
                return Ok(addresses);
            } else
            {
                throw new NotFoundException($"Customer with id {customerId} not found");
            }         
        }

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var address = _addressRepository.Read(id);

            if (address != null)
            {
                return Ok(address);
            } else
            {
                throw new NotFoundException($"Address with {id} not found");
            }        
        }

        // POST api/<AddressesController>
        [HttpPost]
        public IActionResult Post([FromBody] Address address)
        {
            var customer = _customerRepository.Read(address.CustomerId);
            if ( customer != null)
            {
                int addressId = _addressRepository.Create(address);

                if(addressId == 0)
                {
                    throw new Exception("Server error");
                }

                return Ok();

            } else
            {
                throw new NotFoundException($"Customer with {address.CustomerId} not found");
            }         
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Address address)
        {
            if (_addressRepository.Read(id) != null)
            {
                _addressRepository.Update(address);
                return NoContent();

            } else
            {
                throw new NotFoundException($"Address with {id} not found");
            }
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_addressRepository.Read(id) != null)
            {
                _addressRepository.Delete(id);
                return NoContent();

            } else
            {
                throw new NotFoundException($"Address with {id} not found");
            }           
        }
    }
}
