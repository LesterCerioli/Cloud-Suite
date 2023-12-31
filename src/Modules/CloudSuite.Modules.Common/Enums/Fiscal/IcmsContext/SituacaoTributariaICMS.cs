namespace CloudSuite.Modules.Common.Enums.Fiscal.IcmsContext
{
    public enum SituacaoTributariaICMS
    {
        /// <summary>
        /// Não Especificado
        /// </summary>
        NaoEspecificado = -1,

        /// <summary>
        /// 00 - Tributada integralmente
        /// </summary>
        Cst00 = 0,

        /// <summary>
        /// 10 - Tributada e com cobrança do ICMS por substituição tributária
        /// </summary>
        Cst10 = 10,

        /// <summary>
        /// 20 - Com redução de base de cálculo
        /// </summary>
        Cst20 = 20,
    }
}