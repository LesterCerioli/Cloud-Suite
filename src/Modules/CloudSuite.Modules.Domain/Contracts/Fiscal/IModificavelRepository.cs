using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Contracts.Fiscal
{
<<<<<<< HEAD:src/Modules/CloudSuite.Modules.Domain/Contracts/Fiscal/IModificavelRepository.cs
    public interface IModificavelRepository
    {
        bool Modificado { get; }
=======
    public class ExternalLoginConfirmationViewModel
    {   
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="The {0} field is required.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage ="The {0} field is required.")]
        [Display(Name = "Name")]
        public string? FullName { get; set; }
>>>>>>> b4b71ac91554233119de5d6dbb767686a42a3641:src/Modules/CloudSuite.Modules.Application/ViewModels/Core/Account/ExternalLoginConfirmationViewModel.cs
    }
}
