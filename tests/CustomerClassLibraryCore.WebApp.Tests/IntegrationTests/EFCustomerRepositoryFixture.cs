using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibraryCore.WebApp.Tests.IntegrationTests
{
    class EFCustomerRepositoryFixture
    {
        public Customer CreateMockCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            var customer = MockCustomer();

            customerRepository.Create(customer);
            return customer;
        }

        public Customer MockCustomer()
        {
            var address = new Address()
            {
                AdressLine = "Address line",
                AdressLine2 = "Address line 2",
                AddressTypeEnum = AddressType.Billing,
                PostalCode = "123456",
                State = "Anystate",
                City = "Anytown",
                Country = "USA"
            };

            var note = new CustomerNote()
            {
                Note = "Kiity Ipsum"
            };

            var customer = new Customer();
            customer.FirstName = "John";
            customer.LastName = "Doe";
            customer.PhoneNumber = "1111111";
            customer.Email = "jd@gmail.com";
            customer.TotalPurshasesAmount = 100;
            customer.AddAddress(address);
            customer.AddNote(note);

            return customer;
        }
    }
}
