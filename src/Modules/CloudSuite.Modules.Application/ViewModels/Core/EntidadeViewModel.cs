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
    public class EntidadeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(450)]
        [DisplayName("Slug")]
        public string? Slug { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(450)]
        public string Name { get; set; }

        [StringLength(450)]
        public string EntityTypeId { get; set; }

        public EntidadeTipo EntityType { get; set; }
    }
}
