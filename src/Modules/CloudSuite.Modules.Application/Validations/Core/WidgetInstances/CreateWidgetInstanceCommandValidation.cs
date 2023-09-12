using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.WidgetInstances
{
  public class CreateWidgetInstanceCommandValidation : AbstractValidator<CreateWidgetInstanceCommand>
  {
    public CreateWidgetInstanceCommandValidation()
    {
      RuleFor(Command => Command.Name)
      .NotEmpty()
      .WithMessage("Nome deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("Nome deve conter no máximo 450 caracteres");
    }
  }
}