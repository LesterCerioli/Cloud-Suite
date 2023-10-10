using CloudSuite.Modules.Application.Validations.Core.Medias;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Media
{
    public class CheckMediaExistsByCaptionRequestValidationTests
    {
        [Fact]
        public void Valid_Caption_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckMediaExistsByCaptionRequestValidation();
            var validRequest = new CheckMediaExistsByCaptionRequest
            {
                Caption = "Caption Válido"
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.Caption, validRequest);
        }

        [Fact]
        public void Empty_Caption_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckMediaExistsByCaptionRequestValidation();
            var invalidRequest = new CheckMediaExistsByCaptionRequest
            {
                Caption = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Caption, invalidRequest)
                .WithErrorMessage("Caption deve ser preenchido");
        }

        [Fact]
        public void Caption_TooLong_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckMediaExistsByCaptionRequestValidation();
            var invalidRequest = new CheckMediaExistsByCaptionRequest
            {
                Caption = new string('A', 451) 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Caption, invalidRequest)
                .WithErrorMessage("Caption deve conter no máximo 450 caracteres");
        }
    }
}