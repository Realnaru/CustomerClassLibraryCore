using CustomerClassLibraryCore.BusinessEntities;
using CustomerClassLibraryCore.Data.EFData;
using CustomerClassLibraryCore.Data.Repositories;
using CustomerClassLibraryCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CustomerClassLibraryCore.WebApp.Tests
{
    public class ServiceCollectionTests
    {
        [Fact]
        public void ShouldRegisterServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IEntityRepository<Customer>, EFCustomerRepository>();
            serviceCollection.AddTransient<IEntityRepository<Address>, EFAddressRepository>();
            serviceCollection.AddTransient<IEntityRepository<CustomerNote>, EFNoteRepository>();


            var provider = serviceCollection.BuildServiceProvider();
            var customerRepository = provider.GetService<IEntityRepository<Customer>>();
            var addressRepository = provider.GetService<IEntityRepository<Address>>();
            var noteRepository = provider.GetService<IEntityRepository<CustomerNote>>();

            Assert.IsAssignableFrom<IEntityRepository<Customer>>(customerRepository);
            Assert.IsAssignableFrom<IEntityRepository<Address>>(addressRepository);
            Assert.IsAssignableFrom<IEntityRepository<CustomerNote>>(noteRepository);
        }
    }
}
