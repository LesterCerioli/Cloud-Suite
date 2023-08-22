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
    public class WidgetInstanceMap : IEntityTypeConfiguration<WidgetInstance>
    {
        public void Configure(EntityTypeBuilder<WidgetInstance> builder)
        {
            builder.Property(a => a.Name)
               .HasColumnName("Name")
               .HasColumnType("varchar(450)")
               .HasMaxLength(450)
               .IsRequired();

            builder.Property(a => a.WidgetId)
                .HasColumnName("WidgetId")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.Data)
                .HasColumnName("Data")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

                builder.Property(a => a.HtmlData)
                .HasColumnName("HtmlData")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

                builder.Property(a => a.DisplayOrder)
                .HasColumnName("DisplayOrder")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.IsPublished)
              .HasColumnName("IsPublished")
              .HasColumnType("bit");

            builder.Property(y => y.CreatedOn)
               .HasColumnName("CreatedOn")
               .HasColumnType("DateTimeOffset")
               .IsRequired();

            builder.Property(y => y.LatestUpdatedOn)
               .HasColumnName("LatestUpdatedOn")
               .HasColumnType("DateTimeOffset")
               .IsRequired();

            builder.Property(y => y.PublishStart)
               .HasColumnName("PublishStart")
               .HasColumnType("DateTimeOffset")
               .IsRequired();

            builder.Property(y => y.PublishEnd)
               .HasColumnName("PublishEnd")
               .HasColumnType("DateTimeOffset")
               .IsRequired();

            builder.HasOne(a => a.Widget)
               .WithMany()
               .HasForeignKey(a => a.WidgetId)
               .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(a => a.WidgetZone)
                .WithMany()
                .HasForeignKey(a => a.WidgetZoneId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
