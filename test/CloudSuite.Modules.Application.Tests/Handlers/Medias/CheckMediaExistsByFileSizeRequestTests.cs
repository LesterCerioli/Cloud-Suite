using System;
using CloudSuite.Modules.Application.Handlers.Core.Medias.Requests;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias.Requests.Tests
{
    public class CheckMediaExistsByFileSizeRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            int? fileSize = 1024; // Replace with the desired file size

            // Act
            var request = new CheckMediaExistsByFileSizeRequest(fileSize);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(fileSize, request.FileSize); // Assert that FileSize is set correctly
        }
    }
}
