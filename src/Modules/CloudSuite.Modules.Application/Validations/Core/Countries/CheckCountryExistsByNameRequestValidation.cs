using CloudSuite.Modules.Application.Handlers.Core.Countries.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Countries
{
  public class CheckCountryExistsByNameRequestValidation : AbstractValidator<CheckCountryExistsByNameRequest>
  {
    public CheckCountryExistsByNameRequestValidation()
    {
      RuleFor(command => command.CountryName)
      .NotEmpty()
      .MaximumLength(50)
      .WithMessage("CountryName deve ser preenchida");
    }
  }
}