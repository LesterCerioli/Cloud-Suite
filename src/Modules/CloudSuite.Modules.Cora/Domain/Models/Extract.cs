using System.ComponentModel.DataAnnotations;
using CloudSuite.Modules.Common.Enums.Cora;
using CloudSuite.Modules.Common.ValueObjects;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Cora.Domain.Models
{
    public class Extract : Entity, IAggregateRoot
    {
        private List<Transaction> _transactions;

        public Extract(DateTimeOffset startDate, decimal? startBalance, 
        DateTimeOffset? endDate, decimal? endBalance, 
        Customer customer, Transaction transaction,
        decimal? aggregationsCreditTotal, decimal? aggregationsDebitTotal,
        string? headerBusinessName, string? headerBusinessDocument, decimal entryAmount)
        {
            StartDate = startDate;
            StartBalance = startBalance;
            EndDate = endDate;
            EndBalance = endBalance;
            Customer = customer;
            Transaction = transaction;
            AggregationsCreditTotal = aggregationsCreditTotal;
            AggregationsDebitTotal = aggregationsDebitTotal;
            HeaderBusinessName = headerBusinessName;
            HeaderBusinessDocument = headerBusinessDocument;
            _transactions = new List<Transaction>();
            EntryAmount = entryAmount;
            
        }

        public DateTimeOffset StartDate { get; private set; }

        public decimal? StartBalance { get; private set; }

        public DateTimeOffset? EndDate { get; private set; }

        public decimal? EndBalance { get; private set; }

        public Customer Customer { get; private set; }

        public OperationTypeEnum EntryType { get; private set; }

        public Transaction Transaction { get; private set; }
          
        public decimal? AggregationsCreditTotal { get; private set; }

        public decimal? AggregationsDebitTotal { get; private set; }

        public decimal? EntryAmount { get; private set; }

        public string? HeaderBusinessName { get; private set; }

        public string? HeaderBusinessDocument { get; private set; }

        public Guid TransactionId { get; private set; }

        public IReadOnlyCollection<Transaction> Transactions { get { return _transactions.ToArray(); } }
        
    }
}