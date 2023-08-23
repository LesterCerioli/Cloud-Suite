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
    public class StateViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("StateName")]
        [MaxLength(100)]
        public string StateName { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("UF")]
        [MaxLength(2)]
        public string? UF { get; private set; }

        [DisplayName("Country")]
        [MaxLength(100)]
        public string Country { get; set; }

        [DisplayName("CountryId")]
        [MaxLength(100)]
        public Guid CountryId { get; private set; }

       
    }
}
