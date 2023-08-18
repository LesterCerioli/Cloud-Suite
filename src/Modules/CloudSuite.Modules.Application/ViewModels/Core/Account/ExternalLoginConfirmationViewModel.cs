using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels.Core.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage ="The {0} field is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="The {0} field is required.")]
        [Display(Name = "Name")]
        public string FullName { get; set; }
    }
}
