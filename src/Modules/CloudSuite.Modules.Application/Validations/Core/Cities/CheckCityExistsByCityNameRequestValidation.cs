using CloudSuite.Modules.Application.Handlers.Core.Cities.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Cities
{
  public class CheckCityExistsByCityNameRequestValidation : AbstractValidator<CheckCityExistsByCityNameRequest>
  {
    public CheckCityExistsByCityNameRequestValidation()
    {
      RuleFor(request => request.CityName)
      .NotEmpty()
      .WithMessage("CityName deve ser preenchida")
      .MaximumLength(50)
      .WithMessage("CityName muito longo, deve conter até 50 caracteres");
    }
  }
}