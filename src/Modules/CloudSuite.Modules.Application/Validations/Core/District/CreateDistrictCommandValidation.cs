using CloudSuite.Modules.Application.Handlers.Core.Districts;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.District
{
    public class CreateDistrictCommandValidation : AbstractValidator<CreateDistrictCommand>
    {
        public CreateDistrictCommandValidation()        
        {
            RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Nome do Bairro deve ser preenchido")
            .MaximumLength(450)
            .WithMessage("Nome do Bairro deve possuir no máximo 450 caracteres");
        }
    }
}