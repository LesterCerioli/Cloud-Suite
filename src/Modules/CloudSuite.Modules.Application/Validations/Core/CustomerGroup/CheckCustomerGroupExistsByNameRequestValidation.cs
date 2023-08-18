using CloudSuite.Modules.Application.Handlers.Core.CustomerGroups.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.CustomerGroups
{
  public class CheckCustomerGroupExistsByNameRequestValidation : AbstractValidator<CheckCustomerGroupExistsByNameRequest>
  {
    public CheckCustomerGroupExistsByNameRequestValidation()
    {
      RuleFor(request => request.Name)
      .NotEmpty()
      .WithMessage("Name deve ser preenchida")
      .MaximumLength(50)
      .WithMessage("Name muito longo, deve conter até 50 caracteres");
    }
  }
}