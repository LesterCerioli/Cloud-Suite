using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.WidgetInstances
{
    public class CheckWidgetInstanceExistsByDataRequestValidationTests
    {
        [Fact]
        public void Valid_WidgetInstance_Data_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByDataRequestValidation();
            var validRequest = new CheckWidgetInstanceExistsByDataRequest
            {
                Data = "Dados válidos"
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.Data, validRequest);
        }

        [Fact]
        public void WidgetInstance_Data_Null_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByDataRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByDataRequest
            {
                Data = null
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Data, invalidRequest)
                .WithErrorMessage("Dados deve ser preenchido");
        }

        [Fact]
        public void WidgetInstance_Data_Empty_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByDataRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByDataRequest
            {
                Data = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Data, invalidRequest)
                .WithErrorMessage("Dados deve ser preenchido");
        }

        [Fact]
        public void WidgetInstance_Data_TooLong_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByDataRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByDataRequest
            {
                Data = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque gravida sapien vel nulla fermentum, in sollicitudin ligula bibendum."
                
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Data, invalidRequest)
                .WithErrorMessage("Dados deve conter no máximo 100 caracteres");
        }
    }
}