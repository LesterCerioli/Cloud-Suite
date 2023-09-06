using CloudSuite.Modules.Application.Handlers.Token.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Token
{
  public class SendTokenRequestValidation : AbstractValidator<SendTokenRequest>
  {
    public SendTokenRequestValidation()
    {
      RuleFor(request => request.FullName)
      .NotEmpty()
      .WithMessage("Nome completo deve ser preenchido")
      .MaximumLength(40)
      .WithMessage("Nome completo deve conter 40 caracteres");

      RuleFor(request => request.Telephone)
      .NotEmpty()
      .WithMessage("Telephone completo deve ser preenchido");
    }
  }
}