using CloudSuite.Modules.Application.Handlers.Core.Countries.Responses;
using FluentValidation.Results;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Core.Countries.Responses
{
    public class CreateCountryResponseTests
    {
        [Fact]
        public void Constructor_WithValidationResult_SetsPropertiesCorrectly()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var validationResult = new ValidationResult();

            // Act
            var response = new CreateCountryResponse(requestId, validationResult);

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
            var response = new CreateCountryResponse(requestId, validationFailure);

            // Assert
            response.RequestId.Should().Be(requestId);
            response.Errors.Should().ContainSingle().And.Contain(validationFailure);
        }
    }
}
