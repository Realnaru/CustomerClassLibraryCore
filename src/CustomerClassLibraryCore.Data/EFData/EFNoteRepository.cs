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
        public int Create(CustomerNote entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CustomerNote entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public int GetAmountOfRows()
        {
            throw new NotImplementedException();
        }

        public CustomerNote Read(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerNote> ReadAll()
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

        public void Update(CustomerNote entity)
        {
            throw new NotImplementedException();
        }
    }
}
