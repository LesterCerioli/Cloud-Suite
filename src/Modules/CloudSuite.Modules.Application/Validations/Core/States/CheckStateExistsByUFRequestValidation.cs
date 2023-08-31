using CloudSuite.Modules.Application.Handlers.Core.States.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.States
{
  public class CheckStateExistsByUFRequestValidation : AbstractValidator<CheckStateExistsByUFRequest>
  {
    public CheckStateExistsByUFRequestValidation()        
    {
      RuleFor(request => request.UF)
      .NotEmpty()
      .WithMessage("UF deve ser preenchido")
      .MaximumLength(2)
      .WithMessage("UF deve conter 2 caracteres");
    }
  }
}