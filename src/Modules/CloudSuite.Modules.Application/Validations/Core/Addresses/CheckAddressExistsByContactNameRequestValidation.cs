using CloudSuite.Modules.Application.Handlers.Core.Addresses.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Addresses
{
  public class CheckAddressExistsByContactNameRequestValidation : AbstractValidator<CheckAddressExistsByContactNameRequest>
  {
    public CheckAddressExistsByContactNameRequestValidation()
    {
      RuleFor(command => command.ContactName)
      .NotEmpty()
      .MaximumLength(100)
      .WithMessage("Nome do Contato deve ser preenchido");
    }
  }
  
}