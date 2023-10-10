using CloudSuite.Modules.Application.Validations.Core.States;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.States
{
    public class CreateStateCommandValidationTests
    {
        [Fact]
        public void Valid_StateName_And_UF_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CreateStateCommandValidation();
            var validCommand = new CreateStateCommand
            {
                StateName = "NomeDoEstado",
                UF = "SP"
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(command => command.StateName, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.UF, validCommand);
        }

        [Fact]
        public void Empty_StateName_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateStateCommandValidation();
            var invalidCommand = new CreateStateCommand
            {
                StateName = string.Empty,
                UF = "SP"
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.StateName, invalidCommand)
                .WithErrorMessage("Nome do Estado deve ser preenchido");
        }

        [Fact]
        public void Empty_UF_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateStateCommandValidation();
            var invalidCommand = new CreateStateCommand
            {
                StateName = "NomeDoEstado",
                UF = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.UF, invalidCommand)
                .WithErrorMessage("UF deve ser preenchido");
        }

        [Fact]
        public void UF_TooLong_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateStateCommandValidation();
            var invalidCommand = new CreateStateCommand
            {
                StateName = "NomeDoEstado",
                UF = "SPS" 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.UF, invalidCommand)
                .WithErrorMessage("UF deve conter 2 caracteres");
        }
    }
}