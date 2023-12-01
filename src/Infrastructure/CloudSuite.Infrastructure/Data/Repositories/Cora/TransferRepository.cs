using CloudSuite.Infrastructure.Data.Cora.Context;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora
{
	public class TransferRepository : ITransferRepository
	{
		protected readonly CoraDbContext Db;
		protected readonly DbSet<Transfer> DbSet;

		public TransferRepository(CoraDbContext context)
		{
			Db = context;
			DbSet = context.Transfers;
		}

		

		public Task Add(Transfer transfer)
		{
			throw new NotImplementedException();
		}

		public Task<Transfer> GetByAccountNumber(string accountNumber)
		{
			throw new NotImplementedException();
		}

		public Task<Transfer> GetByAmount(string amount)
		{
			throw new NotImplementedException();
		}

		public Task<Transfer> GetByBankCodeRecipient(string bankCode)
		{
			throw new NotImplementedException();
		}

		public Task<Transfer> GetByBranchNumberRecipient(string branchNumber)
		{
			throw new NotImplementedException();
		}

		public Task<Transfer> GetByCategory(string category)
		{
			throw new NotImplementedException();
		}

		public Task<Transfer> GetByCode(string code)
		{
			throw new NotImplementedException();
		}

		public Task<Transfer> GetByScheduled(DateTimeOffset scheduled)
		{
			throw new NotImplementedException();
		}

		public Task<Transfer> GetByStatus(string status)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Transfer>> GetList()
		{
			throw new NotImplementedException();
		}

		public void Remove(Transfer transfer)
		{
			throw new NotImplementedException();
		}

		public void Update(Transfer transfer)
		{
			throw new NotImplementedException();
		}
	}
}
