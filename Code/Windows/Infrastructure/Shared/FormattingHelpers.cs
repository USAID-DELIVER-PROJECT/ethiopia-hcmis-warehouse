using System;
using System.Data;
using System.Globalization;

namespace HCMIS.Shared.Helpers
{
    public class FormattingHelpers
    {
        public static int PrecisionAfterDecimal { get; set; }

        public static string GetNumberFormatting()
        {
            int noOfDigits = PrecisionAfterDecimal;
            string sharps = "#,###,###,##0.";

            for (int j = noOfDigits; j > 1; j--)
            {
                sharps += "#";
            }

            sharps += "0";
            return sharps;
        }
        
        public static string GetBirrFormatting()
        {
            int noOfDigits = PrecisionAfterDecimal;
            string sharps = "ETB "+"#,###,###,##0.";

            for (int j = noOfDigits; j > 1; j--)
            {
                sharps += "#";
            }

            sharps += "0";
            return sharps;
        }
        
        public static string GetPercentFormatting()
        {
            int noOfDigits = PrecisionAfterDecimal;
            string sharps ="#,###,###,##0";

         

            sharps += " % ";
            return sharps;
        }
  
        public static string GetExchangeRateFormatting()
        {
            int noOfDigits = 5;
            string sharps = "#,###,###,##0.";

            for (int j = noOfDigits; j > 1; j--)
            {
                sharps += "#";
            }

            sharps += "0";
            return sharps;
        }
        
        public static DataView  GetCurrencyList()
        {
            DataTable currency = new DataTable();
            currency.Columns.Add("ID");
            currency.Columns.Add("Name");
            currency.Columns.Add("Symbol");


            foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
              
                RegionInfo regionInfo = new RegionInfo(cultureInfo.LCID);
                DataRow dr = currency.NewRow();
                dr["ID"] = Convert.ToInt32(cultureInfo.LCID);
                dr["Name"] = regionInfo.CurrencyEnglishName;
                dr["Symbol"] = regionInfo.ISOCurrencySymbol;
                
                if(currency.Select(string.Format("Symbol like '{0}'",dr["Symbol"])).Length == 0)
                    currency.Rows.Add(dr);
            }
            return new DataView(currency);
        }
 
        public static string GetCurrencyFormatByLCID(int LCID)
        {
            if(LCID !=0)
                return (new CultureInfo(LCID)).NumberFormat.CurrencySymbol + " " + GetNumberFormatting();
            return GetNumberFormatting();
        }
    }
}