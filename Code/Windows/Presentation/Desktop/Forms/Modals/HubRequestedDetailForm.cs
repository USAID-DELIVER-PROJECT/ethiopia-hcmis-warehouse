using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class HubRequestedDetailForm : Form
    {
        private DataView hubrequest;

        public HubRequestedDetailForm()
        {
            InitializeComponent();
        }

        public HubRequestedDetailForm(DataView hubrequest)
        {
            // TODO: Complete member initialization
            this.hubrequest = hubrequest;
            InitializeComponent();
         }

        private void HubRequestedDetailForm_Load(object sender, EventArgs e)
        {
            hubRequestedgridControl.DataSource = hubrequest;
        }

        public static string TimeAgo(DateTime dateTimeObj)
        {
            var isFutureDate = dateTimeObj > DateTime.Now;
            var timeSpan = isFutureDate ? (dateTimeObj.Subtract(DateTime.Now)) : DateTime.Now.Subtract(dateTimeObj);
            var description = Describe(timeSpan);
            if (isFutureDate)
            {
                return (string.Format("in {0}", description));
            }
            return description == "Just now" ? description : (string.Format("{0} ago", description));
        }

        public static string Describe(TimeSpan t)
        {
            int[] ints = {
                         t.Days,
                         t.Hours,
                         t.Minutes,
                         t.Seconds
                     };

            double[] doubles = {
                               t.TotalDays,
                               t.TotalHours,
                               t.TotalMinutes,
                               t.TotalSeconds
                           };

            var firstNonZero = ints.Select((value, index) => new { value, index }).FirstOrDefault(x => x.value != 0);
            if (firstNonZero == null)
            {
                return "Just now";
            }
            var i = firstNonZero.index;
            // var prefix = (i >= 3) ? "" : "about ";
            var quantity = (int)Math.Round(doubles[i]);
            return Tense(quantity, Names[i]);
        }

        public static string Tense(int quantity, string noun)
        {
            return quantity == 1
                ? "1 " + noun
                : string.Format("{0} {1}s", quantity, noun);
        }

        static readonly string[] Names = {
                                         "day",
                                         "hour",
                                         "minute",
                                         "second"
                                     };

        private void hubRequestedgridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "PODate")
                e.DisplayText = !DBNull.Value.Equals(e.Value) ? TimeAgo(Convert.ToDateTime(e.Value)) : "Not Requested Before";
        }
    }
}
