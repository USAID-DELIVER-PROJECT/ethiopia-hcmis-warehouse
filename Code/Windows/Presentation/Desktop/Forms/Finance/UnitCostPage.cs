using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;

namespace HCMIS.Desktop.Forms.Modals.Finance
{
    public partial class UnitCostPage : DevExpress.XtraEditors.XtraForm
    {
        private int ReceiptID;
        private int ItemID;
        private int ItemUnitID;
        private int ManufacturerID;
        private int ActivityID;
        private double NewUnitCost;
        private DataTable ReceiveDocDetails;
        
        public UnitCostPage()
        {
            InitializeComponent();
        }

        public UnitCostPage(int ReceiptID, int ItemID, int ItemUnitID, int ManufacturerID, int ActivityID, double NewUnitCost)
        {
            InitializeComponent();
            //Load All From Receivedoc
            this.ReceiptID = ReceiptID;
            this.ItemID = ItemID;       
            this.ItemUnitID = ItemUnitID;
            this.ManufacturerID = ManufacturerID;
            this.ActivityID = ActivityID;
            this.NewUnitCost = NewUnitCost;
        }

        private void PricePerPackPage_Load(object sender, EventArgs e)
        {
            LoadAndBind();
            //Incase the user Closes the form in other Method Than the 2 available but
            //the Default Dialog Result return should be Cancel
       //     this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
       }
        /// <summary>
        /// Load All Neccessary Data and Bind To DataSource
        /// </summary>
        void LoadAndBind()
        {
            //Bind
            gridRelatedReceives.DataSource = ReceiveDocDetails;
            //Load Detail Table To Grid
            ReceiveDocDetails = ReceiveDoc.GetRelatedReceiveForUnitCost(ReceiptID, ItemID, ItemUnitID, ManufacturerID, ActivityID, NewUnitCost);
            gridRelatedReceives.DataSource = ReceiveDocDetails;
            
            //Load Header Information From first row to be displayed
            if (ReceiveDocDetails.Rows.Count > 0)
            {
                DataRow dr = ReceiveDocDetails.Rows[0];
                txtStockCode.EditValue = dr["StockCode"].ToString();
                txtItemName.EditValue = dr["FullItemName"].ToString();
                txtItemUnit.EditValue = dr["ItemUnitName"].ToString();
                txtManufacturerName.EditValue= dr["ManufacturerName"].ToString();
                txtActivityName.EditValue = dr["ActivityName"].ToString();
            }
         
        }
        private void LoadReceivesDetails()
        {
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (DataRowView Cursor in ReceiveDocDetails.AsDataView())
            {
                int ID = Convert.ToInt32(Cursor["ID"]);
                ReceiveDoc.SetUnitCostByReceiveDoc(ID, NewUnitCost, CurrentContext.UserId);
                if (BLL.Settings.IsCenter)
                {
                    ReceiveDoc.SetAverageCostByReceiveDoc(ID, NewUnitCost, CurrentContext.UserId);
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        
    }
}