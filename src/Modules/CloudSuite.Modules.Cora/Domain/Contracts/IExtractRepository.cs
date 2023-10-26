using CloudSuite.Modules.Cora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Contracts
{
    public interface IExtractRepository
    {
        Task<Extract> GetByStartDate(DateTimeOffset dataInicio);

        Task<Extract> GetByEndDate(DateTimeOffset dataFinal);

        Task<Extract> GetByEntryId(string clientName);

        Task<Extract> GetByEntryAmount(decimal amount);

        Task<Extract> GetByEntryCreatedAt(string entryCreatedAt);

        Task<Extract> GetByEntryTransactionId(string transactionId);

        Task<Extract> GetByEntryTransactionCounterPartyName(string counterPartyName);

        Task<Extract> GetByEntryTransactionCounterPartyIdentity(string counterPartyIdentity);

        Task<IEnumerable<Extract>> GetList();

        Task Add(Extract extract);

        void Update(Extract extract);

        void Remove(Extract extract);
    }
}
