using CloudSuite.Modules.Application.Validations.Core.States;
using FluentValidation.TestHelper;
using Xunit;


namespace CloudSuite.Modules.Application.Tests.Validations.States
{
    public class CheckStateExistsByStateNameRequestValidationTests
    {
        [Fact]
        public void Valid_StateName_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckStateExistsByStateNameRequestValidation();
            var validRequest = new CheckStateExistsByStateNameRequest
            {
                StateName = "NomeDoEstado"
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.StateName, validRequest);
        }

        [Fact]
        public void Empty_StateName_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckStateExistsByStateNameRequestValidation();
            var invalidRequest = new CheckStateExistsByStateNameRequest
            {
                StateName = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.StateName, invalidRequest)
                .WithErrorMessage("Nome do Estado deve ser preenchido");
        }

        [Fact]
        public void StateName_TooLong_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckStateExistsByStateNameRequestValidation();
            var invalidRequest = new CheckStateExistsByStateNameRequest
            {
                StateName = new string('A', 101) 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.StateName, invalidRequest)
                .WithErrorMessage("Nome do Estado deve conter no máximo 100 caracteres");
        }
    }
}