using CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Fiscal.NFes.Emissao
{
    public class DownloadInutilizacaoMap : IEntityTypeConfiguration<DownloadInutilizacao>
    {
        public void Configure(EntityTypeBuilder<DownloadInutilizacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Chave)
            .HasColumnName("Chave")
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
        }
    }
}