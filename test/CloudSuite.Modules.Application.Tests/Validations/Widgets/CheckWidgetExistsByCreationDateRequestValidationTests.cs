using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using CloudSuite.Modules.Application.Validations.Core.Widgets;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Widgets
{
    public class CheckWidgetExistsByCreationDateRequestValidationTests
    {
        [Fact]
        public void Valid_WidgetExistsByCreationDateRequest_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckWidgetExistsByCreationDateRequestValidation();
            var validRequest = new CheckWidgetExistsByCreationDateRequest
            {
                CreatedOn = DateTimeOffset.Now.AddDays(-1) 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.CreatedOn, validRequest);
        }

        [Fact]
        public void WidgetExistsByCreationDateRequest_Invalid_CreatedOn_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetExistsByCreationDateRequestValidation();
            var invalidRequest = new CheckWidgetExistsByCreationDateRequest
            {
                CreatedOn = default(DateTimeOffset) 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.CreatedOn, invalidRequest)
                .WithErrorMessage("CreatedOn deve ser preenchido");
        }
    }
}