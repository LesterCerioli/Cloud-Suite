using CloudSuite.Modules.Application.Validations.Core.Cities;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Cities
{
    public class CheckCityExistsByCityNameRequestValidationTests
    {
        [Fact]
        public void Valid_CityName_Should_Pass_Validation()
        {

            var validator = new CheckCityExistsByCityNameRequestValidation();
            var validRequest = new CheckCityExistsByCityNameRequest
            {
                CityName = "Cidade válida"
            };


            validator.ShouldNotHaveValidationErrorFor(request => request.CityName, validRequest);
        }

        [Fact]
        public void Empty_CityName_Should_Fail_Validation()
        {

            var validator = new CheckCityExistsByCityNameRequestValidation();
            var invalidRequest = new CheckCityExistsByCityNameRequest
            {
                CityName = string.Empty
            };


            validator.ShouldHaveValidationErrorFor(request => request.CityName, invalidRequest)
                .WithErrorMessage("O nome da cidade deve ser preenchido");
        }

        [Fact]
        public void CityName_TooLong_Should_Fail_Validation()
        {

            var validator = new CheckCityExistsByCityNameRequestValidation();
            var invalidRequest = new CheckCityExistsByCityNameRequest
            {
                CityName = new string('A', 101) 
            };


            validator.ShouldHaveValidationErrorFor(request => request.CityName, invalidRequest)
                .WithErrorMessage("O nome da cidade deve ter no máximo 100 caracteres");
        }
    }
}
