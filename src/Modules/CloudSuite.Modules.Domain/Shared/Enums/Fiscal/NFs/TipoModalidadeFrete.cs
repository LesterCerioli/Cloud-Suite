namespace CloudSuite.Modules.Domain.Shared.Enums.Fiscal.NFs
{
    public enum TipoModalidadeFrete
    {
        /// <summary>
        /// 0 - Por conta do Emitente.
        /// </summary>
        Emitente = 0,

        /// <summary>
        /// 1 - Por conta do Destinatário.
        /// </summary>
        Destinatario = 1,

        /// <summary>
        /// 2 - Por conta do Terceiros.
        /// </summary>
        Terceiros = 2,

        /// <summary>
        /// 9 - Sem Frete.
        /// </summary>
        SemFrete = 9

    }
}