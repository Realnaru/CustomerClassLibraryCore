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

            //serviceCollection.AddTransient<IEntityRepository<Customer>, EFCustomerRepository>();
        }
    }
}
