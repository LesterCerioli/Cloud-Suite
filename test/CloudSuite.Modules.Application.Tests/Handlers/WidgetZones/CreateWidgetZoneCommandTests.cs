using CloudSuite.Modules.Application.Handlers.Core.WidgetZones;
using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Responses;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.WidgetZones
{
    public class CreateWidgetZoneCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidWidgetZoneEntity()
        {
            // Arrange
            var command = new CreateWidgetZoneCommand
            {
                Name = "Zone Name",
                Description = "Zone Description"
            };

            var widgetZoneEntity = command.GetEntity();

            // Assert
            Assert.NotNull(widgetZoneEntity);
            Assert.Equal(command.Id, widgetZoneEntity.Id);
            Assert.Equal(command.Name, widgetZoneEntity.Name);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateWidgetZoneCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateWidgetZoneResponse()
        {
            // Arrange
            var command = new CreateWidgetZoneCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateWidgetZoneResponse>>(command);
        }
    }
}
