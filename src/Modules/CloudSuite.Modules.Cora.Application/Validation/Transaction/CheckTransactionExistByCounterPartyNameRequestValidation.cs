using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Cora.Application.Validation.Transaction
{
    public class CheckTransactionExistByCounterPartyNameRequestValidation : AbstractValidator<CheckTransactionExistByCounterPartyNameRequest>
    {
        public CheckTransactionExistByCounterPartyNameRequestValidation()
        {
            RuleFor(a => a.EntryTransactionCounterPartyName)
            .MinimumLength(3)
            .WithMessage("O nome da contraparte da transação deve ter pelo menos 3 caracteres.")
            .MaximumLength(60)
            .WithMessage("O nome da contraparte da transação deve ter no máximo 60 caracteres.");
        }
    }
}
