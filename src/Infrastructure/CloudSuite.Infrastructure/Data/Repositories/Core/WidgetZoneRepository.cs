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
    public class WidgetZoneRepository : IWidgetZoneRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<WidgetZone> DbSet;

        public WidgetZoneRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.WidgetZones;
        }
        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<WidgetZone> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<WidgetZone> GetByDescription(string description)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Description == description);
        }

        public async Task<IEnumerable<WidgetZone>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(WidgetZone widgetZone)
        {
            await Task.Run(() => {
                DbSet.Add(widgetZone);
                Db.SaveChanges();
            });
        }

        public void Update(WidgetZone widgetZone)
        {
            DbSet.Update(widgetZone);
        }

        public void Remove(WidgetZone widgetZone)
        {
            DbSet.Remove(widgetZone);
        }
    }
}
