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
	public class AccountEFCoreMapping : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.HasKey(c => c.Id);

			
			builder.Property(c => c.Agency)
				.HasMaxLength(6); // Adjust the maximum length as needed

			builder.Property(c => c.AccountNumber)
				.HasMaxLength(10); // Adjust the maximum length as needed

			builder.Property(c => c.AccountDigit)
				.HasMaxLength(1); // Adjust the maximum length as needed

			builder.Property(c => c.BankName)
				.HasMaxLength(100); // Adjust the maximum length as needed

			builder.Property(c => c.BankCode)
				.HasMaxLength(20); // Adjust the maximum length as needed
		}
	}
}
