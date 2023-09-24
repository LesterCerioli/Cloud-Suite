using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.WidgetZones.Requests
{
    public class CheckWidgetZoneExistsByNameRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var name = "ExampleWidgetZone"; // Substitua pelo valor desejado

            // Act
            var request = new CheckWidgetZoneExistsByNameRequest(name);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.Name.Should().Be(name);
        }
    }
}
