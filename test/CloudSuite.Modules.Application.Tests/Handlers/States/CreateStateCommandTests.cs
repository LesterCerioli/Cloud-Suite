using CloudSuite.Modules.Application.Handlers.Core.States.Responses;
using CloudSuite.Modules.Application.Handlers.Core.States;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.States
{
    public class CreateStateCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidStateEntity()
        {
            // Arrange
            var command = new CreateStateCommand
            {
                StateName = "Name State",
                UF = "UF State",
            };

            var StateEntity = command.GetEntity();

            // Assert
            Assert.NotNull(StateEntity);
            Assert.Equal(command.Id, StateEntity.Id);
            Assert.Equal(command.StateName, StateEntity.StateName);
            Assert.Equal(command.UF, StateEntity.UF);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateStateCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateStateResponse()
        {
            // Arrange
            var command = new CreateStateCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateStateResponse>>(command);
        }
    }
}
