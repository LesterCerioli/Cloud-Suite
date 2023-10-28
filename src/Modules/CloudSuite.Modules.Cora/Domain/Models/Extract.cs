using CloudSuite.Modules.Common.Enums.Cora;
using CloudSuite.Modules.Common.ValueObjects;
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

            

            [Required(ErrorMessage = "The {0} field is required.")]
            public DateTimeOffset StartDate { get; private set; }

            // Valor total na data inicial do extrato
            public int? StartBalance { get; private set; }

            [Required(ErrorMessage = "The {0} field is required.")]
            public DateTimeOffset EndDate { get; private set; }

            // Valor total na data final do extrato 
            public int? EndBalance { get; private set; }

            public Customer Customer { get; private set; }

            public OperationTypeEnum OperationTypeEnum { get; private set; }

            public int? EntryAmount { get; private set; }

            public string? EntryCreatedAt { get; private set; }

            public string? EntryTransactionId { get; private set; }

            public TransactionTypeEnum TransactionTypeEnum { get; private set; }

            public string? EntryTransactionDescription { get; private set; }

            public string? EntryTransactionCounterPartyName { get; private set; }

            public string? EntryTransactionCounterPartyIdentity { get; private set; }

            public int? AggregationsCreditTotal { get; private set; }

            public int? AggregationsDebitTotal { get; private set; }

            [Required(ErrorMessage = "The {0} field is required.")]
            public string HeaderBusinessName { get; private set; }

            [Required(ErrorMessage = "The {0} field is required.")]
            public string HeaderBusinessDocument { get; private set; }
        
    }
}
