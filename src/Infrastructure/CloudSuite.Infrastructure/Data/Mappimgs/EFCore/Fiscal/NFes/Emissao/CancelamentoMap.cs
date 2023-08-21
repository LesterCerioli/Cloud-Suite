using CloudSuite.Modules.Domain.Models.Fiscal.NFes.Emissao;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Fiscal.NFes.Emissao
{
    public class CancelamentoMap : IEntityTypeConfiguration<Cancelamento>
    {
        public void Configure(EntityTypeBuilder<Cancelamento> builder)
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

            builder.Property(c => c.DhEvento)
            .HasColumnName("DhEvento")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.NProt)
            .HasColumnName("NProt")
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