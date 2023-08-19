using CloudSuite.Modules.Application.Handlers.Core.Cities;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Cities
{
  public class CreateCityCommandValidation : AbstractValidator<CreateCityCommand>
  {
    public CreateCityCommandValidation()
    {
      RuleFor(request => request.CityName)
      .NotEmpty()
      .WithMessage("CityName deve ser preenchida")
      .MaximumLength(50)
      .WithMessage("CityName muito longo, deve conter até 50 caracteres");

      RuleFor(command => command.State)
      .NotEmpty()
      .WithMessage("State deve ser preenchida");
    }
  }
}