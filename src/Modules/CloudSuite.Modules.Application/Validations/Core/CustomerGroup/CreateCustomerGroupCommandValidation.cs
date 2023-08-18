using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.CustomerGroups
{
  public class CreateCustomerGroupCommandValidation : AbstractValidator<CreateCustomerGroupCommand>
  {
    public CreateCustomerGroupCommandValidation()
    {
        RuleFor(command => command.Name)
        .NotEmpty()
        .WithMessage("Name deve ser preenchida")
        .MaximumLength(50)
        .WithMessage("Name muito longo, deve conter até 50 caracteres");

        RuleFor(command => command.Description)
        .NotEmpty()
        .WithMessage("Description deve ser preenchida")
        .MaximumLength(255)
        .WithMessage("Description muito longo, deve conter até 255 caracteres");

        RuleFor(command => command.IsActive)
        .NotNull()
        .NotEmpty()
        .WithMessage("IsActive deve ser especificado");

        RuleFor(command => command.IsDeleted)
        .NotNull()
        .NotEmpty()
        .WithMessage("IsDeleted deve ser especificado");

        RuleFor(command => command.CreatedOn)
        .NotNull()
        .WithMessage("CreatedOn deve ser especificado")
        .Must(date => date.HasValue && date.Value != default(DateTimeOffset))
        .WithMessage("CreatedOn deve ser uma data válida");

        RuleFor(command => command.LatestUpdatedOn)
        .NotNull()
        .WithMessage("LatestUpdatedOn deve ser especificado")
        .Must(date => date.HasValue && date.Value != default(DateTimeOffset))
        .WithMessage("LatestUpdatedOn deve ser uma data válida");
    }
  }
}