using CustomerClassLibraryCore.Data.EFData;
using CustomerClassLibraryCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibraryCore.Data.Repositories
{
    public class EFCustomerRepository : IEntityRepository<Customer>
    {
        private CustomerDataContext _context;

        public EFCustomerRepository()
        {
            _context = new CustomerDataContext();
        }
        public int Create(Customer entity)
        {
            _context.Customers.Add(entity);
            foreach(var address in entity.AdressesList)
            {
                _context.AdressesList.Add(address);
            }
            foreach(var note in entity.Note)
            {
                _context.Add(note);
            }

            _context.SaveChanges();

            return entity.CustomerId;
        }

        public Customer Read(int entityId)
        {
            return _context.Customers.Find(entityId);
        }

        public List<Customer> ReadAll()
        {
            List<Customer> customers = _context.Customers.ToList();
            return customers;
        }


        public void Update(Customer entity)
        {
            var customer = _context.Customers.Find(entity.CustomerId);

            if (customer == null)
            {
                return;
            }

            _context.Entry(customer).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            var customer = _context.Customers.
                                    Include("AdressesList").
                                    Include("Note").
                                    First(x => x.CustomerId == entity.CustomerId);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }

        }

        public void DeleteAll()
        {
            var customers = _context.Customers.Include("AdressesList").Include("Note").ToList();

            foreach (var customer in customers)
            {
                _context.Customers.Remove(customer);
            }

            _context.SaveChanges();
        }

        public void Delete(int entityId)
        {
            _context.Customers.Remove(_context.Customers.Find(entityId));
            _context.SaveChanges();
        }

        //-----------------------------------------------------------------------------------------------------//

        public int GetAmountOfRows()
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
    }
}
