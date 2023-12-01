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
	public class TransactionRepository : ITransactionRepository
	{
		protected readonly CoraDbContext Db;
		protected readonly DbSet<Transaction> DbSet;
		public TransactionRepository(CoraDbContext context)
		{
			Db = context;
			DbSet = context.Transactions;
		}

		

		public async Task Add(Transaction transaction)
		{
			await Task.Run(() =>
			{
				DbSet.Add(transaction);
				Db.SaveChangesAsync();	
			});
		}

		public async Task<Transaction> GetByCounterPartyName(string entryTransactionCounterPartyName)
		{
			return await DbSet.FirstOrDefaultAsync(a => a.EntryTransactionCounterPartyName == entryTransactionCounterPartyName);
		}

		public async Task<Transaction> GetByTransactionOrder(string transactionOrder)
		{
			return await DbSet.FirstOrDefaultAsync(a => a.TransactiOnorder == transactionOrder);
		}

		public async Task<IEnumerable<Transaction>> GetList()
		{
			return await DbSet.ToListAsync();
		}

		public void Remove(Transaction transaction)
		{
			DbSet.Remove(transaction);
		}

		public void Update(Transaction transaction)
		{
			DbSet.Update(transaction);	
		}
	}
}
