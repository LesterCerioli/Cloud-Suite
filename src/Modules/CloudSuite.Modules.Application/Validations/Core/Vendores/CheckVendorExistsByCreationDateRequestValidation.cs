using CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Vendores
{
  public class CheckVendorExistsByCreationDateRequestValidation : AbstractValidator<CheckVendorExistsByCreationDateRequest>
  {
    public CheckVendorExistsByCreationDateRequestValidation()        
    {
      RuleFor(request => request.CreatedOn)
      .NotEmpty().WithMessage("CreatedOn deve ser preenchido")
      .Must(date => date != default(DateTimeOffset)).WithMessage("CreatedOn deve ser uma data/hora válida");
    }
  }
}