using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.WidgetInstances
{
    public class CheckWidgetInstanceExistsByHtmlDataRequestValidationTests
    {
        [Fact]
        public void Valid_WidgetInstance_HtmlData_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByHtmlDataRequestValidation();
            var validRequest = new CheckWidgetInstanceExistsByHtmlDataRequest
            {
                HtmlData = "DadosHtml válidos" 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.HtmlData, validRequest);
        }

        [Fact]
        public void WidgetInstance_HtmlData_Empty_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByHtmlDataRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByHtmlDataRequest
            {
                HtmlData = ""
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.HtmlData, invalidRequest)
                .WithErrorMessage("DadosHtml deve ser preenchido");
        }

        [Fact]
        public void WidgetInstance_HtmlData_Exceeds_MaximumLength_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckWidgetInstanceExistsByHtmlDataRequestValidation();
            var invalidRequest = new CheckWidgetInstanceExistsByHtmlDataRequest
            {
                HtmlData = "DadosHtml com mais de 100 caracteres, uma string muito longa para teste."
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.HtmlData, invalidRequest)
                .WithErrorMessage("DadosHtml deve conter no máximo 100 caracteres");
        }
    }
}