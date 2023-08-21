using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Shared.Enums
{
    public enum ModalidadeBaseCalculo
    {
        // <summary>
        /// Não Informado (-1).
        /// </summary>
        NaoEspecificado = -1,

        /// <summary>
        /// 0 - Margem do Valor Agregado em Porcentagem
        /// </summary>
        MargemAgregado = 0,

        /// <summary>
        /// 1 - Pauta em Valor
        /// </summary>
        Pauta = 1,

        /// <summary>
        /// 2 - Preço Tabelado Máximo em Valor
        /// </summary>
        PrecoTabelado = 2,

        /// <summary>
        /// 3 - Valor da Operação
        /// </summary>
        ValorOperacao = 3
    }
}
