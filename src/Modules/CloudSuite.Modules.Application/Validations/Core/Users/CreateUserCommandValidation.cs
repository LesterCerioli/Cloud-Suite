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
      .WithMessage("FullName deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("FullName muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(30)
      .WithMessage("FullName muito longo, deve conter até 30 caracteres");
      

      RuleFor(command => command.Email)
      .NotEmpty()
      .WithMessage("Email deve ser preenchido");


      RuleFor(command => command.Cpf)
      .NotEmpty()
      .WithMessage("Cpf deve ser preenchido");

      RuleFor(command => command.Vendor)
      .NotEmpty()
      .WithMessage("Vendor deve ser preenchido");

      RuleFor(command => command.IsDeleted)
      .NotNull()
      .WithMessage("IsDeleted deve ser preenchido");

      RuleFor(command => command.CreatedOn)
      .NotEmpty().WithMessage("CreatedOn deve ser preenchido")
      .Must(date => date != default(DateTimeOffset)).WithMessage("CreatedOn deve ser uma data/hora válida");
      
      RuleFor(command => command.LatestUpdatedOn)
      .NotEmpty().WithMessage("LatestUpdatedOn deve ser preenchido")
      .Must(date => date != default(DateTimeOffset)).WithMessage("LatestUpdatedOn deve ser uma data/hora válida");

      RuleFor(command => command.Culture)
      .NotEmpty()
      .WithMessage("Culture deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("Culture muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(50)
      .WithMessage("Culture muito longo, deve conter até 50 caracteres");

      RuleFor(command => command.ExtensionData)
      .NotEmpty()
      .WithMessage("ExtensionData deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("ExtensionData muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(50)
      .WithMessage("ExtensionData muito longo, deve conter até 50 caracteres");
    }          
  }
}