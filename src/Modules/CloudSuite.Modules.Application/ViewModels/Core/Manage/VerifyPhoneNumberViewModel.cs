using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels.Core.Manage
{
    internal class VerifyPhoneNumberViewModel
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
