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
    public class CountryViewModel
    {
        [Key] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("NomePaís")]
        [MaxLength(450)]
        public string? CountryName { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Código3")]
        [MaxLength(450)]
        public string? Code3 { get; private set; }

    }
}
