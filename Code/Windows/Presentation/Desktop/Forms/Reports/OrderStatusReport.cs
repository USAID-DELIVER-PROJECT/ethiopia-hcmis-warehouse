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
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-OS-OS-RP","Order Status","")]
    public partial class OrderStatusReport : XtraForm
    {
        public OrderStatusReport()
        {
            InitializeComponent();
        }

        private void OrderStatusReport_Load(object sender, EventArgs e)
        {
            lkStoreType.SetupModeEditor().SetDefaultMode();
   
            lkStoreType_EditValueChanged(null,null);
            
        }

        private void gridOrderListView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridOrderListView.GetFocusedDataRow();
            if (dr != null)
            {
                int OrderID = Convert.ToInt32(dr["ID"]);
                OrderDetail order = new OrderDetail();
                order.LoadAllByOrderID(OrderID);
                gridOrderDetail.DataSource = order.DefaultView;
            }
        }

        private void txtFacilityName_EditValueChanged(object sender, EventArgs e)
        {
            gridOrderListView.ActiveFilterString = "FacilityName like '" + txtFacilityName.Text + "%'";
            gridOrderListView_FocusedRowChanged(null, null);
        }

        private void lkStoreType_EditValueChanged(object sender, EventArgs e)
        {
            gridOrders.DataSource = BLL.Order.GetOrderStatusList(Convert.ToInt32(lkStoreType.EditValue));
        }
    }
}
