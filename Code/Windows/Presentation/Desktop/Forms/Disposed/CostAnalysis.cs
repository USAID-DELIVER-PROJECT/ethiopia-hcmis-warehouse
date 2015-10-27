using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using DevExpress.XtraEditors;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class CostAnalysis : DevExpress.XtraEditors.XtraForm
    {
        DataView dvJournal;
        int supplierID;
        int storeID;
        public CostAnalysis()
        {
            dvJournal = new DataView();
            InitializeComponent();
        }
        public CostAnalysis(DataView dvJournal,int supplierID,int storeID)
        {
           this.supplierID = supplierID;
            this.storeID = storeID ;
            this.dvJournal = dvJournal;
            InitializeComponent();
        }

        private void CostAnalysis_Load(object sender, EventArgs e)
        {
            gridJournal.DataSource = dvJournal;
            var store = new BLL.Activity();
            store.LoadByPrimaryKey(storeID);
            textEdit1.EditValue = store.Name;
            var supplier = new BLL.Supplier();
            supplier.LoadByPrimaryKey(supplierID);
            textEdit2.EditValue = supplier.CompanyName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridJournal.Print();
            this.Close();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}