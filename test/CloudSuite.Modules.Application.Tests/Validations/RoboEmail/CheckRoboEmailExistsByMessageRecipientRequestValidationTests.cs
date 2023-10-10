using CloudSuite.Modules.Application.Validations.Core.RoboEmail;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.RoboEmail
{
    public class CheckRoboEmailExistsByMessageRecipientRequestValidationTests
    {
        [Fact]
        public void Valid_MessageRecipient_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckRoboEmailExistsByMessageRecipientRequestValidation();
            var validRequest = new CheckRoboEmailExistsByMessageRecipientRequest
            {
                MessageRecipient = "Descrição Válida"
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.MessageRecipient, validRequest);
        }

        [Fact]
        public void Empty_MessageRecipient_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckRoboEmailExistsByMessageRecipientRequestValidation();
            var invalidRequest = new CheckRoboEmailExistsByMessageRecipientRequest
            {
                MessageRecipient = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.MessageRecipient, invalidRequest)
                .WithErrorMessage("Descrição deve ser preenchida");
        }

        [Fact]
        public void MessageRecipient_TooLong_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckRoboEmailExistsByMessageRecipientRequestValidation();
            var invalidRequest = new CheckRoboEmailExistsByMessageRecipientRequest
            {
                MessageRecipient = new string('A', 101) 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.MessageRecipient, invalidRequest)
                .WithErrorMessage("A descrição deve conter no máximo 100 caracteres");
        }
    }
}