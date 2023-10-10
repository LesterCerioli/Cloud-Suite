using CloudSuite.Modules.Application.Validations.Core.AppSettings;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.AppSettings
{
    public class CheckAppSettingExistsByModuleRequestValidationTests
    {
        [Fact]
        public void Valid_Module_Should_Pass_Validation()
        {
            var validator = new CheckAppSettingExistsByModuleRequestValidation();
            var validRequest = new CheckAppSettingExistsByModuleRequest
            {
                Module = "Módulo válido"
            };

            validator.ShouldNotHaveValidationErrorFor(request => request.Module, validRequest);
        }

        [Fact]
        public void Empty_Module_Should_Fail_Validation()
        {
            var validator = new CheckAppSettingExistsByModuleRequestValidation();
            var invalidRequest = new CheckAppSettingExistsByModuleRequest
            {
                Module = string.Empty
            };

            validator.ShouldHaveValidationErrorFor(request => request.Module, invalidRequest)
                .WithErrorMessage("Modulo deve ser preenchido");
        }

        [Fact]
        public void Module_TooLong_Should_Fail_Validation()
        {
            var validator = new CheckAppSettingExistsByModuleRequestValidation();
            var invalidRequest = new CheckAppSettingExistsByModuleRequest
            {
                Module = new string('A', 451) 
            };

            validator.ShouldHaveValidationErrorFor(request => request.Module, invalidRequest)
                .WithErrorMessage("Modulo deve possuir no máximo 450 caracteres");
        }
        
    }
}