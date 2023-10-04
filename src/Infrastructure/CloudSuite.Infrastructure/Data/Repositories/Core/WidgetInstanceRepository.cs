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
    public class WidgetInstanceRepository : IWidgetInstanceRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<WidgetInstance> DbSet;

        public WidgetInstanceRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.WidgetInstances;
        }

        public async Task<WidgetInstance> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<WidgetInstance> GetByWidgetId(string widgetId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.WidgetId == widgetId);
        }

        public async Task<WidgetInstance> GetByDisplayOrder(int displayOrder)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.DisplayOrder == displayOrder);
        }

        public async Task<WidgetInstance> GetByData(string data)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Data == data);
        }

        public async Task<WidgetInstance> GetByHtmlData(string htmlData)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.HtmlData == htmlData);
        }


        public async Task<IEnumerable<WidgetInstance>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(WidgetInstance widgetInstance)
        {
            await Task.Run(() => {
                DbSet.Add(widgetInstance);
                Db.SaveChanges();
            });
        }

        public void Update(WidgetInstance widgetInstance)
        {
            DbSet.Update(widgetInstance);
        }

        public void Remove(WidgetInstance widgetInstance)
        {
            DbSet.Remove(widgetInstance);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
