using CloudSuite.Modules.Cora.Application.Handlers.Extract.Request;
using FluentValidation;

namespace CloudSuite.Modules.Cora.Application.Validation.Extract
{
    public class CheckExtractExistByCostumerRequestValidation : AbstractValidator<CheckExtractExistByCostumerRequest>
    {
        public CheckExtractExistByCostumerRequestValidation()
        {

            RuleFor(c => c.Customer.FirstName)
           .NotEmpty()
           .WithMessage("O primeiro nome é obrigatório.")
           .MinimumLength(3)
           .WithMessage("O primeiro nome deve ter pelo menos 3 caracteres.")
           .MaximumLength(20)
           .WithMessage("O primeiro nome deve ter no máximo 20 caracteres.");

            RuleFor(c => c.Customer.MiddleName)
            .MinimumLength(3)
            .WithMessage("O nome do meio deve ter pelo menos 3 caracteres.")
            .MaximumLength(20)
            .WithMessage("O nome do meio deve ter no máximo 40 caracteres.");

            RuleFor(c => c.Customer.LastName)
            .MinimumLength(3)
            .WithMessage("O sobrenome deve ter pelo menos 3 caracteres.")
            .MaximumLength(20)
            .WithMessage("O sobrenome deve ter no máximo 40 caracteres.");
        }
    }
}
