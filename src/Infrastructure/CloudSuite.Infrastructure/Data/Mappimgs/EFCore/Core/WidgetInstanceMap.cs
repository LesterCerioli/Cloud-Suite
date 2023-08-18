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
    public class WidgetInstanceMap : IEntityTypeConfiguration<WidgetInstance>
    {
        public void Configure(EntityTypeBuilder<WidgetInstance> builder)
        {
            throw new NotImplementedException();
        }
    }
}
