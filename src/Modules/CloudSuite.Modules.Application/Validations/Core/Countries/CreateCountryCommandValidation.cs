using CloudSuite.Modules.Application.Handlers.Core.Countries;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Countries
{
  public class CreateCountryCommandValidation : AbstractValidator<CreateCountryCommand>
  {
    public CreateCountryCommandValidation()
    {
      RuleFor(request => request.CountryName)
      .NotEmpty()
      .WithMessage("CountryName deve ser preenchida")
      .MaximumLength(50)
      .WithMessage("CountryName muito longo, deve conter até 50 caracteres");

      RuleFor(request => request.Code3)
      .NotEmpty()
      .WithMessage("Code3 deve ser preenchida")
      .MaximumLength(3)
      .WithMessage("Code3 muito curto, não deve conter mais de 3 caracteres");

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