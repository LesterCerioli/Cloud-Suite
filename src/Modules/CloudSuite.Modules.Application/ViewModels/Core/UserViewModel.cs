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
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [MaxLength(450)]
        [DisplayName("FullName")]
        public string? FullName { get; private set; }

        [DisplayName("Email")]
        [MaxLength(100)]
        public Email Email { get; private set; }

        [DisplayName("Cpf")]
        [MaxLength(11)]
        public Cpf Cpf { get; private set; }

        public Vendor Vendor { get; private set; }

        public bool? IsDeleted { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public DateTimeOffset? LatestUpdatedOn { get; private set; }

        [StringLength(450)]
        public string? RefreshTokenHash { get; private set; }

        [StringLength(450)]
        public string? Culture { get; private set; }

        /// <inheritdoc />
        public string? ExtensionData { get; private set; }

        public IReadOnlyCollection<Vendor> Vendors => _vendors.AsReadOnly();

        // public Customer Customer { get; private set; }


        public Guid VendorId { get; private set; }

        public IList<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
