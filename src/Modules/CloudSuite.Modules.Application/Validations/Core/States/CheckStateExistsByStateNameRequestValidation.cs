using CloudSuite.Modules.Application.Handlers.Core.States.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.States
{
  public class CheckStateExistsByStateNameRequestValidation : AbstractValidator<CheckStateExistsByStateNameRequest>
  {
    public CheckStateExistsByStateNameRequestValidation()        
    {
      RuleFor(request => request.StateName)
      .NotEmpty()
      .WithMessage("Nome do Estado deve ser preenchido")
      .MaximumLength(100)
      .WithMessage("Nome do Estado deve conter no máximo 100 caracteres");
    }
  }
}