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
            .WithMessage("Descrição deve ser preenchida")
            .MaximumLength(100)
            .WithMessage("A descrição deve conter no máximo 100 caracteres");
        }
    }
}