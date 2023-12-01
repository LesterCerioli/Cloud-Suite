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
	public class TransferEFCoreMapping : IEntityTypeConfiguration<Transfer>
	{
		public void Configure(EntityTypeBuilder<Transfer> builder)
		{
			throw new NotImplementedException();
		}
	}
}
