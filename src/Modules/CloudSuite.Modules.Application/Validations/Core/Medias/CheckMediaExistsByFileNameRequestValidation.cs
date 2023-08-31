using CloudSuite.Modules.Application.Handlers.Core.Medias.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Medias
{
  public class CheckMediaExistsByFileNameRequestValidation : AbstractValidator<CheckMediaExistsByFileNameRequest>
  {
    public CheckMediaExistsByFileNameRequestValidation()        
    {
      RuleFor(request => request.FileName)
      .NotEmpty()
      .WithMessage("FileName deve ser preenchida")
      .MinimumLength(450)
      .WithMessage("FileName deve conter no máximo 450 caracteres");
    }
  }
}