using System;
using Xunit;
using CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests.Tests
{
    public class CheckVendorExistsByCreationDateRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            DateTimeOffset createdOn = DateTimeOffset.UtcNow;

            // Act
            var request = new CheckVendorExistsByCreationDateRequest(createdOn);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(createdOn, request.CreatedOn); // Assert that CreatedOn is set correctly
        }
    }
}
