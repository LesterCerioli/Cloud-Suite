using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class CityViemModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "este campo é obrigatório.")]
        [DisplayName("NomeCidade")]
        [MaxLength(45)]
        public string? CityName { get; set; }
    }
}
