using CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Fiscal.NFes.Emissao
{
    public class DownloadEventoMap : IEntityTypeConfiguration<DownloadEvento>
    {
        public void Configure(EntityTypeBuilder<DownloadEvento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ChNFe)
            .HasColumnName("ChNFe")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.TpAmb)
            .HasColumnName("TpAmb")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.TpDown)
            .HasColumnName("TpDown")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.TpEvento)
            .HasColumnName("TpEvento")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.NSeqEvento)
            .HasColumnName("NSeqEvento")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        }
    }
}