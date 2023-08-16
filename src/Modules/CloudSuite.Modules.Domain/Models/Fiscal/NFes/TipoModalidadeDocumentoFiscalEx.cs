namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes
{
    public static class TipoModalidadeDocumentoFiscalEx
    {
        private static readonly Type Typo = typeof(TipoModalidadeDocumentoFiscal);

        public static TipoModalidadeDocumentoFiscal Parse(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return (TipoModalidadeDocumentoFiscal)Enum.Parse(Typo, value);
        }
        
    }
}