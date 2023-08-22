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
    public class VendorMap : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.Slug)
                .HasColumnName("Slug")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.IsActive)
              .HasColumnName("IsActive")
              .HasColumnType("bit");

            builder.Property(a => a.IsDeleted)
              .HasColumnName("IsDeleted")
              .HasColumnType("bit");

            builder.Property(y => y.CreatedOn)
               .HasColumnName("CreatedOn")
               .HasColumnType("DateTimeOffset")
               .IsRequired();

            builder.Property(y => y.LatestUpdatedOn)
               .HasColumnName("LatestUpdatedOn")
               .HasColumnType("DateTimeOffset")
               .IsRequired();

            builder.HasOne(a => a.Email)
               .WithMany()
               .HasForeignKey(a => a.EmailId)
               .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(a => a.Cnpj)
                .WithMany()
                .HasForeignKey(a => a.CnpjId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
