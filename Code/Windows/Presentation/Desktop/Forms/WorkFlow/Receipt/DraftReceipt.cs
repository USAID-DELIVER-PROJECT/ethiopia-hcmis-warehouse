using System;
using System.ComponentModel;
using System.Data;
using BLL;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraLayout.Utils;
using HCMIS.Concrete.Models;
using HCMIS.Desktop.Forms.Reports;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Modals;
using PalletLocation = BLL.PalletLocation;
using ReceiveDoc = BLL.ReceiveDoc;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("RE-RE-DR-CN", "Draft Receipt", "")]
    public partial class DraftReceipt : XtraForm
    {

        int ReceiptID;

        public DraftReceipt()
        {
            InitializeComponent();
        }


        private void PutAwayListsLoad(object sender, EventArgs e)
        {
            BindFormContents();

        }

        private void BindFormContents()
        {
            if (!BLL.Settings.IsCenter)
            {

                lkAccount.SetupActivityEditor().SetDefaultActivity();

            }
            else
            {
                colLocation.Visible = false;
                layoutAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            //Warehouse 
            lkWarehouse.Properties.DataSource = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);

            PalletLocation pl = new PalletLocation();
            lkPalletLocations.DataSource = PalletLocation.GetAll();

            gridReceives.DataSource = pl.GetDraftReceives(CurrentContext.UserId);
            if (BLL.Settings.UseNewUserManagement)
            {
                if (this.HasPermission("Cancel"))
                {
                    lcCancelReceive.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }

                if (this.HasPermission("Confirm"))
                {
                    layoutConfirm.Visibility = LayoutVisibility.Always;
                }
            }else
            {
                lcCancelReceive.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutConfirm.Visibility = LayoutVisibility.Always;
            }


        }

        private void gridReceiveView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Bind the detail grid
            PalletLocation pl = new PalletLocation();
            if (e != null && e.PrevFocusedRowHandle < -1)
                return;

            try
            {
                DataRow dr = gridReceiveView.GetFocusedDataRow();
                
                if (dr == null)
                    return;

                ReceiptID = Convert.ToInt32(dr["ReceiptID"]);
                BLL.Receipt receiptDoc = new BLL.Receipt();
                receiptDoc.LoadByPrimaryKey(ReceiptID);

                DataTable GRNFDetail = receiptDoc.GetDetailsForGRNF();

               
                if (GRNFDetail.Rows.Count > 0)
                {
                    //var store = new Store();
                    //store.
                    BLL.PO order = new BLL.PO();
                    //var Mode = new Mode();
                    //Mode.LoadByPrimaryKey(order.ModeID);
                    //lblMode.Text = Mode.TypeName;
                    HeaderSection.Text = GRNFDetail.Rows[0]["PONumber"].ToString();
                    

                    lblRecieveStatus.Text = dr["recieveStatus"].ToString();
                    lblReceiptNo.Text = dr["ReceiptNo"].ToString();
                    lblRecievedBy.Text = dr["ReceivedBy"].ToString();
                    lblRecievedDate.Text = Convert.ToDateTime(dr["Date"]).ToShortDateString();
                    lblReciveType.Text = (dr["ReceiveType"]).ToString();
                    lblWayBill.Text = (dr["WayBillNo"]).ToString()!="" ? dr["WayBillNo"].ToString() : "-";
                    lblTransferVoucherNo.Text = (dr["transferNo"]).ToString() != "" ? dr["transferNo"].ToString() : "-";
                    
                    var warehouse = new BLL.Warehouse();
                    warehouse.LoadByPrimaryKey(receiptDoc.WarehouseID);
                    lblWarehouse.Text = warehouse.Name;
                    lblSupplier.Text = dr["Supplier"].ToString();

                    var cluster = new BLL.Cluster();
                    cluster.LoadByPrimaryKey(warehouse.ClusterID);
                    lblCluster.Text = cluster.Name;



                    lblDocType.Text ="";

                    lblPoType.Text = dr["POType"].ToString();
                    //var ps = new BLL.PhysicalStore();
                    //ps.LoadByPrimaryKey(order.p);
                    //lblStore.Text = ps.Name;

                    
                    txtOrderNo.EditValue = GRNFDetail.Rows[0]["PONumber"];
                    lblPoNumber.Text = GRNFDetail.Rows[0]["PONumber"].ToString();

                    lblInvoiceNumber.Text = receiptDoc.STVOrInvoiceNo;

                    lblInsurancePolicy.Text = receiptDoc.InsurancePolicyNo!=""?receiptDoc.InsurancePolicyNo : "-";

                    var activity = new Activity();
                    activity.LoadByPrimaryKey(Convert.ToInt32(GRNFDetail.Rows[0]["ActivityID"]));

                    txtActivity.EditValue = activity.FullActivityName;
                    lblActivity.Text = activity.Name;

                    lblSubAccount.Text = activity.SubAccountName;
                    lblMode.Text = activity.ModeName;
                    lblAccount.Text = activity.AccountName;
                    
                    gridDetails.DataSource = GRNFDetail;
                }

                if (ReceiveDoc.IsThereShortageOrDamage(ReceiptID))
                {
                    gridShortage.DataSource = receiptDoc.GetDiscrepancyForGRNF();
                }

            }

            catch
            {
                gridDetails.DataSource = null;
            }
        }

        private void OnQueryPopup(object sender, CancelEventArgs e)
        {
            PalletLocation pl = new PalletLocation();
            LookUpEdit lke = (LookUpEdit)gridDetailView.ActiveEditor;
            int itemID = Convert.ToInt32(gridDetailView.GetFocusedDataRow()["ItemID"]);
            lke.Properties.DataSource = PalletLocation.GetAllFreeFor(itemID);
        }

        private void OnConfirmClicked(object sender, EventArgs e)
        {
            PassReceiveForQtyConfirmation();
           
        }

        private void PassReceiveForQtyConfirmation()
        {
            if (gridReceiveView.GetFocusedDataRow() != null)
            {
                String reference = gridReceiveView.GetFocusedDataRow()["RefNo"].ToString();

                if (gridDetailView.DataSource == null)
                    return;

                BLL.ReceiveDoc recDoc = new ReceiveDoc();
                recDoc.LoadByReferenceNo(reference);
                recDoc.SetStatusAsReceived(CurrentContext.UserId);
                BLL.Receipt receiptStatus = new BLL.Receipt();
                receiptStatus.LoadByPrimaryKey(ReceiptID);
                receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED, null, this.GetFormIdentifier(), CurrentContext.UserId, "Quantity edited");
          
                XtraMessageBox.Show("Receipt forwarded for quantity confirmation!", "Success", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                BindFormContents();
            }
        }

        private void gridReceiveView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridReceiveView_FocusedRowChanged(null, null);
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
           ResetText();
            if (lkAccount.EditValue != null && lkWarehouse.EditValue != null)
            {
                gridReceiveView.ActiveFilterString = String.Format("StoreID = {0} and WarehouseID = {1}", lkAccount.EditValue, lkWarehouse.EditValue);
            }
            else if (lkWarehouse.EditValue != null)
            {
                gridReceiveView.ActiveFilterString = String.Format("WarehouseID = {0}", lkWarehouse.EditValue);
            }
            else if (lkAccount.EditValue != null)
            {
                gridReceiveView.ActiveFilterString = String.Format("StoreID = {0}", lkAccount.EditValue);
            }
        }

        private void gridDetailView_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridDetailView.GetFocusedDataRow();
            int receiveID = Convert.ToInt32(dr["ReceiveID"]);
            using (EditReceived er = new EditReceived(receiveID))
            {
                er.ShowDialog();
            }

        }



        private void lkWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            lkAccount_EditValueChanged(null, null);
        }


        private void btnCancelReceive_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Are you sure, you want to Cancel the Receipt Document?", "Are you sure:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                
                try
                {
                    int receiptID = Convert.ToInt32(gridReceiveView.GetFocusedDataRow()["ReceiptID"].ToString());
                    var receiveDoc = new ReceiveDoc();
                    receiveDoc.LoadByReceiptID(receiptID);
                    receiveDoc.Rewind();
                    while (!receiveDoc.EOF)
                    {
                        BLL.ReceiveDoc.DeleteAReceiveDocEntry(receiveDoc.ID, CurrentContext.UserId);
                        receiveDoc.MoveNext();
                    }
                    XtraMessageBox.Show("You have successfully canceled the draft receipt.", "Confirmation");
                    BindFormContents();
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show(exception.Message);
                }


            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gridReceiveView.ActiveFilterString = string.Format("PONo like '%{0}%' or Date like '%{0}%'", textEdit1.Text);
        }
    }
}