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
    public class DistrictMap : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.Property(a => a.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.Type)
                .HasColumnName("Type")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.Location)
                .HasColumnName("Location")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(a => a.State)
                .WithMany()
                .HasForeignKey(a => a.StateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
