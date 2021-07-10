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
    public class NotesController : ControllerBase
    {
        private IEntityRepository<Customer> _customerRepository;
        private IEntityRepository<CustomerNote> _noteRepository;

        public NotesController()
        {
            _customerRepository = new EFCustomerRepository();
            _noteRepository = new EFNoteRepository();
        }

        public NotesController(IEntityRepository<Customer> customerRepository, IEntityRepository<CustomerNote> noteRepository)
        {
            _customerRepository = customerRepository;
            _noteRepository = noteRepository;
            
        }
        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<CustomerNote> Get()
        {
            return _noteRepository.ReadAll();
        }

        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<CustomerNote> GetAll(int id)
        {
            return _noteRepository.ReadAll(id);
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public CustomerNote Get(int id)
        {
            return _noteRepository.Read(id);
        }

        // POST api/<NotesController>
        [HttpPost]
        public void Post([FromBody] CustomerNote note)
        {
            if (_customerRepository.Read(note.CustomerId) != null)
            {
                _noteRepository.Create(note);
            }      
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerNote note)
        {
            if (_noteRepository.Read(id) != null)
            {
                _noteRepository.Update(note);
            }
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var note =_noteRepository.Read(id);

            if (note != null)
            {
                _noteRepository.Delete(id);
            }
           
        }
    }
}
