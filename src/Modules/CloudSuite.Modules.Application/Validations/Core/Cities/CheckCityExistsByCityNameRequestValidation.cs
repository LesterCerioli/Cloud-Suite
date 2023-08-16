using CloudSuite.Modules.Application.Handlers.Core.Cities.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Cities
{
  public class CheckCityExistsByCityNameRequestValidation : AbstractValidator<CheckCityExistsByCityNameRequest>
  {
    public CheckCityExistsByCityNameRequestValidation()
    {
      RuleFor(command => command.CityName)
      .NotEmpty()
      .MaximumLength(50)
      .WithMessage("CityName deve ser preenchida");
    }
  }
  
}