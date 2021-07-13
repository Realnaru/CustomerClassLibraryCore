using CustomerClassLibraryCore.Common;
using CustomerClassLibraryCore.Data.Repositories;
using CustomerClassLibraryCore.Repositories;
using CustomerClassLibraryCore.WebApp.Tests.IntegrationTests;
using CustomerClassLibraryWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
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
            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.MockCustomer();

            var expectedResult = new List<Customer>()
            { 
                new Customer(),
                new Customer()
            };

            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.ReadAll()).Returns(expectedResult);

            var controller = new CustomersController(customerRepositoryMock.Object);
            var customers = controller.Get();

            Assert.NotNull(customers);
            Assert.IsType<OkObjectResult>(customers);

            var actualList = ((OkObjectResult)(customers)).Value as List<Customer>;     
            Assert.Equal(expectedResult, actualList);
        }

        [Fact]
        public void ShouldThrowExceptionIfThereAreNoCustomers()
        {
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Customer>());

            var controller = new CustomersController(customerRepositoryMock.Object);

            Assert.Throws<NotFoundException>(() => controller.Get());
        }

        [Fact]
        public void ShouldThrowExceptionIfThereAreNoCustomer()
        {
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.Read(1)).Returns((Customer)null);

            var controller = new CustomersController(customerRepositoryMock.Object);

            Assert.Throws<NotFoundException>(() => controller.Get(1));
        }

        [Fact]
        public void ShouldThrowExceptionIfCustomerIsNotCreated()
        {
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            var fixture = new EFCustomerRepositoryFixture();

            var customer = fixture.MockCustomer();

            customerRepositoryMock.Setup(x => x.Create(customer)).Returns(0);

            var controller = new CustomersController(customerRepositoryMock.Object);

            Assert.Throws<Exception>(() => controller.Post(customer));
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsNoCustomerToUpdate()
        {
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            var fixture = new EFCustomerRepositoryFixture();

            var customer = fixture.MockCustomer();

            customerRepositoryMock.Setup(x => x.Read(1)).Returns((Customer)null);

            var controller = new CustomersController(customerRepositoryMock.Object);

            Assert.Throws<NotFoundException>(() => controller.Put(1, customer));
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsNoCustomerToDelete()
        {
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            var fixture = new EFCustomerRepositoryFixture();

            var customer = fixture.MockCustomer();

            customerRepositoryMock.Setup(x => x.Read(1)).Returns((Customer)null);

            var controller = new CustomersController(customerRepositoryMock.Object);

            Assert.Throws<NotFoundException>(() => controller.Delete(1));
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
            Assert.IsType<OkObjectResult>(fetchedCustomer);

            var actualCustomer = ((OkObjectResult)fetchedCustomer).Value as Customer;
            
            Assert.Equal(customer, actualCustomer);
        }

        [Fact]
        public void ShouldCreateNewCustomer()
        {
            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.MockCustomer();

            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.Read(1)).Returns(customer);
            customerRepositoryMock.Setup(x => x.Create(customer)).Returns(1);

            var controller = new CustomersController(customerRepositoryMock.Object);
            controller.Post(customer);
            var fetchedCustomer = controller.Get(1);

            customerRepositoryMock.Verify(x => x.Create(customer), Times.Exactly(1));
            Assert.NotNull(fetchedCustomer);
            Assert.IsType<OkObjectResult>(fetchedCustomer);
        }

        [Fact]
        public void ShouldUpdateCustomer()
        {
            var fixture = new EFCustomerRepositoryFixture();
            var customer = fixture.MockCustomer();

            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.Read(1)).Returns(customer);

            var controller = new CustomersController(customerRepositoryMock.Object);
            var result = controller.Put(1, customer);
            var fetchedCustomer = controller.Get(1);

            Assert.NotNull(fetchedCustomer);
            Assert.IsType<NoContentResult>(result);
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
            var result = controller.Delete(1);

            customerRepositoryMock.Verify(x => x.Read(1), Times.Exactly(1));
            customerRepositoryMock.Verify(x => x.Delete(1), Times.Exactly(1));
            Assert.IsType<NoContentResult>(result);
        }
    }

}
