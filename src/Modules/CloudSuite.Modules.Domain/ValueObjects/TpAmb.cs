using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.ValueObjects
{
    public enum TpAmb
    {
        /// <summary>
        /// Ambiente de produção
        /// </summary>
        [Description("Produção")]
        Producao = 1,

        /// <summary>
        /// Ambiente de homologação
        /// </summary>
        [Description("Homologação")]
        Homologacao = 2
    }
}
