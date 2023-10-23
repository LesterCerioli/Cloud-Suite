using System;
using System.Collections.Generic;
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
    }
}
