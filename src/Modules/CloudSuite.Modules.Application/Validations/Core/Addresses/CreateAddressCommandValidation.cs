using CloudSuite.Modules.Application.Handlers.Core.Addresses;
using CloudSuite.Modules.Domain.ValueObjects;
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
      .WithMessage("AddressLine1 is required");

      RuleFor(a => a.City)
      .NotEmpty()
      .WithMessage("City is required");
    }
  }
  
}