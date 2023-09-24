using CloudSuite.Modules.Application.Handlers.Core.Users.Responses;
using FluentValidation.Results;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Core.Users.Responses
{
    public class CreateUserResponseTests
    {
        [Fact]
        public void Constructor_WithValidationResult_SetsPropertiesCorrectly()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var validationResult = new ValidationResult();

            // Act
            var response = new CreateUserResponse(requestId, validationResult);

            // Assert
            response.RequestId.Should().Be(requestId);
            response.Errors.Should().BeEmpty();
        }

        [Fact]
        public void Constructor_WithValidationFailure_SetsPropertiesCorrectly()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var validationFailure = "Validation failed";

            // Act
            var response = new CreateUserResponse(requestId, validationFailure);

            // Assert
            response.RequestId.Should().Be(requestId);
            response.Errors.Should().ContainSingle().And.Contain(validationFailure);
        }
    }
}
