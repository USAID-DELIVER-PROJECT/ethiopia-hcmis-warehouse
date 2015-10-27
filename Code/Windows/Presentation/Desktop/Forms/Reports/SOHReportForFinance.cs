using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using CalendarLib;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Reports;
using ReceiptConfirmationPrintout = BLL.ReceiptConfirmationPrintout;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-FS-FS-RP", "Finance SOH Report", "")]
    public partial class SOHReportForFinance : XtraForm
    {
        public SOHReportForFinance()
        {
            InitializeComponent();
        }

        private void SOHReportForFinance_Load(object sender, EventArgs e)
        {
            lkWarehouse.Properties.DataSource = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);
            lkAccount.SetupActivityEditor().SetDefaultActivity();
        }

        private XtraReport GetReport()
        {
            var financeReport = new HCMIS.Desktop.Reports.SOHReportForFinance(CurrentContext.LoggedInUserName);
            int warehouseID = Convert.ToInt32(lkWarehouse.EditValue);
            int activityID = Convert.ToInt32(lkAccount.EditValue);
            DataView reportData = BLL.Balance.GetSOHReportForFinance(warehouseID,activityID);
            financeReport.DataSource = reportData;

            printControl1.PrintingSystem = financeReport.PrintingSystem;
            return financeReport;
        }
        private XtraReport GetReport(DataView reportData)
        {
            var financeReport = new HCMIS.Desktop.Reports.SOHReportForFinance(CurrentContext.LoggedInUserName);
           financeReport.DataSource = reportData;

            printControl1.PrintingSystem = financeReport.PrintingSystem;
            return financeReport;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printControl1.PrintingSystem != null)
            {
                XtraReport report = GetReport();
                MemoryStream stream = new MemoryStream();
                report.ExportToPdf(stream);
                report.PrintDialog();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (printControl1.PrintingSystem != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
                dialog.Filter = "XLS (*.XLS)|*.xls";
                dialog.FilterIndex = 0;
                if (dialog.ShowDialog() != DialogResult.Cancel)
                {
                    XtraReport report = GetReport();
                    string fileName = dialog.FileName;
                    if (!fileName.EndsWith(".xls"))
                    {
                        fileName = fileName + ".xls";
                    }
                    report.ExportToXls(fileName);
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var report = GetReport();
            if (report != null)
            {
                report.CreateDocument();
            }
        }

        private void lkWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            lkInventoryStore.Properties.DataSource =
               PhysicalStore.GetStoresWithWarehouseAndCluster(Convert.ToInt32(lkWarehouse.EditValue));
    
        }

        private void lkInventoryStore_EditValueChanged(object sender, EventArgs e)
        {
            if (lkInventoryStore.EditValue != null && lkInventoryStore.EditValue != "" && lkAccount.EditValue != null)
            {
                lkPeriod.Properties.DataSource = InventoryPeriod.GetInvetoryPeriods(Convert.ToInt32(lkInventoryStore.EditValue));
            }
            else
            {
                lkPeriod.Properties.DataSource = null;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lkPeriod.EditValue != null)
            {
                int periodId = Convert.ToInt32(lkPeriod.EditValue);
                DataView reportData =  BLL.Inventory.SOHForFinance(Convert.ToInt32(lkAccount.EditValue),periodId);

                var report = GetReport(reportData);
                if (report != null)
                {
                    report.CreateDocument();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           if (lkPeriod.EditValue != null)
            {
             if (printControl1.PrintingSystem != null)
            {
                int periodId = Convert.ToInt32(lkPeriod.EditValue);
                DataView reportData = BLL.Inventory.SOHForFinance(Convert.ToInt32(lkAccount.EditValue),periodId);

                
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
                dialog.Filter = "XLS (*.XLS)|*.xls";
                dialog.FilterIndex = 0;
                if (dialog.ShowDialog() != DialogResult.Cancel)
                {
                    var report = GetReport(reportData);
             
                    string fileName = dialog.FileName;
                    if (!fileName.EndsWith(".xls"))
                    {
                        fileName = fileName + ".xls";
                    }
                    report.ExportToXls(fileName);
                }
            }
            
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (lkPeriod.EditValue != null)
            {
                int periodId = Convert.ToInt32(lkPeriod.EditValue);
                DataView reportData = BLL.Inventory.SOHForFinance(Convert.ToInt32(lkAccount.EditValue),periodId);

                if (printControl1.PrintingSystem != null)
                {
                    var report = GetReport(reportData);
                    MemoryStream stream = new MemoryStream();
                    report.ExportToPdf(stream);
                    report.PrintDialog();
                }
            }
        }
    }
}