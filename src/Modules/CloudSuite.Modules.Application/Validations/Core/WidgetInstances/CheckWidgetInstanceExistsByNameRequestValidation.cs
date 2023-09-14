using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.WidgetInstances
{
  public class CheckWidgetInstanceExistsByNameRequestValidation : AbstractValidator<CheckWidgetInstanceExistsByNameRequest>
  {
    public CheckWidgetInstanceExistsByNameRequestValidation()
    {
      RuleFor(request => request.Name)
      .NotEmpty()
      .WithMessage("Nome deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("Nome deve conter no máximo 450 caracteres");
    }
  }
}