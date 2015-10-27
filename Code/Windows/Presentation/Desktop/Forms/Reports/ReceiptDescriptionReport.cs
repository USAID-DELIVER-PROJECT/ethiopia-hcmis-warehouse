using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;


namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-RD-RD-RP", "Receipt Description Report", "Receipt Description Report")]
    public partial class ReceiptDescriptionReport : Form
    {
        private BLL.ReceiptConfirmationPrintout rctPrintout;

        public ReceiptDescriptionReport()
        {
            InitializeComponent();
        }

        private void InvoiceCheck_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            lkAccount.SetupAccountEditor().SetDefaultAccount();
        }

        private void radioGpC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReceiptDescriptions();
        }

        private void LoadReceiptDescriptions()
        {
            if(radioGpC.EditValue == null || lkAccount.EditValue == null)
            {
                return;
            }

            rctPrintout = new BLL.ReceiptConfirmationPrintout();
            if (radioGpC.EditValue.ToString() == "GRV")
            {
                rctPrintout.GetGRVAndiGRVDescriptions(Convert.ToInt32(lkAccount.EditValue));
            }
            else if (radioGpC.EditValue.ToString() == "GRNF")
            {
                rctPrintout.GetGRNFDescriptions(Convert.ToInt32(lkAccount.EditValue));
            }
            else if (radioGpC.EditValue.ToString() == "SRM")
            {
                rctPrintout.GetSRMDescriptions(Convert.ToInt32(lkAccount.EditValue));
                grdViewSTVForChecking.Columns["Supplier"].Caption = "Returned From";
            }
            grdSTVs.DataSource = rctPrintout.DefaultView;
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            LoadReceiptDescriptions();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PrepareGridForExport();
                grdViewSTVForChecking.ExportToXlsx(saveFileDialog.FileName + ".xlsx");
                XtraMessageBox.Show("The file has been exported");
            }
        }

        private void PrepareGridForExport()
        {
            gridColumn1.GetBestWidth();
            gridColumn2.GetBestWidth();
            gridColumn3.GetBestWidth();
            gridColumn4.GetBestWidth();
            gridColumn5.GetBestWidth();
            gridColumn6.GetBestWidth();
            gridColumn7.GetBestWidth();
            gridColumn8.GetBestWidth();
            gridColumn9.GetBestWidth();
            gridColumn11.GetBestWidth();
            colTotalAmount.GetBestWidth();
            grdViewSTVForChecking.BestFitColumns();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            grdViewSTVForChecking.OptionsPrint.AutoWidth = true;
            var pcLink = new PrintableComponentLink(new PrintingSystem()) {Component = grdSTVs, Landscape = true};
            pcLink.CreateDocument();
            pcLink.ShowPreviewDialog();
            
        }
    }
}