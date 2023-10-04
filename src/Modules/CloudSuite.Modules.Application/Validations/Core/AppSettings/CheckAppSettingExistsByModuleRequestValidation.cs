using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.AppSettings
{
  public class CheckAppSettingExistsByModuleRequestValidation : AbstractValidator<CheckAppSettingExistsByModuleRequest>
  {
    public CheckAppSettingExistsByModuleRequestValidation()
    {
      RuleFor(request => request.Module)
      .NotEmpty()
      .WithMessage("Modulo deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("Modulo deve possuir no máximo 450 caracteres");
    }
  }
}