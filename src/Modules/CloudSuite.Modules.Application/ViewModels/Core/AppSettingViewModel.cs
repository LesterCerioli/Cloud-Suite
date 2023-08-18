using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class AppSettingViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string? Key { get; set; }

        public string? Value { get; set; }
    }
}
