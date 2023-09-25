using CloudSuite.Modules.Application.Handlers.Core.States.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.States.Requests
{
    public class CheckStateExistsByUFRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var stateUF = "NY"; // Substitua pelo valor desejado

            // Act
            var request = new CheckStateExistsByUFRequest(stateUF);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.UF.Should().Be(stateUF);
        }
    }
}
