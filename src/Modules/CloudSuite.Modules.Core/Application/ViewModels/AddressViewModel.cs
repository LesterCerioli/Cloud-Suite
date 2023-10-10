using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Core.Application.ViewModel
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("NomeContato")]
        [MaxLength(100)]
        public string? ContactName { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("EndereçoLinha1")]
        [MaxLength(450)]
        public string? AddressLine1 { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Cidade")]
        [MaxLength(100)]
        public string? City { get; private set; }

        [DisplayName("Distrito")]
        [MaxLength(100)]
        public string? District { get; private set; }

    }
}