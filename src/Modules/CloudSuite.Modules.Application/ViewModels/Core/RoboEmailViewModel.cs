using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class RoboEmailViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("EmailAddressSender")]
        [MaxLength(100)]
        public string EmailAddressSender { get; private set; }

        [DisplayName("Subject")]
        public string Subject { get; private set; }

        [DisplayName("Body")]
        public string Body { get; private set; }

        //Data e hora de reebimento do email
        [DisplayName("ReceivedTime")]
        public DateTimeOffset ReceivedTime { get; private set; }

        [DisplayName("MessageRecipient")]
        public string MessageRecipient { get; private set; }
    }
}
