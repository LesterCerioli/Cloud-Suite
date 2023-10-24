    using NetDevPack.Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace CloudSuite.Modules.Cora.Domain.Models
    {
        public class Extract : Entity, IAggregateRoot
        {

            public Extract(object startDate, Guid id)
            {
                Id = id;
            }

            public Extract(DateTimeOffset startDate, int startBalance, DateTimeOffset endDate, int endBalance,
                           string? entryId, string? entryType, int? entryAmount, string? entryCreatedAt,
                           string? entryTransactionId, int entryTransactionType, string entryTransactionDescription,
                           string entryTransactionCounterPartyName, string entryTransactionCounterPartyIdentity, string? aggregationsCreditTotal,
                           string? aggregationsDebitTotal, string? headerBusinessName, string? headerBusinessDocument)
            {
                StartDate = DateTime.Now;
                StartBalance = startBalance;
                EndDate = DateTime.Now;
                EndBalance = endBalance;
                EntryId = entryId;
                EntryType = entryType;
                EntryAmount = entryAmount;
                EntryCreatedAt = entryCreatedAt;
                EntryTransactionId = entryTransactionId;
                EntryTransactionType = entryTransactionType;
                EntryTransactionDescription = entryTransactionDescription;
                EntryTransactionCounterPartyName = entryTransactionCounterPartyName;
                EntryTransactionCounterPartyIdentity = entryTransactionCounterPartyIdentity;
                AggregationsCreditTotal = aggregationsCreditTotal;
                AggregationsDebitTotal = aggregationsDebitTotal;
                HeaderBusinessName = headerBusinessName;
                HeaderBusinessDocument = headerBusinessDocument;
            }

            [Required(ErrorMessage = "The {0} field is required.")]
            public DateTimeOffset StartDate { get; private set; }

            public int StartBalance { get; private set; }

            [Required(ErrorMessage = "The {0} field is required.")]
            public DateTimeOffset EndDate { get; private set; }

            public int EndBalance { get; private set; }

            public string? EntryId { get; private set; }

            public string? EntryType { get; private set; }

            public int? EntryAmount { get; private set; }

            public string? EntryCreatedAt { get; private set; }

            public string? EntryTransactionId { get; private set; }

            public int EntryTransactionType { get; private set; }

            public string EntryTransactionDescription { get; private set; }

            public string EntryTransactionCounterPartyName { get; private set; }

            public string EntryTransactionCounterPartyIdentity { get; private set; }

            public string? AggregationsCreditTotal { get; private set; }

            public string? AggregationsDebitTotal { get; private set; }

            [Required(ErrorMessage = "The {0} field is required.")]
            public string? HeaderBusinessName { get; private set; }

            [Required(ErrorMessage = "The {0} field is required.")]
            public string? HeaderBusinessDocument { get; private set; }
        }
    }
