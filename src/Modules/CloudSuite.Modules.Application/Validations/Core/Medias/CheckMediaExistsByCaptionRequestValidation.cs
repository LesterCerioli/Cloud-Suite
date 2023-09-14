using CloudSuite.Modules.Application.Handlers.Core.Medias.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Medias
{
  public class CheckMediaExistsByCaptionRequestValidation : AbstractValidator<CheckMediaExistsByCaptionRequest>
  {
    public CheckMediaExistsByCaptionRequestValidation()        
    {
      RuleFor(request => request.Caption)
      .NotEmpty()
      .WithMessage("Caption deve ser preenchido")
      .MinimumLength(450)
      .WithMessage("Caption deve conter no máximo 450 caracteres");
    }
  }
}