using CloudSuite.Modules.Application.Handlers.Core.States;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.States
{
  public class CreateStateCommandValidation : AbstractValidator<CreateStateCommand>
  {
    public CreateStateCommandValidation()
    {
      RuleFor(command => command.StateName)
      .NotEmpty()
      .WithMessage("Nome do Estado deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("Nome do Estado deve conter no máximo 100 caracteres");

      RuleFor(command => command.UF)
      .NotEmpty()
      .WithMessage("UF deve ser preenchido")
      .MaximumLength(2)
      .WithMessage("UF deve conter 2 caracteres");
    }
  }
}