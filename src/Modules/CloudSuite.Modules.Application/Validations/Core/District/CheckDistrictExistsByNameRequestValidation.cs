using CloudSuite.Modules.Application.Handlers.Core.Districts.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.District
{
    public class CheckDistrictExistsByNameRequestValidation : AbstractValidator<CheckDistrictExistsByNameRequest>
    {
        public CheckDistrictExistsByNameRequestValidation()        
        {
            RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Nome do Bairro deve ser preenchido")
            .MaximumLength(450)
            .WithMessage("Nome do Bairro deve possuir no máximo 450 caracteres");
        }
    }
}