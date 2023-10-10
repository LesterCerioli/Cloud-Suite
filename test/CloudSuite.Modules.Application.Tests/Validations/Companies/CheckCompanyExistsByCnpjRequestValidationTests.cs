using CloudSuite.Modules.Application.Validations.Core.Companies;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Companies
{
    public class CheckCompanyExistsByCnpjRequestValidationTests
    {
        [Fact]
        public void Valid_Cnpj_Should_Pass_Validation()
        {

            var validator = new CheckCompanyExistsByCnpjRequestValidation();
            var validRequest = new CheckCompanyExistsByCnpjRequest
            {
                Cnpj = "12345678901234" 
            };


            validator.ShouldNotHaveValidationErrorFor(request => request.Cnpj, validRequest);
        }

        [Fact]
        public void Empty_Cnpj_Should_Fail_Validation()
        {

            var validator = new CheckCompanyExistsByCnpjRequestValidation();
            var invalidRequest = new CheckCompanyExistsByCnpjRequest
            {
                Cnpj = string.Empty
            };


            validator.ShouldHaveValidationErrorFor(request => request.Cnpj, invalidRequest)
                .WithErrorMessage("Cnpj deve ser preenchido");
        }

        [Fact]
        public void Invalid_Cnpj_Format_Should_Fail_Validation()
        {

            var validator = new CheckCompanyExistsByCnpjRequestValidation();
            var invalidRequest = new CheckCompanyExistsByCnpjRequest
            {
                Cnpj = "12345" 
            };


            validator.ShouldHaveValidationErrorFor(request => request.Cnpj, invalidRequest)
                .WithErrorMessage("Cnpj deve ser preenchido");
        }
    }
}