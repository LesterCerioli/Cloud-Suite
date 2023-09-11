using CloudSuite.Modules.Application.Handlers.Core.Companies.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Companies
{
  public class CheckCompanyExistsByRegisterNameRequestValidation : AbstractValidator<CheckCompanyExistsByRegisterNameRequest>
  {
    public CheckCompanyExistsByRegisterNameRequestValidation()
    {
      RuleFor(command => command.RegisterName)
      .NotEmpty()
      .WithMessage("Nome de registro deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("Nome de registro deve possuir no máximo 100 caracteres");
    }
  }
}