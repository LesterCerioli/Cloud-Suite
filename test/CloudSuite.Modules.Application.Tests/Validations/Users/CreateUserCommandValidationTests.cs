using CloudSuite.Modules.Application.Validations.Core.Users;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Users
{
    public class CreateUserCommandValidationTests
    {
        [Fact]
        public void Valid_CreateUserCommand_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CreateUserCommandValidation();
            var validCommand = new CreateUserCommand
            {
                FullName = "Nome Completo", 
                Email = "teste@example.com",
                Cpf = "12345678900", 
                Vendor = "Fornecedor" 
                
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(command => command.FullName, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Email, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Cpf, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Vendor, validCommand);
           
        }

        [Fact]
        public void Empty_FullName_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateUserCommandValidation();
            var invalidCommand = new CreateUserCommand
            {
                FullName = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.FullName, invalidCommand)
                .WithErrorMessage("O nome completo deve ser preenchido");
        }

        [Fact]
        public void Empty_Email_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateUserCommandValidation();
            var invalidCommand = new CreateUserCommand
            {
                Email = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.Email, invalidCommand)
                .WithErrorMessage("Email deve ser preenchido");
        }

        [Fact]
        public void Empty_Cpf_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateUserCommandValidation();
            var invalidCommand = new CreateUserCommand
            {
                Cpf = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.Cpf, invalidCommand)
                .WithErrorMessage("Cpf deve ser preenchido");
        }

        [Fact]
        public void Empty_Vendor_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CreateUserCommandValidation();
            var invalidCommand = new CreateUserCommand
            {
                Vendor = string.Empty
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(command => command.Vendor, invalidCommand)
                .WithErrorMessage("Fornecedor deve ser preenchido");
        }
    }
}