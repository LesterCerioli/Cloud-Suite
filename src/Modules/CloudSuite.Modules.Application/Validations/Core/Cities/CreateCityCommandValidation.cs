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
      .MaximumLength(100)
      .WithMessage("O nome da cidade deve ser preenchido");

      
    }
  }
  
}