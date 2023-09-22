using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.AppSettings.Requests
{
    public class CheckAppSettingExistsByModuleRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var module = "exampleModule"; // Substitua pelo valor desejado

            // Act
            var request = new CheckAppSettingExistsByModuleRequest(module);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.Module.Should().Be(module);
        }
    }
}
