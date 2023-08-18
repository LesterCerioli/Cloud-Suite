using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.RoboEmail
{
    public class CheckRoboEmailExistsByMessageRecipientRequestValidation : AbstractValidator<CheckRoboEmailExistsByMessageRecipientRequest>
    {
        public CheckRoboEmailExistsByMessageRecipientRequestValidation()        
        {
            RuleFor(command => command.MessageRecipient)
            .NotEmpty()
            .WithMessage("Destinario deve ser preenchida")
            .MinimumLength(3)
            .WithMessage("Destinario muito curto, deve conter mais de 3 caracteres");
        }
    }
}