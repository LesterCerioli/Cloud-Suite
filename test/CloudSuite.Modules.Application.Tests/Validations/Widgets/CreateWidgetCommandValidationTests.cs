using CloudSuite.Modules.Application.Handlers.Core.Widgets;
using CloudSuite.Modules.Application.Validations.Core.Widgets;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Widgets
{
    public class CreateWidgetCommandValidationTests
    {
         private readonly CreateWidgetCommandValidation _validator;

        public CreateWidgetCommandValidationTests()
        {
            _validator = new CreateWidgetCommandValidation();
        }

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(command => command.Name, new CreateWidgetCommand());
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Name_ShouldNotBeNullOrWhitespace(string name)
        {
            _validator.ShouldHaveValidationErrorFor(command => command.Name, new CreateWidgetCommand
            {
                Name = name
            });
        }

        [Fact]
        public void Name_ShouldNotExceedMaxLength()
        {
            var name = new string('A', 451);
            _validator.ShouldHaveValidationErrorFor(command => command.Name, new CreateWidgetCommand
            {
                Name = name
            });
        }

        [Fact]
        public void ViewComponentName_ShouldNotBeEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(command => command.ViewComponentName, new CreateWidgetCommand());
        }


        [Fact]
        public void ValidCommand_ShouldPassValidation()
        {
            var validCommand = new CreateWidgetCommand
            {
                Name = "Valid Name",
                ViewComponentName = "Valid ViewComponentName",
                CreateUrl = "https://example.com/create",
                EditUrl = "https://example.com/edit",
                IsPublished = true,
                CreatedOn = DateTimeOffset.UtcNow,
                LatestUpdatedOn = DateTimeOffset.UtcNow
            };

            _validator.ShouldNotHaveValidationErrorFor(command => command.Name, validCommand);
            _validator.ShouldNotHaveValidationErrorFor(command => command.ViewComponentName, validCommand);
            _validator.ShouldNotHaveValidationErrorFor(command => command.CreateUrl, validCommand);
            _validator.ShouldNotHaveValidationErrorFor(command => command.EditUrl, validCommand);
            _validator.ShouldNotHaveValidationErrorFor(command => command.IsPublished, validCommand);
            _validator.ShouldNotHaveValidationErrorFor(command => command.CreatedOn, validCommand);
            _validator.ShouldNotHaveValidationErrorFor(command => command.LatestUpdatedOn, validCommand);
        }
    }
}