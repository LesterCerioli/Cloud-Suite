using CloudSuite.Modules.Application.Handlers.Core.Widgets;
using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Widgets
{
    public class CreateWidgetCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidWidgetEntity()
        {
            // Arrange
            var command = new CreateWidgetCommand
            {
                Name = "Widget Name",
                ViewComponentName = "WidgetComponent",
                CreateUrl = "/create",
                EditUrl = "/edit",
                IsPublished = true
            };

            var widgetEntity = command.GetEntity();

            // Assert
            Assert.NotNull(widgetEntity);
            Assert.Equal(command.Id, widgetEntity.Id);
            Assert.Equal(command.Name, widgetEntity.Name);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateWidgetCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateWidgetResponse()
        {
            // Arrange
            var command = new CreateWidgetCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateWidgetResponse>>(command);
        }
    }
}
