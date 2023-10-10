using CloudSuite.Modules.Application.Validations.Core.Medias;
using FluentValidation.TestHelper;
using Xunit;


namespace CloudSuite.Modules.Application.Tests.Validations.Media
{
    public class CheckMediaExistsByFileSizeRequestValidationTests
    {
        [Fact]
        public void Valid_FileSize_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckMediaExistsByFileSizeRequestValidation();
            var validRequest = new CheckMediaExistsByFileSizeRequest
            {
                FileSize = 1024 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.FileSize, validRequest);
        }

        [Fact]
        public void Zero_FileSize_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckMediaExistsByFileSizeRequestValidation();
            var invalidRequest = new CheckMediaExistsByFileSizeRequest
            {
                FileSize = 0
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.FileSize, invalidRequest)
                .WithErrorMessage("FileSize deve ser maior que zero");
        }

        [Fact]
        public void Negative_FileSize_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckMediaExistsByFileSizeRequestValidation();
            var invalidRequest = new CheckMediaExistsByFileSizeRequest
            {
                FileSize = -1
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.FileSize, invalidRequest)
                .WithErrorMessage("FileSize deve ser maior que zero");
        }
    }
}