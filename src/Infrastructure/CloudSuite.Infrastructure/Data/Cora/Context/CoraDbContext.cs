using CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Cora;
using CloudSuite.Modules.Cora.Domain.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Cora.Context
{
	public class CoraDbContext : DbContext
	{
        public CoraDbContext(DbContextOptions<CoraDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Extract> Extracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new ExtractEFCoreMapping());
            modelBuilder.ApplyConfiguration(new AccountEFCoreMapping());

            modelBuilder.Entity<Account>(c =>
            {
                c.ToTable("Accounts");
            });

            modelBuilder.Entity<Extract>(c =>
            {
                c.ToTable("Extracts");
            });
        }
    }
}
