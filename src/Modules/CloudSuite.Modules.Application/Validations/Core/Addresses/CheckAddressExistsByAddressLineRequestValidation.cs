using CloudSuite.Modules.Application.Handlers.Core.Addresses.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Addresses
{
  public class CheckAddressExistsByAddressLineRequestValidation : AbstractValidator<CheckAddressExistsByAddressLineRequest>
  {
    public CheckAddressExistsByAddressLineRequestValidation()
    {
      RuleFor(request => request.AddressLine1)
      .NotEmpty()
      .WithMessage("AddressLine1 deve ser preenchida")
      .MaximumLength(50)
      .WithMessage("AddressLine1 muito longa, dete conter até 50 caracteres");
    }
  }
}