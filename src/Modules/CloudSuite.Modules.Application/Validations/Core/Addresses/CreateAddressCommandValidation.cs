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
      .MaximumLength(450)
      .WithMessage("Endereço deve ser preenchido");

      RuleFor(command => command.ContactName)
      .NotEmpty()
      .MaximumLength(100)
      .WithMessage("Nome do contato deve ser preenchido");
    }
  }
}