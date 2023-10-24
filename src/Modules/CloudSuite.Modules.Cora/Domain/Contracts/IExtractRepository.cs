using CloudSuite.Modules.Cora.Domain.Models.CloudSuite.Modules.Cora.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Contracts
{
        public interface IExtratoRepository
        {
            Task<Extract> GetByStartDate(DateTimeOffset dataInicio);

            Task<Extract> GetByEndDate(DateTimeOffset dataFinal);

            //Task<Extract> GetByType(EntryType entryType); nesses dois casos o (EntryType, TransactionType)são ENUMs estão presentes na minha branch mas não na develops.

            //Task<Extract> GetByTransactionType(TransactionType transactionType);

            Task<Extract> GetByEntryAmount(decimal amount);

            Task<Extract> GetByEntryCreatedAt(string EntryCreatedAt);

            Task<Extract> GetByEntryTransactionId(string EntryTransactionId);

            Task<Extract> GetByEntryTransactionDescription(string EntryTransactionId);

            Task<Extract> GetByEntryTransactionCounterPartyName(string EntryTransactionCounterPartyName);

            Task<Extract> GetByEntryTransactionCounterPartyIdentity(string EntryTransactionCounterPartyIdentity);

            Task<Extract> GetByAggregationsCreditTotaly(string EntryTransactionCounterPartyIdentity);

            Task<Extract> GetByAggregationsDebitTotal(string EntryTransactionCounterPartyIdentity);

            Task<Extract> GetByHeaderBusinessName(string EntryTransactionCounterPartyIdentity);

            Task<Extract> GetByHeaderBusinessDocument(string EntryTransactionCounterPartyIdentity);

            Task<IEnumerable<Extract>> GetList();

            Task Add(Extract extrato);

            void Update(Extract extrato);

            void Remove(Extract extrato);
        }
    }
