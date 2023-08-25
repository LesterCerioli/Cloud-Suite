using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Widgets
{
  public class CheckWidgetExistsByCreationDateRequestValidation : AbstractValidator<CheckWidgetExistsByCreationDateRequest>
  {
    public CheckWidgetExistsByCreationDateRequestValidation()        
    {
      RuleFor(request => request.CreatedOn)
      .NotEmpty()
      .WithMessage("CreatedOn deve ser preenchido")
      .Must(date => date != default(DateTimeOffset))
      .WithMessage("CreatedOn deve ser uma data/hora válida");
    }
  }
}