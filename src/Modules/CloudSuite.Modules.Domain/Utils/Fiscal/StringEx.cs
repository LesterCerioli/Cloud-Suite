namespace CloudSuite.Modules.Domain.Utils.Fiscal
{
    public static class StringEx
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (value == null) return null;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
        
    }
}