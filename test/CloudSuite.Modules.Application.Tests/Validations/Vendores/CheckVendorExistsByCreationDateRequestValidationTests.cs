using CloudSuite.Modules.Application.Validations.Core.Vendores;
using FluentValidation.TestHelper;
using System;
using Xunit;


namespace CloudSuite.Modules.Application.Tests.Validations.Vendores
{
    public class CheckVendorExistsByCreationDateRequestValidationTests
    {
        [Fact]
        public void Valid_CreationDate_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckVendorExistsByCreationDateRequestValidation();
            var validRequest = new CheckVendorExistsByCreationDateRequest
            {
                CreatedOn = DateTimeOffset.UtcNow 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.CreatedOn, validRequest);
        }

        [Fact]
        public void Empty_CreationDate_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckVendorExistsByCreationDateRequestValidation();
            var invalidRequest = new CheckVendorExistsByCreationDateRequest
            {
                CreatedOn = default(DateTimeOffset)
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.CreatedOn, invalidRequest)
                .WithErrorMessage("CreatedOn deve ser uma data/hora válida");
        }
    }
}