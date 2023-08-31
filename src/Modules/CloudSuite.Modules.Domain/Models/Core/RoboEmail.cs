using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class RoboEmail : Entity, IAggregateRoot
    {
        public RoboEmail(string? emailAddressSender, string? subject, string? body, DateTimeOffset? receivedTime, string? messageRecipient)
        {
            EmailAddressSender = emailAddressSender;
            Subject = subject;
            Body = body;
            ReceivedTime = receivedTime;
            MessageRecipient = messageRecipient;
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(100)]
        public string? EmailAddressSender { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(10)]
        public string? Subject { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(100)]
        public string? Body { get; private set; }

        //Data e hora de reebimento do email
        public DateTimeOffset? ReceivedTime { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(100)]
        public string? MessageRecipient { get; private set; }
        
    }
}