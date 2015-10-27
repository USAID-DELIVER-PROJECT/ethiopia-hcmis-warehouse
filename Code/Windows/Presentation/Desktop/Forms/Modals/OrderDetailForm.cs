using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class OrderDetailForm : DevExpress.XtraEditors.XtraForm
    {
        private int _itemID = 0;
        private int _unitID = 0;

        public OrderDetailForm(int itemID, int unitID)
        {
            _itemID = itemID;
            _unitID = unitID;
            InitializeComponent();
        }

        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            
            Item item = new Item();
            item.LoadByPrimaryKey(_itemID);

            txtItemName.Text = item.FullItemName;

            ItemUnit iu = new ItemUnit();
            iu.LoadByPrimaryKey(_unitID);
            txtUnit.Text = iu.Text;

            
            BLL.Balance balance = new Balance();
            gridApprovedPrinted.DataSource = balance.GetApprovedValueForFacility(CurrentContext.UserId, item.ID, iu.ID);

            gridPicklistPrinted.DataSource = balance.GetPicklistedValueForFacility(CurrentContext.UserId, item.ID, iu.ID);

            var activities = new Activity();
            activities.LoadByUserID(CurrentContext.UserId);
          
            DataTable dtbl = null;
            while (!activities.EOF)
            {
                DataTable dt = balance.GetSOHForAnItem(activities.ID, item.ID, iu.ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dt.Columns.Add("Account");
                    dt.Rows[0]["Account"] = activities.FullActivityName;
                    if (dtbl == null && Convert.ToInt32(dt.Rows[0]["SOH"]) > 0)
                    {
                        dtbl = dt;
                    }
                    else if (Convert.ToInt32(dt.Rows[0]["SOH"]) > 0)
                    {
                        dtbl.ImportRow(dt.Rows[0]);
                    }
                }
                activities.MoveNext();
            }

            gridItemStockStatus.DataSource = dtbl;
            this.Text = string.Format("({0} - {1}) Details of : {2}", _itemID, _unitID, item.FullItemName);

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridViewPicklistPrinted_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridViewPicklistPrinted.GetFocusedDataRow();
            if (dr != null)
            {
                int orderID = Convert.ToInt32(dr["OrderID"]);
                PickList pl = new PickList();
                gridPickListDetail.DataSource = pl.GetPickListDetailWithDiagnostics(orderID, _itemID, _unitID);

               // groupPLDetail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            }else{
               // groupPLDetail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
       }
    }
}