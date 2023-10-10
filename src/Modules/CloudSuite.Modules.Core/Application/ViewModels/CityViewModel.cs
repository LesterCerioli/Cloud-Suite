using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Core.Application.ViewModels
{
    public class CityViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "este campo é obrigatório.")]
        [DisplayName("NomeCidade")]
        [MaxLength(100)]
        public string? CityName { get; set; }
        
    }
}