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
    public class CityRepository : ICityRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<City> DbSet;

        public CityRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.Cities;
        }

        public async Task<City> GetByCityName(string cityName)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.CityName == cityName);
        }

        public async Task<IEnumerable<City>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(City city)
        {
            await Task.Run(() => {
                DbSet.Add(city);
                Db.SaveChanges();
            });
        }

        public void Update(City city)
        {
            DbSet.Update(city);
        }

        public void Remove(City city)
        {
            DbSet.Remove(city);
        }
    }
}
