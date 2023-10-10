using CloudSuite.Modules.Application.Validations.Core.Vendores;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Vendores
{
    public class CheckVendorExistsByNameRequestValidationTests
    {
        [Fact]
        public void Valid_Name_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckVendorExistsByNameRequestValidation();
            var validRequest = new CheckVendorExistsByNameRequest
            {
                Name = "Nome do Fornecedor" 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.Name, validRequest);
        }

        [Fact]
        public void Empty_Name_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckVendorExistsByNameRequestValidation();
            var invalidRequest = new CheckVendorExistsByNameRequest
            {
                Name = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Name, invalidRequest)
                .WithErrorMessage("Nome do fornecedor deve ser preenchido.");
        }

        [Fact]
        public void Name_Over_Maximum_Length_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckVendorExistsByNameRequestValidation();
            var invalidRequest = new CheckVendorExistsByNameRequest
            {
                Name = new string('X', 451) 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Name, invalidRequest)
                .WithErrorMessage("Nome deve conter no máximo 450 caracteres.");
        }
    }
}