using CloudSuite.Modules.Application.Handlers.Core.Users.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Users
{
  public class CheckUserExistsByEmailRequestValidation : AbstractValidator<CheckUserExistsByEmailRequest>
  {
    public CheckUserExistsByEmailRequestValidation()        
    {
      RuleFor(request => request.Email)
      .NotEmpty()
      .WithMessage("Email deve ser preenchido");
    }
  }
}