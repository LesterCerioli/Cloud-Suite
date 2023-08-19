using CloudSuite.Modules.Application.Handlers.Core.Addresses;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Addresses
{
  public class CreateAddressCommandValidation : AbstractValidator<CreateAddressCommand>
  {
    public CreateAddressCommandValidation()
    {
      RuleFor(request => request.AddressLine1)
      .NotEmpty()
      .WithMessage("AddressLine1 deve ser preenchida")
      .MaximumLength(50)
      .WithMessage("AddressLine1 muito longa, dete conter até 50 caracteres");

      RuleFor(request => request.ContactName)
      .NotEmpty()
      .WithMessage("ContactName deve ser preenchida")
      .MinimumLength(50)
      .WithMessage("ContactName muito longo, deve conter até 50 caracteres");
    }
  }
}