using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.WidgetInstances
{
  public class CheckWidgetInstanceExistsByHtmlDataRequestValidation : AbstractValidator<CheckWidgetInstanceExistsByHtmlDataRequest>
  {
    public CheckWidgetInstanceExistsByHtmlDataRequestValidation()
    {
      RuleFor(request => request.HtmlData)
      .NotEmpty()
      .WithMessage("DadosHtml deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("DadosHtml deve conter no máximo 100 caracteres");
    }
  }
}