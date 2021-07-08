using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Data.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibraryCore.WebApp.Tests.IntegrationTests
{
    class EFAddressRepositoryFixture
    {
        public Address CreateMockAddress()
        {
            var customerAddressRepository = new EFAddressRepository();
            var address = MockAddress();

            customerAddressRepository.Create(address);

            return address;
        }

        public Address MockAddress()
        {
            var address = new Address();

            address.AdressLine = "123";
            address.AdressLine2 = "Main St";
            address.AddressTypeEnum = AddressType.Billing;
            address.PostalCode = "123456";
            address.Country = "Canada";
            address.City = "Anytown";
            address.State = "Anystate";

            return address;
        }
    }
}
