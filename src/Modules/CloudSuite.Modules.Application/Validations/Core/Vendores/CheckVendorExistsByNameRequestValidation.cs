using CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Vendores
{
  public class CheckVendorExistsByNameRequestValidation : AbstractValidator<CheckVendorExistsByNameRequest>
  {
    public CheckVendorExistsByNameRequestValidation()        
    {
      RuleFor(request => request.Name)
      .NotEmpty()
      .WithMessage("Nome do fornecedor deve ser preenchido.")
      .MaximumLength(450)
      .WithMessage("Nome deve conter no máximo 450 caracteres.");
    }
  }
}