using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Cora.Application.Validation.Transaction
{
    public class CheckTransactionExistByTransactionOrderRequestValidation : AbstractValidator<CheckTransactionExistByTransactionOrderRequest>
    {

        public CheckTransactionExistByTransactionOrderRequestValidation() 
        {
            RuleFor(a => a.TransactiOnorder)
            .Matches(@"^\d+$")
            .WithMessage("A ordem de transação deve conter apenas números. Letras e símbolos não são permitidos.");
        }
    }
}
