using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.CustomerGroups
{
  public class CheckCustomerGroupExistsByCreatedOnRequestValidation : AbstractValidator<CheckCustomerGroupExistsByCreatedOnRequest>
  {
    public CheckCustomerGroupExistsByCreatedOnRequestValidation()
    {
      RuleFor(request => request.CreatedOn)
      .NotEmpty()
      .WithMessage("CreateOn deve ser especificado")
      .Must(date => date != default)
      .WithMessage("CreatedOne deve ser uma data válida");
    }
  }
}