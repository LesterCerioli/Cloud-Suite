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
    public class UserRepository : IUserRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<User> DbSet;

        public UserRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.Users;
        }

        public async Task<User> GetByEmail(Email email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email) ;
        }

        public async Task<User> GetByCpf(Cpf cpf)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf.CpfNumber == cpf.CpfNumber);
        }

        public async Task<IEnumerable<User>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(User user)
        {
            await Task.Run(() => {
                DbSet.Add(user);
                Db.SaveChanges();
            });
        }

        public void Update(User user)
        {
            DbSet.Update(user);
        }

        public void Remove(User user)
        {
            DbSet.Remove(user);
        }
    }
}
