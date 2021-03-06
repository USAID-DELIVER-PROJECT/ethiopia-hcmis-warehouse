
// Generated by MyGeneration Version # (1.2.0.7)

using System;
using System.Data;
using DAL;

namespace BLL
{
	public class Period : _Period
	{
		/// <summary>
        /// Gets all Periods.
        /// </summary>
        /// <returns></returns>
        public static Period GetAllPeriods()
        {
            BLL.Period period = new Period();
            period.LoadAll();

		    period.AddColumn("StartDate_EndDate",typeof(string));
            DataRow[] dataRows = period.DataTable.Select();
            foreach (DataRow r in dataRows)
            {
                r["StartDate_EndDate"] = Convert.ToDateTime(r["StartDate"]).ToString("MMMM,dd,yyyy") + " - " + Convert.ToDateTime(r["EndDate"]).ToString("MMMM,dd,yyyy");
            }
		    return period;
        }
	}
}
