using CloudSuite.Modules.Application.Handlers.Core.Districts.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.District
{
    public class CheckDistrictExistsByNameRequestValidation : AbstractValidator<CheckDistrictExistsByNameRequest>
    {
        public CheckDistrictExistsByNameRequestValidation()        
        {
            RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage("Name deve ser preenchida")
            .MinimumLength(3)
            .WithMessage("Name muito curto");
        }
    }
}