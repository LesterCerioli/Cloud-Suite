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
      .WithMessage("Name deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("Name muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(30)
      .WithMessage("Name muito longo, deve conter até 30 caracteres");
      
      RuleFor(command => command.Slug)
      .NotEmpty()
      .WithMessage("Slug deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("Slug muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(30)
      .WithMessage("Slug muito longo, deve conter até 30 caracteres");;

      RuleFor(command => command.Description)
      .NotEmpty()
      .WithMessage("Description deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("Description muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(255)
      .WithMessage("Description muito longo, deve conter até 255 caracteres");

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