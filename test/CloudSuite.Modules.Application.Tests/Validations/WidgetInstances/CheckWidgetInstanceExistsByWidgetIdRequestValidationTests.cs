using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.WidgetInstances
{
    public class CheckWidgetInstanceExistsByWidgetIdRequestValidationTests
    {
        [Fact]
        public void Valid_WidgetId_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByWidgetIdRequestValidation();
            var validRequest = new CheckWidgetInstanceExistsByWidgetIdRequest
            {
                WidgetId = "widget123"
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.WidgetId, validRequest);
        }

        [Fact]
        public void WidgetId_Empty_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByWidgetIdRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByWidgetIdRequest
            {
                WidgetId = ""
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.WidgetId, invalidRequest)
                .WithErrorMessage("WidgetId deve ser preenchido");
        }

        [Fact]
        public void WidgetId_Exceeds_MaximumLength_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByWidgetIdRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByWidgetIdRequest
            {
                WidgetId = "widgetIdMuitoLongoQueExcede450CaracteresParaTeste"
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.WidgetId, invalidRequest)
                .WithErrorMessage("WidgetId deve conter no máximo 450 caracteres");
        }
    }
}