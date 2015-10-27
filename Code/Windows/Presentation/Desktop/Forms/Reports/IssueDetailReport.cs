using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using HCMIS.Concrete.Models;
using HCMIS.Core.Distribution.Services;
using Item = BLL.Item;

namespace HCMIS.Desktop.Forms.Reports
{
    public partial class IssueDetailReport : DevExpress.XtraEditors.XtraForm
    {
        public string Item, Manufacturer, Unit, MovingAverage;
        public int ItemId, UnitId, ManufacturerId, MovingAverageId;
        public decimal UnitCost, Margin, SellingPrice;
        public int AffectedLedgerID;

        public IssueDetailReport()
        {
            InitializeComponent();
        }
      
        private void PricePerPackPage_Load(object sender, EventArgs e)
        {
            LoadAndBind();
            //Incase the user Closes the form in other Method Than the 2 available but
            //the Default Dialog Result return should be Cancel
              
        }
        /// <summary>
        /// Load All Neccessary Data and Bind To DataSource
        /// </summary>
        void LoadAndBind()
        {
            //Bind
        
          
          
        }

       
        private void btnConfirm_Click(object sender, EventArgs e)
        {
           
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