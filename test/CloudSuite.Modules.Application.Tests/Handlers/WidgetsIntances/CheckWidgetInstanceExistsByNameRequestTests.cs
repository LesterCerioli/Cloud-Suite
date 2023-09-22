using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.WidgetInstances.Requests
{
    public class CheckWidgetInstanceExistsByNameRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var name = "ExampleWidgetInstance"; // Substitua pelo valor desejado

            // Act
            var request = new CheckWidgetInstanceExistsByNameRequest(name);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.Name.Should().Be(name);
        }
    }
}
