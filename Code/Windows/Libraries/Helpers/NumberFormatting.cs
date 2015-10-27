using System;

namespace Helpers
{
    public static class NumberFormatting
    {
        public static double Format(this double value)
        {
            return value.Format(0);
        }

        public static double Format(this double value, int decimalPlace)
        {
            var absVal = Math.Abs(value);

                if (absVal < 1 && absVal > 0)
                {
                    return Math.Round(value, absVal < 0.1 ? GetSignificantDigitPlace(value) : decimalPlace + 1, MidpointRounding.AwayFromZero);
                }
                return Math.Round(value, decimalPlace, MidpointRounding.AwayFromZero);

        }

        public static decimal Format(this decimal value)
        {
            return value.Format(0);  
        }

        public static decimal Format(this decimal value, int decimalPlace)
        {
            var absVal = Math.Abs(value);

                if (absVal < 1 && absVal > 0)
                {
                    return Math.Round(value, (double)absVal < 0.1 ? GetSignificantDigitPlace((double)value) : decimalPlace + 1, MidpointRounding.AwayFromZero);
                }
                return Math.Round(value, decimalPlace, MidpointRounding.AwayFromZero);
      }

        private static int GetSignificantDigitPlace(double value)
        {
            var i = 0;
            while (Math.Abs(value) < 1)
            {
                value *= 10;
                i++;
            }

            return i;
        }


    }
}