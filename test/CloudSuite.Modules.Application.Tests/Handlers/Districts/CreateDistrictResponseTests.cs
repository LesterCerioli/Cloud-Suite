using CloudSuite.Modules.Application.Handlers.Core.Districts.Responses;
using FluentValidation.Results;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Core.Districts.Responses
{
    public class CreateDistrictResponseTests
    {
        [Fact]
        public void Constructor_WithValidationResult_SetsPropertiesCorrectly()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var validationResult = new ValidationResult();

            // Act
            var response = new CreateDistrictResponse(requestId, validationResult);

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
            var response = new CreateDistrictResponse(requestId, validationFailure);

            // Assert
            response.RequestId.Should().Be(requestId);
            response.Errors.Should().ContainSingle().And.Contain(validationFailure);
        }
    }
}
