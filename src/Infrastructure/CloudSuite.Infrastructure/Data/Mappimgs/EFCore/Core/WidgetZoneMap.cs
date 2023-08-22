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
    public class WidgetZoneMap : IEntityTypeConfiguration<WidgetZone>
    {
        public void Configure(EntityTypeBuilder<WidgetZone> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
               .HasColumnName("Name")
               .HasColumnType("varchar(450)")
               .HasMaxLength(450)
               .IsRequired();

            builder.Property(a => a.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
