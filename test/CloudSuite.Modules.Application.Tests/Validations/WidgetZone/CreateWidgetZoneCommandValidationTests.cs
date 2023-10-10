using CloudSuite.Modules.Application.Handlers.Core.WidgetZones;
using CloudSuite.Modules.Application.Validations.Core.WidgetZones;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.WidgetZone
{
    public class CreateWidgetZoneCommandValidationTests
    {
         private readonly CreateWidgetZoneCommandValidation _validator;

        public CreateWidgetZoneCommandValidationTests()
        {
            _validator = new CreateWidgetZoneCommandValidation();
        }

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(command => command.Name, new CreateWidgetZoneCommand());
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Name_ShouldNotBeNullOrWhitespace(string name)
        {
            _validator.ShouldHaveValidationErrorFor(command => command.Name, new CreateWidgetZoneCommand
            {
                Name = name
            });
        }

        [Fact]
        public void Name_ShouldNotExceedMaxLength()
        {
            var name = new string('A', 451); 
            _validator.ShouldHaveValidationErrorFor(command => command.Name, new CreateWidgetZoneCommand
            {
                Name = name
            });
        }

        [Fact]
        public void Description_ShouldNotBeEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(command => command.Description, new CreateWidgetZoneCommand());
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Description_ShouldNotBeNullOrWhitespace(string description)
        {
            _validator.ShouldHaveValidationErrorFor(command => command.Description, new CreateWidgetZoneCommand
            {
                Description = description
            });
        }

        [Fact]
        public void Description_ShouldNotExceedMaxLength()
        {
            var description = new string('A', 101); 
            _validator.ShouldHaveValidationErrorFor(command => command.Description, new CreateWidgetZoneCommand
            {
                Description = description
            });
        }

        [Fact]
        public void ValidCommand_ShouldPassValidation()
        {
            var validCommand = new CreateWidgetZoneCommand
            {
                Name = "Valid Name",
                Description = "Valid Description"
            };

            _validator.ShouldNotHaveValidationErrorFor(command => command.Name, validCommand);
            _validator.ShouldNotHaveValidationErrorFor(command => command.Description, validCommand);
        }
    }
}