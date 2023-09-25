using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using FluentValidation.Results;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Core.WidgetInstances.Responses
{
    public class CreateWidgetInstanceResponseTests
    {
        [Fact]
        public void Constructor_WithValidationResult_SetsPropertiesCorrectly()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var validationResult = new ValidationResult();

            // Act
            var response = new CreateWidgetInstanceResponse(requestId, validationResult);

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
            var response = new CreateWidgetInstanceResponse(requestId, validationFailure);

            // Assert
            response.RequestId.Should().Be(requestId);
            response.Errors.Should().ContainSingle().And.Contain(validationFailure);
        }
    }
}
