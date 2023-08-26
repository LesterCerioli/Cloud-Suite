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
      .WithMessage("O NOME deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("NOME muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(450)
      .WithMessage("NOME muito longo, deve conter até 450 caracteres");
      

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