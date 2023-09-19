using AutoMapper;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Threading.Tasks;
using Xunit;xs

namespace CloudSuite.Modules.Application.Tests.Services.Districts
{
    public class DistrictServiceTests
    {
        private readonly Mock<IDistrictRepository> _districtRepositoryMock;
        private readonly Mock<IMediatorHandler> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly DistrictService _districtService;

        public DistrictServiceTests()
        {
            _districtRepositoryMock = new Mock<IDistrictRepository>();
            _mediatorMock = new Mock<IMediatorHandler>();
            _mapperMock = new Mock<IMapper>();

            _districtService = new DistrictService(
                _districtRepositoryMock.Object,
                _mapperMock.Object,
                _mediatorMock.Object);
        }

        [Fact]
        public async Task GetByName_ShouldReturnDistrictViewModel()
        {
            // Arrange
            var districtName = "Test District";
            var districtEntity = new DistrictEntity(); // Replace with your entity

            _districtRepositoryMock
                .Setup(repo => repo.GetByName(districtName))
                .ReturnsAsync(districtEntity);

            var expectedViewModel = new DistrictViewModel(); // Replace with your view model
            _mapperMock.Setup(mapper => mapper.Map<DistrictViewModel>(districtEntity)).Returns(expectedViewModel);

            // Act
            var result = await _districtService.GetByName(districtName);

            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your specific requirements
        }

        [Fact]
        public async Task Save_ShouldCallRepositoryAdd()
        {
            // Arrange
            var createCommand = new CreateDistrictCommand(); // Replace with your command

            // Act
            await _districtService.Save(createCommand);

            // Assert
            _districtRepositoryMock.Verify(repo => repo.Add(It.IsAny<YourEntityType>()), Times.Once);
        }

        // Add more test methods for other scenarios and edge cases

        public void Dispose()
        {
            _districtService.Dispose();
        }
        
    }
}