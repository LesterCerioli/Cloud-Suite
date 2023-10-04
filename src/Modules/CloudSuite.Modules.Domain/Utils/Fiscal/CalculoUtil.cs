namespace CloudSuite.Modules.Domain.Utils.Fiscal
{
    internal static class Modulo11Calculator
    {
        public static int Calculate(string value)
        {
            int multiplier = 2; // Initial value
            int weighting = 0;

            for (int i = value.Length - 1; i >= 0; i--)
            {
                weighting += Convert.ToInt32(value[i].ToString()) * multiplier++; // Position value * multiplier
                if (multiplier > 9)
                    multiplier = 2;
            }

            int remainder = (weighting % 11);

            int digit = 0;
            if (remainder > 1)
                digit = 11 - remainder;

            return digit;
        }

        
    }
}