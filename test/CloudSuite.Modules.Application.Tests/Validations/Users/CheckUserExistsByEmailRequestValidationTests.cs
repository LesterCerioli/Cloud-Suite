using CloudSuite.Modules.Application.Validations.Core.Users;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Users
{
    public class CheckUserExistsByEmailRequestValidationTests
    {
        [Fact]
        public void Valid_Email_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckUserExistsByEmailRequestValidation();
            var validRequest = new CheckUserExistsByEmailRequest
            {
                Email = "teste@hotmail.com" 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.Email, validRequest);
        }

        [Fact]
        public void Empty_Email_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckUserExistsByEmailRequestValidation();
            var invalidRequest = new CheckUserExistsByEmailRequest
            {
                Email = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Email, invalidRequest)
                .WithErrorMessage("Email deve ser preenchido");
        }

        [Fact]
        public void Invalid_Email_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckUserExistsByEmailRequestValidation();
            var invalidRequest = new CheckUserExistsByEmailRequest
            {
                Email = "emailinvalido" 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Email, invalidRequest)
                .WithErrorMessage("Email deve ser preenchido");
        }
    }
}