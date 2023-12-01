using CloudSuite.Modules.Cora.Application.Handlers.Transactions;
using FluentValidation;

namespace CloudSuite.Modules.Cora.Application.Validation.Transaction
{
    public class CreateTransactionCommandValidation : AbstractValidator<CreateTransactionCommand>
    {

        public CreateTransactionCommandValidation() 
        { 
            var command = new CreateTransactionCommand();

            RuleFor(a => a.Operation)
            .IsInEnum()
            .WithMessage("A operação não é um tipo enum válido.");

            RuleFor(a => a.TransactionTypeEnum)
            .IsInEnum()
            .WithMessage("A operação não é um tipo enum válido.");

            RuleFor(a => a.EntryAmount)
            .Must(amount => amount == default(decimal))
            .WithMessage("O valor total deve ser um número decimal válido.");

            RuleFor(a => a.EntryCreatedAt)
            .Must(createdAt => createdAt == default(DateTimeOffset))
            .WithMessage("A data da transação deve ser um DateTimeOffset válido.");

            RuleFor(a => a.EntryTransactionDescription)
            .MinimumLength(3)
            .WithMessage("A descrição da transação deve ter pelo menos 3 caracteres.")
            .MaximumLength(100)
            .WithMessage("A descrição da transação deve ter no máximo 100 caracteres.");

            RuleFor(a => a.EntryTransactionCounterPartyName)
            .MinimumLength(3)
            .WithMessage("O nome da contraparte da transação deve ter pelo menos 3 caracteres.")
            .MaximumLength(60)
            .WithMessage("O nome da contraparte da transação deve ter no máximo 60 caracteres.");

            RuleFor(a => a.TransactiOnorder)
            .Matches(@"^\d+$")
            .WithMessage("A ordem de transação deve conter apenas números. Letras e símbolos não são permitidos.");

        }
    }
}
