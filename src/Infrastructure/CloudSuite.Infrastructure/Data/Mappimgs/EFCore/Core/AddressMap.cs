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
        public class AddressMap : IEntityTypeConfiguration<Address>
        {
            public void Configure(EntityTypeBuilder<Address> builder)
            {
                builder.HasKey(c => c.Id);

                builder.Property(c => c.ContactName)
                    .HasColumnName("ContactName")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                builder.Property(c => c.AddressLine1)
                    .HasColumnName("AddressLine1")
                    .HasColumnType("varchar(450)")
                    .HasMaxLength(450)
                    .IsRequired();

                builder.HasOne(c => c.District)
                    .WithMany()
                    .HasForeignKey(c => c.DistrictId)
                    .OnDelete(DeleteBehavior.Restrict);

            }
        }
    }
