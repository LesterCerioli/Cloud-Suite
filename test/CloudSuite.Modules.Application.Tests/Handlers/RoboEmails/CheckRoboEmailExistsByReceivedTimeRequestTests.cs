using System;
using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests.Tests
{
    public class CheckRoboEmailExistsByReceivedTimeRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            DateTimeOffset receivedTime = DateTimeOffset.Now;

            // Act
            var request = new CheckRoboEmailExistsByReceivedTimeRequest(receivedTime);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(receivedTime, request.ReceivedTime); // Assert that ReceivedTime is set correctly
        }
    }
}
