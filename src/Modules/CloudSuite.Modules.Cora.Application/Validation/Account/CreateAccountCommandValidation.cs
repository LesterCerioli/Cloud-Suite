using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Cora.Application.Handlers.Account;
using FluentValidation;

namespace CloudSuite.Modules.Cora.Application.Validation.Account
{
    public class CreateAccountCommandValidation : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidation() 
        {

             RuleFor(c => c.Agency)
             .NotEmpty()
             .WithMessage("Número da agência é obrigatório.")
             .Equal("0001")
             .WithMessage("Número da agência deve ser 0001.");

            RuleFor(c => c.AccountNumber)
            .NotEmpty()
            .WithMessage("Número da conta é obrigatório.")
            .MinimumLength(7)
            .WithMessage("a conta deve ter 7 caracteres.")
            .MaximumLength(7)
            .WithMessage("a conta deve ter 7 caracteres.");

            RuleFor(c => c.AccountDigit)
            .NotEmpty()
            .WithMessage("Número do dígito da conta é obrigatório.");


            RuleFor(c => c.BankCode)
            .NotEmpty()
            .WithMessage("Código da Cora é obrigatório.")
            .Equal("403")
            .WithMessage("Código da Cora deve ser 403.");

            RuleFor(c => c.BankName)
            .NotEmpty()
            .WithMessage("Nome oficial da Cora é obrigatório.");
        }
    }
}
