using CloudSuite.Modules.Application.Validations.Core.District;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.District
{
    public class CheckDistrictExistsByNameRequestValidationTests
    {
        [Fact]
        public void Valid_Name_Should_Pass_Validation()
        {

            var validator = new CheckDistrictExistsByNameRequestValidation();
            var validRequest = new CheckDistrictExistsByNameRequest
            {
                Name = "Nome do Bairro Válido"
            };


            validator.ShouldNotHaveValidationErrorFor(request => request.Name, validRequest);
        }

        [Fact]
        public void Empty_Name_Should_Fail_Validation()
        {
           
            var validator = new CheckDistrictExistsByNameRequestValidation();
            var invalidRequest = new CheckDistrictExistsByNameRequest
            {
                Name = string.Empty
            };


            validator.ShouldHaveValidationErrorFor(request => request.Name, invalidRequest)
                .WithErrorMessage("Nome do Bairro deve ser preenchido");
        }

        [Fact]
        public void Name_TooLong_Should_Fail_Validation()
        {

            var validator = new CheckDistrictExistsByNameRequestValidation();
            var invalidRequest = new CheckDistrictExistsByNameRequest
            {
                Name = new string('A', 451) 
            };


            validator.ShouldHaveValidationErrorFor(request => request.Name, invalidRequest)
                .WithErrorMessage("Nome do Bairro deve possuir no máximo 450 caracteres");
        }
    }
}