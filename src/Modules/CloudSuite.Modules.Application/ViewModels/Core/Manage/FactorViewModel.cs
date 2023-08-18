using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels.Core.Manage
{
    public class FactorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string? Purpose { get; set; }
    }
}
