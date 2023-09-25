using CloudSuite.Modules.Application.Handlers.Core.Addresses.Responses;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Core.Addresses.Responses
{
    public class CheckAddressExistsByContactNameResponseTests
    {
        [Fact]
        public void Constructor_WithValidationResult_SetsPropertiesCorrectly()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var exists = true;
            var validationResult = new ValidationResult();

            // Act
            var response = new CheckAddressExistsByContactNameResponse(requestId, exists, validationResult);

            // Assert
            response.RequestId.Should().Be(requestId);
            response.Exists.Should().Be(exists);
            response.Errors.Should().BeEmpty();
        }

        [Fact]
        public void Constructor_WithValidationFailure_SetsPropertiesCorrectly()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var validationFailure = "Validation failed.";

            // Act
            var response = new CheckAddressExistsByContactNameResponse(requestId, validationFailure);

            // Assert
            response.RequestId.Should().Be(requestId);
            response.Exists.Should().BeFalse();
            response.Errors.Should().ContainSingle().And.Contain(validationFailure);
        }
    }
}
