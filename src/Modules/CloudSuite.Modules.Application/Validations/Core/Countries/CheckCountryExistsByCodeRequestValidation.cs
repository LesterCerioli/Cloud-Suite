using CloudSuite.Modules.Application.Handlers.Core.Countries.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Countries
{
  public class CheckCountryExistsByCodeRequestValidation : AbstractValidator<CheckCountryExistsByCodeRequest>
  {
    public CheckCountryExistsByCodeRequestValidation()
    {
     RuleFor(request => request.Code3)
      .NotEmpty()
      .WithMessage("Code3 deve ser preenchida")
      .MaximumLength(3)
      .WithMessage("Code3 muito curto, não deve conter mais de 3 caracteres");
    }
  }
}