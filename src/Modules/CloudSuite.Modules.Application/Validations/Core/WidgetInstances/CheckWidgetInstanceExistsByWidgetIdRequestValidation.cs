using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.WidgetInstances
{
  public class CheckWidgetInstanceExistsByWidgetIdRequestValidation : AbstractValidator<CheckWidgetInstanceExistsByWidgetIdRequest>
  {
    public CheckWidgetInstanceExistsByWidgetIdRequestValidation()
    {
      RuleFor(request => request.WidgetId)
      .NotEmpty()
      .WithMessage("WidgetId deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("WidgetId deve conter no máximo 450 caracteres");
    }
  }
}