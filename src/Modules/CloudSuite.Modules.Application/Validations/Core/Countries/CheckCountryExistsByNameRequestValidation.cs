using CloudSuite.Modules.Application.Handlers.Core.Countries.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Countries
{
  public class CheckCountryExistsByNameRequestValidation : AbstractValidator<CheckCountryExistsByNameRequest>
  {
    public CheckCountryExistsByNameRequestValidation()
    {
      RuleFor(request => request.CountryName)
      .NotEmpty()
      .WithMessage("CountryName deve ser preenchida")
      .MaximumLength(50)
      .WithMessage("CountryName muito longo, deve conter até 50 caracteres");
    }
  }
}