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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FullName)
                .HasColumnName("FullName")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.RefreshTokenHash)
                .HasColumnName("RefreshTokenHash")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.Culture)
                .HasColumnName("Culture")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

                builder.Property(a => a.ExtensionData)
                .HasColumnName("ExtensionData")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

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

            builder.OwnsOne(p => p.Cpf)
                            .Property(p => p.CpfNumber).HasColumnName("Cpf");

            builder.OwnsOne(p => p.Email)
                            .Property(p => p.EmailAddress).HasColumnName("Email");

            builder.HasOne(a => a.Vendor)
                .WithMany()
                .HasForeignKey(a => a.VendorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
