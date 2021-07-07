using CustomerClassLibraryCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibraryCore.Data.Repositories
{
    public class EFCustomerRepository : IEntityRepository<Customer>
    {
        public int Create(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
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

        public Customer Read(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<Customer> ReadAll(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> ReadPartially(int pageNumber, int rowsCount)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
