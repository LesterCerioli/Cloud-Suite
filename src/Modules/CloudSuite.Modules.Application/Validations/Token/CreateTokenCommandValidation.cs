using CloudSuite.Modules.Application.Handlers.Token;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Token
{
  public class CreateTokenCommandValidation : AbstractValidator<CreateTokenCommand>
  {
    public CreateTokenCommandValidation()
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

      RuleFor(command => command.Phone)
      .NotEmpty()
      .WithMessage("Telefone deve ser preenchido")
      .MaximumLength(13)
      .WithMessage("Telefone deve conter 13 caracteres");

      RuleFor(command => command.Created)
      .NotEmpty()
      .WithMessage("Data de criação deve ser preenchido")
      .Must(date => date != default(DateTimeOffset))
      .WithMessage("Data de criação deve ser uma data válida");

      RuleFor(command => command.Validated)
      .NotEmpty()
      .WithMessage("Validade deve ser preenchido")
      .Must(date => date != default(DateTimeOffset))
      .WithMessage("Validade deve ser uma data válida");

      RuleFor(command => command.Token)
      .NotEmpty()
      .WithMessage("Token deve ser preenchido")
      .MaximumLength(4)
      .WithMessage("Token deve conter 4 caracteres");
    }
  }
}