using CloudSuite.Modules.Application.Validations.Core.AppSettings;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.AppSettings
{
    public class CheckAppSettingExistsByValueRequestValidationTests
    {
        [Fact]
        public void Valid_Value_Should_Pass_Validation()
        {
            var validator = new CheckAppSettingExistsByValueRequestValidation();
            var validRequest = new CheckAppSettingExistsByValueRequest
            {
                Value = "Valor válido"
            };

            validator.ShouldNotHaveValidationErrorFor(request => request.Value, validRequest);
        }

        [Fact]
        public void Empty_Value_Should_Fail_Validation()
        {
            var validator = new CheckAppSettingExistsByValueRequestValidation();
            var invalidRequest = new CheckAppSettingExistsByValueRequest
            {
                Value = string.Empty
            };

            validator.ShouldHaveValidationErrorFor(request => request.Value, invalidRequest)
                .WithErrorMessage("O valor de AppSetting deve ser preenchido");
        }

        [Fact]
        public void Value_TooLong_Should_Fail_Validation()
        {
            var validator = new CheckAppSettingExistsByValueRequestValidation();
            var invalidRequest = new CheckAppSettingExistsByValueRequest
            {
                Value = new string('A', 451) 
            };

            validator.ShouldHaveValidationErrorFor(request => request.Value, invalidRequest)
                .WithErrorMessage("O valor de AppSetting deve possuir no máximo 450 caracteres");
        }
    }
}
