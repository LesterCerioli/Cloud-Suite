using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.RoboEmails.Requests
{
    public class CheckRoboEmailExistsByMessageRecipientRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var messageRecipient = "recipient@example.com"; // Substitua pelo valor desejado

            // Act
            var request = new CheckRoboEmailExistsByMessageRecipientRequest(messageRecipient);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.MessageRecipient.Should().Be(messageRecipient);
        }
    }
}
