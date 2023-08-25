using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Widgets
{
  public class CheckWidgetExistsByLatestUpdatedDateRequestValidation : AbstractValidator<CheckWidgetExistsByLatestUpdatedDateRequest>
  {
    public CheckWidgetExistsByLatestUpdatedDateRequestValidation()        
    {
      RuleFor(request => request.CreateUrl)
      .NotEmpty()
      .WithMessage("CreateUrl deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("CreateUrl muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(255)
      .WithMessage("CreateUrl muito longo, deve conter até 255 caracteres");
    }
  }
}