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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(a => a.Company)
                .WithMany()
                .HasForeignKey(a => a.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Cnpj)
                .WithMany()
                .HasForeignKey(a => a.Cnpj)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
