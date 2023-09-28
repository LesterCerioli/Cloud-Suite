using System;
using CloudSuite.Modules.Application.Handlers.Core.Medias.Requests;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias.Requests.Tests
{
    public class CheckMediaExistsByFileNameRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            string fileName = "TestFileName";

            // Act
            var request = new CheckMediaExistsByFileNameRequest(fileName);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(fileName, request.FileName); // Assert that FileName is set correctly
        }
    }
}
