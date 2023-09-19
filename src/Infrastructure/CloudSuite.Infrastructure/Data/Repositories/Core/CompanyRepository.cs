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
    public class CompanyRepository : ICompanyRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<Company> DbSet;

        public CompanyRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.Companys;
        }

        public void Dispose()
        {
            Db.Dispose();
        }


        public async Task<Company> GetByFantasyName(string fantasyName)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.FantasyName == fantasyName);
        }

        public async Task<Company> GetByRegisterName(string registerName)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.RegisterName == registerName);
        }

        public async Task<Company> GetByCnpj(Cnpj cnpj)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Cnpj.CnpjNumber == cnpj.CnpjNumber);
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(Company company)
        {
            await Task.Run(() => {
                DbSet.Add(company);
                Db.SaveChanges();
            });
        }

        public void Update(Company company)
        {
            DbSet.Update(company);
        }

        public void Remove(Company company)
        {
            DbSet.Remove(company);
        }
    }
}
