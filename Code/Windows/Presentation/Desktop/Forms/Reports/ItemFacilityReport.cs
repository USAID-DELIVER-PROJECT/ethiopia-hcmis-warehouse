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

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-DR-DR-RP", "Facility Distribution Report", "")]
    public partial class ItemFacilityReport : XtraForm
    {
        public ItemFacilityReport()
        {
            InitializeComponent();
            BindBasicData();
        }

        private void BindBasicData()
        {
            var mode = new BLL.Mode();
            mode.LoadAll();
            lkMode.Properties.DataSource = mode.DefaultView;
            lkRegion.Properties.DataSource = BLL.Region.GetAllRegions().DefaultView;
            deStartDate.EditValue = BLL.FiscalYear.Current.StartDate;
            deEndDate.EditValue = BLL.FiscalYear.Current.EndDate;

            //gridFacilityReport.DataSource = BLL.Institution.GetItemFacilityDistribution(
        }

        private void BindReport()
        {
            if(lkMode.EditValue != null)
                gridFacilityReport.DataSource = BLL.Institution.GetItemFacilityDistribution
                    (
                        Convert.ToInt32(lkMode.EditValue)
                        , (DateTime)deStartDate.EditValue
                        , (DateTime)deEndDate.EditValue
                        , lkRegion.EditValue == null ? -1 : Convert.ToInt32(lkRegion.EditValue)
                        , lkZone.EditValue == null ? -1 : Convert.ToInt32(lkZone.EditValue)
                        , lkWoreda.EditValue == null ? -1 : Convert.ToInt32(lkWoreda.EditValue)
                    ).DefaultView;
        }

        private void lkRegion_EditValueChanged(object sender, EventArgs e)
        {
            lkZone.Properties.DataSource = BLL.Zone.GetZoneByRegion(Convert.ToInt32(lkRegion.EditValue)).DefaultView;
             lkZone.EditValue = null;
            lkWoreda.EditValue = null;
            BindReport();
            
        }

        private void lkZone_EditValueChanged(object sender, EventArgs e)
        {
            lkWoreda.Properties.DataSource = BLL.Woreda.GetWoredaByZone(Convert.ToInt32(lkZone.EditValue)).DefaultView;
            lkWoreda.EditValue = null;
            BindReport();
        }

        private void lkMode_EditValueChanged(object sender, EventArgs e)
        {
            BindReport();
        }

        private void lkWoreda_EditValueChanged(object sender, EventArgs e)
        {
            BindReport();
        }

        private void deStartDate_EditValueChanged(object sender, EventArgs e)
        {
            BindReport();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Export to Excel";
            dialog.AddExtension = true;
            dialog.DefaultExt = "xlsx";
          
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                gridFacilityReportView.ExportToXlsx(dialog.FileName);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridFacilityReportView.Print();
        }

     

    }
}
