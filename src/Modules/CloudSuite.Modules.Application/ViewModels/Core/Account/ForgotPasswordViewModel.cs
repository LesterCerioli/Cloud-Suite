using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CloudSuite.Modules.Application.ViewModels.Core.Account
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="The {0} field is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
