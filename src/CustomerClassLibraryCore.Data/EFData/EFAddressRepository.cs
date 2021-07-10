using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibraryCore.Data.EFData
{
    public class EFAddressRepository : IEntityRepository<Address>
    {
        private CustomerDataContext _context;

        public EFAddressRepository()
        {
            _context = new CustomerDataContext();
        }

        public int Create(Address entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

            return entity.AddressId;
        }

        public Address Read(int entityId)
        {
            return _context.AdressesList.Find(entityId);
        }

        public List<Address> ReadAll()
        {
            return _context.AdressesList.ToList();
        }

        public List<Address> ReadAll(int entityId)
        {
            return _context.AdressesList.Where(x => x.CustomerId == entityId).ToList();
        }

        public void Update(Address entity)
        {
            var address = _context.AdressesList.Find(entity.AddressId);

            if (address == null)
            {
                return;
            }

            _context.Entry(address).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void Delete(int entityId)
        {
            _context.AdressesList.Remove(_context.AdressesList.Find(entityId));
            _context.SaveChanges();
        }

        //-------------------------------------------------------------------------//


        public void Delete(Address entity)
        {
            throw new NotImplementedException();
        }

        public int GetAmountOfRows()
        {
            throw new NotImplementedException();
        }

        public List<Address> ReadPartially(int pageNumber, int rowsCount)
        {
            throw new NotImplementedException();
        }

       
    }
}
