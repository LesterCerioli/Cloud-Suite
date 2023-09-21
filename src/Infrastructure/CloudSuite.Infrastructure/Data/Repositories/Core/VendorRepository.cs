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
    public class VendorRepository : IVendorRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<Vendor> DbSet;

        public VendorRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.Vendors;
        }

        public async Task<Vendor> GetByCnpj(Cnpj cnpj)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Cnpj.CnpjNumber == cnpj.CnpjNumber);
        }

        public async Task<Vendor> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Vendor> GetByCreationDate(DateTimeOffset creationDate)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.CreatedOn == creationDate);
        }

        public async Task<IEnumerable<Vendor>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(Vendor vendor)
        {
            await Task.Run(() => {
                DbSet.Add(vendor);
                Db.SaveChanges();
            });
        }

        public void Update(Vendor vendor)
        {
            DbSet.Update(vendor);
        }

        public void Remove(Vendor vendor)
        {
            DbSet.Remove(vendor);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
