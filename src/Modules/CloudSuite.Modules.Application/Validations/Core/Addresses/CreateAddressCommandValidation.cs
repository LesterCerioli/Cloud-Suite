using CloudSuite.Modules.Application.Handlers.Core.Addresses;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Addresses
{
  public class CreateAddressCommandValidation : AbstractValidator<CreateAddressCommand>
  {
    public CreateAddressCommandValidation()
    {
      RuleFor(a => a.AddressLine1)
      .NotEmpty()
      .MaximumLength(50)
      .WithMessage("AddressLine1 deve ser preenchida");

      RuleFor(a => a.ContactName)
      .NotEmpty()
      .WithMessage("ContactName deve ser preenchida");
    }
  }
  
}