using CloudSuite.Modules.Domain.Models.Finance;

namespace CloudSuite.Modules.Domain.Contracts.Finance
{
    public interface IBankAccountRepository
    {
         
         Task<BankAccount> GetByBranch(string branch);

         Task<BankAccount> GetByBranchDigit(string branchDigit);

         Task<BankAccount> GetByAccount(string account);

         Task<BankAccount> GetByAccountDigit(string accountDigit);

         Task<IEnumerable<BankAccount>> GetList();

         Task Add(BankAccount bankAccount);

         void Update(BankAccount bankAccount);

         void Remove(BankAccount bankAccount);

    }
}