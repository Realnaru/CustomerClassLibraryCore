using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibraryCore.WebApp.Tests.IntegrationTests
{
    public class EFCustomerRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEFCustomerRepository()
        {
            var customerRepository = new EFCustomerRepository();
            Assert.NotNull(customerRepository);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAllCustomers()
        {
            var customerRepository = new EFCustomerRepository();
            customerRepository.DeleteAll();

            var customers = customerRepository.ReadAll();
            Assert.Empty(customers);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            var customer = new Customer();

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

            customerRepository.DeleteAll();

            customer.FirstName = "John";
            customer.LastName = "Doe";
            customer.PhoneNumber = "1111111";
            customer.Email = "jd@mail.com";
            customer.TotalPurshasesAmount = 1000;
            customer.AddAddress(address);
            customer.AddNote(note);

            int customerId = customerRepository.Create(customer);

            Assert.NotEqual(0, customerId);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFCustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customer = fixture.CreateMockCustomer();
            int customerId = customer.CustomerId;

            var createdCustomer = customerRepository.Read(customerId);

            Assert.Equal(customer.FirstName, createdCustomer.FirstName);
            Assert.Equal(customer.LastName, createdCustomer.LastName);
            Assert.Equal(customer.PhoneNumber, createdCustomer.PhoneNumber);
            Assert.Equal(customer.Email, createdCustomer.Email);
            Assert.Equal(customer.TotalPurshasesAmount, createdCustomer.TotalPurshasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToReadAllCustomers()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFCustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customer = fixture.CreateMockCustomer();
            var secondCustomer = fixture.CreateMockCustomer();
            
            List<Customer> customers = customerRepository.ReadAll();
            Assert.Equal(2, customers.Count);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFCustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customer = fixture.CreateMockCustomer();
            int customerId = customer.CustomerId;
          
            var createdCustomer = customerRepository.Read(customerId);

            createdCustomer.FirstName = "Jein";
            createdCustomer.LastName = "Roe";
            createdCustomer.PhoneNumber = "999999";
            createdCustomer.Email = "dj@gmail.com";
            createdCustomer.TotalPurshasesAmount = 1000;

            customerRepository.Update(createdCustomer);

            var updatedCustomer = customerRepository.Read(createdCustomer.CustomerId);

            Assert.Equal("Jein", updatedCustomer.FirstName);
            Assert.Equal("Roe", updatedCustomer.LastName);
            Assert.Equal("999999", updatedCustomer.PhoneNumber);
            Assert.Equal("dj@gmail.com", updatedCustomer.Email);
            Assert.Equal(1000, updatedCustomer.TotalPurshasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFCustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customer = fixture.CreateMockCustomer();
            int customerId = customer.CustomerId;

            var createdCustomer = customerRepository.Read(customerId);

            customerRepository.Delete(createdCustomer);

            var deletedCustomer = customerRepository.Read(customerId);

            Assert.Null(deletedCustomer);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomerById()
        {
            var customerRepository = new EFCustomerRepository();
            var fixture = new EFCustomerRepositoryFixture();

            customerRepository.DeleteAll();

            var customer = fixture.CreateMockCustomer();
            int customerId = customer.CustomerId;

            customerRepository.Delete(customerId);

            var deletedCustomer = customerRepository.Read(customerId);

            Assert.Null(deletedCustomer);
        }

    }
}
