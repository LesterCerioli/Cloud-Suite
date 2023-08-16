namespace CloudSuite.Modules.Domain.Models.Finance
{
    public class BankAccount : Entity, |IAggregateRoot
    {
        public BankAccount(Guid id, string branch,
            string? account, string? accountDigit)
        {
            Id = id;
            Branch = branch;
            Account = account;
            AccountDigit = accountDigit;

        }
        
                
        public string? Branch { get; private set; }
        
        public string? BranchDigit { get; private set; }
        
        public string? Account { get; private set; }
        
        public string? AccountDigit { get; private set; }
        
    }
}