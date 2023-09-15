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
    public class DistrictRepository : IDistrictRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<District> DbSet;

        public DistrictRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.Districts;
        }

        public async Task<District> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<District>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(District district)
        {
            await Task.Run(() => {
                DbSet.Add(district);
                Db.SaveChanges();
            });
        }

        public void Update(District district)
        {
            DbSet.Update(district);
        }

        public void Remove(District district)
        {
            DbSet.Remove(district);
        }
    }
}
