using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using CloudSuite.Modules.Application.Validations.Core.Widgets;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.Widgets
{
    public class CheckWidgetExistsByEditUrlRequestValidationTests
    {
        private readonly CheckWidgetExistsByEditUrlRequestValidation _validator;

        public CheckWidgetExistsByEditUrlRequestValidationTests()
        {
            _validator = new CheckWidgetExistsByEditUrlRequestValidation();
        }

        [Fact]
        public void EditUrl_ShouldNotBeEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(request => request.EditUrl, new CheckWidgetExistsByEditUrlRequest());
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void EditUrl_ShouldNotBeNullOrWhitespace(string editUrl)
        {
            _validator.ShouldHaveValidationErrorFor(request => request.EditUrl, new CheckWidgetExistsByEditUrlRequest
            {
                EditUrl = editUrl
            });
        }

        [Theory]
        [InlineData("https://example.com/very/long/url/that/is/more/than/450/characters/in/length")]
        public void EditUrl_ShouldNotExceedMaxLength(string editUrl)
        {
            _validator.ShouldHaveValidationErrorFor(request => request.EditUrl, new CheckWidgetExistsByEditUrlRequest
            {
                EditUrl = editUrl
            });
        }

        [Fact]
        public void EditUrl_ShouldBeValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(request => request.EditUrl, new CheckWidgetExistsByEditUrlRequest
            {
                EditUrl = "https://example.com"
            });
        }
    }
}