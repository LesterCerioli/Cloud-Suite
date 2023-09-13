using CloudSuite.Modules.Application.Handlers.Core.AppSettings;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.AppSettings
{
  public class CreateAppSettingCommandValidation : AbstractValidator<CreateAppSettingCommand>
  {
    public CreateAppSettingCommandValidation()
    {
      RuleFor(command => command.Value)
      .NotEmpty()
      .WithMessage("O valor de AppSetting deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("O valor de AppSetting deve possuir no máximo 450 caracteres");

      RuleFor(command => command.Module)
      .NotEmpty()
      .WithMessage("Modulo deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("Modulo deve possuir no máximo 450 caracteres");
    }
  }
}