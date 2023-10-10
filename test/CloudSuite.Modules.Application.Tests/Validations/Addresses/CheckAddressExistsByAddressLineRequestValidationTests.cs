using CloudSuite.Modules.Application.Validations.Core.Addresses;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Addresses
{
    public class CheckAddressExistsByAddressLineRequestValidationTests
    {
         [Fact]
        public void Valid_AddressLine1_Should_Pass_Validation()
        {

            var validator = new CheckAddressExistsByAddressLineRequestValidation();
            var validRequest = new CheckAddressExistsByAddressLineRequest
            {
                AddressLine1 = "Endereço Válido"
            };


            validator.ShouldNotHaveValidationErrorFor(request => request.AddressLine1, validRequest);
        }

        [Fact]
        public void Empty_AddressLine1_Should_Fail_Validation()
        {

            var validator = new CheckAddressExistsByAddressLineRequestValidation();
            var invalidRequest = new CheckAddressExistsByAddressLineRequest
            {
                AddressLine1 = string.Empty
            };


            validator.ShouldHaveValidationErrorFor(request => request.AddressLine1, invalidRequest)
                .WithErrorMessage("Endereço deve ser preenchido");
        }

        [Fact]
        public void AddressLine1_TooLong_Should_Fail_Validation()
        {

            var validator = new CheckAddressExistsByAddressLineRequestValidation();
            var invalidRequest = new CheckAddressExistsByAddressLineRequest
            {
                AddressLine1 = new string('A', 451) 
            };


            validator.ShouldHaveValidationErrorFor(request => request.AddressLine1, invalidRequest)
                .WithErrorMessage("Endereço não deve possuir mais que 450 caracteres");
        }
    }
}