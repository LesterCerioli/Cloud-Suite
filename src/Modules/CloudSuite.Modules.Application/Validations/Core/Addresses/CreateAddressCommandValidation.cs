using CloudSuite.Modules.Application.Handlers.Core.Addresses;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Addresses
{
  public class CreateAddressCommandValidation : AbstractValidator<CreateAddressCommand>
  {
    public CreateAddressCommandValidation()
    {
      RuleFor(command => command.AddressLine1)
      .NotEmpty()
      .MaximumLength(50)
      .WithMessage("AddressLine1 deve ser preenchida");

      RuleFor(command => command.ContactName)
      .NotEmpty()
      .WithMessage("ContactName deve ser preenchida");
    }
  }
  
}