using CloudSuite.Modules.Application.Validations.Core.Countries;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Countries
{
    public class CheckCountryExistsByCodeRequestValidationTests
    {
        [Fact]
        public void Valid_Code3_Should_Pass_Validation()
        {

            var validator = new CheckCountryExistsByCodeRequestValidation();
            var validRequest = new CheckCountryExistsByCodeRequest
            {
                Code3 = "ABC" 
            };


            validator.ShouldNotHaveValidationErrorFor(request => request.Code3, validRequest);
        }

        [Fact]
        public void Empty_Code3_Should_Fail_Validation()
        {

            var validator = new CheckCountryExistsByCodeRequestValidation();
            var invalidRequest = new CheckCountryExistsByCodeRequest
            {
                Code3 = string.Empty
            };


            validator.ShouldHaveValidationErrorFor(request => request.Code3, invalidRequest)
                .WithErrorMessage("O código deve ser preenchido");
        }

        [Fact]
        public void Code3_TooLong_Should_Fail_Validation()
        {

            var validator = new CheckCountryExistsByCodeRequestValidation();
            var invalidRequest = new CheckCountryExistsByCodeRequest
            {
                Code3 = new string('A', 451) 
            };


            validator.ShouldHaveValidationErrorFor(request => request.Code3, invalidRequest)
                .WithErrorMessage("O código não deve possuir mais que 450 caracteres");
        }
    }
}