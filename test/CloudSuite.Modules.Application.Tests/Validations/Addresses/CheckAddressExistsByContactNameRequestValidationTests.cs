using CloudSuite.Modules.Application.Validations.Core.Addresses;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Addresses
{
    public class CheckAddressExistsByContactNameRequestValidationTests
    {
        [Fact]
        public void Valid_ContactName_Should_Pass_Validation()
        {

            var validator = new CheckAddressExistsByContactNameRequestValidation();
            var validRequest = new CheckAddressExistsByContactNameRequest
            {
                ContactName = "Nome válido"

            };


            validator.ShouldNotHaveValidationErrorFor(request => request.ContactName, validRequest);
        }

        [Fact]
        public void Empty_ContactName_Should_Fail_Validation()
        {

            var validator = new CheckAddressExistsByContactNameRequestValidation();
            var invalidRequest = new CheckAddressExistsByContactNameRequest
            {
                ContactName = string.Empty
            };

            validator.ShouldHaveValidationErrorFor(request => request.ContactName, invalidRequest)
                .WithErrorMessage("Nome do Contato deve ser preenchido");
        }

        [Fact]
        public void ContactName_TooLong_Should_Fail_Validation()
        {

            var validator = new CheckAddressExistsByContactNameRequestValidation();
            var invalidRequest = new CheckAddressExistsByContactNameRequest
            {
                ContactName = new string('A', 101) 
               
            };

            validator.ShouldHaveValidationErrorFor(request => request.ContactName, invalidRequest)
                .WithErrorMessage("Nome do Contato deve ser preenchido");
        }
    }
}