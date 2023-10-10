using CloudSuite.Modules.Application.Validations.Core.Cities;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Cities
{
    public class CreateCityCommandValidationTests
    {
        [Fact]
        public void Valid_CityName_Should_Pass_Validation()
        {

            var validator = new CreateCityCommandValidation();
            var validCommand = new CreateCityCommand
            {
                CityName = "Cidade válida"
            };


            validator.ShouldNotHaveValidationErrorFor(command => command.CityName, validCommand);
        }

        [Fact]
        public void Empty_CityName_Should_Fail_Validation()
        {

            var validator = new CreateCityCommandValidation();
            var invalidCommand = new CreateCityCommand
            {
                CityName = string.Empty
            };


            validator.ShouldHaveValidationErrorFor(command => command.CityName, invalidCommand)
                .WithErrorMessage("O nome da cidade deve ser preenchido");
        }

        [Fact]
        public void CityName_TooLong_Should_Fail_Validation()
        {

            var validator = new CreateCityCommandValidation();
            var invalidCommand = new CreateCityCommand
            {
                CityName = new string('A', 101) 
            };


            validator.ShouldHaveValidationErrorFor(command => command.CityName, invalidCommand)
                .WithErrorMessage("O nome da cidade deve ter no máximo 100 caracteres");
        }
    }
}
