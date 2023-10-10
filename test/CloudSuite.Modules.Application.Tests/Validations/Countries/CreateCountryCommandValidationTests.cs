using CloudSuite.Modules.Application.Validations.Core.Countries;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Countries
{
    public class CreateCountryCommandValidationTests
    {
        [Fact]
        public void Valid_CountryCommand_Should_Pass_Validation()
        {

            var validator = new CreateCountryCommandValidation();
            var validCommand = new CreateCountryCommand
            {
                CountryName = "Nome do País Válido",
                Code3 = "ABC" 

            };


            validator.ShouldNotHaveValidationErrorFor(command => command.CountryName, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Code3, validCommand);

        }

        [Fact]
        public void Empty_CountryName_Should_Fail_Validation()
        {

            var validator = new CreateCountryCommandValidation();
            var invalidCommand = new CreateCountryCommand
            {
                CountryName = string.Empty,
                Code3 = "ABC"
       
            };

            validator.ShouldHaveValidationErrorFor(command => command.CountryName, invalidCommand)
                .WithErrorMessage("O nome do País deve ser preenchido");
        }

        [Fact]
        public void Empty_Code3_Should_Fail_Validation()
        {

            var validator = new CreateCountryCommandValidation();
            var invalidCommand = new CreateCountryCommand
            {
                CountryName = "Nome do País Válido",
                Code3 = string.Empty

            };


            validator.ShouldHaveValidationErrorFor(command => command.Code3, invalidCommand)
                .WithErrorMessage("Código3 não pode ter mais que 450 caracteres");
        }
    }
}