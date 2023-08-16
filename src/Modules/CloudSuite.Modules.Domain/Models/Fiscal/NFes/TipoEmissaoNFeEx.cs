namespace CloudSuite.Modules.Domain.Models.Fiscal.NFes
{
    public static class TipoEmissaoNFeEx
    {
        public static string GetCustomValue(this TipoEmissaoNF source)
        {
            return ((int)source).ToString();
        }

        public static TipoEmissaoNF Parse(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return (TipoEmissaoNF)Enum.Parse(typeof(TipoEmissaoNF), value);
        }
        
    }
}