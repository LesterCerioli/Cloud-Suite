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

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(450)]
        public string? Value { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(450)]
        public string? Module { get; private set; }

        public bool? IsVisibleInCommonSettingPage { get; private set; }
    }
}
