using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
     [FormIdentifier("RP-DD-DD-RP", "Dashboard", "")]
    public partial class Dashboard : DevExpress.XtraEditors.XtraForm
    {

        private bool zoomedIn = false;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            BindTransactionSummary();
        }

        private void BindTransactionSummary()
        {
            gridInvoiceSummary.DataSource = Order.GetWeeklyInvoiceSummary();
            gvInvoiceSummary.ExpandAllGroups();
            gridPickListSummary.DataSource = Order.GetWeeklyPickListSummary();
            gvPickList.ExpandAllGroups();
            wishListSummary.DataSource = Order.GetWeeklyWishListSummary();
            gvWishList.ExpandAllGroups();
            RefreshTransactions(15);
            RefreshActivity(15);
        }

        private void RefreshTransactions(int days)
        {
            chartTransactions.DataSource = IssueDoc.GetWeeklyTransactionSummary(days);
        }

        private void RefreshActivity(int days)
        {
            chartActivity.Series["Requested"].DataSource = Order.GetWishListSummary(days);
            chartActivity.Series["Cancelled"].DataSource = Order.GetOrdersForReport(OrderStatus.Constant.CANCELED, days);
            chartActivity.Series["Issued"].DataSource = IssueDoc.GetIssueSummary(days);
            chartActivity.Series["Picklist"].DataSource = PickList.GetPickListSummary(days);
        }

        private void chartActivity_Click(object sender, EventArgs e)
        {
            if (!zoomedIn)
            {
                ZoomIn(lcActivitySummary);
                zoomedIn = true;
                RefreshActivity(30);
                lcActivitySummary.Text = "Activity Summary (Click on the chart to zoom out)";
            }
            else
            {
                ZoomOut();
                zoomedIn = false;
                RefreshActivity(15);
                lcActivitySummary.Text = "Activity Summary (Click on the chart to zoom in)";
            }
        }

        private void ZoomIn(DevExpress.XtraLayout.LayoutControlGroup lcToZoomIn)
        {
            DevExpress.XtraLayout.LayoutControlGroup[] layoutControls = { lcActivitySummary, lcInvoiceSummary, lcPicklistSummary, lcTransactionSummary, lcWishlistSummary };
            foreach (DevExpress.XtraLayout.LayoutControlGroup lc in layoutControls)
            {
                if (lc == lcToZoomIn)
                    lc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                else
                    lc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void ZoomOut()
        {
            DevExpress.XtraLayout.LayoutControlGroup[] layoutControls = { lcActivitySummary, lcInvoiceSummary, lcPicklistSummary, lcTransactionSummary, lcWishlistSummary };
            foreach (DevExpress.XtraLayout.LayoutControlGroup lc in layoutControls)
            {                
                    lc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void chartTransactions_Click(object sender, EventArgs e)
        {
            if (!zoomedIn)
            {
                ZoomIn(lcTransactionSummary);
                zoomedIn = true;
                RefreshTransactions(30);
                lcTransactionSummary.Text = "Transaction Summary (Click on the chart to zoom out)";
            }
            else
            {
                ZoomOut();
                zoomedIn = false;
                RefreshTransactions(15);
                lcTransactionSummary.Text = "Transaction Summary (Click on the chart to zoom in)";
            }
        }

    }
}