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
    public class ContentViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(450)]
        [DisplayName("Nome")]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(450)]
        [DisplayName("Slug")]
        public string? Slug { get; private set; }

        [Required(ErrorMessage = "O campo deve ser preenchido.")]
        [StringLength(450)]
        [DisplayName("MetaTitulo")]
        public string? MetaTitle { get; private set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido.")]
        [StringLength(450)]
        [DisplayName("MetaKeyWords")]
        public string? MetaKeywords { get; private set; }

        [Required(ErrorMessage = "este campo deve ser preenchido.")]
        [DisplayName("MetaDescription")]
        public string? MetaDescription { get; private set; }

        [DisplayName("isPublished")]
        public bool? IsPublished { get; private set; }

        [DisplayName("PublicadoPor")]
        public DateTimeOffset? PublishedOn { get; private set; }

        [DisplayName("CriadoPor")]
        public string? CreatedBy { get; private set; }

        [DisplayName("CriadoEm")]
        public DateTimeOffset? CreatedOn { get; private set; }

        [DisplayName("AtualizadoEm")]
        public DateTimeOffset? LatestUpdatedOn { get; private set; }

        [DisplayName("AtualizadoPor")]
        public string LatestUpdatedBy { get; private set; }
    }
}
