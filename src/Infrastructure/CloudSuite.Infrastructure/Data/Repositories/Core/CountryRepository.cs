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
    public class CountryRepository : ICountryRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<Country> DbSet;

        public CountryRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.Countries;
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<Country> GetByName(string countryName)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.CountryName == countryName);
        }

        public async Task<Country> GetByCode(string code3)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Code3 == code3);
        }

        public async Task<IEnumerable<Country>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(Country country)
        {
            await Task.Run(() => {
                DbSet.Add(country);
                Db.SaveChanges();
            });
        }

        public void Update(Country country)
        {
            DbSet.Update(country);
        }

        public void Remove(Country country)
        {
            DbSet.Remove(country);
        }
    }
}
