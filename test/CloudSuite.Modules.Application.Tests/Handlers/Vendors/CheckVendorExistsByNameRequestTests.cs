using System;
using Xunit;
using CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests.Tests
{
    public class CheckVendorExistsByNameRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            string name = "VendorName";

            // Act
            var request = new CheckVendorExistsByNameRequest(name);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(name, request.Name); // Assert that Name is set correctly
        }
    }
}
