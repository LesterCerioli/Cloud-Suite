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
            .MinimumLength(3)
            .WithMessage("Assunto muito curto, deve conter mais de 3 caracteres");
        }
    }
}