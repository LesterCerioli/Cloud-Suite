namespace CloudSuite.Modules.Common.Enums.Fiscal
{
    public enum Services
    {
        #region NFSe
        /// <summary>
        /// Enviar Lote RPS NFS-e 
        /// </summary>
        RecepcionarLoteRps,
        /// <summary>
        /// Consultar Situação do lote RPS NFS-e
        /// </summary>
        ConsultarSituacaoLoteRps,
        /// <summary>
        /// Consultar NFS-e por RPS
        /// </summary>
        ConsultarNfsePorRps,
        /// <summary>
        /// Consultar NFS-e por NFS-e
        /// </summary>
        ConsultarNfse,
        /// <summary>
        /// Consultar lote RPS
        /// </summary>
        ConsultarLoteRps,
        /// <summary>
        /// Cancelar NFS-e
        /// </summary>
        CancelarNfse,
        /// <summary>
        /// Consultar a URL de visualização da NFSe
        /// </summary>
        ConsultarURLNfse,
        #endregion

        /// <summary>
        /// Nulo / Nenhum serviço em execução
        /// </summary>        
        Nulo
        
    }
}