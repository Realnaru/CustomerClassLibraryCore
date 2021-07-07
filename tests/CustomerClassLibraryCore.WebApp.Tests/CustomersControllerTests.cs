using CustomerClassLibraryCore.Repositories;
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
        public void ShouldGetAllCustomers()
        {
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Customer>());

            var controller = new CustomersController(customerRepositoryMock.Object);
            var customers = controller.Get();

            Assert.NotNull(customers);
        }
    }
}
