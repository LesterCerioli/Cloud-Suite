using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class RoboEmailViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string? EmailAddressSender { get; private set; }

        public string? Subject { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string? Body { get; private set; }

        //Data e hora de reebimento do email
        public DateTimeOffset ReceivedTime { get; private set; }

        public string? MessageRecipient { get; private set; }
    }
}