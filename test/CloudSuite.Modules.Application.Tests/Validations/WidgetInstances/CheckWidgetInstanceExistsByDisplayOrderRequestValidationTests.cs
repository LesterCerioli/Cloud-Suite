using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.WidgetInstances
{
    public class CheckWidgetInstanceExistsByDisplayOrderRequestValidationTests
    {
        [Fact]
        public void Valid_WidgetInstance_DisplayOrder_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByDisplayOrderRequestValidation();
            var validRequest = new CheckWidgetInstanceExistsByDisplayOrderRequest
            {
                DisplayOrder = 1 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.DisplayOrder, validRequest);
        }

        [Fact]
        public void WidgetInstance_DisplayOrder_Zero_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByDisplayOrderRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByDisplayOrderRequest
            {
                DisplayOrder = 0
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.DisplayOrder, invalidRequest)
                .WithErrorMessage("DisplayOrder deve ser preenchido");
        }

        [Fact]
        public void WidgetInstance_DisplayOrder_Negative_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByDisplayOrderRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByDisplayOrderRequest
            {
                DisplayOrder = -1
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.DisplayOrder, invalidRequest)
                .WithErrorMessage("DisplayOrder deve ser preenchido");
        }
    }
}