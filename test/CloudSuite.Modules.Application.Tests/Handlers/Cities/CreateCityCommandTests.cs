using CloudSuite.Modules.Application.Handlers.Core.Cities;
using CloudSuite.Modules.Application.Handlers.Core.Cities.Responses;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Cities
{
    public class CreateCityCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidCityEntity()
        {
            // Arrange
            var cityName = "City_Name";
            var command = new CreateCityCommand();

            // Act
            command.CityName = cityName; // Define o nome da cidade no comando.
            var cityEntity = command.GetEntity();

            // Assert
            Assert.NotNull(cityEntity);
            Assert.Equal(cityName, cityEntity.CityName);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange & Act
            var command = new CreateCityCommand();

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateCityResponse()
        {
            // Arrange & Act
            var command = new CreateCityCommand();

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateCityResponse>>(command);
        }
    }
}
