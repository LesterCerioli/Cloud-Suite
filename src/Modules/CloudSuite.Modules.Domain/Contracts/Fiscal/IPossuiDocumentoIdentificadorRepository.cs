using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Fiscal
{
    public interface IPossuiDocumentoIdentificadorRepository
    {
        string CNPJ { get; set; }
        string CPF { get; set; }
    }
}
