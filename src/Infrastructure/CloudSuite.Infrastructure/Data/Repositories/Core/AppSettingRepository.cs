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
    public class AppSettingRepository : IAppSettingRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<AppSetting> DbSet;

        public AppSettingRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.AppSettings;
        }

        public async Task<AppSetting> GetByValue(string value)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Value == value);
        }

        public async Task<AppSetting> GetByModule(string module)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Module == module);
        }

        public async Task<IEnumerable<AppSetting>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(AppSetting appsetings)
        {
            await Task.Run(() => {
                DbSet.Add(appsetings);
                Db.SaveChanges();
            });
        }

        public void Update(AppSetting appsetings)
        {
            DbSet.Update(appsetings);
        }

        public void Remove(AppSetting appsetings)
        {
            DbSet.Remove(appsetings);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
