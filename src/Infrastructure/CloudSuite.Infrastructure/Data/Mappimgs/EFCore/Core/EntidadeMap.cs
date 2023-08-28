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
    public class EntidadeMap : IEntityTypeConfiguration<Entidade>
    {
        public void Configure(EntityTypeBuilder<Entidade> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Slug)
                .HasColumnName("Slug")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.HasOne(c => c.EntidadeTipo)
                .WithMany()
                .HasForeignKey(c => c.EntidadeTipoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
