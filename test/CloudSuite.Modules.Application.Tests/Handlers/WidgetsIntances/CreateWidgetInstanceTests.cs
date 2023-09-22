using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances;
using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.WidgetInstances
{
    public class CreateWidgetInstanceCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidWidgetInstanceEntity()
        {
            // Arrange
            var name = "WidgetInstanceName";

            var command = new CreateWidgetInstanceCommand
            {
                Name = name,
                WidgetId = "WidgetId",
                DisplayOrder = 1,
                Data = "WidgetData",
                HtmlData = "<div>Widget HTML Data</div>"
            };

            // Act
            var widgetInstanceEntity = command.GetEntity();

            // Assert
            Assert.NotNull(widgetInstanceEntity);
            Assert.NotEqual(Guid.Empty, widgetInstanceEntity.Id); // Ensure Id is not empty
            Assert.Equal(name, widgetInstanceEntity.Name);
            // Add other assertions as needed
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateWidgetInstanceCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateWidgetInstanceResponse()
        {
            // Arrange
            var command = new CreateWidgetInstanceCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateWidgetInstanceResponse>>(command);
        }
    }
}
