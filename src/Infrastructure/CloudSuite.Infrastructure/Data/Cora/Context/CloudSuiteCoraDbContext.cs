using CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Cora;
using CloudSuite.Modules.Cora.Domain.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Data.Cora.Context
{
    public class CloudSuiteCoraDbContext : DbContext
    {
        public CloudSuiteCoraDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<EventArgs>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new AccountEFCoreMap());
            


            modelBuilder.Entity<Account>(c =>
            {
                c.ToTable("Accounts");
            });

            

            base.OnModelCreating(modelBuilder);
        }

    }
}