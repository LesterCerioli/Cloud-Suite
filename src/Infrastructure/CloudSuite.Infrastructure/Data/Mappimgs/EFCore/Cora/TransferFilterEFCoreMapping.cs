using CloudSuite.Modules.Cora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Cora
{
	public class TransferFilterEFCoreMapping : IEntityTypeConfiguration<TransferFilter>
	{
		public void Configure(EntityTypeBuilder<TransferFilter> builder)
		{
			builder.HasKey(d => d.Id);

			builder.Property(d => d.StartDate)
				.IsRequired(); // Adjust as needed

			builder.Property(d => d.EndDate)
				.IsRequired(); // Adjust as needed

			builder.Property(d => d.Page)
				.HasMaxLength(50);
		}
	}
}
