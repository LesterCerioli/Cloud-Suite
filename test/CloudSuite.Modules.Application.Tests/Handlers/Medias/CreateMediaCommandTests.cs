using CloudSuite.Modules.Application.Handlers.Core.Medias;
using CloudSuite.Modules.Application.Handlers.Core.Medias.Responses;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Medias
{
    public class CreateMediaCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidMediaEntity()
        {
            // Arrange
            var caption = "Sample Caption";
            var fileSize = 1024;
            var fileName = "sample.jpg";
            var mediaType = MediaType.Image; // Replace with the appropriate MediaType value.

            var command = new CreateMediaCommand
            {
                Caption = caption,
                FileSize = fileSize,
                FileName = fileName,
                MediaType = mediaType
            };

            // Act
            var mediaEntity = command.GetEntity();

            // Assert
            Assert.NotNull(mediaEntity);
            Assert.Equal(caption, mediaEntity.Caption);
            Assert.Equal(fileSize, mediaEntity.FileSize);
            Assert.Equal(fileName, mediaEntity.FileName);
            Assert.Equal(mediaType, mediaEntity.MediaType);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange & Act
            var command = new CreateMediaCommand();

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateMediaResponse()
        {
            // Arrange & Act
            var command = new CreateMediaCommand();

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateMediaResponse>>(command);
        }
    }
}
