using CloudSuite.Modules.Application.Validations.Core.Vendores;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Vendores
{
    public class CheckVendorExistsByCnpjRequestValidationTests
    {
        [Fact]
        public void Valid_Cnpj_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckVendorExistsByCnpjRequestValidation();
            var validRequest = new CheckVendorExistsByCnpjRequest
            {
                Cnpj = "12345678901234" 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.Cnpj, validRequest);
        }

        [Fact]
        public void Empty_Cnpj_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckVendorExistsByCnpjRequestValidation();
            var invalidRequest = new CheckVendorExistsByCnpjRequest
            {
                Cnpj = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Cnpj, invalidRequest)
                .WithErrorMessage("Cnpj deve ser preenchido");
        }
    }
}