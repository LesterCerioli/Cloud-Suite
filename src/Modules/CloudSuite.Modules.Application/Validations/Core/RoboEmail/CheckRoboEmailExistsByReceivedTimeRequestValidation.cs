using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.RoboEmail
{
    public class CheckRoboEmailExistsByReceivedTimeRequestValidation : AbstractValidator<CheckRoboEmailExistsByReceivedTimeRequest>
    {
        public CheckRoboEmailExistsByReceivedTimeRequestValidation()        
        {
            RuleFor(request => request.ReceivedTime)
            .NotEmpty()
            .WithMessage("ReceivedTime deve ser preenchida");
        }
    }
}