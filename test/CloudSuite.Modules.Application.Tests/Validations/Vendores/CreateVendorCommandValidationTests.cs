using CloudSuite.Modules.Application.Handlers.Core.Vendores;
using CloudSuite.Modules.Application.Validations.Core.Vendores;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Vendores
{
    public class CreateVendorCommandValidationTests
    {
        [Fact]
        public void Valid_Vendor_Command_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CreateVendorCommandValidation();
            var validCommand = new CreateVendorCommand
            {
                Name = "Nome do Fornecedor",
                Slug = "slug-do-fornecedor",
                Description = "Descrição do fornecedor",
                Cnpj = "12345678901234", 
                CreatedOn = DateTimeOffset.Now,
                LatestUpdatedOn = DateTimeOffset.Now,
                IsActive = true,
                IsDeleted = false
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(command => command.Name, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Slug, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Description, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Cnpj, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.Email, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.CreatedOn, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.LatestUpdatedOn, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.IsActive, validCommand);
            validator.ShouldNotHaveValidationErrorFor(command => command.IsDeleted, validCommand);
        }
    }
}