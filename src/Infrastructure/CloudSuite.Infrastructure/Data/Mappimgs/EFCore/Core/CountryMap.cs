using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Core
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CountryName)
                .HasColumnName("CountryName")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(c => c.Code3)
                .HasColumnName("Code3")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.IsBillingEnabled)
                .HasColumnName("IsBillingEnabled")
                .HasColumnType("bit");

            builder.Property(a => a.IsShippingEnabled)
                .HasColumnName("IsShippingEnabled")
                .HasColumnType("bit");

            builder.Property(a => a.IsCityEnabled)
                .HasColumnName("IsCityEnabled")
                .HasColumnType("bit");

            builder.Property(a => a.IsZipCodeEnabled)
                .HasColumnName("IsZipCodeEnabled")
                .HasColumnType("bit");

            builder.Property(a => a.IsDistrictEnabled)
                .HasColumnName("IsDistrictEnabled")
                .HasColumnType("bit");

            builder.HasOne(a => a.States)
                .WithMany()
                .HasForeignKey(a => a.StateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
