using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.WidgetInstances
{
  public class CheckWidgetInstanceExistsByDataRequestValidation : AbstractValidator<CheckWidgetInstanceExistsByDataRequest>
  {
    public CheckWidgetInstanceExistsByDataRequestValidation()
    {
      RuleFor(request => request.Data)
      .NotEmpty()
      .WithMessage("Dados deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("Dados deve conter no máximo 450 caracteres");
    }
  }
}