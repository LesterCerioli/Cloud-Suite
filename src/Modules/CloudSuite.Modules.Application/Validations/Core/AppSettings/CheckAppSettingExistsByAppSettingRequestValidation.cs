using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.AppSettings
{
  public class CheckAppSettingExistsByAppSettingRequestValidation : AbstractValidator<CheckAppSettingExistsByAppSettingRequest>
  {
    public CheckAppSettingExistsByAppSettingRequestValidation()
    {
      RuleFor(request => request.Value)
      .NotEmpty()
      .WithMessage("O valor de AppSetting deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("O valor de AppSetting deve possuir no máximo 450 caracteres");
    }
  }
}