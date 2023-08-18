
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Core.Context
{
    public class CloudSuiteDbContext : DbContext
    {
        public CloudSuiteDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<AppSetting> AppSettings { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        // public DbSet<Customer> Customers { get; set; }

        // public DbSet<CustomerGroup> CustomerGroups { get; set; }

        public DbSet<District> Districts { get; set; } 

        public DbSet<Entidade> Entidades { get; set; }

        public DbSet<EntidadeTipo> EntidadeTipos { get; set; }

        public DbSet<Media> Medias { get; set; }

        public DbSet<Role> Roles { get; set; }  

        public DbSet<State> States { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
        
        public DbSet<Widget> Widgets { get; set; }

        public DbSet<WidgetInstance> WidgetInstances { get; set; }

        public DbSet<WidgetZone> WidgetZones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<EventArgs>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //modelBuilder.ApplyConfiguration(new AddressMap());
            //modelBuilder.ApplyConfiguration(new AppSettingMap());
            //modelBuilder.ApplyConfiguration(new CityMap());
            //modelBuilder.ApplyConfiguration(new CountryMap());
            //modelBuilder.ApplyConfiguration(new CustomerMap());
            //modelBuilder.ApplyConfiguration(new CustomerGroupMap());
            //modelBuilder.ApplyConfiguration(new DistrictMap());
            //modelBuilder.ApplyConfiguration(new EntidadeMap());
            //modelBuilder.ApplyConfiguration(new EntidadeTipoMap());
            //modelBuilder.ApplyConfiguration(new MediaMap());
            //modelBuilder.ApplyConfiguration(new RoleMap());
            //modelBuilder.ApplyConfiguration(new StateMap());
            //modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new UserRoleMap());
            //modelBuilder.ApplyConfiguration(new VendorMap());
            //modelBuilder.ApplyConfiguration(new WidgetMap());
            //modelBuilder.ApplyConfiguration(new WidgetInstanceMap());
            //modelBuilder.ApplyConfiguration(new WidgetZoneMap());

            modelBuilder.Entity<Address>(c =>
            {
                c.ToTable("Addresses");
            });

            modelBuilder.Entity<AppSetting>(c =>
            {
                c.ToTable("AppSettings");
            });

            modelBuilder.Entity<City>(c =>
            {
                c.ToTable("Cities");
            });

            modelBuilder.Entity<Country>(c =>
            {
                c.ToTable("Contries");
            });

            // modelBuilder.Entity<Customer>(c =>
            // {
            //     c.ToTable("Customers");
            // });

            // modelBuilder.Entity<CustomerGroup>(c =>
            // {
            //     c.ToTable("CustomerGroups");
            // });

            // modelBuilder.Entity<CustomerGroupUser>(c =>
            // {
            //     c.ToTable("CustomerGroupUsers");
            // });

            modelBuilder.Entity<District>(c =>
            {
                c.ToTable("Districts");
            });

            modelBuilder.Entity<Entidade>(c =>
            {
                c.ToTable ("Entidades");
            });

            modelBuilder.Entity<EntidadeTipo>(c =>
            {
                c.ToTable("EntidadeTipos");
            });
            
            modelBuilder.Entity<Media>(c =>
            {
                c.ToTable("Medias");
            });

            modelBuilder.Entity<Role>(c =>
            {
                c.ToTable("Roles");
            });

            modelBuilder.Entity<State>(c =>
            {
                c.ToTable("States");
            });

            modelBuilder.Entity<User>(c =>
            {
                c.ToTable("Users");
            });

            modelBuilder.Entity<UserRole>(c =>
            {
                c.ToTable("UserRoles");
            });

            modelBuilder.Entity<Vendor>(c =>
            {
                c.ToTable("Vendors");
            });

            modelBuilder.Entity<Widget>(c =>
            {
                c.ToTable("Widgets");
            });

            modelBuilder.Entity<WidgetInstance>(c =>
            {
                c.ToTable("WidgetInstances");
            });

            modelBuilder.Entity<WidgetZone>(c =>
            {
                c.ToTable("WidgetZones");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
