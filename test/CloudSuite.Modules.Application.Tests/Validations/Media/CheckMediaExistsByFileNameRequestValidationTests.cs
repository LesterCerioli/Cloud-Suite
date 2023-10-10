using CloudSuite.Modules.Application.Validations.Core.Medias;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Media
{
    public class CheckMediaExistsByFileNameRequestValidationTests
    {
         [Fact]
        public void Valid_FileName_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckMediaExistsByFileNameRequestValidation();
            var validRequest = new CheckMediaExistsByFileNameRequest
            {
                FileName = "NomeDoArquivo.txt"
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.FileName, validRequest);
        }

        [Fact]
        public void Empty_FileName_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckMediaExistsByFileNameRequestValidation();
            var invalidRequest = new CheckMediaExistsByFileNameRequest
            {
                FileName = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.FileName, invalidRequest)
                .WithErrorMessage("FileName deve ser preenchida");
        }

        [Fact]
        public void FileName_TooLong_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckMediaExistsByFileNameRequestValidation();
            var invalidRequest = new CheckMediaExistsByFileNameRequest
            {
                FileName = new string('A', 451)
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.FileName, invalidRequest)
                .WithErrorMessage("FileName deve conter no máximo 450 caracteres");
        }
    }
}