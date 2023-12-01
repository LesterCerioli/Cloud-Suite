using CloudSuite.Modules.Cora.Application.Handlers.Extrato;
using FluentValidation;

namespace CloudSuite.Modules.Cora.Application.Validation.Extract
{
    public class CreateExtractCommandValidation : AbstractValidator<CreateExtractCommand>
    {
        public CreateExtractCommandValidation() 
        {
            var command = new CreateExtractCommand();

            RuleFor(a => a.StartDate)
            .NotEmpty()
            .Must(date => date == default(DateTimeOffset))
            .WithMessage("O Formato da data está incorreto.")
            .Must(date => date <= DateTime.Now)
            .WithMessage("A data não pode ser superior à data atual.");

            RuleFor(a => a.StartBalance)
            .Must(balance => balance >= 0)
            .WithMessage("O saldo em centavos da conta na data da primeira movimentação precisa ser maior ou igual a 0.")
            .Must(balance => balance is int)
            .WithMessage("Balance deve ser um número inteiro.");

            RuleFor(a => a.EndDate)
            .NotEmpty()
            .Must(date => date == default(DateTimeOffset))
            .WithMessage("O Formato da data está incorreto.")
            .Must(date => date >= command.StartDate)
            .WithMessage("A data não pode ser anterior à data de inicio.")
            .Must(date => date <= DateTime.Now)
            .WithMessage("A data de término não pode ser superior à data atual.");

            RuleFor(a => a.EndBalance)
            .Must(balance => balance >= 0)
            .WithMessage("O saldo em centavos da conta na data da primeira movimentação precisa ser maior ou igual a 0.")
            .Must(balance => balance is int)
            .WithMessage("Balance deve ser um número inteiro.");

            RuleFor(c => c.Customer.FirstName)
             .NotEmpty()
             .WithMessage("O primeiro nome é obrigatório.")
             .MinimumLength(3)
             .WithMessage("O primeiro nome deve ter pelo menos 3 caracteres.")
             .MaximumLength(40)
             .WithMessage("O primeiro nome deve ter no máximo 40 caracteres.");

            RuleFor(c => c.Customer.MiddleName)
            .MinimumLength(3)
            .When(c => !string.IsNullOrEmpty(c.Customer.MiddleName))
            .WithMessage("O nome do meio deve ter pelo menos 3 caracteres.")
            .MaximumLength(40)
            .When(c => !string.IsNullOrEmpty(c.Customer.MiddleName))
            .WithMessage("O nome do meio deve ter no máximo 40 caracteres.");

            RuleFor(c => c.Customer.LastName)
            .MinimumLength(3)
            .WithMessage("O sobrenome deve ter pelo menos 3 caracteres.")
            .MaximumLength(40)
            .WithMessage("O sobrenome deve ter no máximo 40 caracteres.");

            //RuleFor(a => a.Transaction.Operation)
            //.IsInEnum()
            //.WithMessage("A operação não é um tipo enum válido.");

            RuleFor(a => a.Transaction.TransactionTypeEnum)
            .IsInEnum()
            .WithMessage("O tipo de transação não é um tipo enum válido.");

            RuleFor(a => a.Transaction.EntryTransactionDescription)
            .MinimumLength(3)
            .WithMessage("A descrição da transação deve ter pelo menos 3 caracteres.")
            .MaximumLength(100)
            .WithMessage("A descrição da transação deve ter no máximo 100 caracteres.");

            RuleFor(a => a.Transaction.EntryTransactionCounterPartyName)
            .MinimumLength(3)
            .WithMessage("O nome da contraparte da transação deve ter pelo menos 3 caracteres.")
            .MaximumLength(60)
            .WithMessage("O nome da contraparte da transação deve ter no máximo 60 caracteres.");

            RuleFor(a => a.Transaction.TransactiOnorder)
            .Matches(@"^\d+$")
            .WithMessage("A ordem de transação deve conter apenas números. Letras e símbolos não são permitidos.");

            RuleFor(a => a.AggregationsCreditTotal)
            .Must(aggregationsCreditTotal => aggregationsCreditTotal >= 0)
            .WithMessage("A Soma dos valores listados que entraram na conta, como operação de crédito. precisa ser maior que 0");

            RuleFor(a => a.AggregationsDebitTotal)
            .Must(aggregationsDebitTotal => aggregationsDebitTotal >= 0)
            .WithMessage("Soma dos valores listados que saíram na conta, como operação de débito precisa ser maior que 0");

            RuleFor(a => a.HeaderBusinessName)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("Numero minimo de caracteres no nome da contra parte não foi alcançado.")
            .MaximumLength(60)
            .WithMessage("Numero maximo de caracteres no nome da contra parte excedido.");

            RuleFor(a => a.HeaderBusinessDocument)
            .NotEmpty()
            .WithMessage("O documento de identificação é obrigatório.")
            .Matches(@"^\d+$")
            .WithMessage("O documento de identificação deve conter apenas números. Letras e símbolos não são permitidos.");

        }
    }
   }
