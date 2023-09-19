using CloudSuite.Infrastructure.Data.Core.Context;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Repositories.Core
{
    public class StateRepository : IStateRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<State> DbSet;

        public StateRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.States;
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<State> GetByName(string stateName)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.StateName == stateName);
        }

        public async Task<State> GetByUF(string uf)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.UF == uf);
        }


        public async Task<IEnumerable<State>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(State state)
        {
            await Task.Run(() => {
                DbSet.Add(state);
                Db.SaveChanges();
            });
        }

        public void Update(State state)
        {
            DbSet.Update(state);
        }

        public void Remove(State state)
        {
            DbSet.Remove(state);
        }
    }
}
