using CloudSuite.Modules.Domain.Models.Finance;
using CloudSuite.Modules.Domain.Models.Fiscal.NFes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
