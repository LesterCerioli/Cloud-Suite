using CloudSuite.Modules.Application.Handlers.Token.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Token
{
  public class SendTokenRequestValidation : AbstractValidator<SendTokenRequest>
  {
    public SendTokenRequestValidation()
    {
      RuleFor(command => command.FullName)
      .NotEmpty()
      .WithMessage("Nome completo deve ser preenchido")
      .MaximumLength(40)
      .WithMessage("Nome completo deve conter 40 caracteres");

      RuleFor(command => command.PhoneRegion)
      .NotEmpty()
      .WithMessage("DDD deve ser preenchido")
      .MaximumLength(2)
      .WithMessage("DDD deve conter 2 caracteres");

      RuleFor(command => command.PhoneNumber)
      .NotEmpty()
      .WithMessage("Telefone deve ser preenchido")
      .MaximumLength(13)
      .WithMessage("Telefone deve conter 13 caracteres");
    }
  }
}