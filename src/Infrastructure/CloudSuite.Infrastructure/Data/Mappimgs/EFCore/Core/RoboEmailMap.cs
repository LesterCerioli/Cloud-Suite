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
    public class RoboEmailMap : IEntityTypeConfiguration<RoboEmail>
    {
        public void Configure(EntityTypeBuilder<RoboEmail> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.EmailAddressSender)
                .HasColumnName("EmailAddressSender")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Subject)
                .HasColumnName("Subject")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Body)
                .HasColumnName("Body")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.MessageRecipient)
                .HasColumnName("MessageRecipient")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(y => y.ReceivedTime)
               .HasColumnName("ReceivedTime")
               .HasColumnType("DateTimeOffset")
               .IsRequired();
        }
    }
}
