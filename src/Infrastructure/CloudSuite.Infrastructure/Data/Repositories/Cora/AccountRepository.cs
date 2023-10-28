using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora
{
	public class AccountRepository : IAccountRepository
	{
		public Task Add(Account account)
		{
			throw new NotImplementedException();
		}

		public Task<Account> GetByAccountDigit(string accountDigit)
		{
			throw new NotImplementedException();
		}

		public Task<Account> GetByAccountNumber(string accountNumber)
		{
			throw new NotImplementedException();
		}

		public Task<Account> GetByAgency(string agency)
		{
			throw new NotImplementedException();
		}

		public Task<Account> GetByBankCode(string bankCode)
		{
			throw new NotImplementedException();
		}

		public Task<Account> GetByBankName(string bankName)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Account>> GetList()
		{
			throw new NotImplementedException();
		}

		public void Remove(Account account)
		{
			throw new NotImplementedException();
		}

		public void Update(Account account)
		{
			throw new NotImplementedException();
		}
	}
}
