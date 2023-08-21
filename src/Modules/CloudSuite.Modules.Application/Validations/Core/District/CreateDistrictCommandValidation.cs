using CloudSuite.Modules.Application.Handlers.Core.Districts;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.District
{
  public class CreateDistrictCommandValidation : AbstractValidator<CreateDistrictCommand>
  {
    public CreateDistrictCommandValidation()        
    {
      RuleFor(command => command.Name)
      .NotEmpty()
      .WithMessage("Name deve ser preenchida")
      .MinimumLength(3)
      .WithMessage("Name muito curto");

      RuleFor(command => command.Type)
      .NotEmpty()
      .WithMessage("Type deve ser preenchida")
      .MinimumLength(3)
      .WithMessage("Type muito curto");

      RuleFor(command => command.Location)
      .NotEmpty()
      .WithMessage("Location deve ser preenchida")
      .MinimumLength(3)
      .WithMessage("Location muito curto");
    }
  }
}