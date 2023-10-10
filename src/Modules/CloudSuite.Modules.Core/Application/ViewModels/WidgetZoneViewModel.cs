using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


amespace CloudSuite.Modules.Core.Application.ViewModels
{
    public class WidgetZoneViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Nome")]
        [MaxLength(450)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Descrição")]
        [MaxLength(100)]
        public string? Description { get; set; }
        
    }
}