using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Widgets
{
  public class CheckWidgetExistsByEditUrlRequestValidation : AbstractValidator<CheckWidgetExistsByEditUrlRequest>
  {
    public CheckWidgetExistsByEditUrlRequestValidation()        
    {
      RuleFor(request => request.EditUrl)
      .NotEmpty()
      .WithMessage("EditUrl deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("EditUrl deve conter no máximo 450 caracteres");
    }
  }
}