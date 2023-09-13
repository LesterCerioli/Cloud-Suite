using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.WidgetInstances
{
  public class CheckWidgetInstanceExistsByDisplayOrderRequestValidation : AbstractValidator<CheckWidgetInstanceExistsByDisplayOrderRequest>
  {
    public CheckWidgetInstanceExistsByDisplayOrderRequestValidation()
    {
      RuleFor(request => request.DisplayOrder)
      .NotEmpty()
      .WithMessage("DisplayOrder deve ser preenchido");
    }
  }
}