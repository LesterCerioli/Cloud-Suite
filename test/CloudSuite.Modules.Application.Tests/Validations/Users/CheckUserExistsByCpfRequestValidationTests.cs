using CloudSuite.Modules.Application.Validations.Core.Users;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Users
{
    public class CheckUserExistsByCpfRequestValidationTests
    {
        [Fact]
        public void Valid_Cpf_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckUserExistsByCpfRequestValidation();
            var validRequest = new CheckUserExistsByCpfRequest
            {
                Cpf = "12345678900" 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.Cpf, validRequest);
        }

        [Fact]
        public void Empty_Cpf_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckUserExistsByCpfRequestValidation();
            var invalidRequest = new CheckUserExistsByCpfRequest
            {
                Cpf = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Cpf, invalidRequest)
                .WithErrorMessage("Cpf deve ser preenchido");
        }

        [Fact]
        public void Invalid_Cpf_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckUserExistsByCpfRequestValidation();
            var invalidRequest = new CheckUserExistsByCpfRequest
            {
                Cpf = "123456" 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Cpf, invalidRequest)
                .WithErrorMessage("Cpf deve ser preenchido");
        }
    }
}