using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Desktop.Helpers
{
    class DateTimeFunctions
    {
        public static string GetDateSpan(DateTime? theDate)
        {
            if (theDate != null)
            {
                TimeSpan? tsp = BLL.DateTimeHelper.ServerDateTime - theDate.Value;


                TimeSpan ts = tsp.Value;
                string interpretation = GetDateInterpretation(ts.Days);

                if (interpretation != "")
                {
                    return interpretation + " ago";
                }
                else
                {
                    return "Today";
                }
            }
            return "";
        }


        private static string GetDateInterpretation(int days)
        {
            string interpretation = "";

            if (days > 365)
            {
                int year = days / 365;
                if (year == 1)
                {
                    interpretation += string.Format("1 year ");
                }
                else
                {
                    interpretation += string.Format("{0} years ", year);
                }
                days = days % 365;

            }
            if (days > 30)
            {
                int months = days / 30;
                if (months == 1)
                {
                    interpretation += "1 month ";
                }
                else
                {
                    interpretation += string.Format("{0} months ", months);
                }
                days = days % 30;
            }

            if (days > 0)
            {
                interpretation += string.Format("{0} days ", days);
            }

            return interpretation;
        }
    }
}
