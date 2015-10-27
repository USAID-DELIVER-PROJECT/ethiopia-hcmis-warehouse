using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class RequisitionCenter : Form
    {
        public RequisitionCenter()
        {
            InitializeComponent();
        }

        private void RequisitionCenter_Load(object sender, EventArgs e)
        {
            var mode = new Mode();
            mode.LoadAll();
            lkMode.Properties.DataSource = mode.DefaultView;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if(lkMode.EditValue !=null)
            {
                Balance balance = new Balance();
                balance.GetSOHByMode(Convert.ToInt32(lkMode.EditValue));
                gridSOH.DataSource = balance.GetSOHByMode(Convert.ToInt32(lkMode.EditValue));
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            var dt = (DataView) gridView1.DataSource;
            dt.RowFilter = "Requested >0";
            if (dt == null) return;
            var po = new PO();
            po.AddNew();
            var serverDateTime = DateTimeHelper.ServerDateTime;
            po.PODate = serverDateTime;
            po.DateOfEntry = serverDateTime;
            po.PurchaseType = POType.INTERNAL;
            po.PaymentTypeID = PaymentType.Constants.STV;
            po.TermOfPayement = TermOfPayment.List[6].ID;
            po.PurchaseOrderStatusID = 9; //PurchaseOrderStatus ==> Processed
            po.SavedbyUserID = CurrentContext.LoggedInUser.ID;
            po.Save();
            var purchaseOrderDetail = new PurchaseOrderDetail();
            foreach (DataRowView dr in dt)
            {
                var itemUnit = new ItemUnitBase();
                itemUnit.LoadByPrimaryKey(Convert.ToInt32(dr["UnitID"]));
               
                purchaseOrderDetail.AddNew();
                purchaseOrderDetail.ItemID = Convert.ToInt32(dr["ItemID"]);
                purchaseOrderDetail.UnitOfIssueID = itemUnit.UnitOfIssueID;
                purchaseOrderDetail.Quantity = Convert.ToInt32(dr["Requested"]);
                purchaseOrderDetail.PurchaseOrderID = po.ID; 
                purchaseOrderDetail.Rowguid = Guid.NewGuid();
                purchaseOrderDetail.ApprovedQuantity = 0;
          
            } 
            purchaseOrderDetail.Save();
            lookUpEdit1_EditValueChanged(null, null);

           
        }

    }
}
