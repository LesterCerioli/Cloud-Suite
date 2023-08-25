using CloudSuite.Modules.Application.Handlers.Core.Widgets;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Widgets
{
  public class CreateWidgetCommandValidation : AbstractValidator<CreateWidgetCommand>
  {
     public CreateWidgetCommandValidation()
    {
      RuleFor(command => command.Name)
      .NotEmpty()
      .WithMessage("Name deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("Name muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(30)
      .WithMessage("Name muito longo, deve conter até 30 caracteres");
      
      RuleFor(command => command.ViewComponentName)
      .NotEmpty()
      .WithMessage("ViewComponentName deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("ViewComponentName muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(30)
      .WithMessage("ViewComponentName muito longo, deve conter até 30 caracteres");;

      RuleFor(command => command.CreateUrl)
      .NotEmpty()
      .WithMessage("CreateUrl deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("CreateUrl muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(255)
      .WithMessage("CreateUrl muito longo, deve conter até 255 caracteres");

      RuleFor(command => command.EditUrl)
      .NotEmpty()
      .WithMessage("EditUrl deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("EditUrl muito curto, deve conter mais de 3 caracteres")
      .MaximumLength(255)
      .WithMessage("EditUrl muito longo, deve conter até 255 caracteres");

      RuleFor(command => command.IsPublished)
      .NotNull()
      .WithMessage("IsPublished deve ser preenchido");

      RuleFor(command => command.CreatedOn)
      .NotEmpty()
      .WithMessage("CreatedOn deve ser preenchido")
      .Must(date => date != default(DateTimeOffset))
      .WithMessage("CreatedOn deve ser uma data/hora válida");

      RuleFor(command => command.LatestUpdatedOn)
      .NotEmpty()
      .WithMessage("LatestUpdatedOn deve ser preenchido")
      .Must(date => date != default(DateTimeOffset))
      .WithMessage("LatestUpdatedOn deve ser uma data/hora válida");
    } 
  }
}