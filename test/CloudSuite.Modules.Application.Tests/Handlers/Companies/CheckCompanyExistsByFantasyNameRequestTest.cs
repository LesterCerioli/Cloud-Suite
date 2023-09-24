using CloudSuite.Modules.Application.Handlers.Core.Companies.Requests;
using CloudSuite.Modules.Application.Validations.Core.Companies;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Companies
{
    public class CheckCompanyExistsByFantasyNameRequestValidationTests
    {
        [Fact]
        public void Should_Have_Error_When_FantasyName_Is_Empty()
        {
            // Arrange
            var validator = new CheckCompanyExistsByFantasyNameRequestValidation();
            var request = new CheckCompanyExistsByFantasyNameRequest(fantasyName: ""); // Provide the fantasyName parameter here

            // Act
            var result = validator.TestValidate(request);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.FantasyName)
                  .WithErrorMessage("Nome fantasia deve ser preenchido");
        }

        [Fact]
        public void Should_Have_Error_When_FantasyName_Is_Too_Long()
        {
            // Arrange
            var validator = new CheckCompanyExistsByFantasyNameRequestValidation();
            var request = new CheckCompanyExistsByFantasyNameRequest(fantasyName: new string('A', 101)); // Provide the fantasyName parameter here

            // Act
            var result = validator.TestValidate(request);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.FantasyName)
                  .WithErrorMessage("Nome fantasia deve possuir no máximo 100 caracteres");
        }

        [Fact]
        public void Should_Not_Have_Error_When_FantasyName_Is_Valid()
        {
            // Arrange
            var validator = new CheckCompanyExistsByFantasyNameRequestValidation();
            var request = new CheckCompanyExistsByFantasyNameRequest(fantasyName: "ValidFantasyName"); // Provide the fantasyName parameter here

            // Act
            var result = validator.TestValidate(request);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.FantasyName);
        }
    }
}
