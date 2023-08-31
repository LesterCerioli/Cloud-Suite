
using CloudSuite.Modules.Application.Handlers.Core.WidgetZones;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.WidgetZones
{
  public class CreateWidgetZoneCommandValidation : AbstractValidator<CreateWidgetZoneCommand>
  {
     public CreateWidgetZoneCommandValidation()
    {
      RuleFor(command => command.Name)
      .NotEmpty()
      .WithMessage("Name deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("Nome deve conter no máximo 450 caracteres");

      RuleFor(command => command.Description)
      .NotEmpty()
      .WithMessage("CreateUrl deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("CreateUrl deve conter no máximo 450 caracteres");

     } 
  }
}