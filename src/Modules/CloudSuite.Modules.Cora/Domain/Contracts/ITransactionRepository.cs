using CloudSuite.Modules.Cora.Domain.Models;

namespace CloudSuite.Modules.Cora.Domain.Contracts
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetByCounterPartyName(string entryTransactionCounterPartyName);

        Task<Transaction> GetByTransactionOrder(string transactionOrder);

        Task<IEnumerable<Transaction>> GetList();

        Task Add(Transaction transaction);

        void Update(Transaction transaction);

        void Remove(Transaction transaction);
   
    }
}