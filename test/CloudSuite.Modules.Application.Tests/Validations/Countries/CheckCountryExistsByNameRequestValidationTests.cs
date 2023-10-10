using CloudSuite.Modules.Application.Validations.Core.Countries;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Countries
{
    public class CheckCountryExistsByNameRequestValidationTests
    {
        [Fact]
        public void Valid_CountryName_Should_Pass_Validation()
        {

            var validator = new CheckCountryExistsByNameRequestValidation();
            var validRequest = new CheckCountryExistsByNameRequest
            {
                CountryName = "Nome do País Válido"
            };


            validator.ShouldNotHaveValidationErrorFor(request => request.CountryName, validRequest);
        }

        [Fact]
        public void Empty_CountryName_Should_Fail_Validation()
        {

            var validator = new CheckCountryExistsByNameRequestValidation();
            var invalidRequest = new CheckCountryExistsByNameRequest
            {
                CountryName = string.Empty
            };


            validator.ShouldHaveValidationErrorFor(request => request.CountryName, invalidRequest)
                .WithErrorMessage("O nome do País deve ser preenchido");
        }

        [Fact]
        public void CountryName_TooLong_Should_Fail_Validation()
        {

            var validator = new CheckCountryExistsByNameRequestValidation();
            var invalidRequest = new CheckCountryExistsByNameRequest
            {
                CountryName = new string('A', 451)
            };


            validator.ShouldHaveValidationErrorFor(request => request.CountryName, invalidRequest)
                .WithErrorMessage("O nome do País não deve possuir mais que 450 caracteres");
        }
    }
}