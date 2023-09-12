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
      .WithMessage("O nome do País deve ser preenchido");

      RuleFor(command => command.Code3)
      .NotEmpty()
      .MaximumLength(450)
      .WithMessage("Código3 não pode ter mais que 450 caracteres");

          
      
      
    }
  }
}