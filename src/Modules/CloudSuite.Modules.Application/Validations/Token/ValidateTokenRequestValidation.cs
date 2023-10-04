using CloudSuite.Modules.Application.Handlers.Token.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Token
{
  public class ValidateTokenRequestValidation : AbstractValidator<ValidateTokenRequest>
  {
    public ValidateTokenRequestValidation()
    {
      RuleFor(a => a.RequestId)
      .NotEmpty()
      .WithMessage("Id de envio não é válido");

      RuleFor(request => request.Token)
      .NotEmpty()
      .WithMessage("Token deve ser preenchido")
      .MaximumLength(4)
      .WithMessage("Token deve conter 4 caracteres");
    }
  }
}
