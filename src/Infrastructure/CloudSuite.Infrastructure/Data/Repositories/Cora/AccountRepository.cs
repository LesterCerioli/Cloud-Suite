using CloudSuite.Infrastructure.Data.Cora.Context;
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
		public AccountRepository(CoraDbContext context)
		{

		}
		public async Task Add(Account account)
		{
			
		}

		public async Task<Account> GetByAccountDigit(string accountDigit)
		{
			throw new NotImplementedException();
		}

		public async Task<Account> GetByAccountNumber(string accountNumber)
		{
			throw new NotImplementedException();
		}

		public async Task<Account> GetByAgency(string agency)
		{
			throw new NotImplementedException();
		}

		public async Task<Account> GetByBankCode(string bankCode)
		{
			throw new NotImplementedException();
		}

		public async Task<Account> GetByBankName(string bankName)
		{
			throw new NotImplementedException();
		}

		public asyncTask<IEnumerable<Account>> GetList()
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
