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
    public class CustomerGroupMap : IEntityTypeConfiguration<CustomerGroup>
    {
        public void Configure(EntityTypeBuilder<CustomerGroup> builder)
        {
            builder.HasKey();

            builder.Property(a => a.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
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

            builder.HasOne(a => a.CustomerGroupUser)
                .WithMany()
                .HasForeignKey(a => a.CustomerGroupUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
