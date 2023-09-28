using System;
using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests.Tests
{
    public class CheckAppSettingExistsByValueRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            string value = "TestValue";

            // Act
            var request = new CheckAppSettingExistsByValueRequest(value);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(value, request.Value); // Assert that Value is set correctly
        }
    }
}
