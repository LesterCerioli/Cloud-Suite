using CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Core;
using CloudSuite.Modules.Domain.Models.Cora.ExtractContext;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Cora;

namespace CloudSuite.Infrastructure.Data.Cora.Context
{
    public class CloudSuiteCoraDbContext : DbContext
    {
        public CloudSuiteCoraDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Extract> Extracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<EventArgs>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new ExtractMap());

            modelBuilder.Entity<Extract>(c =>
            {
                c.ToTable("Extracts");
            });
        }
    }
}