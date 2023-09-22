using AutoMapper;
using CloudSuite.Modules.Application.AutoMapper;
using CloudSuite.Modules.Application.Handlers.Core.Districts;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.Services.Implementations.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Tests.Models;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Services.District
{
    public class DistrictServiceFakeTests 
    {


        [Fact]
        public async Task GetByName_Should_Return_DistrictViewModel()
        {
            // Arrange
            var districtRepositoryMock = new Mock<IDistrictRepository>();
            //districtRepositoryMock.Setup(repo => repo.GetByName(It.IsAny<string>()))
                //.ReturnsAsync(new DistrictEntityTests(Guid.NewGuid(), "SampleDistrictName", "SampleType", "SampleLocation"));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelMappingProfile>(); // Configure AutoMapper profile here
            });
            var mapper = mapperConfig.CreateMapper();

            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var districtService = new DistrictService(districtRepositoryMock.Object, mapper, mediatorHandlerMock.Object);

            // Act
            var result = await districtService.GetByName("SampleDistrictName");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DistrictViewModel>(result);
            // Add more assertions as needed
        }

        [Fact]
        public async Task Save_Should_Add_DistrictEntity()
        {
            // Arrange
            var districtRepositoryMock = new Mock<IDistrictRepository>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelMappingProfile>(); // Configure AutoMapper profile here
            });
            var mapper = mapperConfig.CreateMapper();

            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var districtService = new DistrictService(districtRepositoryMock.Object, mapper, mediatorHandlerMock.Object);

            var createDistrictCommand = new CreateDistrictCommand(); // Provide necessary data for the command

            // Act
            await districtService.Save(createDistrictCommand);

            // Assert
            //districtRepositoryMock.Verify(repo => repo.Add(It.IsAny<District>()), Times.Once);
        }

        // Add more test methods for other scenarios and edge cases
    }
}
