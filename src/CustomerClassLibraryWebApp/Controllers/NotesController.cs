using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Data.EFData;
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
        private EFNoteRepository _noteRepository;

        public NotesController()
        {
            _noteRepository = new EFNoteRepository();
        }
        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<CustomerNote> Get()
        {
            return _noteRepository.ReadAll();
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public CustomerNote Get(int id)
        {
            return _noteRepository.Read(id);
        }

        // POST api/<NotesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _noteRepository.Delete(id);
        }
    }
}
