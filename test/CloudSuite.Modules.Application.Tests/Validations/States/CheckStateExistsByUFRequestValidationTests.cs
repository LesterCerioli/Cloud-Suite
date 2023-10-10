using CloudSuite.Modules.Application.Validations.Core.States;
using FluentValidation.TestHelper;
using Xunit;


namespace CloudSuite.Modules.Application.Tests.Validations.States
{
    public class CheckStateExistsByUFRequestValidationTests
    {
        [Fact]
        public void Valid_UF_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckStateExistsByUFRequestValidation();
            var validRequest = new CheckStateExistsByUFRequest
            {
                UF = "SP"
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.UF, validRequest);
        }

        [Fact]
        public void Empty_UF_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckStateExistsByUFRequestValidation();
            var invalidRequest = new CheckStateExistsByUFRequest
            {
                UF = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.UF, invalidRequest)
                .WithErrorMessage("UF deve ser preenchido");
        }

        [Fact]
        public void UF_TooLong_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckStateExistsByUFRequestValidation();
            var invalidRequest = new CheckStateExistsByUFRequest
            {
                UF = "SPS" 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.UF, invalidRequest)
                .WithErrorMessage("UF deve conter 2 caracteres");
        }
    }
}