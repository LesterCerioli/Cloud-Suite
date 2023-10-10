using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Core.Application.ViewModels
{
    public class CompanyViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("CnpjNumero")]
        [MaxLength(14)]
        public string? CnpjNumber { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("NomeFantasia")]
        [MaxLength(100)]
        public string? FantasyName { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("NomeRegistro")]
        [MaxLength(100)]
        public string? RegisterName { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("EndereçoLinha1")]
        [MaxLength(450)]
        public string? AddressLine1 { get; private set; }
        
    }
}