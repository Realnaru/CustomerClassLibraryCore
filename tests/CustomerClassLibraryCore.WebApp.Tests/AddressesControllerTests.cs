using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Data.EFData;
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
    public class AddressesControllerTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressesController()
        {
            var controler = new AddressesController(new EFAddressRepository(), new EFCustomerRepository());
            Assert.NotNull(controler);
        }

        [Fact]
        public void ShouldBeAbleToGetAllAddresses()
        {
            var fixture = new EFAddressRepositoryFixture();
            var addreessRepositoryMock = new Mock<IEntityRepository<Address>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            var controler = new AddressesController(addreessRepositoryMock.Object, customerRepositoryMock.Object);

            var address = fixture.MockAddress();
            var secondAddress = fixture.MockAddress();

            addreessRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Address>() { address, secondAddress });
           
            var addresses = controler.Get();

            Assert.Equal(address, addresses.ToList()[0]);
            Assert.Equal(secondAddress, addresses.ToList()[1]);
        }

        [Fact]
        public void ShouldBeAbleToGetAddress()
        {
            var fixture = new EFAddressRepositoryFixture();
            var addreessRepositoryMock = new Mock<IEntityRepository<Address>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            var controler = new AddressesController(addreessRepositoryMock.Object, customerRepositoryMock.Object);

            var address = fixture.MockAddress();

            addreessRepositoryMock.Setup(x => x.Read(1)).Returns(address);

            var fetchedAddress = controler.Get(1);

            addreessRepositoryMock.Verify(x => x.Read(1), Times.Exactly(1));
            Assert.Equal(address, fetchedAddress);         
        }

        [Fact]
        public void ShouldBeAbleToGetAllAddressesByCustomerId()
        {
            var fixture = new EFAddressRepositoryFixture();
            var addreessRepositoryMock = new Mock<IEntityRepository<Address>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            var controler = new AddressesController(addreessRepositoryMock.Object, customerRepositoryMock.Object);

            var address = fixture.MockAddress();
            var secondAddress = fixture.MockAddress();

            addreessRepositoryMock.Setup(x => x.ReadAll(1)).Returns(new List<Address>() { address, secondAddress });

            var addresses = controler.GetAll(1);

            Assert.Equal(address, addresses.ToList()[0]);
            Assert.Equal(secondAddress, addresses.ToList()[1]);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var fixture = new EFAddressRepositoryFixture();
            var fixtureCustomer = new EFCustomerRepositoryFixture();
            var addreessRepositoryMock = new Mock<IEntityRepository<Address>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            var controler = new AddressesController(addreessRepositoryMock.Object, customerRepositoryMock.Object);

            var address = fixture.MockAddress();
            address.CustomerId = 1;
            var customer = fixtureCustomer.MockCustomer();

            customerRepositoryMock.Setup(x => x.Read(1)).Returns(customer);
            addreessRepositoryMock.Setup(x => x.Read(1)).Returns(address);

            controler.Post(address);
            var createdAddress = controler.Get(1);

            addreessRepositoryMock.Verify(x => x.Create(address), Times.Exactly(1));
            Assert.Equal(address, createdAddress);        
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var fixture = new EFAddressRepositoryFixture();
            var addreessRepositoryMock = new Mock<IEntityRepository<Address>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            var controler = new AddressesController(addreessRepositoryMock.Object, customerRepositoryMock.Object);

            var address = fixture.MockAddress();

            addreessRepositoryMock.Setup(x => x.Read(1)).Returns(address);
            addreessRepositoryMock.Setup(x => x.Update(address));

            controler.Put(1, address);
            var udatedAddress = controler.Get(1);

            addreessRepositoryMock.Verify(x => x.Update(address), Times.Exactly(1));          
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var fixture = new EFAddressRepositoryFixture();
            var addreessRepositoryMock = new Mock<IEntityRepository<Address>>();
            var customerRepositoryMock = new Mock<IEntityRepository<Customer>>();
            var controler = new AddressesController(addreessRepositoryMock.Object, customerRepositoryMock.Object);

            var address = fixture.MockAddress();

            addreessRepositoryMock.Setup(x => x.Read(1)).Returns(address);
            addreessRepositoryMock.Setup(x => x.Delete(1));

            controler.Delete(1);

            addreessRepositoryMock.Verify(x => x.Read(1), Times.Exactly(1));
            addreessRepositoryMock.Verify(x => x.Delete(1), Times.Exactly(1));
        }
    }
}
