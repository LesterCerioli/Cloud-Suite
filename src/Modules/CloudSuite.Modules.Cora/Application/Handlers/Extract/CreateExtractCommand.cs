using CloudSuite.Modules.Common.Enums.Cora;
using CloudSuite.Modules.Cora.Application.Handlers.Extrato.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using ExtractEntity = CloudSuite.Modules.Cora.Domain.Models.Extract;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extrato
{
    public class CreateExtractCommand : IRequest<CreateExtractResponse>
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTimeOffset StartDate { get; private set; }

        public int StartBalance { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTimeOffset EndDate { get; private set; }

        public int EndBalance { get; private set; }

        public string? EntryId { get; private set; }

        public EntryTypeEnum? EntryType { get; private set; }

        public int? EntryAmount { get; private set; }

        public string? EntryCreatedAt { get; private set; }

        public string? EntryTransactionId { get; private set; }

        public EntryTransactionTypeEnum EntryTransactionType { get; private set; }

        public string? EntryTransactionDescription { get; private set; }

        public string? EntryTransactionCounterPartyName { get; private set; }

        public string? EntryTransactionCounterPartyIdentity { get; private set; }

        public string? AggregationsCreditTotal { get; private set; }

        public string? AggregationsDebitTotal { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string HeaderBusinessName { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string HeaderBusinessDocument { get; private set; }


        public ExtractEntity GetEntity()
        {
            return new ExtractEntity(
                this.StartDate,
                this.StartBalance,
                this.EndDate,
                this.EndBalance,
                this.EntryId,
                this.EntryType,
                this.EntryAmount,
                this.EntryCreatedAt,
                this.EntryTransactionId,
                this.EntryTransactionType,
                this.EntryTransactionDescription,
                this.EntryTransactionCounterPartyName,
                this.EntryTransactionCounterPartyIdentity,
                this.AggregationsCreditTotal,
                this.AggregationsDebitTotal,
                this.HeaderBusinessName,
                this.HeaderBusinessDocument);

        }


    }
}