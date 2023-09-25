using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Widgets.Requests
{
    public class CheckWidgetExistsByLatestUpdatedDateRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var createUrl = "https://example.com/widgets/create"; // Substitua pelo valor desejado

            // Act
            var request = new CheckWidgetExistsByLatestUpdatedDateRequest(createUrl);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.CreateUrl.Should().Be(createUrl);
        }
    }
}
