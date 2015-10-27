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
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Reports;
using ReceiptConfirmationPrintout = BLL.ReceiptConfirmationPrintout;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-DC-DB-RP","Document Browser","")]
    public partial class DocumentBrowser : XtraForm
    {
        public DocumentBrowser()
        {
            InitializeComponent();
        }

        private void DocumentBrowser_Load(object sender, EventArgs e)
        {
            SetPermission();
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                documentType.Properties.Items.Clear();
                
                if(this.HasPermission("GRNF"))
                    documentType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("GRNF", "GRNF"));

                if (this.HasPermission("iGRV"))
                    documentType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("iGRV", "iGRV"));

                if (this.HasPermission("GRV"))
                    documentType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("GRV", "GRV"));

                if (this.HasPermission("SRM"))
                    documentType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("SRM", "SRM"));

                if (this.HasPermission("Cost-Analysis"))
                    documentType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Cost",
                                                                                                     "Cost Analysis"));
                if (this.HasPermission("STV"))
                    documentType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("STV", "STV"));

                if (this.HasPermission("Cash"))
                    documentType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Cash", "Cash"));

                if (this.HasPermission("Credit"))
                    documentType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Credit", "Credit"));
            }
        }

        private void viewChoices_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var report = GetReport();
            if (report != null)
            {
                report.CreateDocument();
            }
            else
            {
                XtraMessageBox.Show("Error while looking for the document!","Error");
            }
            
        }

        private XtraReport GetReport()
        {
            DataRow dr = viewChoices.GetFocusedDataRow();
            XtraReport report = null;
            if (dr != null)
            {
                int id = Convert.ToInt32(dr["ID"]);
                switch (documentType.EditValue.ToString())
                {
                    case "GRNF":
                        report = WorkflowReportFactory.CreateGRNFPrintout(id);
                        break;
                    case "GRV":
                    case "SRM":
                    case "iGRV":
                        report = WorkflowReportFactory.CreateReceiptPrintout(CurrentContext.LoggedInUserName, id);
                        break;
                    case "Cost":
                        report = WorkflowReportFactory.CreateCostAnalysis(id);
                        break;
                    case "STV":
                    case "Cash":
                    case "Credit":
                        {
                            report = WorkflowReportFactory.CreateInvoice(id);
                        }
                        break;
                }
                printControl1.PrintingSystem = report.PrintingSystem;
                SetTextWatermark(report);
            }
            return report;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Search();
        }



        private void Search()
        {
            if (txtDocumentNumber.Text == "")
                return;
            printControl1.PrintingSystem = null;
            printControl1.Refresh();
            int searchID = Convert.ToInt32(txtDocumentNumber.Text);
            DataTable dtChoices = null; 
            switch (documentType.EditValue.ToString())
            {
                case "GRNF":
                case "Cost":
                    dtChoices = ReceiptConfirmationPrintout.GetListOfGRNFPrinted(searchID);
                    break;
                case "STV":
                case "Cash":
                case "Credit":
                    dtChoices = BLL.Issue.Search(txtDocumentNumber.Text, documentType.EditValue.ToString());
                    break;
                case "GRV":
                    dtChoices = BLL.ReceiptConfirmationPrintout.GetListOfGRVPrinted(searchID);
                    break;
                case "SRM":
                    dtChoices = BLL.ReceiptConfirmationPrintout.GetListOfSRMPrinted(searchID);
                    break;
                case "iGRV":
                    dtChoices = BLL.ReceiptConfirmationPrintout.GetListOfiGRVPrinted(searchID);
                    break;
            }

            viewChoices.Columns.Clear();
            gridChoices.DataSource = dtChoices;
            if (dtChoices != null)
            {
                viewChoices.Columns["ID"].Visible = false;
                viewChoices.Columns["IsVoid"].Visible = false;
            }
        }

        private void gridChoices_Click(object sender, EventArgs e)
        {
            viewChoices_FocusedRowChanged(null, null);
        }

        public void SetTextWatermark(XtraReport report)
        {
            // Adjust text watermark settings.
            report.Watermark.Text = "Not Origional";
            report.Watermark.TextDirection = DirectionMode.ForwardDiagonal;
            report.Watermark.Font = new Font("Arial Black", 50);
            report.Watermark.ForeColor = Color.DarkRed;
            report.Watermark.TextTransparency = 60;
            report.Watermark.ShowBehind = true;
            //report.Watermark.PageRange = "1,3-5";
        }

        private void documentType_EditValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printControl1.PrintingSystem != null)
            {
                XtraReport report = GetReport();
                MemoryStream stream = new MemoryStream();
                report.ExportToPdf(stream);
                if(report.PrintDialog()==DialogResult.OK)
                {
                    HCMIS.Core.Distribution.Services.PrintLogService.SavePrintLogNoWait(stream,
                                                                                  "Archive_" +
                                                                                  documentType.EditValue.ToString(),
                                                                                  true,
                                                                                  Convert.ToInt32(txtDocumentNumber.Text),
                                                                                  CurrentContext.UserId,
                                                                                  BLL.DateTimeHelper.ServerDateTime);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (printControl1.PrintingSystem != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments); 
                dialog.Filter = "PDF (*.PDF)|*.pdf" ;
                dialog.FilterIndex = 0;
                if (dialog.ShowDialog() != DialogResult.Cancel)
                {
                    XtraReport report = GetReport();
                    string fileName = dialog.FileName;
                    if (!fileName.EndsWith(".pdf"))
                    {
                        fileName = fileName + ".pdf";
                    }
                    report.ExportToPdf(fileName);
                    
                    MemoryStream stream = new MemoryStream();
                    report.ExportToPdf(stream);
                    HCMIS.Core.Distribution.Services.PrintLogService.SavePrintLogNoWait(stream,
                                                                                  "Archive_Export_" +
                                                                                  documentType.EditValue.ToString(),
                                                                                  true,
                                                                                  Convert.ToInt32(txtDocumentNumber.Text),
                                                                                  CurrentContext.UserId,
                                                                                  BLL.DateTimeHelper.ServerDateTime);
                }
                
            }
        }

       
    }
}
