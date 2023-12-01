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
	public class TransferFilterRepository : ITransferFilterRepository
	{
		protected readonly CoraDbContext Db;
		protected readonly DbSet<TransferFilter> DbSet;
		public TransferFilterRepository(CoraDbContext context)
		{
			Db = context;
			DbSet = context.TransferFilters;
		}

		

		public async Task Add(TransferFilter transferFilter)
		{
			await Task.Run(() =>
			{
				DbSet.Add(transferFilter);
				Db.SaveChangesAsync();
			});
		}

		public async Task<TransferFilter> GetByEndDate(DateTime endDate)
		{
			return await DbSet.FirstOrDefaultAsync(d => d.EndDate == endDate);
		}

		public async Task<TransferFilter> GetByPage(string page)
		{
			return await DbSet.FirstOrDefaultAsync(d => d.Page == page);
		}

		public async Task<TransferFilter> GetByStartDate(DateTime startDate)
		{
			return await DbSet.FirstOrDefaultAsync(d => d.StartDate == startDate);
		}

		public async Task<IEnumerable<TransferFilter>> GetList()
		{
			return await DbSet.ToListAsync();
		}

		public void Remove(TransferFilter transferFilter)
		{
			Db.Remove(transferFilter);
		}

		public void Update(TransferFilter transferFilter)
		{
			Db.Update(transferFilter);	
		}
	}
}
