using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.WidgetZones
{
  public class CheckWidgetZoneExistsByDescriptionRequestValidation : AbstractValidator<CheckWidgetZoneExistsByDescriptionRequest>
  {
    public CheckWidgetZoneExistsByDescriptionRequestValidation()        
    {
      RuleFor(request => request.Description)
      .NotEmpty()
      .WithMessage("CreateUrl deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("CreateUrl muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(255)
      .WithMessage("CreateUrl muito longo, deve conter até 255 caracteres");
    }
  }
}