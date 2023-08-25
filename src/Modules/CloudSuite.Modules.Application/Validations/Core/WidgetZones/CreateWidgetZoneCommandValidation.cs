
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
      .MinimumLength(3)
      .WithMessage("Name muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(30)
      .WithMessage("Name muito longo, deve conter até 30 caracteres");
      
      RuleFor(command => command.Description)
      .NotEmpty()
      .WithMessage("CreateUrl deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("CreateUrl muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(255)
      .WithMessage("CreateUrl muito longo, deve conter até 255 caracteres");

    } 
  }
}