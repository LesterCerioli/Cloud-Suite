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
      .MaximumLength(50)
      .WithMessage("CountryName deve ser preenchida");

      RuleFor(command => command.Code3)
      .NotEmpty()
      .WithMessage("Code3 deve ser preenchida")
      .MaximumLength(3)
      .WithMessage("Code3 não pode ter mais de 3 letras");

      RuleFor(command => command.IsBillingEnabled)
      .NotNull()
      .WithMessage("IsBillingEnabled deve ser especificado");

      RuleFor(command => command.IsShippingEnabled)
      .NotNull()
      .WithMessage("IsShippingEnabled deve ser especificado");

      RuleFor(command => command.IsCityEnabled)
      .NotNull()
      .WithMessage("IsCityEnabled deve ser especificado");

      RuleFor(command => command.IsZipCodeEnabled)
      .NotNull()
      .WithMessage("IsZipCodeEnabled deve ser especificado");

      RuleFor(command => command.IsDistrictEnabled)
      .NotNull()
      .WithMessage("IsDistrictEnabled deve ser especificado");
    }
  }
}