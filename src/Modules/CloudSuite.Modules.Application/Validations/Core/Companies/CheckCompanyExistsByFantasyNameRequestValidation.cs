using CloudSuite.Modules.Application.Handlers.Core.Companies.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Companies
{
  public class CheckCompanyExistsByFantasyNameRequestValidation : AbstractValidator<CheckCompanyExistsByFantasyNameRequest>
  {
    public CheckCompanyExistsByFantasyNameRequestValidation()
    {
      RuleFor(request => request.FantasyName)
      .NotEmpty()
      .WithMessage("Nome fantasia deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("Nome fantasia deve possuir no máximo 100 caracteres");
    }
  }
}