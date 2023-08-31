using CloudSuite.Modules.Application.Handlers.Core.Vendores;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Vendores
{
  public class CreateVendorCommandValidation : AbstractValidator<CreateVendorCommand>
  {
    public CreateVendorCommandValidation()
    {
      RuleFor(command => command.Name)
      .NotEmpty()
      .WithMessage("Nome deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("Nome deve conter no máximo 450 caracteres");
      
      RuleFor(command => command.Slug)
      .NotEmpty()
      .WithMessage("Slug deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("Slug deve conter no máximo 450 caracteres");;

      RuleFor(command => command.Description)
      .NotEmpty()
      .WithMessage("Description deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("Description deve conter no máximo 100 caracteres");

      RuleFor(command => command.Cnpj)
      .NotEmpty()
      .WithMessage("Cnpj deve ser preenchido");

      RuleFor(command => command.Email)
      .NotNull()
      .WithMessage("Email deve ser preenchido");

      RuleFor(command => command.CreatedOn)
      .NotEmpty().WithMessage("CreatedOn deve ser preenchido")
      .Must(date => date != default(DateTimeOffset)).WithMessage("CreatedOn deve ser uma data/hora válida");
      
      RuleFor(command => command.LatestUpdatedOn)
      .NotEmpty().WithMessage("LatestUpdatedOn deve ser preenchido")
      .Must(date => date != default(DateTimeOffset)).WithMessage("LatestUpdatedOn deve ser uma data/hora válida");

      RuleFor(command => command.IsActive)
      .NotNull()
      .WithMessage("IsActive deve ser preenchido");

      RuleFor(command => command.IsDeleted)
      .NotNull()
      .WithMessage("IsDeleted deve ser preenchido");
    } 
  }
}