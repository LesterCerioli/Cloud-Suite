using CloudSuite.Modules.Cora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Contracts
{
    public interface IAccountRepository
    {
        Task<Account> GetByBankCode(string bankCode);

        Task<Account> GetByAgency(string agency);

        Task<Account> GetByAccountNumber(string accountNumber);

        Task<Account> GetByAccountDigit(string accountDigit);

        Task<Account> GetByBankName(string bankName);

        Task<IEnumerable<Account>> GetList();

        Task Add(Account account);

        void Update(Account account);

        void Remove(Account account);
        
    }
}
