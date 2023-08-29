using CloudSuite.Modules.Application.Handlers.Core.Users.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Users
{
  public class CheckUserExistsByCpfRequestValidation : AbstractValidator<CheckUserExistsByCpfRequest>
  {
    public CheckUserExistsByCpfRequestValidation()        
    {
      RuleFor(request => request.Cpf)
      .NotEmpty()
      .WithMessage("Cpf deve ser preenchido");
    }
  }
}