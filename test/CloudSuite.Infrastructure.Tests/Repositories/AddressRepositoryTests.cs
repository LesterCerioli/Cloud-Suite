using CloudSuite.Infrastructure.Data.Core.Context;
using CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Core;
using CloudSuite.Infrastructure.Data.Repositories.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Tests.Repositories
{
    public class AddressRepositoryTests 
    {
        private readonly Mock<IAddressRepository> _addressRepository;

        public AddressRepositoryTests()
        {
            _addressRepository = new Mock<IAddressRepository>();
        }

        [Fact]
        public async Task GetByContactName_ValidContactName_ReturnsAddress()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CloudSuiteDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new CloudSuiteDbContext(options);
            var repository = new AddressRepository(context);

            var testContactName = "John Doe";
            var expectedAddress = new AddressMap
            {
                //ContactName = testContactName,
                // Set other properties as needed
            };

            //context.Addresses.Add(expectedAddress);
            context.SaveChanges();

            // Act
            var result = await repository.GetByContactName(testContactName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testContactName, result.ContactName);
        }

    }
}
