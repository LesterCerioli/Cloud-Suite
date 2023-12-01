using CloudSuite.Modules.Common.Enums.Cora;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Cora.Domain.Models
{
    public class Transaction : Entity, IAggregateRoot
    {
        public Transaction(decimal? entryAmount, DateTimeOffset? entryCreatedAt, string? entryTransactionDescription,
            string? entryTransactionCounterPartyName, string? transactiOnorder, string? entryTransactionCounterPartyIdentity)
        {
            //Operation = operation;
            //TransactionTypeEnum = transactionTypeEnum;
            EntryAmount = entryAmount;
            EntryCreatedAt = entryCreatedAt;
            EntryTransactionDescription = entryTransactionDescription;
            EntryTransactionCounterPartyName = entryTransactionCounterPartyName;
            TransactiOnorder = transactiOnorder;
            EntryTransactionCounterPartyIdentity = entryTransactionCounterPartyIdentity;
        }

        //public Transaction() {}
        //public OperationTypeEnum Operation { get; private set; }

        public TransactionTypeEnum TransactionTypeEnum { get; private set; }

        public decimal? EntryAmount { get; private set; }

        public DateTimeOffset? EntryCreatedAt { get; private set; }

        public string? EntryTransactionDescription { get; private set; }

        public string? EntryTransactionCounterPartyName { get; private set; }

        public string? TransactiOnorder {get; private set;}

        public string? EntryTransactionCounterPartyIdentity { get; private set; }
        
    }
}