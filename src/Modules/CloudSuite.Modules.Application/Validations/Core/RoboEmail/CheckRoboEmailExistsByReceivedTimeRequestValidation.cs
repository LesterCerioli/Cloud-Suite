using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.RoboEmail
{
    public class CheckRoboEmailExistsByReceivedTimeRequestValidation : AbstractValidator<CheckRoboEmailExistsByReceivedTimeRequest>
    {
        public CheckRoboEmailExistsByReceivedTimeRequestValidation()        
        {
            RuleFor(command => command.ReceivedTime)
            .NotEmpty()
            .WithMessage("Horas de recebimento deve ser preenchida");
        }
    }
}