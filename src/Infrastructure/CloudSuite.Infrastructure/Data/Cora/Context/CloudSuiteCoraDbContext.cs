using CloudSuite.Modules.Domain.Models.Cora.ExtractContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
    }
}