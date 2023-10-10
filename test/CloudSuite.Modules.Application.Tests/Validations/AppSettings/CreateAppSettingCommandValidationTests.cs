using CloudSuite.Modules.Application.Validations.Core.AppSettings;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.AppSettings
{
    public class CreateAppSettingCommandValidationTests
    {
        [Fact]
        public void Valid_AppSetting_Should_Pass_Validation()
        {
            var validator = new CreateAppSettingCommandValidation();
            var validCommand = new CreateAppSettingCommand
            {
                Value = "Valor válido",
                Module = "Módulo válido"
            };

            validator.ShouldNotHaveValidationErrorFor(command => command.Value, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Module, validCommand);
        }

        [Fact]
        public void Empty_Value_Should_Fail_Validation()
        {

            var validator = new CreateAppSettingCommandValidation();
            var invalidCommand = new CreateAppSettingCommand
            {
                Value = string.Empty,
                Module = "Módulo válido"

            };


            validator.ShouldHaveValidationErrorFor(command => command.Value, invalidCommand)
                .WithErrorMessage("O valor de AppSetting deve ser preenchido");
        }

        [Fact]
        public void Value_TooLong_Should_Fail_Validation()
        {

            var validator = new CreateAppSettingCommandValidation();
            var invalidCommand = new CreateAppSettingCommand
            {
                Value = new string('A', 451), 
                Module = "Módulo válido"

            };

            validator.ShouldHaveValidationErrorFor(command => command.Value, invalidCommand)
                .WithErrorMessage("O valor de AppSetting deve possuir no máximo 450 caracteres");
        }

        [Fact]
        public void Empty_Module_Should_Fail_Validation()
        {

            var validator = new CreateAppSettingCommandValidation();
            var invalidCommand = new CreateAppSettingCommand
            {
                Value = "Valor válido",
                Module = string.Empty
                
            };


            validator.ShouldHaveValidationErrorFor(command => command.Module, invalidCommand)
                .WithErrorMessage("Modulo deve ser preenchido");
        }

        [Fact]
        public void Module_TooLong_Should_Fail_Validation()
        {

            var validator = new CreateAppSettingCommandValidation();
            var invalidCommand = new CreateAppSettingCommand
            {
                Value = "Valor válido",
                Module = new string('A', 451) 

            };


            validator.ShouldHaveValidationErrorFor(command => command.Module, invalidCommand)
                .WithErrorMessage("Modulo deve possuir no máximo 450 caracteres");
        }
    }
}