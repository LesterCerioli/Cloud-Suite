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
    public class EntityRepository : IEntityRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<Entidade> DbSet;

        public EntityRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.Entidades;
        }

        public void Dispose()
        {
            Db.Dispose();
        }


        public async Task<Entidade> GetBySlug(string slug)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Slug == slug);
        }

        public async Task<Entidade> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<Entidade>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(Entidade entity)
        {
            await Task.Run(() => {
                DbSet.Add(entity);
                Db.SaveChanges();
            });
        }

        public void Update(Entidade entity)
        {
            DbSet.Update(entity);
        }

        public void Remove(Entidade entity)
        {
            DbSet.Remove(entity);
        }
    }
}
