using CloudSuite.Modules.Application.Handlers.Core.Users.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Users;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Users
{
    public class CreateUserCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidUserEntity()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                FullName = "John Doe",
                IsDeleted = false,
                CreatedOn = DateTimeOffset.Now,
                LatestUpdatedOn = DateTimeOffset.Now,
                RefreshTokenHash = "hashedToken", 
                Culture = "en-US",
                ExtensionData = "SomeData"
            };

            var UserEntity = command.GetEntity();

            // Assert
            Assert.NotNull(UserEntity);
            Assert.Equal(command.Id, UserEntity.Id);
            Assert.Equal(command.FullName, UserEntity.FullName);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateUserCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateUserResponse()
        {
            // Arrange
            var command = new CreateUserCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateUserResponse>>(command);
        }
    }
}
