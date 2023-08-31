﻿using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Core
{
    public class AppSettingMap : IEntityTypeConfiguration<AppSetting>
    {     
        public void Configure(EntityTypeBuilder<AppSetting> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Value)
                .HasColumnName("Value")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.Module)
                .HasColumnName("Module")
                .HasColumnType("varchar(450)")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(a => a.IsVisibleInCommonSettingPage)
                .HasColumnName("IsVisibleInCommonSettingPage")
                .HasColumnType("bit");
                
        }
    }
}
