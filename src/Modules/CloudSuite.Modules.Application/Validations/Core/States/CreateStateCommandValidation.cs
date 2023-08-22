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
      .WithMessage("StateName deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("StateName muito curto, deve conter mais de 3 caracteres");

      RuleFor(command => command.UF)
      .NotEmpty()
      .WithMessage("UF deve ser preenchido")
      .MaximumLength(2)
      .WithMessage("UF deve conter 2 caracteres");
    }
  }
}