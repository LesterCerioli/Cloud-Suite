using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
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
        public string Name { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(450)]
        public string Slug { get; private set; }

        [StringLength(450)]
        public string MetaTitle { get; private set; }

        [StringLength(450)]
        public string MetaKeywords { get; private set; }

        public string MetaDescription { get; private set; }

        public bool IsPublished { get; private set; }

        public DateTimeOffset PublishedOn { get; private set; }

        public long CreatedById { get; private set; }

        public string CreatedBy { get; private set; }

        public DateTimeOffset CreatedOn { get; private set; }

        public DateTimeOffset LatestUpdatedOn { get; private set; }

        public long LatestUpdatedById { get; private set; }

        public string LatestUpdatedBy { get; private set; }
    }
}
