using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using HCMIS.Core.Finance.CostTier.Services;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Forms.Modals;
using HCMIS.Specification.Finance.CostTier;
using HCMIS.Core.Finance.CostTier;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    
    public partial class MovingAverage : DevExpress.XtraEditors.XtraForm
    {
        
        private CostElement costElement;
        private string receiveDocs;
        private decimal previousUnitCost, previousQty;
        private AverageCostCalculator averageCostCalculator;

        public MovingAverage()
        {
            InitializeComponent();
        }
        public MovingAverage(CostElement costElement,string receivedocs)
        {
            InitializeComponent();
            this.costElement = costElement;
            receiveDocs = receivedocs;
        }
        public MovingAverage(int itemID,int itemUnitID,int manufacturerID,int MovingAverageID,double Qty,double UnitCost,double margin,string receivedocs)
        {
            InitializeComponent();
            costElement = new CostElement();
            costElement.ItemID = itemID;
            costElement.ItemUnitID = itemUnitID;
            costElement.ManufacturerID = manufacturerID;
            costElement.MovingAverageID = MovingAverageID;
            costElement.UnitCost = UnitCost;
            costElement.Margin = margin;
            costElement.Qty = Qty;
            receiveDocs = receivedocs;
        }

        private void PriceSettings_Load(object sender, EventArgs e)
        {
            LoadAndCalculate();
            CreateDataViewAndBind();
        }

        private void LoadAndCalculate()
        {
            var ledgerService = new LedgerService();
            var ledgerObject = ledgerService.GetLedger(costElement.ItemID, costElement.ItemUnitID, costElement.ManufacturerID,
                                                       costElement.MovingAverageID);

            previousQty = ReceiveDoc.GetSoundStock(costElement);


            previousUnitCost = Math.Round(ledgerObject.UnitCost, BLL.Settings.NoOfDigitsAfterTheDecimalPoint,
                                          MidpointRounding.AwayFromZero);


            AverageCostCalculator averageCostCalculator = new AverageCostCalculator(costElement);

            costElement.AverageCost = averageCostCalculator.CalculateMovingAverage(Convert.ToDouble(previousQty),
                                                                                   Convert.ToDouble(previousUnitCost),
                                                                                   costElement.Qty, costElement.UnitCost);
            costElement.SellingPrice = averageCostCalculator.GetSellingPrice(BLL.Settings.IsCenter?0:costElement.Margin);

            txtItemName.Text = costElement.ItemName;
            txtManufacturer.Text = costElement.ManufacturerName;
            txtUnit.Text = costElement.ItemUnitName;
        }

        private void CreateDataViewAndBind()
        {
            DataTable dataTable = dataSet1.Tables["MovingAverage"];
            DataRow dataRow = dataTable.NewRow();
            dataRow["Quantity"] = costElement.Qty;
            dataRow["UnitCost"] = costElement.UnitCost;
            dataRow["TotalBegCost"] = costElement.Qty*costElement.UnitCost;

            dataRow["PreviousQuantity"] = previousQty;
            dataRow["PreviousUnitCost"] = previousUnitCost;
            dataRow["PreviousTotalCost"] = previousQty*previousUnitCost;
            dataRow["TotalQuantity"] = Convert.ToDecimal(costElement.Qty) + previousQty;
            dataRow["AverageCost"] = costElement.AverageCost;
            dataRow["TotalCost"] = (Convert.ToDecimal(costElement.Qty) + previousQty)*
                                   Convert.ToDecimal(costElement.AverageCost);
            dataRow["Margin"] = costElement.Margin;
            dataRow["SellingPrice"] = costElement.SellingPrice;
            dataTable.Rows.Add(dataRow); 
            gridBeginning.DataSource = dataTable;
        }

        private void btnMovingAverage_Click(object sender, EventArgs e)
        {
            MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();

            var dialogResult =
                XtraMessageBox.Show(
                    String.Format("Are you Sure you want to Set the  Price for {0}", txtItemName.Text),
                    "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    transaction.BeginTransaction();
                    // This is where we set the Price
                    JournalService journalService = new JournalService();
                    journalService.StartRecordingSession();
                    costElement.SavePrice(CurrentContext.UserId, "", journalService, ChangeMode.BeginningBalance);
                    journalService.CommitRecordingSession();
                    journalService.StartRecordingSession(); 
                    costElement.ConfirmPrice(CurrentContext.UserId, "", journalService, ChangeMode.BeginningBalance);
                    journalService.CommitRecordingSession();
                    ReceiveDoc receiveDoc = new ReceiveDoc();
                    receiveDoc.SavePrice(costElement, CurrentContext.UserId);
              
                    ReceiveDocConfirmation receiveDocConfirmation = new ReceiveDocConfirmation();
                    receiveDocConfirmation.ChangeStatusByAccountReceiveDocs(receiveDocs, ReceiptConfirmationStatus.Constants.GRV_PRINTED, ReceiptConfirmationStatus.Constants.PRICE_CALCULATED);
                    transaction.CommitTransaction();
                    this.Close();
                }
                catch (Exception exception)
                {
                    transaction.RollbackTransaction();
                    XtraMessageBox.Show("Error : " + exception.Message, "Error...", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    throw exception;
                }
            }
        }
    }
}