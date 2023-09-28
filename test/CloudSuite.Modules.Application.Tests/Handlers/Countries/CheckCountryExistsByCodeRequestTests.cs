using System;
using CloudSuite.Modules.Application.Handlers.Core.Countries.Requests;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.Countries.Requests.Tests
{
    public class CheckCountryExistsByCodeRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            string code3 = "USA";

            // Act
            var request = new CheckCountryExistsByCodeRequest(code3);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(code3, request.Code3); // Assert that Code3 is set correctly
        }
    }
}
