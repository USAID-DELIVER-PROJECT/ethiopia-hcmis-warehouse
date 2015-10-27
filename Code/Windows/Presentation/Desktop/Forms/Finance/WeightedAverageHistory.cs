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
using DevExpress.XtraCharts;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class WeightedAverageHistory : XtraForm
    {
        CostElement costElement;


        public WeightedAverageHistory(int ItemID, int AccountID, int ManufacturerID, int ItemUnitID)
        {
            costElement = new CostElement(ItemID, AccountID, ManufacturerID, ItemUnitID);
            InitializeComponent();
        }
        public WeightedAverageHistory(CostElement costElement)
        {
            this.costElement = costElement;
            InitializeComponent();
        }
        private void WeightedAverageHistory_Load(object sender, EventArgs e)
        {
            MovingAverageHistory history = new MovingAverageHistory();
            gridBeggining.DataSource = history.GetBeginningBalance(costElement);
            gridAllSimilarItems.DataSource = history.GetHistory(costElement);
            
        }

        public object WeightAverageLog { get; set; }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridAllSimilarItems.ShowPrintPreview();
        }
        
    }
}
