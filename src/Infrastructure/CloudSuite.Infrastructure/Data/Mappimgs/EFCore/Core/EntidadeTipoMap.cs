using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Core
{
    public class EntidadeTipoMap : IEntityTypeConfiguration<EntidadeTipo>
    {
        public void Configure(EntityTypeBuilder<EntidadeTipo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(c => c.AreaName)
                .HasColumnName("AreaName")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(c => c.RoutingController)
                .HasColumnName("RoutingController")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(c => c.RoutingAction)
                .HasColumnName("RoutingAction")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.IsMenuable)
                .HasColumnName("IsMenuable")
                .HasColumnType("bit");

        }
    }
}
