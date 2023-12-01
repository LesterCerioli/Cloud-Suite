using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Responses;
using MediatR;

namespace CloudSuite.Modules.Cora.Application.Handlers.Transactions.Requests
{
    public class CheckTransactionExistByTransactionOrderRequest : IRequest<CheckTransactionExistByTransactionOrderResponse>
    {
        public Guid Id { get; private set; }

        public string? TransactiOnorder { get; private set; }

        public CheckTransactionExistByTransactionOrderRequest(string transactionOrder)
        {
            
            Id = Guid.NewGuid();
            TransactiOnorder = transactionOrder;

        }
    }

}
