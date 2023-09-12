using CloudSuite.Modules.Application.Handlers.Core.Medias.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Medias
{
  public class CheckMediaExistsByFileSizeRequestValidation : AbstractValidator<CheckMediaExistsByFileSizeRequest>
  {
    public CheckMediaExistsByFileSizeRequestValidation()        
    {
      RuleFor(command => command.FileSize)
      .NotEmpty()
      .WithMessage("FileSize deve ser preenchido")
      .GreaterThan(0)
      .WithMessage("FileSize deve ser maior que zero");
    }
  }
}