using System;
using FluentValidation.Results;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies.Responses.Tests
{
    public class CheckCompanyExistsByFantasyNameResponseTests
    {
        [Fact]
        public void Constructor_WithValidationResult_AddsErrors()
        {
            // Arrange
            Guid requestId = Guid.NewGuid();
            bool exists = false;
            var validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure("PropertyName", "Error Message"));

            // Act
            var response = new CheckCompanyExistsByFantasyNameResponse(requestId, exists, validationResult);

            // Assert
            Assert.Equal(requestId, response.RequestId);
            Assert.Equal(exists, response.Exists);
            Assert.NotEmpty(response.Errors); // Assert that errors are not empty
            Assert.Contains("Error Message", response.Errors); // Assert the presence of "Error Message"
        }

        [Fact]
        public void Constructor_WithValidationFailure_AddsError()
        {
            // Arrange
            Guid requestId = Guid.NewGuid();
            string validationFailure = "Error Message";

            // Act
            var response = new CheckCompanyExistsByFantasyNameResponse(requestId, validationFailure);

            // Assert
            Assert.Equal(requestId, response.RequestId);
            Assert.False(response.Exists);
            Assert.Single(response.Errors); // Assert that there is one error
            Assert.Contains(validationFailure, response.Errors); // Assert the presence of "Error Message"
        }
    }
}
