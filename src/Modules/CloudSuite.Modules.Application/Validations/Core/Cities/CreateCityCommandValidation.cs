using CloudSuite.Modules.Application.Handlers.Core.Cities;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Cities
{
  public class CreateCityCommandValidation : AbstractValidator<CreateCityCommand>
  {
    public CreateCityCommandValidation()
    {
      RuleFor(command => command.CityName)
      .NotEmpty()
      .MaximumLength(50)
      .WithMessage("CityName deve ser preenchida");

      RuleFor(command => command.State)
      .NotEmpty()
      .WithMessage("State deve ser preenchida");
    }
  }
  
}