using CloudSuite.Modules.Application.Handlers.Core.Addresses.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Core.Addresses.Requests
{
    public class CheckAddressExistsByContactNameRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var contactName = "John Doe"; // Substitua pelo valor desejado

            // Act
            var request = new CheckAddressExistsByContactNameRequest(contactName);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.ContactName.Should().Be(contactName);
        }
    }
}
