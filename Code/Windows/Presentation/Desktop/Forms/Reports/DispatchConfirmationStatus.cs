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
using HCMIS.Desktop.Reports;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.DocumentExchange.Documents.XmlMappings;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("DI-DC-DC-RP", "&Dispatch Confirmation Status", "")]

    public partial class DispatchConfirmationStatus : Form
    {

        public DispatchConfirmationStatus()
        {
            InitializeComponent();
        }

        private void DispatchConfirmationStatus_Load(object sender, EventArgs e)
        {
            lkAccountTree.SetupAccountEditor().SetDefaultAccount();
            lkWarehouse.Properties.DataSource = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);
            lkWarehouse.ItemIndex = 0;
            
        
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            PopulateItemList();
        }

        private void gridItemsView_CustomColumnDisplayText(object sender,DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "DispatchConfirmed")
                if (Convert.ToString(e.Value) == "False")
                {
                    e.DisplayText = "Dispatch Not Confirmed";
                }
                else if (Convert.ToString(e.Value) == "True")
                {
                    e.DisplayText = "Dispatch Confirmed";
                }
                else
                {
                    e.DisplayText = "Not Known";
                }
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
            printableComponentLink2.CreateMarginalHeaderArea += new CreateAreaEventHandler(printableComponentLink2_CreateMarginalHeaderArea);
            printableComponentLink2.CreateDocument();
            printableComponentLink2.ShowPreview();

        }

        private void printableComponentLink2_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            string[] header = { "Warehouse: " + lkWarehouse.Text, "Account: " + lkAccountTree.Text };
            printableComponentLink2.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
        }

        
        private void chkShowDispatched_CheckedChanged(object sender, EventArgs e)
        {
            PopulateItemList();
        }

        private void PopulateItemList()
        {
            var issue = new Issue();
            issue.GetDisptachConfirmationStatus(Convert.ToInt32(lkAccountTree.EditValue), Convert.ToInt32(lkWarehouse.EditValue));
            if (chkShowDispatched.Checked)
            {
                gridItemsView.ActiveFilterString = string.Format("[DispatchConfirmed]='True'");
            }
            else if (!chkShowDispatched.Checked)
            {
                //issue.GetDisptachConfirmationStatus(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkWarehouse.EditValue));
                gridViewControl.DataSource = issue.DefaultView;
            }
        }

        private void lkAccountTree_EditValueChanged(object sender, EventArgs e)
        {
            PopulateItemList();
        }

        private void txtItemName_EditValueChanged(object sender, EventArgs e)
        {
            gridItemsView.ActiveFilterString = string.Format("PrintedNo like '{0}%' or PrintedDate like '{0}%'", txtFilter.Text);
        }

        private void gridViewControl_Click(object sender, EventArgs e)
        {

        }

        private void gridItemsView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridItemsView.GetFocusedDataRow();

            lblIssueType.Text = dr["OrderType"]!=DBNull.Value ? (string) dr["OrderType"] : "-";
            
            
            

            if ((dr["ReceivingUnitID"]) != DBNull.Value)
            {
                var ins = new Institution();
                ins.LoadByPrimaryKey(Convert.ToInt32(dr["ReceivingUnitID"]));
                
                lblRegion.Text = ins.RegionName ?? "-";
                lblWoreda.Text = ins.WoredaName ?? "-";
                lblZone.Text = ins.ZoneName ?? "-";

                var own = new OwnershipType();
                own.LoadByPrimaryKey(ins.Ownership);
                lblOwnership.Text = own.Name ?? "-";

                var iss = new Issue();
                iss.LoadByPrimaryKey(Convert.ToInt32(dr["STVID"]));

                if (!iss.IsColumnNull("PaymentTypeID"))
                {
                    var pType = new PaymentType();

                     pType.LoadByPrimaryKey(iss.PaymentTypeID);
                    lblPaymentType.Text = pType.Name;

                }
                lblPaymentType.Text = "-";

                if (!iss.IsColumnNull("VoidRequestDateTime"))
                    lblVoidRequestedDate.Text = iss.VoidRequestDateTime.ToShortDateString();
                else
                {
                    lblVoidRequestedDate.Text = "-";
                }
               if(!iss.IsColumnNull("VoidApprovalDateTime"))
                lblVoidConfirmedDate.Text= iss.VoidApprovalDateTime.ToShortDateString();
               else
               {
                   lblVoidConfirmedDate.Text = "-";

               }
               var user = new User();
                if (!iss.IsColumnNull("VoidRequestUserID"))
                {
                    
                    user.LoadByPrimaryKey(iss.VoidRequestUserID);
                    lblVoidRequestedBy.Text = user.FullName;
                }
                else lblVoidRequestedBy.Text = "-";
                if (!iss.IsColumnNull("VoidApprovedByUserID"))
                {
                    user.LoadByPrimaryKey(iss.VoidApprovedByUserID);
                    lblVoidConfirmedBy.Text = user.FullName;
                }
                else lblVoidConfirmedBy.Text = "-";

                lblInstitutionType.Text = ins.InstitutionTypeName;

                if (!iss.IsColumnNull("DocumentTypeID"))
                {
                    lblDocumentType.Text = DocumentType.GetDocumentType(iss.DocumentTypeID).Name;
                }
                else
                    lblDocumentType.Text = "";



            }
            else
            {
                lblRegion.Text = lblWoreda.Text = lblZone.Text = "-";
            }

            lblPrintedDate.Text = string.IsNullOrEmpty((Convert.ToDateTime(dr["PrintedDate"].ToString())).ToShortDateString()) ? "-" : (Convert.ToDateTime(dr["PrintedDate"].ToString())).ToShortDateString();
            lblAccount.Text = string.IsNullOrEmpty(dr["AccountName"].ToString()) ? "-" : dr["AccountName"].ToString();
            lblSubAccount.Text = string.IsNullOrEmpty(dr["SubAccountName"].ToString()) ? "-" : dr["SubAccountName"].ToString();
            lblActivity.Text = string.IsNullOrEmpty(dr["ActivityName"].ToString()) ? "-" : dr["ActivityName"].ToString();
            lblPrintedBy.Text = string.IsNullOrEmpty(dr["IssuedBy"].ToString()) ? "-" : dr["IssuedBy"].ToString();

            lblIssueStatus.Text = string.IsNullOrEmpty(dr["Status"].ToString()) ? "-" : dr["Status"].ToString();
           int accountid =  Convert.ToInt32(dr["AccountID"]);
           Account account = new Account();
           account.LoadByPrimaryKey(accountid);
           Mode mode = new Mode();
           mode.LoadByPrimaryKey(account.ModeID);
           lblMode.Text = mode.TypeName;

        
        }
    }
}
