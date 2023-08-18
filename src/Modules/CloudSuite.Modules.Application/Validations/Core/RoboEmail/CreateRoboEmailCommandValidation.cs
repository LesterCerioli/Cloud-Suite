using CloudSuite.Modules.Application.Handlers.Core.RoboEmails;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.RoboEmail
{
    public class CreateRoboEmailCommandValidation : AbstractValidator<CreateRoboEmailCommand>
    {
        public CreateRoboEmailCommandValidation()        
        {
            RuleFor(command => command.EmailAddressSender)
            .NotEmpty()
            .WithMessage("Remetente do endereço de e-mail deve ser preenchida")
            .MinimumLength(3)
            .WithMessage("Remetente do endereço de e-mail muito curto, deve conter mais de 3 caracteres");

            RuleFor(command => command.Subject)
            .NotEmpty()
            .WithMessage("Assunto deve ser preenchida")
            .MinimumLength(3)
            .WithMessage("Assunto muito curto, deve conter mais de 3 caracteres");

            RuleFor(command => command.Body)
            .NotEmpty()
            .WithMessage("Menssagem deve ser preenchida")
            .MinimumLength(3)
            .WithMessage("Menssagem muito curta, deve conter mais de 3 caracteres");

            RuleFor(command => command.ReceivedTime)
            .NotEmpty()
            .WithMessage("ReceivedTime deve ser preenchida");

            RuleFor(command => command.MessageRecipient)
            .NotEmpty()
            .WithMessage("Destinario deve ser preenchida")
            .MinimumLength(3)
            .WithMessage("Destinario muito curto, deve conter mais de 3 caracteres");
        }
    }
}