namespace CloudSuite.Modules.Domain.Utils.Fiscal
{
    public static class DecimalExtensions
    {
        public static decimal TruncateDecimals(this decimal value, int digits)
        {
            return DecimalTruncator.Truncate(value, digits);
        }
    }

    internal static class DecimalTruncator
    {
        public static decimal Truncate(decimal value, int digits)
        {
            var maxDigits = (decimal)Math.Pow(10.0, digits);
            return decimal.Truncate(value * maxDigits) / maxDigits;
        }
    }
}