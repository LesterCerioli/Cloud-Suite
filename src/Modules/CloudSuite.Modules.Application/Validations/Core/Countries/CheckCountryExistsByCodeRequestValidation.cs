using CloudSuite.Modules.Application.Handlers.Core.Countries.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Countries
{
  public class CheckCountryExistsByCodeRequestValidation : AbstractValidator<CheckCountryExistsByCodeRequest>
  {
    public CheckCountryExistsByCodeRequestValidation()
    {
     RuleFor(command => command.Code3)
      .NotEmpty()
      .WithMessage("O código deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("O código não deve possuir mais que 450 caracteres");
    }
  }
  
}