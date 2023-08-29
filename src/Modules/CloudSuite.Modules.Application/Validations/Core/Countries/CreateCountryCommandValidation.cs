using CloudSuite.Modules.Application.Handlers.Core.Countries;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Countries
{
  public class CreateCountryCommandValidation : AbstractValidator<CreateCountryCommand>
  {
    public CreateCountryCommandValidation()
    {
      RuleFor(command => command.CountryName)
      .NotEmpty()
      .MaximumLength(450)
      .WithMessage("O nome do País deve ser preenchida");

      RuleFor(command => command.Code3)
      .NotEmpty()
      .MaximumLength(3)
      .WithMessage("Code3 não pode ter mais de 3 letras");

          
      
      
    }
  }
}