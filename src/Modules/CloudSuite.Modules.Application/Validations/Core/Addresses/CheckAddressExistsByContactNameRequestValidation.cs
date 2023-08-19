using CloudSuite.Modules.Application.Handlers.Core.Addresses.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Addresses
{
  public class CheckAddressExistsByContactNameRequestValidation : AbstractValidator<CheckAddressExistsByContactNameRequest>
  {
    public CheckAddressExistsByContactNameRequestValidation()
    {
      RuleFor(request => request.ContactName)
      .NotEmpty()
      .WithMessage("ContactName deve ser preenchida")
      .MinimumLength(50)
      .WithMessage("ContactName muito longo, deve conter até 50 caracteres");
    }
  }
}