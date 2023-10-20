using CloudSuite.Modules.Application.ViewModels.Cora;
using CloudSuite.Modules.Common.Enums.Cora;
using CloudSuite.Modules.Cora.Application.Handlers.Extrato;
using CloudSuite.Modules.Domain.Models.Cora.ExtractContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Cora
{
    public interface IExtractService
    {
        Task<ExtractViewModel> GetByStartDate(DateTimeOffset dataInicio);

        Task<ExtractViewModel> GetByEndDate(DateTimeOffset dataFinal);

        Task<ExtractViewModel> GetByType(EntryType entryType);

        Task<ExtractViewModel> GetByTransactionType(TransactionType transactionType);

        Task<ExtractViewModel> GetByEntryAmount(decimal amount);

        Task<ExtractViewModel> GetByEntryCreatedAt(string EntryCreatedAt);

        Task<ExtractViewModel> GetByEntryTransactionId(string EntryTransactionId);

        Task<ExtractViewModel> GetByEntryTransactionDescription(string EntryTransactionId);

        Task<ExtractViewModel> GetByEntryTransactionCounterPartyName(string EntryTransactionCounterPartyName);

        Task<ExtractViewModel> GetByEntryTransactionCounterPartyIdentity(string EntryTransactionCounterPartyIdentity);

        Task<ExtractViewModel> GetByAggregationsCreditTotaly(string EntryTransactionCounterPartyIdentity);

        Task<ExtractViewModel> GetByAggregationsDebitTotal(string EntryTransactionCounterPartyIdentity);

        Task<ExtractViewModel> GetByHeaderBusinessName(string EntryTransactionCounterPartyIdentity);

        Task<ExtractViewModel> GetByHeaderBusinessDocument(string EntryTransactionCounterPartyIdentity);

        Task Save(CreateExtractCommand commandCreate);
    }
}
