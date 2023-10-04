using CloudSuite.Modules.Application.Handlers.Core.Countries.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Countries.Requests
{
    public class CheckCountryExistsByNameRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var countryName = "United States"; // Substitua pelo valor desejado

            // Act
            var request = new CheckCountryExistsByNameRequest(countryName);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.CountryName.Should().Be(countryName);
        }
    }
}
