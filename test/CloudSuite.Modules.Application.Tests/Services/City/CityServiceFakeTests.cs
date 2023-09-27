using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Core.Cities;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.Services.Implementations.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace CloudSuite.Modules.Application.Tests.Services.City
{
    public class CityServiceFakeTests
    {
        private readonly Mock<ICityService> _cityService;

        public CityServiceFakeTests() 
        {
            _cityService = new Mock<ICityService>();
        }

        [Fact]
        public async Task GetByCityName_ShouldReturnCityViewModel()
        {
            // Arrange
            var mockCityService = new Mock<ICityService>();
            mockCityService
                .Setup(service => service.GetByCityName(It.IsAny<string>()))
                .ReturnsAsync(new CityViewModel());

            var cityService = new CityServiceFakeTests();
            
            
            



        }

        
    }
}
