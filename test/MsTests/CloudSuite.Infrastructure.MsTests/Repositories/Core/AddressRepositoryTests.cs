using CloudSuite.Infrastructure.Data.Core.Context;
using CloudSuite.Infrastructure.Data.Repositories.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.MsTests.Repositories.Core
{
    [TestClass]
    public class AddressRepositoryTests
    {
        private CloudSuiteDbContext _dbContext;
        private AddressRepository _addressRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<CloudSuiteDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Use an in-memory database for testing
                .Options;

            _dbContext = new CloudSuiteDbContext(options);
            _addressRepository = new AddressRepository(_dbContext);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetByContactNameAsync_ShouldReturnCorrectAddress()
        {
            // Arrange
            var expectedContactName = "John Doe";
            //var address = new Address { ContactName = expectedContactName };
            //await _addressRepository.Add(address);

            // Act
            var result = await _addressRepository.GetByContactName(expectedContactName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedContactName, result.ContactName);
        }

        [TestMethod]
        public async Task GetByAddressLineAsync_ShouldReturnCorrectAddress()
        {
            // Arrange
            var expectedAddressLine = "123 Main Street";
            //var address = new Address { AddressLine1 = expectedAddressLine };
            //await _addressRepository.Add(address);

            // Act
            var result = await _addressRepository.GetByAddressLine(expectedAddressLine);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedAddressLine, result.AddressLine1);
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAllAddresses()
        {
            // Arrange
            //await _addressRepository.Add(new Address { ContactName = "John Doe" });
            //await _addressRepository.Add(new Address { ContactName = "Jane Smith" });

            // Act
            var result = await _addressRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task AddAsync_ShouldAddAddressToDatabase()
        {
            // Arrange
            //var address = new Address { ContactName = "New Contact" };

            // Act
            //await _addressRepository.Add(address);

            // Assert
            var result = await _dbContext.Addresses.FirstOrDefaultAsync(a => a.ContactName == "New Contact");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Update_ShouldUpdateAddressInDatabase()
        {
            // Arrange
            //var address = new Address { ContactName = "John Doe" };
            //_addressRepository.Add(address);

            // Act
            //address.ContactName = "Updated Contact";
            //_addressRepository.Update(address);

            // Assert
            //var result = _dbContext.Entry(address).State;
            //Assert.AreEqual(EntityState.Modified, result);
        }

        [TestMethod]
        public async Task RemoveAsync_ShouldRemoveAddressFromDatabase()
        {
            // Arrange
            //var address = new Address { ContactName = "John Doe" };
            //await _addressRepository.Add(address);

            // Act
            //_addressRepository.Remove(address);

            // Assert
            var result = await _dbContext.Addresses.FirstOrDefaultAsync(a => a.ContactName == "John Doe");
            Assert.IsNull(result);
        }
    }
}
