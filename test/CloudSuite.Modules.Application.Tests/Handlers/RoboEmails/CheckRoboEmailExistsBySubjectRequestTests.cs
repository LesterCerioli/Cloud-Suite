using System;
using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests.Tests
{
    public class CheckRoboEmailExistsBySubjectRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            string subject = "TestSubject";

            // Act
            var request = new CheckRoboEmailExistsBySubjectRequest(subject);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(subject, request.Subject); // Assert that Subject is set correctly
        }
    }
}
