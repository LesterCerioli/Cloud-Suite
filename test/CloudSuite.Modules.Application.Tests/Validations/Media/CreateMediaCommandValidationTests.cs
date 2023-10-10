using CloudSuite.Modules.Application.Validations.Core.Medias;
using FluentValidation.TestHelper;
using Xunit;


namespace CloudSuite.Modules.Application.Tests.Validations.Media
{
    public class CreateMediaCommandValidationTests
    {
        [Fact]
        public void Valid_CreateMediaCommand_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CreateMediaCommandValidation();
            var validCommand = new CreateMediaCommand
            {
                Caption = "Caption Válido",
                FileSize = 1024, 
                FileName = "NomeDoArquivo.txt",
                MediaType = MediaType.Image 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(command => command.Caption, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.FileSize, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.FileName, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.MediaType, validCommand);
        }

        [Fact]
        public void Empty_Caption_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateMediaCommandValidation();
            var invalidCommand = new CreateMediaCommand
            {
                Caption = string.Empty,
                FileSize = 1024,
                FileName = "NomeDoArquivo.txt",
                MediaType = MediaType.Image
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.Caption, invalidCommand)
                .WithErrorMessage("Caption deve ser preenchido");
        }

        [Fact]
        public void Zero_FileSize_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateMediaCommandValidation();
            var invalidCommand = new CreateMediaCommand
            {
                Caption = "Caption Válido",
                FileSize = 0,
                FileName = "NomeDoArquivo.txt",
                MediaType = MediaType.Image
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.FileSize, invalidCommand)
                .WithErrorMessage("FileSize deve ser maior que zero");
        }

        [Fact]
        public void Empty_FileName_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateMediaCommandValidation();
            var invalidCommand = new CreateMediaCommand
            {
                Caption = "Caption Válido",
                FileSize = 1024,
                FileName = string.Empty,
                MediaType = MediaType.Image
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.FileName, invalidCommand)
                .WithErrorMessage("FileName deve ser preenchido");
        }

        [Fact]
        public void Short_MediaType_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateMediaCommandValidation();
            var invalidCommand = new CreateMediaCommand
            {
                Caption = "Caption Válido",
                FileSize = 1024,
                FileName = "NomeDoArquivo.txt",
                MediaType = MediaType.I 
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.MediaType, invalidCommand)
                .WithErrorMessage("MediaType muito curta");
        }
    }
}