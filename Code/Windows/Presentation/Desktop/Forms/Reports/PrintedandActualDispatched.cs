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
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-PA-PA-RP", "&Printed vs Actual Dispatched", "")]
    public partial class PrintedandActualDispatched : Form
    {
        public PrintedandActualDispatched()
        {
            InitializeComponent();
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            PopulateItemList();
        }

        private void PopulateItemList()
        {
            var issue = new Issue();
            issue.GetPrintedQtyandActualDisptached(Convert.ToInt32(lkAccount.EditValue));
            gridItemControl.DataSource = issue.DefaultView;
        }

        private void PrintedandActualDispatched_Load(object sender, EventArgs e)
        {
            lkAccount.SetupAccountEditor().SetDefaultAccount();
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            gridItemsView.ActiveFilterString = String.Format("[PrintedNo] Like '{0}%'", txtInvoiceNo.Text);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;
            gridItemsView.ExportToXlsx(sfd.FileName + ".xlsx");
            XtraMessageBox.Show("The file has been exported.");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateMarginalHeaderArea += new CreateAreaEventHandler(printableComponentLink1_CreateMarginalHeaderArea);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();
        }

        private void printableComponentLink1_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            string[] header = { "Account: " + lkAccount.Text };
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
           
        }

      
    }
}
