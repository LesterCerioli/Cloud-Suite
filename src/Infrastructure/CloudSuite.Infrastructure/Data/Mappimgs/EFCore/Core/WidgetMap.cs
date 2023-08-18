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
    public class WidgetMap : IEntityTypeConfiguration<Widget>
    {
        public void Configure(EntityTypeBuilder<Widget> builder)
        {
            builder.Property(a => a.Name)
               .HasColumnName("Name")
               .HasColumnType("varchar(450)")
               .HasMaxLength(450)
               .IsRequired();

            builder.Property(a => a.ViewComponentName)
                .HasColumnName("ViewComponentName")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.CreateUrl)
               .HasColumnName("CreateUrl")
               .HasColumnType("varchar(450)")
               .HasMaxLength(450)
               .IsRequired();

            builder.Property(a => a.EditUrl)
                .HasColumnName("EditUrl")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.IsPublished)
              .HasColumnName("IsPublished")
              .HasColumnType("bit");

            builder.Property(y => y.CreatedOn)
               .HasColumnName("CreatedOn")
               .HasColumnType("DateTimeOffset")
               .IsRequired();
        }
    }
}
