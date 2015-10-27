using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HCMIS.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Desktop.Modals;
using PickList = HCMIS.Desktop.Reports.PickList;

namespace HCMIS.Desktop.Forms.Logs
{
    [FormIdentifier("AL-OL-OL-RP", "Issue Order List Log", "")]
    public partial class LogPickList : XtraForm
    {

        public LogPickList()
        {
            InitializeComponent();
        }

        // holds the currently selected order ID
        int OrderID = 0;
        private void ManageItems_Load(object sender, EventArgs e)
        {
            cboStores.SetupActivityEditor().SetDefaultActivity();
            // Bind the routes
            Route route = new Route();
            route.LoadAll();
            lkRoute.Properties.DataSource = route.DefaultView;
        }



        private void cboIssuedTo_EditValueChanged(object sender, EventArgs e)
        {
            if (lkIssuedTo.EditValue != null && cboStores.EditValue != null)
            {
                BLL.PickList plst = new BLL.PickList();
                DataTable dtRec = new DataTable();

                lstRefNo.DataSource = plst.GetDistinctPickList(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(lkIssuedTo.EditValue));
                gridTransactions.DataSource = dtRec;
            }
        }




        private void btnPrint_Click(object sender, EventArgs e)
        {
            var dvPickListMakeup = (DataTable)gridTransactions.DataSource;
            
            var ord = new BLL.Order();
            ord.LoadByPrimaryKey(OrderID);
            
            var rus = new Institution();
            rus.LoadByPrimaryKey(ord.RequestedBy);
            
            if (BLL.Settings.IsCenter)
            {
                dvPickListMakeup.Columns["PhysicalStoreTypeName"].ColumnName = "WarehouseName";
                dvPickListMakeup.Columns["SKUTOPICK"].ColumnName = "QtyInSKU";
                dvPickListMakeup.Columns["StoreGroupName"].ColumnName = "AccountName";
                dvPickListMakeup.Columns.Add("ActivityConcat");

                foreach (DataRow r in dvPickListMakeup.Rows)
                {
                    var activity = new Activity();
                    activity.LoadByPrimaryKey(Convert.ToInt32(r["StoreID"]));
                    r["ActivityConcat"] = activity.FullActivityName;
                }
            }
            var pl = HCMIS.Desktop.Reports.WorkflowReportFactory.CreatePicklistReport(ord, rus.Name, dvPickListMakeup.DefaultView);


            pl.ShowPreviewDialog();
            // refresh the display
            lstRefNo_FocusedNodeChanged(null, null);
        }



        private void lstRefNo_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

            
            var dr = (DataRowView)lstRefNo.GetDataRecordByNode(lstRefNo.Selection[0]);
            if (dr == null)
            {
                return;
            }

            string[] ReferenceNo = new string[2];
            ReferenceNo[0] = dr["RefNo"].ToString();
            ReferenceNo[1] = dr["Date"].ToString();
            DataTable dtTransactions;

            if (ReferenceNo[0] != "")
            {
                OrderID = Convert.ToInt32(dr["ID"]);
                if (OrderID != 0)
                {
                    //dtTransactions = iss.GetIssueByRefNo(ReferenceNo[0], Convert.ToInt32(cboStores.EditValue));
                    OrderID = Convert.ToInt32(dr["ID"]);
                    BLL.PickList pl = new BLL.PickList();
                    dtTransactions = pl.GetPickListDetailsForOrder(OrderID).Table;

                    // Fix the column names for the reports to recognize
                    //dtTransactions.Columns["BatchNumber"].ColumnName = "BatchNo";
                    //dtTransactions.Columns["ExpireDate"].ColumnName = "ExpDate";
                    //dtTransactions.Columns["SKUTOPICK"].ColumnName = "QtyInSKU";
                    //dtTransactions.Columns["Packs"].ColumnName = "Pack";
                    //dtTransactions.Columns["Cost"].ColumnName = "CalculatedCost";
                    gridTransactions.DataSource = dtTransactions;
                }


            }
        }






        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null)
            {
                BLL.PickList pl = new BLL.PickList();
                DataTable dtIssue = pl.GetDistinctPickList(Convert.ToInt32(cboStores.EditValue));
                // add the current year datarow
                DataRowView drv = dtIssue.DefaultView.AddNew();
                drv["ID"] = 0;
                drv["RefNo"] = "Current Year";
                lstRefNo.DataSource = dtIssue;

            }
        }

        private object GetForPrint(DataView dv)
        {
            DataTable dtbl = dv.Table.Clone();
            dtbl.Columns.Add("Supplier");
            dtbl.Clear();
            foreach (DataRowView drv in dv)
            {
                if (dtbl.Rows.Count == 0)
                {
                    dtbl.ImportRow(drv.Row);
                }
                else
                {
                    //check if items with same expiry esists in the table
                    DataRow[] ar = dtbl.Select(string.Format("ItemID={0} and BatchNumber='{1}' and UnitPrice = {2}", drv["ItemID"], drv["BatchNumber"], drv["UnitPrice"]));
                    if (ar.Length > 0)
                    {
                        ar[0]["SKUPICKED"] = Convert.ToInt32(ar[0]["SKUPICKED"]) + Convert.ToInt32(drv["SKUPICKED"]);
                        ar[0]["Cost"] = Convert.ToInt32(ar[0]["Cost"]) + Convert.ToInt32(drv["Cost"]);
                        ar[0].EndEdit();
                    }
                    else
                    {
                        dtbl.ImportRow(drv.Row);
                    }
                }

            }

            Supplier supplier = new Supplier();
            ReceiveDoc rd = new ReceiveDoc();
            foreach (DataRow drw in dtbl.Rows)
            {
                rd.LoadByPrimaryKey(Convert.ToInt32(drw["ReceiveDocID"]));
                if (rd.RowCount > 0)
                {
                    supplier.LoadByPrimaryKey(rd.SupplierID);
                    drw["Supplier"] = supplier.CompanyName;
                    drw.EndEdit();
                }
            }
            return dtbl;
        }

        private void lkRoute_EditValueChanged(object sender, EventArgs e)
        {
            Institution rec = new Institution();

            if (lkRoute.EditValue.ToString() == "0")
            {
                lkIssuedTo.Properties.DataSource = rec.GetFacilitiesThatEverReceivedItems(); ;
            }
            else
            {
                lkIssuedTo.Properties.DataSource = rec.GetAllUnderRoute(Convert.ToInt32(lkRoute.EditValue));
            }

        }

    }
}