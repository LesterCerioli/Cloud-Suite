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
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.Property(a => a.StateName)
                .HasColumnName("StateName")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.UF)
                .HasColumnName("UF")
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();

            builder.HasOne(a => a.Country)
                .WithMany()
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
