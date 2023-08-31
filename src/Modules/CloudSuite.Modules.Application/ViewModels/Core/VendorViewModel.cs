
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class VendorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Nome")]
        [MaxLength(450)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Slug")]
        [MaxLength(450)]
        public string? Slug { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Descrição")]
        [MaxLength(100)]
        public string? Description { get; private set; }

        [DisplayName("NúmeroCnpj")]
        [MaxLength(14)]
        public string? CnpjNumber { get; private set; }

        [DisplayName("Email")]
        [MaxLength(100)]
        public string? Email { get; private set; }

        [DisplayName("CrieadoEm")]
        public DateTime? CreatedOn { get; private set; }

        [DisplayName("ÚltimaAtulizaçãoEm")]
        public DateTime? LatestUpdatedOn { get; private set; }

        [DisplayName("EstáAtivo")]
        public bool? IsActive { get; private set; }

        [DisplayName("IsDeleted")]
        public bool? IsDeleted { get; private set; }

        [DisplayName("NomeUsuário")]
        [MaxLength(100)]
        public string? UserName { get; private set; }
    }
}
