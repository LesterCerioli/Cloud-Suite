using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.RoboEmail
{
    public class CheckRoboEmailExistsBySubjectRequestValidation : AbstractValidator<CheckRoboEmailExistsBySubjectRequest>
    {
        public CheckRoboEmailExistsBySubjectRequestValidation()        
        {
            RuleFor(command => command.Subject)
            .NotEmpty()
            .WithMessage("Assunto deve ser preenchida")
            .MaximumLength(10)
            .WithMessage("Assunto deve conter no máximo 10 caracteres");
        }
    }
}