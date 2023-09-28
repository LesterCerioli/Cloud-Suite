using System;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.States.Responses.Tests
{
    public class CheckStateExistsByUFResponseTests
    {
        [Fact]
        public void Constructor_WithValidationResult_AddsErrors()
        {
            // Arrange
            Guid requestId = Guid.NewGuid();
            bool exists = false;
            var validationResult = new ValidationResult();

            // Act
            var response = new CheckStateExistsByUFResponse(requestId, exists, validationResult);

            // Assert
            Assert.Equal(requestId, response.RequestId);
            Assert.Equal(exists, response.Exists);
            Assert.Empty(response.Errors);
        }

        [Fact]
        public void Constructor_WithValidationFailure_AddsError()
        {
            // Arrange
            Guid requestId = Guid.NewGuid();
            string validationFailure = "Error Message";

            // Act
            var response = new CheckStateExistsByUFResponse(requestId, validationFailure);

            // Assert
            Assert.Equal(requestId, response.RequestId);
            Assert.False(response.Exists);
            Assert.Single(response.Errors);
            Assert.Contains(validationFailure, response.Errors); // Assert the presence of "Error Message"

        }
    }
}
