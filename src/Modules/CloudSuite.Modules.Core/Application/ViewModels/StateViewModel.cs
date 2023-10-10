using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CloudSuite.Modules.Core.Application.ViewModels
{
    public class StateViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("EstadoNome")]
        [MaxLength(100)]
        public string? StateName { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("UF")]
        [MaxLength(2)]
        public string? UF { get; private set; }

        [DisplayName("NomePaís")]
        [MaxLength(100)]
        public string? CountryName { get; set; }
        
    }
}