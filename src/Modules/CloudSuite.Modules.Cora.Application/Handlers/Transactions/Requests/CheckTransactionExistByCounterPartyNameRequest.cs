using CloudSuite.Modules.Cora.Application.Handlers.Transactions.Responses;
using MediatR;


namespace CloudSuite.Modules.Cora.Application.Handlers.Transactions.Requests
{
    public class CheckTransactionExistByCounterPartyNameRequest : IRequest<CheckTransactionExistByCounterPartyNameResponse>
    {
        public Guid Id { get; private set; }

        public string? EntryTransactionCounterPartyName { get; private set; }

        public CheckTransactionExistByCounterPartyNameRequest(string counterPartyName)
        {

            Id = Guid.NewGuid();
            EntryTransactionCounterPartyName = counterPartyName;

        }
    }
}
