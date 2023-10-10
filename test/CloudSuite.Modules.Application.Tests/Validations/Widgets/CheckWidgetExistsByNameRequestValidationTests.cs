using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using CloudSuite.Modules.Application.Validations.Core.Widgets;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Widgets
{
    public class CheckWidgetExistsByNameRequestValidationTests
    {
        private readonly CheckWidgetExistsByNameRequestValidation _validator;

        public CheckWidgetExistsByNameRequestValidationTests()
        {
            _validator = new CheckWidgetExistsByNameRequestValidation();
        }

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(request => request.Name, new CheckWidgetExistsByNameRequest());
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Name_ShouldNotBeNullOrWhitespace(string name)
        {
            _validator.ShouldHaveValidationErrorFor(request => request.Name, new CheckWidgetExistsByNameRequest
            {
                Name = name
            });
        }

        [Theory]
        [InlineData("Name with more than 450 characters .....................................................................................................................................................................................................................")]
        public void Name_ShouldNotExceedMaxLength(string name)
        {
            _validator.ShouldHaveValidationErrorFor(request => request.Name, new CheckWidgetExistsByNameRequest
            {
                Name = name
            });
        }

        [Fact]
        public void Name_ShouldBeValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(request => request.Name, new CheckWidgetExistsByNameRequest
            {
                Name = "Valid Name"
            });
        }
    }
}