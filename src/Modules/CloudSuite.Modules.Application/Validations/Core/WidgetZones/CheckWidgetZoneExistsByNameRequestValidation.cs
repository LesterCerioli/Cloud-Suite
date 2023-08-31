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
      .MaximumLength(450)
      .WithMessage("Nome deve conter no máximo 450 caracteres");
    }
  }
}