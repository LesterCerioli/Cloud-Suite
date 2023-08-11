using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class AppSetting : Entity, IAggregateRoot
    {
        public AppSetting(Guid id)
        {
            Id = id;
        }

        [StringLength(450)]
        public string? Value { get; set; }

        [StringLength(450)]
        public string? Module { get; set; }

        public bool? IsVisibleInCommonSettingPage { get; set; }
    }
}
