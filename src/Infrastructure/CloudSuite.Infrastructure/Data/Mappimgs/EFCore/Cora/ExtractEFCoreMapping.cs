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
	public class ExtractEFCoreMapping : IEntityTypeConfiguration<Extract>
	{
		public void Configure(EntityTypeBuilder<Extract> builder)
		{
			builder.HasKey(e => e.Id);
		}
	}
}
