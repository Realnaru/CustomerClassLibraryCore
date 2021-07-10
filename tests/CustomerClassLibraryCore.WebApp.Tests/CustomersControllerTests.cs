using CustomerClassLibraryCore.Data.Repositories;
using CustomerClassLibraryCore.Repositories;
using CustomerClassLibraryCore.WebApp.Tests.IntegrationTests;
using CustomerClassLibraryWebApp.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibraryCore.WebApp.Tests
{
    public class CustomersControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomersController()
        {
            var customersController = new CustomersController(new EFCustomerRepository());
            Assert.NotNull(customersController);
        }

        [Fact]
        public void ShouldGetAllCustomers()
        {
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Customer>());

            var controller = new CustomersController(customerRepositoryMock.Object);
            var customers = controller.Get();

            Assert.NotNull(customers);
        }

        [Fact]
        public void ShouldGetCustomer()
        {
            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.MockCustomer();

            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.Read(1)).Returns(customer);

            var controller = new CustomersController(customerRepositoryMock.Object);
            var fetchedCustomer = controller.Get(1);

            Assert.NotNull(fetchedCustomer);
            Assert.Equal(customer, fetchedCustomer);
        }

        [Fact]
        public void ShouldCreateNewCustomer()
        {
            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.MockCustomer();

            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.Read(1)).Returns(customer);
            customerRepositoryMock.Setup(x => x.Create(customer));

            var controller = new CustomersController(customerRepositoryMock.Object);
            controller.Post(customer);
            var fetchedCustomer = controller.Get(1);

            customerRepositoryMock.Verify(x => x.Create(customer), Times.Exactly(1));
            Assert.NotNull(fetchedCustomer);
            Assert.Equal(customer, fetchedCustomer);
        }

        [Fact]
        public void ShouldUpdateCustomer()
        {
            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.MockCustomer();

            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.Read(1)).Returns(customer);

            var controller = new CustomersController(customerRepositoryMock.Object);
            controller.Put(1, customer);
            var fetchedCustomer = controller.Get(1);

            Assert.NotNull(fetchedCustomer);
            Assert.Equal(customer, fetchedCustomer);
        }

        [Fact]
        public void ShouldDeleteCustomer()
        {
            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.MockCustomer();

            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.Delete(customer));
            customerRepositoryMock.Setup(x => x.Read(1)).Returns(customer);

            var controller = new CustomersController(customerRepositoryMock.Object);
            controller.Delete(1);
            customerRepositoryMock.Verify(x => x.Read(1), Times.Exactly(1));
            customerRepositoryMock.Verify(x => x.Delete(1), Times.Exactly(1));
        }
    }

}
