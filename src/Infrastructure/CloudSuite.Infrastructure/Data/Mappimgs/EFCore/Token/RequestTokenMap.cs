using CloudSuite.Modules.Domain.Models.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Token   
{
    public class RequestTokenMap : IEntityTypeConfiguration<RequestToken>
    {
        public void Configure(EntityTypeBuilder<RequestToken> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.RequestId)
                .HasColumnName("RequestId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(c => c.FullName)
                .HasColumnName("FullName")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Created)
                .HasColumnName("Created")
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(c => c.Validated)
                .HasColumnName("Validated")
                .HasColumnType("DateTime");

            builder.Property(c => c.Token)
                .HasColumnName("Token")
                .HasColumnType("varchar(4)")
                .HasMaxLength(4)
                .IsRequired();

            builder.OwnsOne(p => p.Telephone, telephone =>
            {
                telephone.Property(a => a.TelephoneNumber)
                .HasColumnName("TelephoneNumber")
                .HasColumnType("varchar(9)")
                .HasMaxLength(9)
                .IsRequired(); 

                telephone.Property(a => a.TelephoneRegion)
                .HasColumnName("TelephoneRegion")
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();
            });
        }
    }
}