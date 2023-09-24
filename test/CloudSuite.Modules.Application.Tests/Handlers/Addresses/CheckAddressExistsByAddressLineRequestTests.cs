using CloudSuite.Modules.Application.Handlers.Core.Addresses.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Addresses.Requests
{
    public class CheckAddressExistsByAddressLineRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var addressLine1 = "123 Main Street"; // Substitua pelo valor desejado

            // Act
            var request = new CheckAddressExistsByAddressLineRequest(addressLine1);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.AddressLine1.Should().Be(addressLine1);
        }
    }
}
