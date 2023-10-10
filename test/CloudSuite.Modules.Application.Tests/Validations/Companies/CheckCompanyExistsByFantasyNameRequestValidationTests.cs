using CloudSuite.Modules.Application.Validations.Core.Companies;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Companies
{
    public class CheckCompanyExistsByFantasyNameRequestValidationTests
    {
        [Fact]
        public void Valid_FantasyName_Should_Pass_Validation()
        {

            var validator = new CheckCompanyExistsByFantasyNameRequestValidation();
            var validRequest = new CheckCompanyExistsByFantasyNameRequest
            {
                FantasyName = "Nome Fantasia Válido"
            };


            validator.ShouldNotHaveValidationErrorFor(request => request.FantasyName, validRequest);
        }

        [Fact]
        public void Empty_FantasyName_Should_Fail_Validation()
        {

            var validator = new CheckCompanyExistsByFantasyNameRequestValidation();
            var invalidRequest = new CheckCompanyExistsByFantasyNameRequest
            {
                FantasyName = string.Empty
            };


            validator.ShouldHaveValidationErrorFor(request => request.FantasyName, invalidRequest)
                .WithErrorMessage("Nome fantasia deve ser preenchido");
        }

        [Fact]
        public void FantasyName_TooLong_Should_Fail_Validation()
        {

            var validator = new CheckCompanyExistsByFantasyNameRequestValidation();
            var invalidRequest = new CheckCompanyExistsByFantasyNameRequest
            {
                FantasyName = new string('A', 101)
            };


            validator.ShouldHaveValidationErrorFor(request => request.FantasyName, invalidRequest)
                .WithErrorMessage("Nome fantasia deve possuir no máximo 100 caracteres");
        }
    }
}
