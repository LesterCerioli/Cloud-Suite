using NetDevPack.Domain;
namespace CloudSuite.Modules.Domain.Models.Finance
{
    public class BankAccount : Entity, IAggregateRoot
    {
        public BankAccount(string? branch, string? branchDigit, string? account, string? accountDigit)
        {
            Branch = branch;
            BranchDigit = branchDigit;
            Account = account;
            AccountDigit = accountDigit;
        }

        public string? Branch { get; private set; }
        
        public string? BranchDigit { get; private set; }
        
        public string? Account { get; private set; }
        
        public string? AccountDigit { get; private set; }
        
    }
}