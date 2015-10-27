using DevExpress.XtraEditors;
using HCMIS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.Models;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-FT-FT-RP", "Facility Trend Report", "")]
    public partial class FacilityTrendReport : XtraForm
    {
        public FacilityTrendReport()
        {
            InitializeComponent();
            Bind();
        }

        void Bind()
        {
            dtpFrom.DateTime = BLL.FiscalYear.Current.StartDate;
            dtpTo.DateTime = BLL.FiscalYear.Current.EndDate;
            grdFacilities.DataSource = BLL.Institution.GetAllReceivingUnits().DefaultView;
        }

        private void grdFacilityView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var facilityID = Convert.ToInt32(grdFacilityView.GetDataRow(e.FocusedRowHandle)["ID"]);

            grdFacilityTrend.DataSource = BLL.Item.GetFacilityHistory(facilityID, dtpFrom.DateTime, dtpTo.DateTime);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            if(saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                grdFacilityTrend.ExportToXlsx(saveDialog.FileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            grdFacilityTrendView.Print();
        }


    }
}
