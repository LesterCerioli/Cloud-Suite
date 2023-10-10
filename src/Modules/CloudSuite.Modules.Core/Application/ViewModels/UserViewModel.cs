using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Core.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [MaxLength(450)]
        [DisplayName("NomeCompleto")]
        public string? FullName { get; private set; }

        [DisplayName("Email")]
        [MaxLength(100)]
        public string? Email { get; private set; }

        [DisplayName("NúmeroCpf")]
        [MaxLength(11)]
        public string? CpfNumber { get; private set; }

        [DisplayName("NomeFornecedor")]
        [MaxLength(100)]
        public string? VendorName { get; private set; }

        [DisplayName("IsDeleted")]
        public bool? IsDeleted { get; private set; }

        [DisplayName("CriadoEm")]
        public DateTime? CreatedOn { get; private set; }

        [DisplayName("ÚltimaAtulizaçãoEm")]
        public DateTime? LatestUpdatedOn { get; private set; }

        [DisplayName("RefreshTokenHash")]
        [MaxLength(450)]
        public string? RefreshTokenHash { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Cultura")]
        [MaxLength(450)]
        public string? Culture { get; private set; }

        /// <inheritdoc />
        [DisplayName("ExtensãoData")]
        [MaxLength(100)]
        public string? ExtensionData { get; private set; }
        
    }
}