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
    public class WidgetRepository : IWidgetRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<Widget> DbSet;

        public WidgetRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.Widgets;
        }

        public async Task<Widget> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Widget> GetByCreationDate(DateTimeOffset creationDate)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.CreatedOn == creationDate);
        }

        public async Task<Widget> GetByLatestUpdatedDate(string createUrl)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.CreateUrl == createUrl);
        }

        public async Task<Widget> GetByEditUrl(string editUrl)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.EditUrl == editUrl);
        }


        public async Task<IEnumerable<Widget>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(Widget widget)
        {
            await Task.Run(() => {
                DbSet.Add(widget);
                Db.SaveChanges();
            });
        }

        public void Update(Widget widgete)
        {
            DbSet.Update(widgete);
        }

        public void Remove(Widget widgete)
        {
            DbSet.Remove(widgete);
        }
    }
}
