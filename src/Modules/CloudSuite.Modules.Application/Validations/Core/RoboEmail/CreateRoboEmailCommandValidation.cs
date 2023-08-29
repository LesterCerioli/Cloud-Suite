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
      .MaximumLength(100)
      .WithMessage("Remetente do endereço de e-mail deve conter no máximo 100 caracteres");

      RuleFor(command => command.Subject)
      .NotEmpty()
      .WithMessage("Assunto deve ser preenchida")
      .MaximumLength(10)
      .WithMessage("Assunto deve conter no máximo 10 caracteres");

      RuleFor(command => command.Body)
      .NotEmpty()
      .WithMessage("Menssagem deve ser preenchida")
      .MinimumLength(3)
      .WithMessage("Menssagem deve conter no máximo 100 caracteres");

      
      RuleFor(command => command.MessageRecipient)
      .NotEmpty()
      .WithMessage("Destinatáriorio deve ser preenchida")
      .MinimumLength(100)
      .WithMessage("Destinatário deve conter no máximo 100 caracteres");
    }
  }
}