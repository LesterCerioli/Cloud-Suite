using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Finance
{
    public class Bank : Entity, IAggregateRoot
    {
        public Bank(Guid id, string bankName,
                string bankCode)
        {
            Id = id;
            BankName = bankName;
            BankCode = bankCode;
        }
        
        public string? BankName { get; private set; }

        public string? BankCode { get; private set; }
        
    }
}