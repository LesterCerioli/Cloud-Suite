namespace CloudSuite.Modules.Domain.Shared.Enums.Fiscal.NFs
{
    public enum TipoProdutoEspecifico
    {
        /// <summary>
        /// Indica que não é um produto específico.
        /// </summary>
        ProdutoNaoEspecifico = 0,

        /// <summary>
        /// Aplicado em caso de produto ser um Veículo Novo.
        /// </summary>
        VeiculoNovo = 1,

        /// <summary>
        /// Aplicado em caso do produto ser Medicamento.
        /// </summary>
        Medicamento = 2,

        /// <summary>
        /// Aplicado em caso do produto ser Armamento.
        /// </summary>
        Armamento = 3,

        /// <summary>
        /// Aplicado em caso do produto ser Combustível.
        /// </summary>
        Combustivel = 4,

        /// <summary>
        /// Aplicado em caso de produto ser relacionado a Papel Imune.
        /// </summary>
        PapelImune = 5

    }
}