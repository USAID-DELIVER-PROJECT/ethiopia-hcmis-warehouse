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
using HCMIS.Desktop.Modals;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    public enum RelatedReceiptMode
    {
        WAREHOUSE_MODE = 1,
        PHYSICAL_STORE_MODE = 2
    }

    public partial class RelatedReceipts : XtraForm
    {
        private RelatedReceiptMode mode;
        private int _reciptID;
        private int _warehouseID;
        private int _accountID;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="warehouseOrPhysicalStoreID"></param>
        /// <param name="reciptID"></param>
        /// <param name="storeOrWarehouse">1-Warehouse, 2-Store</param>
        public RelatedReceipts(int accountID, int warehouseOrPhysicalStoreID, int reciptID, int storeOrWarehouse)
        {
            _reciptID = reciptID;
            _warehouseID = warehouseOrPhysicalStoreID;
            _accountID = accountID;
            if(storeOrWarehouse==1)
            {
                mode = RelatedReceiptMode.WAREHOUSE_MODE;
            }
            else
            {
                mode = RelatedReceiptMode.PHYSICAL_STORE_MODE;
            }
            InitializeComponent();
        }

        private void RelatedReceipts_Load(object sender, EventArgs e)
        {
            BLL.ReceiveDoc rdoc = new ReceiveDoc();
            rdoc.LoadByPrimaryKey(_reciptID);
            if (mode==RelatedReceiptMode.WAREHOUSE_MODE)
            {
                gridMain.DataSource = BLL.Receipt.GetRawInventoryCountbyAccountandWarehouseItem(_accountID, _warehouseID,
                    rdoc.ItemID, rdoc.UnitID);
            }
            else if(mode==RelatedReceiptMode.PHYSICAL_STORE_MODE)
            {
                gridMain.DataSource = BLL.Receipt.GetRawInventoryCountbyAccountandPhysicalStoreItem(_accountID, _warehouseID,
                    rdoc.ItemID, rdoc.UnitID);
            }

        }


        private void gridMasterView_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridMasterView.GetFocusedDataRow();
            EditReceived er = new EditReceived(Convert.ToInt32(dr["ID"]));
            if (er.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //// update the row if has been changed.
                //ReceiveDoc rDoc = new ReceiveDoc();
                //rDoc.LoadByPrimaryKey(Convert.ToInt32(dr["ID"]));

            }
        }
    }
}
