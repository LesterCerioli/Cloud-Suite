using CloudSuite.Modules.Application.Handlers.Core.Companies;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Companies
{
  public class CreateCompanyCommandValidation : AbstractValidator<CreateCompanyCommand>
  {
    public CreateCompanyCommandValidation()
    {
      RuleFor(command => command.FantasyName)
      .NotEmpty()
      .WithMessage("Nome fantasia deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("Nome fantasia deve possuir no máximo 100 caracteres");

      RuleFor(command => command.RegisterName)
      .NotEmpty()
      .WithMessage("Nome de registro deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("Nome de registro deve possuir no máximo 100 caracteres");

      RuleFor(command => command.Cnpj)
      .NotEmpty()
      .WithMessage("O CNPJ deve ser preenchido");

      RuleFor(command => command.Address)
      .NotEmpty()
      .WithMessage("O Endereço deve ser preenchido");
    }
  }
}