using System;
using CalendarLib;
using System.Globalization;

namespace HCMIS.Desktop
{
    public class ConvertDate
    {

        /// <summary>
        /// A Crazy function we need to get rid of.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime DateConverter(string dt)
        {
            DateTime dtCurrent = new DateTime();
            try
            {
                dtCurrent = DateTime.ParseExact(dt, "d", CultureInfo.InvariantCulture);
            }
            catch
            {
                string dtValid = "";
                string yer = "";
                if (Convert.ToInt32(dt.Substring(0, 2)) == 13)
                {
                    dtValid = dt;
                    yer = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurrent = DateTime.ParseExact("12/30/" + yer, "d", CultureInfo.InvariantCulture);
                }
                else if (Convert.ToInt32(dt.Substring(0, 2)) == 2)
                {
                    dtValid =dt;
                    yer = dtValid.Substring(dtValid.Length - 4, 4);
                    var newdate = "02/28/" + yer;
                    dtCurrent = DateTime.ParseExact(newdate, "d", CultureInfo.InvariantCulture);
                }
            }
            return dtCurrent;
        }

        


        public static DateTime DateConverterToEU(string dt)
        {
            DateTime dtCurrent = new DateTime();

            return dtCurrent;
        }

        public static DateTime ConvertFromEthiopian(DateTime dt)
        {
            CalendarLib.DateTimePickerEx dtpkr = new CalendarLib.DateTimePickerEx();
            dtpkr.Text = dt.ToString();
            CalendarLib.EthiopianCalendar ec = new CalendarLib.EthiopianCalendar();
            return dtpkr.Value;
        }

        public static int GetEthiopianMonth(DateTime dt)
        {
            CalendarLib.DateTimePickerEx dtpkr = new CalendarLib.DateTimePickerEx();
            dtpkr.Value = dt;
            dtpkr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            DateTime edt = Convert.ToDateTime(dtpkr.Text);
            return edt.Month;
        }

        public  static int GetEthiopianYear(DateTime dt)
        {
            CalendarLib.DateTimePickerEx dtpkr = new CalendarLib.DateTimePickerEx();
            dtpkr.Value = dt;
            dtpkr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            DateTime edt = Convert.ToDateTime(dtpkr.Text);
            return edt.Year;
        }

        internal static DateTimePickerEx GetCurrentEthiopianDateText()
        {
            DateTimePickerEx dtDate = new DateTimePickerEx();
            //if (CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern != "M/d/yyyy")
            //{
            //    //CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            //}
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtDate.Value = BLL.DateTimeHelper.ServerDateTime;
            return dtDate;
        }
    }
}
