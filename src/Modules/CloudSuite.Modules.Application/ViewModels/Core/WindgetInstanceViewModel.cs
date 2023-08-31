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
    public class WindgetInstanceViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Nome")]
        [MaxLength(450)]
        public string? Name { get; private set; }

        [DisplayName("CriadoEm")]
        public DateTime? CreatedOn { get; private set; }

        [DisplayName("UltimaAtualizaçãoEm")]
        public DateTime? LatestUpdatedOn { get; private set; }

        [DisplayName("DataDeInicioDePublicação")]
        public DateTime?PublishStart { get; private set; }

        [DisplayName("DataDeFimDePublicação")]
        public DateTime? PublishEnd { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("WidgetId")]
        [MaxLength(450)]
        public string? WidgetId { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Dados")]
        [MaxLength(100)]
        public string? Data { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("DadosHtml")]
        [MaxLength(100)]
        public string? HtmlData { get; set; }

    }
}
