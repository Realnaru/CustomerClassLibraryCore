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
    public class NotesController : ControllerBase
    {
        private IEntityRepository<Customer> _customerRepository;
        private IEntityRepository<CustomerNote> _noteRepository;

        public NotesController(IEntityRepository<Customer> customerRepository, IEntityRepository<CustomerNote> noteRepository)
        {
            _customerRepository = customerRepository;
            _noteRepository = noteRepository;
            
        }
        //// GET: api/<NotesController>
        //[HttpGet]
        //public ActionResult Get()
        //{
        //    return Ok(_noteRepository.ReadAll());
        //}

        // GET api/<NotesController>?customerId=10
        [HttpGet]
        public ActionResult GetAll(int customerId)
        {
            var notes = _noteRepository.ReadAll(customerId);
            if (notes.Count != 0)
            {
                return Ok(notes);
            } else
            {
                throw new NotFoundException($"Customer with id {customerId} not found");
            }           
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var note = _noteRepository.Read(id);
            if (note != null)
            {
                return Ok(note);
            } else
            {
                throw new NotFoundException($"Note with {id} not found");
            }     
        }

        // POST api/<NotesController>
        [HttpPost]
        public void Post([FromBody] CustomerNote note)
        {
            if (_customerRepository.Read(note.CustomerId) != null)
            {
                var noteId = _noteRepository.Create(note);
                if (noteId == 0)
                {
                    throw new Exception("Server error");
                }

            } else
            {
                throw new NotFoundException($"Customer with {note.CustomerId} not found");
            } 
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerNote note)
        {
            if (_noteRepository.Read(id) != null)
            {
                _noteRepository.Update(note);
            } else
            {
                throw new NotFoundException($"Note with {id} not found");
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
            } else
            {
                throw new NotFoundException($"Note with {id} not found");
            }          
        }
    }
}
