using CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Vendores
{
  public class CheckVendorExistsByCnpjRequestValidation : AbstractValidator<CheckVendorExistsByCnpjRequest>
  {
    public CheckVendorExistsByCnpjRequestValidation()        
    {
      RuleFor(request => request.Cnpj)
      .NotEmpty()
      .WithMessage("Cnpj deve ser preenchido");
    }
  }
}