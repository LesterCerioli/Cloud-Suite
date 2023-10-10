using CloudSuite.Modules.Application.Validations.Core.Companies;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Companies
{
    public class CheckCompanyExistsByRegisterNameRequestValidationTests
    {
        [Fact]
        public void Valid_RegisterName_Should_Pass_Validation()
        {

            var validator = new CheckCompanyExistsByRegisterNameRequestValidation();
            var validRequest = new CheckCompanyExistsByRegisterNameRequest
            {
                RegisterName = "Nome de Registro Válido"
            };


            validator.ShouldNotHaveValidationErrorFor(request => request.RegisterName, validRequest);
        }

        [Fact]
        public void Empty_RegisterName_Should_Fail_Validation()
        {

            var validator = new CheckCompanyExistsByRegisterNameRequestValidation();
            var invalidRequest = new CheckCompanyExistsByRegisterNameRequest
            {
                RegisterName = string.Empty
            };


            validator.ShouldHaveValidationErrorFor(request => request.RegisterName, invalidRequest)
                .WithErrorMessage("Nome de registro deve ser preenchido");
        }

        [Fact]
        public void RegisterName_TooLong_Should_Fail_Validation()
        {

            var validator = new CheckCompanyExistsByRegisterNameRequestValidation();
            var invalidRequest = new CheckCompanyExistsByRegisterNameRequest
            {
                RegisterName = new string('A', 101) 
            };


            validator.ShouldHaveValidationErrorFor(request => request.RegisterName, invalidRequest)
                .WithErrorMessage("Nome de registro deve possuir no máximo 100 caracteres");
        }
    }
}
