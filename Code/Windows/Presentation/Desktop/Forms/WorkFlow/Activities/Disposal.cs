using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HCMIS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCMIS.Desktop.ViewHelpers;
using BLL.Services;

namespace HCMIS.Desktop.Forms.WorkFlow.Activities
{
    //Copy values over to the other grid -------------------------high priority -- done
    //Ask the user to confirm ------------------------------------low priority
    //Create a new Order entry for each item to be disposed ------high priority
    //Create an IssueDoc entry for each item to be disposed ------high priority
    //Save the entries -------------------------------------------high priority
    //Print some document ----------------------------------------later


   [FormIdentifier("AC-DI-DI-FR", "Disposal", "")]
   //     [FormIdentifier("AC-DN-DN-TA", "Delivery Note To STV", "")]

    public partial class Disposal : XtraForm
    {
        public Disposal()
        {
            InitializeComponent();
            glkActivity.Properties.DataSource = Activity.GetAccountTree(CurrentContext.UserId);
            glkActivity.SetupActivityEditor();
        }

        private void glkActivity_EditValueChanged(object sender, EventArgs e)
        {
            LoadExpiredItems();
        }

        private void LoadExpiredItems()
        {
            Item item = new Item();
            if(glkActivity.EditValue != null)
            {
                int activityId = (int)glkActivity.EditValue;
                var dt = item.GetExpiredItemsByActivity(activityId);
                dt.Columns.Add(
                    new DataColumn()
                    {
                        ColumnName = "IsSelected",
                        DataType = typeof(bool),
                        DefaultValue = false,
                        AllowDBNull = true,
                    }
                );
                grdExpiredItems.DataSource = dt;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
                DataTable dt = new DataTable();
                dt.Columns.Add("ReceiveDocID", typeof(int));
                dt.Columns.Add("ItemID", typeof(int));
                dt.Columns.Add("UnitID", typeof(int));
                dt.Columns.Add("Pack", typeof(decimal));
                dt.Columns.Add("QtyPerPack", typeof(int));
                dt.Columns.Add("StockOnHand", typeof(decimal));
                dt.Columns.Add("StoreID", typeof(int));

                dt.Columns.Add("FullItemName", typeof(string));
                dt.Columns.Add("Unit", typeof(string));
                dt.Columns.Add("BatchNo", typeof(string) );
                dt.Columns.Add("Quantity", typeof(decimal));
                dt.Columns.Add("Amount", typeof(decimal));
                dt.Columns.Add("ExpiryDate", typeof(DateTime));
                dt.Columns.Add("Manufacturer", typeof(string));
                dt.Columns.Add("CountryOfOrigin", typeof(string));

                for (int i = 0; i < grdExpiredItemsView.RowCount; i++)
                {
                    DataRow dr = grdExpiredItemsView.GetDataRow(i);
                    if(Convert.ToBoolean(dr["IsSelected"]) == true)
                        dt.Rows.Add(dr["ReceiveDocID"], dr["ItemID"], dr["UnitID"], dr["Pack"], dr["StoreID"], dr["StockOnHand"], dr["QtyPerPack"], dr["FullItemName"], dr["Unit"], dr["BatchNo"], dr["Quantity"], dr["Amount"], dr["ExpiryDate"], dr["Manufacturer"], dr["CountryOfOrigin"]);
                }

                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Please select items to be disposed.");
                    return;
                }

                xtraTabPage2.PageEnabled = true;
                grdSelectedItems.DataSource = dt;
                xtraTabControl1.SelectedTabPageIndex = 1;
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            TransferService transferService = new TransferService();
            IssueService issueService = new IssueService();
            
            if (XtraMessageBox.Show("Please Confirm that you want to dispose the selected items", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int activityID = Convert.ToInt32(glkActivity.EditValue);
                var dt = (DataView)grdSelectedExpiredItemsView.DataSource;
                
                Order order = OrderForDisposal(activityID);
                PickList picklist = PickList.GeneratePickList(order.ID);
                
                BLL.Issue stvLog = issueService.CreateSTVLog(null, false, picklist, order, null, activityID, false, CurrentContext.UserId);

                foreach (DataRow row in dt.Table.Rows)
                {
                    ReceiveDoc rd = new ReceiveDoc();
                    ReceivePallet rp = new ReceivePallet();

                    rd.LoadByPrimaryKey((int)row["ReceiveDocID"]);
                    rp.LoadByReceiveDocID((int)row["ReceiveDocID"]);

                    var picklistDetail = transferService.GeneratePickListDetail(rd, rp, order, picklist);
                    issueService.CreateIssueFromPicklist(picklistDetail, order, DateTime.Now, stvLog, CurrentContext.LoggedInUser);
                }

                HCMIS.Reports.Workflow.Activities.Disposal disposalPrintout = new HCMIS.Reports.Workflow.Activities.Disposal(glkActivity.Text, txtLicenseNo.Text, DateTime.Now, ((DataView)grdSelectedExpiredItemsView.DataSource).Table);
                disposalPrintout.PrintDialog();
    
                RefreshSelection();
                txtLicenseNo.ResetText();
            }
        }

        private void RefreshSelection()
        {
            grdSelectedItems.DataSource = null;
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            LoadExpiredItems();
        }

        private Order OrderForDisposal(int ActivityID)
        {
            var actvity = new Activity();
            actvity.LoadByPrimaryKey(ActivityID);

            var order = Order.SaveOrderToDB(OrderStatus.Constant.DISPATCH_CONFIRMED, CurrentContext.UserId, null, 5407, PaymentType.Constants.DISPOSAL, actvity.ModeID, "Expired Item Disposal", "", "", (DataView)grdSelectedExpiredItemsView.DataSource);
            return order;
        }

        private void txtBatchNo_EditValueChanged(object sender, EventArgs e)
        {
            LoadExpiredItems();
            if (String.IsNullOrEmpty(txtBatchNo.Text))
                return;


            DataView dv = grdExpiredItemsView.DataSource as DataView;
            grdExpiredItems.DataSource = dv.Table.AsEnumerable().Where(t => t.Field<string>("BatchNo") != null && t.Field<string>("BatchNo").Contains(txtBatchNo.Text)).CopyToDataTable();
        }

        private void xtraTabControl1_TabIndexChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
                if (e.PrevPage == xtraTabPage2 && e.Page == xtraTabPage1) xtraTabPage2.PageEnabled = false;
        }

    }
}
