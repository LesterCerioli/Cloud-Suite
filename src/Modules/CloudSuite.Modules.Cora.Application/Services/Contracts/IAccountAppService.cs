using CloudSuite.Modules.Cora.Application.Handlers.Account;
using CloudSuite.Modules.Cora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Services.Contracts
{
    public interface IAccountAppService
    {
        Task<AccountViewModel> GetByBankCode(string bankCode);

        Task<AccountViewModel> GetByAgency(string agency);

        Task<AccountViewModel> GetByAccountNumber(string accountNumber);

        Task<AccountViewModel> GetByAccountDigit(string accountDigit);

        Task Save(CreateAccountCommand createCommand);
    }
}
