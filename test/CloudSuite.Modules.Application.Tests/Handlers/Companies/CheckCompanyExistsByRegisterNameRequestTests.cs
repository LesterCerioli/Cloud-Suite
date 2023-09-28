using System;
using CloudSuite.Modules.Application.Handlers.Core.Companies.Requests;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies.Requests.Tests
{
    public class CheckCompanyExistsByRegisterNameRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            string registerName = "TestRegisterName";

            // Act
            var request = new CheckCompanyExistsByRegisterNameRequest(registerName);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(registerName, request.RegisterName); // Assert that RegisterName is set correctly
        }
    }
}
