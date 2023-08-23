using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class AppSettingViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(450)]
        [DisplayName("Value")]
        public string? Value { get; private set; }

        [StringLength(450)]
        [DisplayName("Module")]
        public string? Module { get; private set; }

        public bool? IsVisibleInCommonSettingPage { get; private set; }
    }
}
