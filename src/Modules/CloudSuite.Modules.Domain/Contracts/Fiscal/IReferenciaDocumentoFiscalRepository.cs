using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CloudSuite.Modules.Domain.Contracts.Fiscal
{
<<<<<<< HEAD:src/Modules/CloudSuite.Modules.Domain/Contracts/Fiscal/IReferenciaDocumentoFiscalRepository.cs
    public interface IReferenciaDocumentoFiscalRepository
=======
    public class ResetPasswordViewModel
>>>>>>> b4b71ac91554233119de5d6dbb767686a42a3641:src/Modules/CloudSuite.Modules.Application/ViewModels/Core/Account/ResetPasswordViewModel.cs
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        public string? Code { get; set; }
    }
}
