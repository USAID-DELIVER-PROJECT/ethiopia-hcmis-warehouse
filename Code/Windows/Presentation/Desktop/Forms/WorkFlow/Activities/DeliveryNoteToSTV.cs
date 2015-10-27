using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Forms.Logs;
using HCMIS.Desktop.ViewHelpers;

namespace HCMIS.Desktop.Forms.WorkFlow.Activities
{
    [FormIdentifier("AC-DN-DN-TA","Delivery Note To STV","")]
    public partial class DeliveryNoteToSTV : XtraForm
    {
        public DeliveryNoteToSTV()
        {
            InitializeComponent();
        }

        private void DeliveryNoteToSTV_Load(object sender, EventArgs e)
        {
            SetPermission();
            lkStore.SetupActivityEditor().SetDefaultActivity();
           
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnPrintSTV.Enabled = this.HasPermission("Print-STV");
            }
        }

        private void lkStore_EditValueChanged(object sender, EventArgs e)
        {
            if (lkStore.EditValue != null)
            {
                gridDeliveryNotes.DataSource = BLL.Issue.GetDeliveryNotesToBeConverted(Convert.ToInt32(lkStore.EditValue));
                gridDeliveryNoteView_FocusedRowChanged(null, null);
            }
        }

        private void gridDeliveryNoteView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridDeliveryNoteView.GetFocusedDataRow();
            string space = "";


            if (dr == null) return;


            HeaderGroup.Text = (string)dr["FacilityName"] + space.PadRight(160) + "Deliver Note No: " + (Convert.ToInt32(dr["PrintedID"]));
            int STVLogID = Convert.ToInt32(dr["ID"]);
            gridSTVDetails.DataSource = BLL.Issue.GetDetailItems(STVLogID);

            lblMode.Text = dr["Mode"] == DBNull.Value ? "-" : Convert.ToString(dr["Mode"]);
            lblAccount.Text = dr["Account"] == DBNull.Value ? "-" : Convert.ToString(dr["Account"]);
            lblSubAccount.Text = dr["SubAccount"] == DBNull.Value ? "-" : Convert.ToString(dr["SubAccount"]);
            lblActivity.Text = dr["Activity"] == DBNull.Value ? "-" : Convert.ToString(dr["Activity"]);

            lblRegion.Text = dr["Region"] == DBNull.Value ? "-" : Convert.ToString(dr["Region"]);
            lblZone.Text = dr["Zone"] == DBNull.Value ? "-" : Convert.ToString(dr["Zone"]);
            lblWoreda.Text = dr["Woreda"] == DBNull.Value ? "-" : Convert.ToString(dr["Woreda"]);
            lblInstitutionType.Text = dr["InstitutionType"] == DBNull.Value ? "-" : Convert.ToString(dr["InstitutionType"]);
            lblPaymentType.Text = dr["PaymentType"] == DBNull.Value ? "-" : Convert.ToString(dr["PaymentType"]);
            lblOwnership.Text = dr["OwnershipType"] == DBNull.Value ? "-" : Convert.ToString(dr["OwnershipType"]);
            lblOrderNo.Text = dr["OrderNo"] == DBNull.Value ? "-" : Convert.ToString(dr["OrderNo"]);
            lblOrderType.Text = dr["OrderType"] == DBNull.Value ? "-" : Convert.ToString(dr["OrderType"]);
            lblOrderStatus.Text = dr["OrderStatus"] == DBNull.Value ? "-" : Convert.ToString(dr["OrderStatus"]);


            lblPrintedDate.Text = dr["PrintedDate"] == DBNull.Value ? "-" : Convert.ToDateTime(dr["PrintedDate"]).ToShortDateString();
            lblRequestedDate.Text = dr["RequestedDate"] == DBNull.Value ? "-" : Convert.ToDateTime(dr["RequestedDate"]).ToShortDateString();
            lblPrintedBy.Text = dr["PrintedBy"] == DBNull.Value ? "-" : Convert.ToString(dr["PrintedBy"]);
            lblRequestedBy.Text = dr["RequestedBy"] == DBNull.Value ? "-" : Convert.ToString(dr["RequestedBy"]);



            btnPrintSTV.Enabled = !BLL.Settings.UseNewUserManagement || this.HasPermission("Print-STV");
        }

        private void btnPrintSTV_Click(object sender, EventArgs e)
        {
            DataRow dataView = gridDeliveryNoteView.GetFocusedDataRow();
            if (dataView != null)
            {
                int stvlogID = Convert.ToInt32(dataView["ID"]);

                DataView dv = PickList.GetPickedItemsOnSTV( stvlogID,false );

                if (dv.Count > 0 && ValidateAndFixDeliveryNoteHasBeenProperlyPrice(dv))
                {
                    LogIssues logScreen = new LogIssues();

                    BLL.Issue stvLog = new BLL.Issue();
                    stvLog.LoadByPrimaryKey(stvlogID);

                    PickList pickList = new PickList();
                    pickList.LoadByPrimaryKey(stvLog.PickListID);
                    XtraReport xtraReport;
                    PrintDialog printDialog = new PrintDialog();
                    if(printDialog.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }

                    MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
            
                    try
                    {
                     mgr.BeginTransaction();
   
                       xtraReport = logScreen.RePrintSTV(dv, pickList.OrderID, pickList,stvlogID,true);
                        stvLog.HasDeliveryNoteBeenConverted = true;
                        stvLog.Save();
                     mgr.CommitTransaction();
                    }
                    catch (Exception exception)
                    {
                        mgr.RollbackTransaction();
                        XtraMessageBox.Show("Print Problem:" + exception.Message , "Print Problem",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        throw;
                    }
                    if(xtraReport!= null)
                    {
                        xtraReport.Print(printDialog.PrinterSettings.PrinterName);
                    }
                    lkStore_EditValueChanged(null, null);
                }else
                {
                    XtraMessageBox.Show(
                        "You cannot print this STV because price has not been set for all item. Please try again");
                }
                
            }
        }

        //This is a fix It
        //It will fix the Cost if it is set on the ReceiveDoc but if not set on the picklistdetail
        //But if the receiveDoc is not set or GRV is not printed it will return false
        
        private static bool ValidateAndFixDeliveryNoteHasBeenProperlyPrice(DataView dv)
        {
            
            foreach (DataRowView drv in dv)
            {
                    int issueDocId, pickListDetailId;
                    CostElement costElement = new CostElement();
                    try
                    {  
                        issueDocId = Convert.ToInt32(drv["IssueDocID"]);
                        pickListDetailId = Convert.ToInt32(drv["PickListDetailID"]);
                        PickListDetail pickListDetail = costElement.FixDeliveryNoteCostReceiveDoc(issueDocId, pickListDetailId);
                        drv["Cost"] = pickListDetail.Cost;
                        drv["UnitPrice"] = pickListDetail.UnitPrice;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("You cannot print this STV:{0}", ex.Message), "Warning",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;
                    }
            }
            return true;
        }

        
        private void txtFacilityName_EditValueChanged(object sender, EventArgs e)
        {
            ////gridDeliveryNoteView.ActiveFilterString = "FacilityName like '" + txtFacilityName.Text + "%'";
            gridDeliveryNoteView.ActiveFilterString = string.Format("FacilityName like '{0}%' or PrintedID like '{0}%'" , txtFacilityName.Text);
            gridDeliveryNoteView_FocusedRowChanged(null, null);
        }

        private void gridDeliveryNotes_Click(object sender, EventArgs e)
        {

        }

        private void lblZone_Click(object sender, EventArgs e)
        {

        }
    }
}
