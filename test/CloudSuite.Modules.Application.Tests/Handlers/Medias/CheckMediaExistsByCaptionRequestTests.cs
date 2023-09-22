using CloudSuite.Modules.Application.Handlers.Core.Medias.Requests;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Medias.Requests
{
    public class CheckMediaExistsByCaptionRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var mediaCaption = "ExampleCaption"; // Substitua pelo valor desejado

            // Act
            var request = new CheckMediaExistsByCaptionRequest(mediaCaption);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.Caption.Should().Be(mediaCaption);
        }
    }
}
