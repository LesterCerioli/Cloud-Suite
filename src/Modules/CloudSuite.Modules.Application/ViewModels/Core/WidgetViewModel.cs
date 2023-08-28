using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class WidgetViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Nome")]
        [MaxLength(450)]
        public string? Name { get; private set; }

        [DisplayName("ViewNomeComponente")]
        [MaxLength(450)]
        public string? ViewComponentName { get; private set; }

        [DisplayName("CriarUrl")]
        [MaxLength(450)]
        public string? CreateUrl { get; private set; }

        [DisplayName("EditarUrl")]
        [MaxLength(450)]
        public string? EditUrl { get; private set; }

        [DisplayName("CriadoEm")]
        public DateTime? CreatedOn { get; private set; }

        [DisplayName("EstáPublicado")]
        public bool? IsPublished { get; set; }
    }
}
