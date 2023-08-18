using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels.Core.Account
{
    public class SendCodeViewModel


    {   
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Telephone { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}