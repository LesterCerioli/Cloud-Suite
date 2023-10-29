﻿using CloudSuite.Infrastructure.Data.Cora.Context;
using CloudSuite.Modules.Common.Enums.Cora;
using CloudSuite.Modules.Common.ValueObjects;
using CloudSuite.Modules.Cora.Domain.Contracts;
using CloudSuite.Modules.Cora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Cora
{
	public class ExtractRepository : IExtractRepository
	{

        protected readonly CoraDbContext Db;
        protected readonly DbSet<Extract> DbSet;

        public ExtractRepository(CoraDbContext context)
		{
            Db = context;
            DbSet = context.Extracts;

        }
        public async Task Add(Extract extract)
		{
			await Task.Run(() => {
                DbSet.Add(extract);
                Db.SaveChanges();
            });
        }

		public async Task<Extract> GetByCustomer(Customer customer)
		{
			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Customer.LastName == customer.LastName);
		}

		public async Task<Extract> GetByEndDate(DateTimeOffset endDate)
		{
			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.EndDate == endDate);
		}

		public async Task<Extract> GetByEntryAmount(decimal entryAmount)
		{
			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.EntryAmount == entryAmount);
		}

				
		public async Task<Extract> GetByEntryTransactionCounterPartyName(string counterPartyName)
		{
			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.EntryTransactionCounterPartyName == counterPartyName);
		}
			
		
		public async Task<Extract> GetByEntryType(OperationTypeEnum entryType)
		{
			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.OperationTypeEnum == entryType);
		}

		public async Task<Extract> GetByStartDate(DateTimeOffset startDate)
		{
			return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.StartDate == startDate);
		}

		public async Task<IEnumerable<Extract>> GetList()
		{
			return await DbSet.ToListAsync();
		}

		public void Remove(Extract extract)
		{
			DbSet.Remove(extract);
		}

		public void Update(Extract extract)
		{
			DbSet.Update(extract);
		}
	}
}
