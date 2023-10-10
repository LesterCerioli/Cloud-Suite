using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.WidgetInstances
{
    public class CreateWidgetInstanceCommandValidationTests
    {
         [Fact]
        public void Valid_WidgetInstanceCommand_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CreateWidgetInstanceCommandValidation();
            var validCommand = new CreateWidgetInstanceCommand
            {
                Name = "WidgetInstanceName", 
                WidgetId = "widget123",
                Data = "Dados de teste",
                HtmlData = "<div>Conteúdo HTML</div>", 
                DisplayOrder = 1 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(command => command.Name, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.WidgetId, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Data, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.HtmlData, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.DisplayOrder, validCommand);
        }

        [Fact]
        public void WidgetInstanceCommand_Invalid_Name_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateWidgetInstanceCommandValidation();
            var invalidCommand = new CreateWidgetInstanceCommand
            {
                Name = "", 
                WidgetId = "widget123",
                Data = "Dados de teste",
                HtmlData = "<div>Conteúdo HTML</div>",
                DisplayOrder = 1
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.Name, invalidCommand)
                .WithErrorMessage("Nome deve ser preenchido");
        }

        [Fact]
        public void WidgetInstanceCommand_Invalid_DisplayOrder_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateWidgetInstanceCommandValidation();
            var invalidCommand = new CreateWidgetInstanceCommand
            {
                Name = "WidgetInstanceName",
                WidgetId = "widget123",
                Data = "Dados de teste",
                HtmlData = "<div>Conteúdo HTML</div>",
                DisplayOrder = 0
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.DisplayOrder, invalidCommand)
                .WithErrorMessage("DisplayOrder deve ser preenchido");
        }

    }
}