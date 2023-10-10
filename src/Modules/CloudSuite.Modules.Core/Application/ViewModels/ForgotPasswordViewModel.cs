using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Core.Application.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("EmailAddress")]
        [Required(ErrorMessage = "Informe o email!!")]
        public string EmailAddress { get; private set; }
        
    }
}