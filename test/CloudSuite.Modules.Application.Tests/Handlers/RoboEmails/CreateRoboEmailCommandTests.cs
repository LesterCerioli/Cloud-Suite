using CloudSuite.Modules.Application.Handlers.Core.RoboEmails;
using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Responses;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.RoboEmails
{
    public class CreateRoboEmailCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidRoboEmailEntity()
        {
            // Arrange
            var command = new CreateRoboEmailCommand
            {
                EmailAddressSender = "sender@test.com",
                Subject = "Test Subject",
                Body = "Test Body",
                ReceivedTime = DateTimeOffset.Now,
                MessageRecipient = "recipient@test.com",
            };

            var roboEmailEntity = command.GetEntity();

            // Assert
            Assert.NotNull(roboEmailEntity);
            Assert.Equal(command.Id, roboEmailEntity.Id);
            Assert.Equal(command.EmailAddressSender, roboEmailEntity.EmailAddressSender);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateRoboEmailCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateRoboEmailResponse()
        {
            // Arrange
            var command = new CreateRoboEmailCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateRoboEmailResponse>>(command);
        }
    }
}
