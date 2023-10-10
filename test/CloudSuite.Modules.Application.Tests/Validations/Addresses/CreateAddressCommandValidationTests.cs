using CloudSuite.Modules.Application.Validations.Core.Addresses;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Addresses
{
    public class CreateAddressCommandValidationTests
    {
        [Fact]
        public void Valid_Address_Should_Pass_Validation()
        {

            var validator = new CreateAddressCommandValidation();
            var validCommand = new CreateAddressCommand
            {
                AddressLine1 = "Endereço válido",
                ContactName = "Nome do Contato"

            };


            validator.ShouldNotHaveValidationErrorFor(command => command.AddressLine1, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.ContactName, validCommand);
        }

        [Fact]
        public void Empty_Address_Should_Fail_Validation()
        {

            var validator = new CreateAddressCommandValidation();
            var invalidCommand = new CreateAddressCommand
            {
                AddressLine1 = string.Empty,
                ContactName = "Nome do Contato"

            };


            validator.ShouldHaveValidationErrorFor(command => command.AddressLine1, invalidCommand)
                .WithErrorMessage("Endereço deve ser preenchido");
        }

        [Fact]
        public void Address_TooLong_Should_Fail_Validation()
        {

            var validator = new CreateAddressCommandValidation();
            var invalidCommand = new CreateAddressCommand
            {
                AddressLine1 = new string('A', 451), 
                ContactName = "Nome do Contato"

            };


            validator.ShouldHaveValidationErrorFor(command => command.AddressLine1, invalidCommand)
                .WithErrorMessage("Endereço deve conter no máximo 450 caracteres");
        }

        [Fact]
        public void Empty_ContactName_Should_Fail_Validation()
        {

            var validator = new CreateAddressCommandValidation();
            var invalidCommand = new CreateAddressCommand
            {
                AddressLine1 = "Endereço válido",
                ContactName = string.Empty
                
            };


            validator.ShouldHaveValidationErrorFor(command => command.ContactName, invalidCommand)
                .WithErrorMessage("Nome do contato deve ser preenchido");
        }

        [Fact]
        public void ContactName_TooLong_Should_Fail_Validation()
        {

            var validator = new CreateAddressCommandValidation();
            var invalidCommand = new CreateAddressCommand
            {
                AddressLine1 = "Endereço válido",
                ContactName = new string('A', 101) 
            
            };


            validator.ShouldHaveValidationErrorFor(command => command.ContactName, invalidCommand)
                .WithErrorMessage("Nome do contato deve conter no máximo 100 caracteres");
        }
    }
}