using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class CustomerGroupForm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string? Name { get; set; }

        public string? Desccription { get; set; }

        public bool IsActive { get; set; }

        
    }
}
