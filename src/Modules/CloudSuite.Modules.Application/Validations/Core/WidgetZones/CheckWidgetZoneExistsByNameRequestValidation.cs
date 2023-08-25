using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.WidgetZones
{
  public class CheckWidgetZoneExistsByNameRequestValidation : AbstractValidator<CheckWidgetZoneExistsByNameRequest>
  {
    public CheckWidgetZoneExistsByNameRequestValidation()        
    {
      RuleFor(request => request.Name)
      .NotEmpty()
      .WithMessage("Name deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("Name muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(30)
      .WithMessage("Name muito longo, deve conter até 30 caracteres");
    }
  }
}