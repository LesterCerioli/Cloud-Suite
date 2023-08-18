using CloudSuite.Modules.Domain.Models.Finance;
using CloudSuite.Modules.Domain.Models.Fiscal.NFes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Finance
{
    public interface IBankRepository
    {
        Task<Bank> GetByBankName(string bankName);

        Task<Bank> GetByBankCode(string bankCode);

        Task<IEnumerable<Bank>> GetList();

        Task Add(Bank bank);
        void Update(Bank bank);
        void Remove(Bank bank);

    }
}
