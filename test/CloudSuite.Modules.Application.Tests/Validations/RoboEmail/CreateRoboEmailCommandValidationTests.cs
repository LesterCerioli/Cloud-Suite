using CloudSuite.Modules.Application.Validations.Core.RoboEmail;
using FluentValidation.TestHelper;
using Xunit;


namespace CloudSuite.Modules.Application.Tests.Validations.RoboEmail
{
    public class CreateRoboEmailCommandValidationTests
    {
        [Fact]
        public void Valid_CreateRoboEmailCommand_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CreateRoboEmailCommandValidation();
            var validCommand = new CreateRoboEmailCommand
            {
                EmailAddressSender = "remetente@example.com",
                Subject = "Assunto",
                Body = "Mensagem válida",
                ReceivedTime = DateTime.Now,
                MessageRecipient = "destinatario@example.com"
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(command => command.EmailAddressSender, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Subject, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Body, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.ReceivedTime, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.MessageRecipient, validCommand);
        }

        [Fact]
        public void Empty_EmailAddressSender_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateRoboEmailCommandValidation();
            var invalidCommand = new CreateRoboEmailCommand
            {
                EmailAddressSender = string.Empty,
                Subject = "Assunto",
                Body = "Mensagem válida",
                ReceivedTime = DateTime.Now,
                MessageRecipient = "destinatario@example.com"
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.EmailAddressSender, invalidCommand)
                .WithErrorMessage("Remetente do endereço de e-mail deve ser preenchido");
        }
    }
}