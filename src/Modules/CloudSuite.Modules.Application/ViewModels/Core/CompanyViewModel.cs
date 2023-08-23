using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class CompanyViewModel 
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Este campo é de preenchimento obrigatório.")]
        [DisplayName("CnpjNumber")]
        [MaxLength(14)]
        [MinLength(14)]
        public string CnpjNumber { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("FantasyName")]
        [MaxLength(100)]
        public string FantasyName { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("RegisterName")]
        [MaxLength(100)]
        public string RegisterName { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("AddressLine1")]
        public string? AddressLine1 { get; private set; }
        
    }
}