using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Shared.Helpers
{

    public class NumberToEnglish
    {
        public static string ConvertMoneyToWords(double number)
        {
            if (number == 0)
                return "";
            if (number < 0)
                number = number * -1;
            var result = "";
            var stringRepresentation = number.ToString("###.00");
            bool hasDecimalPlaces = stringRepresentation.IndexOf(".") >= 0;
            if (!hasDecimalPlaces)
                return ConvertToWords(Convert.ToInt64(number)) + " Birr Only";
            else
            {
                if (stringRepresentation.IndexOf('.') == 0)
                    stringRepresentation = stringRepresentation.Insert(0, "0");
                var split = stringRepresentation.Split('.');
                var beforeDecimal = split[0] != "" ? Convert.ToInt64(split[0]) : 0;
                var afterDecimal = Convert.ToInt64(split[1].Substring(0, 2));
                if (beforeDecimal > 0)
                    result += ConvertToWords(beforeDecimal) + " Birr ";
                if (afterDecimal > 0)
                {
                    if (beforeDecimal > 0)
                        result += "and ";
                    result += ConvertToWords(afterDecimal);
                    if (afterDecimal == 1)
                        result += " Cent ";
                    else
                        result += " Cents ";
                }
                result += "Only";
            }
            return result;
        }

        static string ConvertToWords(long number)
        {
            var result = "";
            var qualifiers = new string[]{"", "Thousand", "Million", "Billion" };
            int length = (int) (number.ToString().Length - 1)/3;
            for (int i = length; i >= 0; i--)
            {
                var firstTrio = (int)(number / Math.Pow(10,i * 3));
                if (firstTrio > 0)
                {
                    result += Translate(firstTrio) + " " + qualifiers[i];
                    if (i > 0)
                        result += " ";
                }
                number = (long)(number % Math.Pow(10, i * 3));
            }            
            return result;
        }

        static string Translate(int number)
        {
            var ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            if (number < 20)
                return ones[number];
            if (number < 100)
            {
                var firstDigit = (int)number/ 10;
                return tens[firstDigit - 2] + " " + Translate(number % 10);
            }
            else
            {
                var firstDigit = (int)number / 100;
                return Translate(firstDigit) + " Hundred " + Translate(number % 100);
            }
            
        }
    }
}

