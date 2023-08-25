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
        [DisplayName("Name")]
        [MaxLength(450)]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Slug")]
        [MaxLength(450)]
        public string Slug { get; private set; }

        [DisplayName("Description")]
        public string Description { get; private set; }

        [DisplayName("Cnpj")]
        [MaxLength(14)]
        public string Cnpj { get; private set; }

        [DisplayName("Email")]
        [MaxLength(100)]
        public string Email { get; private set; }

        public DateTimeOffset CreatedOn { get; private set; }

        public DateTimeOffset LatestUpdatedOn { get; private set; }

        public bool IsActive { get; private set; }

        public bool IsDeleted { get; private set; }

        [DisplayName("User")]
        [MaxLength(100)]
        public string User { get; private set; }

        public Guid UserId { get; private set; }
    }
}
