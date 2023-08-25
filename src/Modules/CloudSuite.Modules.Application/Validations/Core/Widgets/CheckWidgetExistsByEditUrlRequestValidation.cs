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
      .MinimumLength(3)
      .WithMessage("EditUrl muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(255)
      .WithMessage("EditUrl muito longo, deve conter até 255 caracteres");
    }
  }
}