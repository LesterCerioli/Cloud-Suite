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
    public class AddressRepository : IAddressRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<Address> DbSet;

        public AddressRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.Addresses;
        }

        public async Task<Address> GetByContactName(string contactName)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.ContactName == contactName);
        }

        public async Task<Address> GetByAddressLine(string addressLine1)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.AddressLine1 == addressLine1);
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(Address address)
        {
            await Task.Run(() => {
                DbSet.Add(address);
                Db.SaveChanges();
            });
        }

        public void Update(Address address)
        {
            DbSet.Update(address);
        }

        public void Remove(Address address)
        {
            DbSet.Remove(address);
        }
    }
}
