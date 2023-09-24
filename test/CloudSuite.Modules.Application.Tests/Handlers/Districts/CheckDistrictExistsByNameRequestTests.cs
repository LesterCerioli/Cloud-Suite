using CloudSuite.Modules.Application.Handlers.Core.Districts.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Districts.Requests
{
    public class CheckDistrictExistsByNameRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var districtName = "ExampleDistrict"; // Substitua pelo valor desejado

            // Act
            var request = new CheckDistrictExistsByNameRequest(districtName);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.Name.Should().Be(districtName);
        }
    }
}
