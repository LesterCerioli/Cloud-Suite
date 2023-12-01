using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.ViewModels
{
    public class AccountViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome Banco")]
		[Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
		public string BankName { get; set; }

        [DisplayName("Banco Codigo")]
		[Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
		public string BankCode { get; set; }

        [DisplayName("Agencia")]
		[Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
		public string Agency { get; set; }

        [DisplayName("Conta Numero")]
		[Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
		public string AccountNumber { get; set; }

        [DisplayName("Digito Conta")]
		[Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
		public string DigitAccount { get; set; }
    }
}
