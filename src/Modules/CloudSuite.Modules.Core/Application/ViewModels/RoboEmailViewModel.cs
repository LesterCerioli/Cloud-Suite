using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CloudSuite.Modules.Core.Application.ViewModels
{
    public class RoboEmailViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("EmailEndereçoRemetente")]
        [MaxLength(100)]
        public string? EmailAddressSender { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Assunto")]
        [MaxLength(10)]
        public string? Subject { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("Corpo")]
        [MaxLength(100)]
        public string? Body { get; private set; }

        //Data e hora de reebimento do email
        [DisplayName("DataRecebimento")]
        public DateTime ReceivedTime { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [DisplayName("DestinatarioMensagem")]
        [MaxLength(100)]
        public string? MessageRecipient { get; private set; }
        
    }
}