using CloudSuite.Modules.Common.Enums.Cora;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Cora.Domain.Models
{
    public class Transaction : Entity, IAggregateRoot
    {
        public Transaction(OperationTypeEnum operation, TransactionTypeEnum transactionTypeEnum, string? entryTransactionDescription, string? entryTransactionCounterPartyName, string? transactionOrder, string? entryTransactionCounterPartyIdentity)
        {
            Operation = operation;
            TransactionTypeEnum = transactionTypeEnum;
            EntryTransactionDescription = entryTransactionDescription;
            EntryTransactionCounterPartyName = entryTransactionCounterPartyName;
            TransactiOnorder = transactionOrder;
            EntryTransactionCounterPartyIdentity = entryTransactionCounterPartyIdentity;
        }

        public Transaction() {}
        
        public OperationTypeEnum Operation { get; private set; }

        public TransactionTypeEnum TransactionTypeEnum { get; private set; }

        public string? EntryTransactionDescription { get; private set; }

        public string? EntryTransactionCounterPartyName { get; private set; }

        public string? TransactiOnorder {get; private set;}

        public string? EntryTransactionCounterPartyIdentity { get; private set; }
        
    }
}