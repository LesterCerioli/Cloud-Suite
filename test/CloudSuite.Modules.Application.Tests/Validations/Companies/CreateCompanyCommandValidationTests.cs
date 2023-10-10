using CloudSuite.Modules.Application.Validations.Core.Companies;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Companies
{
    public class CreateCompanyCommandValidationTests
    {
        [Fact]
        public void Valid_CompanyCommand_Should_Pass_Validation()
        {
           
            var validator = new CreateCompanyCommandValidation();
            var validCommand = new CreateCompanyCommand
            {
                FantasyName = "Nome Fantasia Válido",
                RegisterName = "Nome de Registro Válido",
                Cnpj = "12345678901234",
                Address = "Endereço Válido"

            };


            validator.ShouldNotHaveValidationErrorFor(command => command.FantasyName, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.RegisterName, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Cnpj, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Address, validCommand);
        }

        [Fact]
        public void Empty_FantasyName_Should_Fail_Validation()
        {

            var validator = new CreateCompanyCommandValidation();
            var invalidCommand = new CreateCompanyCommand
            {
                FantasyName = string.Empty,
                RegisterName = "Nome de Registro Válido",
                Cnpj = "12345678901234",
                Address = "Endereço Válido"

            };


            validator.ShouldHaveValidationErrorFor(command => command.FantasyName, invalidCommand)
                .WithErrorMessage("Nome fantasia deve ser preenchido");
        }

        [Fact]
        public void Empty_RegisterName_Should_Fail_Validation()
        {

            var validator = new CreateCompanyCommandValidation();
            var invalidCommand = new CreateCompanyCommand
            {
                FantasyName = "Nome Fantasia Válido",
                RegisterName = string.Empty,
                Cnpj = "12345678901234",
                Address = "Endereço Válido"

            };


            validator.ShouldHaveValidationErrorFor(command => command.RegisterName, invalidCommand)
                .WithErrorMessage("Nome de registro deve ser preenchido");
        }

        [Fact]
        public void Empty_Cnpj_Should_Fail_Validation()
        {

            var validator = new CreateCompanyCommandValidation();
            var invalidCommand = new CreateCompanyCommand
            {
                FantasyName = "Nome Fantasia Válido",
                RegisterName = "Nome de Registro Válido",
                Cnpj = string.Empty,
                Address = "Endereço Válido"

            };


            validator.ShouldHaveValidationErrorFor(command => command.Cnpj, invalidCommand)
                .WithErrorMessage("O CNPJ deve ser preenchido");
        }

        [Fact]
        public void Empty_Address_Should_Fail_Validation()
        {

            var validator = new CreateCompanyCommandValidation();
            var invalidCommand = new CreateCompanyCommand
            {
                FantasyName = "Nome Fantasia Válido",
                RegisterName = "Nome de Registro Válido",
                Cnpj = "12345678901234",
                Address = string.Empty

            };


            validator.ShouldHaveValidationErrorFor(command => command.Address, invalidCommand)
                .WithErrorMessage("O Endereço deve ser preenchido");
        }
    }
}