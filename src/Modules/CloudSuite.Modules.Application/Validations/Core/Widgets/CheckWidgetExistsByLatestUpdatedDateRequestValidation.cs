using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Widgets
{
  public class CheckWidgetExistsByLatestUpdatedDateRequestValidation : AbstractValidator<CheckWidgetExistsByLatestUpdatedDateRequest>
  {
    public CheckWidgetExistsByLatestUpdatedDateRequestValidation()        
    {
      RuleFor(request => request.LatestUpdatedOn)
      .NotEmpty()
      .WithMessage("LatestUpdatedOn deve ser preenchido")
      .Must(date => date != default(DateTimeOffset)).WithMessage("LatestUpdatedOn deve ser uma data/hora válida");
    }
  }
}