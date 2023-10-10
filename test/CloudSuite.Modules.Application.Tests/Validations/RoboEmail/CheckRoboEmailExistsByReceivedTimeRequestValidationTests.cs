using CloudSuite.Modules.Application.Validations.Core.RoboEmail;
using FluentValidation.TestHelper;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Validations.RoboEmail
{
    public class CheckRoboEmailExistsByReceivedTimeRequestValidationTests
    {
        [Fact]
        public void Valid_ReceivedTime_Should_Pass_Validation()
        {
            // Arrange
            var validator = new CheckRoboEmailExistsByReceivedTimeRequestValidation();
            var validRequest = new CheckRoboEmailExistsByReceivedTimeRequest
            {
                ReceivedTime = DateTime.Now 
            };

            // Act & Assert
            validator.ShouldNotHaveValidationErrorFor(request => request.ReceivedTime, validRequest);
        }

        [Fact]
        public void Empty_ReceivedTime_Should_Fail_Validation()
        {
            // Arrange
            var validator = new CheckRoboEmailExistsByReceivedTimeRequestValidation();
            var invalidRequest = new CheckRoboEmailExistsByReceivedTimeRequest
            {
                ReceivedTime = DateTime.MinValue
            };

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(request => request.ReceivedTime, invalidRequest)
                .WithErrorMessage("Horas de recebimento deve ser preenchida");
        }
    }
}