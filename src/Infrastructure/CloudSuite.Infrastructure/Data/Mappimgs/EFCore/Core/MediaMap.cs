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
    public class MediaMap : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.Property(a => a.Caption)
                .HasColumnName("Caption")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.FileSize)
                .HasColumnName("FileSize")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.FileName)
                .HasColumnName("FileName")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            //builder.HasOne(a => a.MediaType)
              //  .WithMany()
                //.HasForeignKey(a => a.MediaType)
                //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
