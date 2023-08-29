using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Shared.Enums.Fiscal.IcmsContext
{
    public enum SituacaoTributariaISSQN
    {
        /// <summary>
        /// Não Informado
        /// </summary>
        NaoEspecificado = -1,

        /// <summary>
        /// N - Normal
        /// </summary>
        Normal = 1,

        /// <summary>
        /// R - Retida
        /// </summary>
        Retida = 2,

        /// <summary>
        /// S - Substituta
        /// </summary>
        Substituta = 3,

        /// <summary>
        /// I - Isenta
        /// </summary>
        Isenta = 4
    }
}
