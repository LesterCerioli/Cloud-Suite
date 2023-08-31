using CloudSuite.Modules.Application.Handlers.Core.Users;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Users
{
  public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
  {
    public CreateUserCommandValidation()
    {
      RuleFor(command => command.FullName)
      .NotEmpty()
      .WithMessage("O nome completo deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("O nome completo deve conter no máximo 450 caracteres");
      

      RuleFor(command => command.Email)
      .NotEmpty()
      .WithMessage("Email deve ser preenchido");


      RuleFor(command => command.Cpf)
      .NotEmpty()
      .WithMessage("Cpf deve ser preenchido");

      RuleFor(command => command.Vendor)
      .NotEmpty()
      .WithMessage("Fornecedor deve ser preenchido");

      

      
      
      

      

      
    }          
  }
}