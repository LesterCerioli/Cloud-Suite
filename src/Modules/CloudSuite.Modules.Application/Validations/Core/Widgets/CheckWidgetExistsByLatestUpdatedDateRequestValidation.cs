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
      .MaximumLength(450)
      .WithMessage("CreateUrl deve conter no máximo 450 caracteres");
    }
  }
}