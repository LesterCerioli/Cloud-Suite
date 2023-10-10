using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using CloudSuite.Modules.Application.Validations.Core.Widgets;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Widgets
{
    public class CheckWidgetExistsByLatestUpdatedDateRequestValidationTests
    {
         private readonly CheckWidgetExistsByLatestUpdatedDateRequestValidation _validator;

        public CheckWidgetExistsByLatestUpdatedDateRequestValidationTests()
        {
            _validator = new CheckWidgetExistsByLatestUpdatedDateRequestValidation();
        }

        [Fact]
        public void CreateUrl_ShouldNotBeEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(request => request.CreateUrl, new CheckWidgetExistsByLatestUpdatedDateRequest());
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void CreateUrl_ShouldNotBeNullOrWhitespace(string createUrl)
        {
            _validator.ShouldHaveValidationErrorFor(request => request.CreateUrl, new CheckWidgetExistsByLatestUpdatedDateRequest
            {
                CreateUrl = createUrl
            });
        }

        [Theory]
        [InlineData("https://example.com/very/long/url/that/is/more/than/450/characters/in/length")]
        public void CreateUrl_ShouldNotExceedMaxLength(string createUrl)
        {
            _validator.ShouldHaveValidationErrorFor(request => request.CreateUrl, new CheckWidgetExistsByLatestUpdatedDateRequest
            {
                CreateUrl = createUrl
            });
        }

        [Fact]
        public void CreateUrl_ShouldBeValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(request => request.CreateUrl, new CheckWidgetExistsByLatestUpdatedDateRequest
            {
                CreateUrl = "https://example.com"
            });
        }
    }
}