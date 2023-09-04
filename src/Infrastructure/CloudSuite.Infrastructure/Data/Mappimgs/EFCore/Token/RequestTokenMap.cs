using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Token   
{
    /*
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

            builder.Property(c => c.NomeCompleto)
                .HasColumnName("NomeCompleto")
                .HasColumnType("varchar(40)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(c => c.TelefoneRegiao)
                .HasColumnName("TelefoneRegiao")
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("varchar(13)")
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(c => c.Created)
                .HasColumnName("Created")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.Validated)
                .HasColumnName("Validated")
                .HasColumnType("datetime");

            builder.Property(c => c.Token)
                .HasColumnName("Token")
                .HasColumnType("varchar(4)")
                .HasMaxLength(4)
                .IsRequired();
        }
    }
    */
}