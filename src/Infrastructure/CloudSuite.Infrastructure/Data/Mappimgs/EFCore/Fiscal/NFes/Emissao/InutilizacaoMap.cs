using CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Fiscal.NFes.Emissao
{
    public class InutilizacaoMap : IEntityTypeConfiguration<Inutilizacao>
    {
        public void Configure(EntityTypeBuilder<Inutilizacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CUF)
            .HasColumnName("CUF")
            .HasColumnType("int(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.TpAmb)
            .HasColumnName("TpAmb")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.Ano)
            .HasColumnName("Ano")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.OwnsOne(c => c.Cnpj)
            .Property(c => c.CnpjNumber)
            .HasColumnName("Cnpj")
            .HasColumnType("varchar(14)")
            .HasMaxLength(14)
            .IsRequired();

            builder.Property(c => c.Serie)
            .HasColumnName("Serie")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.NNFIni)
            .HasColumnName("NNFIni")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.NNFFin)
            .HasColumnName("NNFFin")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.XJust)
            .HasColumnName("XJust")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        }
    }
}