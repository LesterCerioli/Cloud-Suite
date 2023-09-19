using AutoMapper;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services.Medias
{
    public class MediaServiceTests
    {
        private readonly Mock<IMediaRepository> _mediaRepositoryMock;
        private readonly Mock<IMediatorHandler> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly MediaService _mediaService;

        public MediaServiceTests()
        {
            _mediaRepositoryMock = new Mock<IMediaRepository>();
            _mediatorMock = new Mock<IMediatorHandler>();
            _mapperMock = new Mock<IMapper>();

            _mediaService = new MediaService(
                _mapperMock.Object,
                _mediaRepositoryMock.Object,
                _mediatorMock.Object);
        }

        [Fact]
        public async Task GetByFileName_ShouldReturnMediaViewModel()
        {
            // Arrange
            var fileName = "test.jpg"; // Replace with a valid file name
            var mediaEntity = new MediaEntity(); // Replace with your entity

            _mediaRepositoryMock
                .Setup(repo => repo.GetByFileName(fileName))
                .ReturnsAsync(mediaEntity);

            var expectedViewModel = new MediaViewModel(); // Replace with your view model
            _mapperMock.Setup(mapper => mapper.Map<MediaViewModel>(mediaEntity)).Returns(expectedViewModel);

            // Act
            var result = await _mediaService.GetByFileName(fileName);

            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your specific requirements
        }

        [Fact]
        public async Task Save_ShouldCallRepositoryAdd()
        {
            // Arrange
            var createCommand = new CreateMediaCommand(); // Replace with your command

            // Act
            await _mediaService.Save(createCommand);

            // Assert
            _mediaRepositoryMock.Verify(repo => repo.Add(It.IsAny<YourEntityType>()), Times.Once);
        }

        // Add more test methods for other scenarios and edge cases

        public void Dispose()
        {
            _mediaService.Dispose();
        }
        
    }
}