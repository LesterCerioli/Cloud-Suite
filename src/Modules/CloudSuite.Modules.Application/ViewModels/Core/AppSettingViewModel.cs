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
        [DisplayName("Valor")]
        public string? Value { get; private set; }

        [StringLength(450)]
        [DisplayName("Modulo")]
        public string? Module { get; private set; }

        [DisplayName("IsVisibleInCommonSettingPage")]
        public bool? IsVisibleInCommonSettingPage { get; private set; }
    }
}
