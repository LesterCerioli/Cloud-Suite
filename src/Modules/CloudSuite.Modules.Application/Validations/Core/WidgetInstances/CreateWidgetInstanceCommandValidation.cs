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

      RuleFor(Command => Command.WidgetId)
      .NotEmpty()
      .WithMessage("WidgetId deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("WidgetId deve conter no máximo 450 caracteres");

      RuleFor(Command => Command.Data)
      .NotEmpty()
      .WithMessage("Dados deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("Dados deve conter no máximo 100 caracteres");

      RuleFor(Command => Command.HtmlData)
      .NotEmpty()
      .WithMessage("DadosHtml deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("DadosHtml deve conter no máximo 100 caracteres");

      RuleFor(Command => Command.DisplayOrder)
      .NotEmpty()
      .WithMessage("DisplayOrder deve ser preenchido");
    }
  }
}