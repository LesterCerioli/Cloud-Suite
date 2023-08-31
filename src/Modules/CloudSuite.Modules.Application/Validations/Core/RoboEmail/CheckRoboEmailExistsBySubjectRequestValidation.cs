using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.RoboEmail
{
    public class CheckRoboEmailExistsBySubjectRequestValidation : AbstractValidator<CheckRoboEmailExistsBySubjectRequest>
    {
        public CheckRoboEmailExistsBySubjectRequestValidation()        
        {
            RuleFor(request => request.Subject)
            .NotEmpty()
            .WithMessage("Assunto deve ser preenchido")
            .MaximumLength(10)
            .WithMessage("Assunto deve conter no máximo 10 caracteres");
        }
    }
}