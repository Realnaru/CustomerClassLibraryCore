using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibraryCore.Data.EFData
{
    public class EFNoteRepository : IEntityRepository<CustomerNote>
    {
        private CustomerDataContext _context;

        public EFNoteRepository()
        {
            _context = new CustomerDataContext();
        }
        public int Create(CustomerNote entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.NoteId;
        }

        public CustomerNote Read(int entityId)
        {
            return _context.Note.Find(entityId);

        }

        public List<CustomerNote> ReadAll()
        {
            return _context.Note.ToList();
        }

        public void Update(CustomerNote entity)
        {
            var note = _context.Note.Find(entity.NoteId);
            if (note == null)
            {
                return;
            }
            _context.Entry(note).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }    

        public void Delete(int entityId)
        {
            _context.Remove(_context.Note.Find(entityId));
            _context.SaveChanges();
        }

        //----------------------------------------------------------------------------------//

        public int GetAmountOfRows()
        {
            throw new NotImplementedException();
        }

        public List<CustomerNote> ReadAll(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerNote> ReadPartially(int pageNumber, int rowsCount)
        {
            throw new NotImplementedException();
        }
        public void Delete(CustomerNote entity)
        {
            throw new NotImplementedException();
        }


    }
}
