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
    public class EmailRepository : IEmailRepository
    {

        protected readonly CloudSuiteDbContext Db;
        protected readonly DbSet<RoboEmail> DbSet;

        public EmailRepository(CloudSuiteDbContext context)
        {
            Db = context;
            DbSet = context.RoboEmails;
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<RoboEmail> GetBySubject(string subject)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Subject == subject);
        }

        public async Task<RoboEmail> GetByReceivedTime(DateTimeOffset receivedTime)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.ReceivedTime == receivedTime);
        }

        public async Task<RoboEmail> GetByMessageRecipient(string messageRecipient)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.MessageRecipient == messageRecipient);
        }

        public async Task<IEnumerable<RoboEmail>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(RoboEmail roboEmail)
        {
            await Task.Run(() => {
                DbSet.Add(roboEmail);
                Db.SaveChanges();
            });
        }

        public void Update(RoboEmail roboEmail)
        {
            DbSet.Update(roboEmail);
        }

        public void Remove(RoboEmail roboEmail)
        {
            DbSet.Remove(roboEmail);
        }
    }
}
