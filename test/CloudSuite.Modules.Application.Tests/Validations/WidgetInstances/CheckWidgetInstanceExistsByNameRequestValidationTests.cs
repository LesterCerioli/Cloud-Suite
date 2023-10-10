using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.WidgetInstances
{
    public class CheckWidgetInstanceExistsByNameRequestValidationTests
    {
        [Fact]
        public void Valid_WidgetInstance_Name_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByNameRequestValidation();
            var validRequest = new CheckWidgetInstanceExistsByNameRequest
            {
                Name = "Nome válido" 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.Name, validRequest);
        }

        [Fact]
        public void WidgetInstance_Name_Empty_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByNameRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByNameRequest
            {
                Name = ""
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Name, invalidRequest)
                .WithErrorMessage("Nome deve ser preenchido");
        }

        [Fact]
        public void WidgetInstance_Name_Exceeds_MaximumLength_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByNameRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByNameRequest
            {
                Name = "Nome muito longo que excede 450 caracteres para teste."
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.Name, invalidRequest)
                .WithErrorMessage("Nome deve conter no máximo 450 caracteres");
        }
    }
}