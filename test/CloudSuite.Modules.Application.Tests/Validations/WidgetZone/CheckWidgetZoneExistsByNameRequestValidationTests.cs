using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetZones;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.WidgetZone
{
    public class CheckWidgetZoneExistsByNameRequestValidationTests
    {
        private readonly CheckWidgetZoneExistsByNameRequestValidation _validator;

        public CheckWidgetZoneExistsByNameRequestValidationTests()
        {
            _validator = new CheckWidgetZoneExistsByNameRequestValidation();
        }

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(request => request.Name, new CheckWidgetZoneExistsByNameRequest());
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Name_ShouldNotBeNullOrWhitespace(string name)
        {
            _validator.ShouldHaveValidationErrorFor(request => request.Name, new CheckWidgetZoneExistsByNameRequest
            {
                Name = name
            });
        }

        [Fact]
        public void Name_ShouldNotExceedMaxLength()
        {
            var name = new string('A', 451); 
            _validator.ShouldHaveValidationErrorFor(request => request.Name, new CheckWidgetZoneExistsByNameRequest
            {
                Name = name
            });
        }

        [Fact]
        public void ValidName_ShouldPassValidation()
        {
            var validRequest = new CheckWidgetZoneExistsByNameRequest
            {
                Name = "Valid Name"
            };

            _validator.ShouldNotHaveValidationErrorFor(request => request.Name, validRequest);
        }
    }
}