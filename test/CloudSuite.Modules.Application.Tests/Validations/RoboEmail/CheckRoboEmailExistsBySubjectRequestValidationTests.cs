using CloudSuite.Modules.Application.Validations.Core.RoboEmail;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.RoboEmail
{
    public class CheckRoboEmailExistsBySubjectRequestValidationTests
    {
         [Fact]
        public void Valid_Subject_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckRoboEmailExistsBySubjectRequestValidation();
            var validRequest = new CheckRoboEmailExistsBySubjectRequest
            {
                Subject = "AssuntoVálido"
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.Subject, validRequest);
        }

        [Fact]
        public void Empty_Subject_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckRoboEmailExistsBySubjectRequestValidation();
            var invalidRequest = new CheckRoboEmailExistsBySubjectRequest
            {
                Subject = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Subject, invalidRequest)
                .WithErrorMessage("Assunto deve ser preenchido");
        }

        [Fact]
        public void Subject_TooLong_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckRoboEmailExistsBySubjectRequestValidation();
            var invalidRequest = new CheckRoboEmailExistsBySubjectRequest
            {
                Subject = new string('A', 11) 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Subject, invalidRequest)
                .WithErrorMessage("Assunto deve conter no máximo 10 caracteres");
        }
    }
}