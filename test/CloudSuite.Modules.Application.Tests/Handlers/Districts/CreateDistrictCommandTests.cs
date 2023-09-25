using CloudSuite.Modules.Application.Handlers.Core.Districts.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Districts;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Districts
{
    public class CreateDistrictCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidDistrictEntity()
        {
            // Arrange
            var command = new CreateDistrictCommand
            {
                Name = "Name District",
                Type = "",
                Location = ""
            };

            var DistrictEntity = command.GetEntity();

            // Assert
            Assert.NotNull(DistrictEntity);
            Assert.Equal(command.Id, DistrictEntity.Id);
            Assert.Equal(command.Name, DistrictEntity.Name);
            Assert.Equal(command.Type, DistrictEntity.Type);
            Assert.Equal(command.Location, DistrictEntity.Location);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateDistrictCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateDistrictResponse()
        {
            // Arrange
            var command = new CreateDistrictCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateDistrictResponse>>(command);
        }
    }
}
