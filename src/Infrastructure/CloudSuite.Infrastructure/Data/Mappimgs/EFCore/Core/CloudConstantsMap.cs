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
    public class CloudConstantsMap : IEntityTypeConfiguration<CloudConstants>
    {
        public void Configure(EntityTypeBuilder<CloudConstants> builder)
        {
        }
    }
}
