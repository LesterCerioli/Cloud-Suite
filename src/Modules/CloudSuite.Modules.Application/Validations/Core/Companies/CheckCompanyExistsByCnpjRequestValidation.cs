using CloudSuite.Modules.Application.Handlers.Core.Companies.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Companies
{
    public class CheckCompanyExistsByCnpjRequestValidation : AbstractValidator<CheckCompanyExistsByCnpjRequest>
    {
        public CheckCompanyExistsByCnpjRequestValidation()
        {
            RuleFor(request => request.Cnpj)
            .NotEmpty()
            .WithMessage("Cnpj deve ser preenchido");
        }
    }
}