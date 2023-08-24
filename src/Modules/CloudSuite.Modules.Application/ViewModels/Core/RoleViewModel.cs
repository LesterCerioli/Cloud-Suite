using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class RoleViewModel
    {
        [DisplayName("Users")]
        public string Users { get; set; }

        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("UserRole")]
        [MaxLength(100)]
        public string UserRole { get; private set; }
    }
}
