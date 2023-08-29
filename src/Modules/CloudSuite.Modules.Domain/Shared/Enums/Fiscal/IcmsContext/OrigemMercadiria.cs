using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Shared.Enums.Fiscal.IcmsContext
{
    public enum OrigemMercadiria
    {
        /// <summary>
        /// Não Especificado (-1).
        /// </summary>
        NaoEspecificado = -1,

        /// <summary>
        /// Nacional (0).
        /// </summary>
        Nacional = 0,

        /// <summary>
        /// Estrangeira com Importação Direta (1).
        /// </summary>
        EstrangeiraDireta = 1,

        /// <summary>
        /// Estrangeira adquirida no Mercado Interno (2).
        /// </summary>
        EstrangeiraIndireta = 2
    }
}
