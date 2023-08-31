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
      .WithMessage("Nome deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("Nome deve conter no máximo 450 caracteres");
      
      RuleFor(command => command.ViewComponentName)
      .NotEmpty()
      .WithMessage("ViewComponentName deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("Nome deve conter no máximo 450 caracteres");

      RuleFor(command => command.CreateUrl)
      .NotEmpty()
      .WithMessage("CreateUrl deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("CreateUrl deve conter no máximo 450 caracteres");

      RuleFor(command => command.EditUrl)
      .NotEmpty()
      .WithMessage("EditUrl deve ser preenchido")
      .MaximumLength(450)
      .WithMessage("EditUrl deve conter no máximo 450 caracteres");

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