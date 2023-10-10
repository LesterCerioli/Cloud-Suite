using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetZones;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.WidgetZone
{
    public class CheckWidgetZoneExistsByDescriptionRequestValidationTests
    {
        private readonly CheckWidgetZoneExistsByDescriptionRequestValidation _validator;

        public CheckWidgetZoneExistsByDescriptionRequestValidationTests()
        {
            _validator = new CheckWidgetZoneExistsByDescriptionRequestValidation();
        }

        [Fact]
        public void Description_ShouldNotBeEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(request => request.Description, new CheckWidgetZoneExistsByDescriptionRequest());
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("aa")] // Minimum length violation
        public void Description_ShouldNotBeInvalid(string description)
        {
            _validator.ShouldHaveValidationErrorFor(request => request.Description, new CheckWidgetZoneExistsByDescriptionRequest
            {
                Description = description
            });
        }

        [Fact]
        public void Description_ShouldNotExceedMaxLength()
        {
            var description = new string('A', 256); // Creating a string with 256 characters
            _validator.ShouldHaveValidationErrorFor(request => request.Description, new CheckWidgetZoneExistsByDescriptionRequest
            {
                Description = description
            });
        }

        [Fact]
        public void ValidDescription_ShouldPassValidation()
        {
            var validRequest = new CheckWidgetZoneExistsByDescriptionRequest
            {
                Description = "Valid Description"
            };

            _validator.ShouldNotHaveValidationErrorFor(request => request.Description, validRequest);
        }
    }
}