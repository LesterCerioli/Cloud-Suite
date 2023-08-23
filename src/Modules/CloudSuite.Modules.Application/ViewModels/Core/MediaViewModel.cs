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
    public class MediaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Caption")]
        [MaxLength(450)]
        public string Caption { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("FileSize")]
        public int FileSize { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [MaxLength(450)]
        public string FileName { get; set; }

        public string MediaType { get; set; }
    }
}
