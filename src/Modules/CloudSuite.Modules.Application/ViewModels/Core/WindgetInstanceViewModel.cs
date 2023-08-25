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
        [DisplayName("Name")]
        [MaxLength(450)]
        public string Name { get; private set; }

        public DateTimeOffset CreatedOn { get; private set; }

        public DateTimeOffset LatestUpdatedOn { get; private set; }


        public DateTimeOffset PublishStart { get; private set; }

        public DateTimeOffset PublishEnd { get; private set; }

        [DisplayName("WidgetId")]
        [MaxLength(450)]
        public string WidgetId { get; private set; }

        [DisplayName("Widget")]
        public string Widget { get; private set; }

        [DisplayName("WidgetZone")]
        public string WidgetZone { get; private set; }

        public int DisplayOrder { get; set; }

        public string Data { get; set; }

        public string HtmlData { get; set; }

    }
}
