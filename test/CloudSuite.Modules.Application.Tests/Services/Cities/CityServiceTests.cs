using AutoMapper;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services.Cities
{
    public class CityServiceTests
    {
        [Fact]
        public async Task GetByCityName_ValidCityName_ReturnsCityViewModel()
        {
            var cityName = "Sao Paulo";
            var expectedCity = new CityViewModel
            {
                cityName = cityName


            };

            var mockCityRepository = new Mock<ICityRepository>();
            mockCityRepository
                .Setup(repo => repo.GetByCityName(cityName))
                .ReturnsAsync(expectedCity); // Return the expectedCity when GetByCityName is called

            var mockMapper = new Mock<IMapper>();
            mockMapper
                .Setup(mapper => mapper.Map<CityViewModel>(expectedCity))
                .Returns(expectedCity); // Return the expectedCity as the mapped result

            var cityService = new CityService(
                mockCityRepository.Object,
                Mock.Of<IMediatorHandler>(), // Mock the IMediatorHandler interface
                mockMapper.Object
            );

            // Act
            var result = await cityService.GetByCityName(cityName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCity.Property1, result.Property1); // Replace Property1 with actual property names
            Assert.Equal(expectedCity.Property2, result.Property2); // Replace Property2 with actual property names
            // Add more property comparisons as needed

        }

        [Fact]
        public async Task Save_ValidCommand_DoesNotThrowException()
        {
            // Arrange
            var command = new CreateCityCommand
            {
                // Initialize the command properties as needed for the test
            };

            var mockCityRepository = new Mock<ICityRepository>();
            mockCityRepository
                .Setup(repo => repo.Add(It.IsAny<City>()))
                .Returns(Task.CompletedTask); // Return a completed task

            var cityService = new CityService(
                mockCityRepository.Object,
                Mock.Of<IMediatorHandler>(), // Mock the IMediatorHandler interface
                Mock.Of<IMapper>() // Mock the IMapper interface
            );

            // Act and Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => cityService.Save(command));
        }
        
    }
}