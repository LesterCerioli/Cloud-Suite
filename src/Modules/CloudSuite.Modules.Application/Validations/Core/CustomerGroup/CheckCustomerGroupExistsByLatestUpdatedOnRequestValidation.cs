using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.CustomerGroups
{
  public class CheckCustomerGroupExistsByLatestUpdatedOnRequestValidation : AbstractValidator<CheckCustomerGroupExistsByLatestUpdatedOnRequest>
  {
    public CheckCustomerGroupExistsByLatestUpdatedOnRequestValidation()
    {
      RuleFor(request => request.LatestUpdatedOn)
      .NotEmpty()
      .WithMessage("LatestUpdatedOn deve ser especificado")
      .Must(date => date != default)
      .WithMessage("LatestUpdatedOn deve ser uma data válida");
    }
  }
}