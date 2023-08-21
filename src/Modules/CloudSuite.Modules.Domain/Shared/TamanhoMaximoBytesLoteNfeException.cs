using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Shared
{
    public class TamanhoMaximoBytesLoteNfeException 
    {
        [Key]
        public Guid Id { get; set; }
        public string? Key { get; set; }

        public string? Value { get; set; }
    }
}
