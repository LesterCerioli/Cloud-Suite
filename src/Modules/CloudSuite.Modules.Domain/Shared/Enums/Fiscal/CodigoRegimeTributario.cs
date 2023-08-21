using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Shared.Enums.Fiscal
{
    public enum CodigoRegimeTributario
    {
        /// <summary>
        /// 0 - Não informado.
        /// </summary>
        NaoInformado = 0,

        /// <summary>
        /// Simples Nacional
        /// </summary>
        SimplesNacional = 1,

        /// <summary>
        /// Simples Nacional com Excesso de Sublimite de Receita Bruta
        /// </summary>
        SimplesNacionalExcessoSublimite = 2,

        /// <summary>
        /// Regime Normal
        /// </summary>
        RegimeNormal = 3
    }
}
