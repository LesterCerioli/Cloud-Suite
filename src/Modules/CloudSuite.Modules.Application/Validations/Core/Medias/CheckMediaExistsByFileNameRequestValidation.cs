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
      .MinimumLength(3)
      .WithMessage("FileName muito curto");
    }
  }
}