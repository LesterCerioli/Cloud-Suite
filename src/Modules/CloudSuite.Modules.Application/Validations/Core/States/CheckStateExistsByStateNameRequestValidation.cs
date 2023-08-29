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
      .WithMessage("StateName deve ser preenchido")
      .MinimumLength(3)
      .WithMessage("StateName muito curto, deve conter mais de 3 caracteres");
    }
  }
}