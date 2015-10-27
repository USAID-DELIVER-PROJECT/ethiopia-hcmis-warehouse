using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class AverageCostCalculator
    {
        //Grouping Elements for MovingAverage
        CostElement CostElements;

        private double _previousQty;
        private double _previousUnitCost;
        private double _previousTotalCost;

        private double _receivedQty;
        private double _receivedUnitCost;
        private double _receivedTotalCost;

        private double _newQty;
        private double _newUnitCost;
        private double _newTotalCost;

        private DataTable _previousDataView;
        private DataTable _receiveDataView;
        private DataTable _newDataView;
        private double _priceDifference=0;

       
        //Properties
        public int ItemID
        {
            get
            {
                return CostElements.ItemID;
            }
        }

        public int ManufacturerID
        {
            get
            {
                return CostElements.ManufacturerID;
            }
        }

        public int ItemUnitID
        {
            get
            {
                return CostElements.ItemUnitID;
            }
        }

        public int AccountID
        {
            get
            {
                return CostElements.MovingAverageID;
            }
        }

        //Constructor
        public double PriceDifference
        {
            get
            {
                return _priceDifference;
            }
        }
     
        public AverageCostCalculator()
        {

        }
        
       
        
        public AverageCostCalculator(CostElement CostElements)
        {
            this.CostElements = CostElements;
        }

        public void LoadbyParameter(int? ReceiptID,int ItemID,int ManufacturerID,int ItemUnitID,int AccountID,int ActivityID)
        {
            CostElements = new CostElement((int)ReceiptID, ItemID, ItemUnitID, AccountID, ManufacturerID);
        }


        public double CalculateMovingAverage(double previousQty, double previousUnitCost, double receivedQty, double receivedUnitCost)
        {
            _previousQty = previousQty;
            _previousUnitCost = previousUnitCost;
            _receivedQty = receivedQty;
            _receivedUnitCost = receivedUnitCost;

            _previousTotalCost = _previousQty * _previousUnitCost;
            _receivedTotalCost = _receivedUnitCost * _receivedQty;

            _newQty = _previousQty + _receivedQty;
            _newTotalCost = _previousTotalCost + _receivedTotalCost;
            if (_newQty != 0)
            {
                _newUnitCost = Math.Round(_newTotalCost / _newQty, BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
                _priceDifference = Math.Round(_newUnitCost * _newQty, BLL.Settings.NoOfDigitsAfterTheDecimalPoint) - Math.Round(_newTotalCost, BLL.Settings.NoOfDigitsAfterTheDecimalPoint);
            }
            else
            {
                _newUnitCost = previousUnitCost;
                _priceDifference = 0;
            }
                return _newUnitCost;
            
        }

        public void SaveWeightedAverageLog(int Userid,int ReceiptID,double Margin,double NewSellingPrice)
        {

           
            MovingAverageHistory wal = new MovingAverageHistory();
            wal.AddNew();
            wal.ReceiptId = ReceiptID;
            wal.ItemID = CostElements.ItemID;
            wal.UnitID = CostElements.ItemUnitID;
            wal.SupplierID = 0;
            wal.ManufacturerID = CostElements.ManufacturerID;
            wal.UserID = Userid;
            wal.StoreID = CostElements.MovingAverageID;
            wal.UPQty = Convert.ToInt32(_receivedQty);

            if (_receivedUnitCost != 0)
                wal.UPUnitCost = _receivedUnitCost;
            else
                wal.UPUnitCost = 0;
            wal.UPTotalCost = _receivedTotalCost;
            wal.PQty = Convert.ToInt32(_previousQty);
            wal.PUnitCost = _previousUnitCost;
            wal.PTotalCost = _previousTotalCost;
            wal.NQty = Convert.ToInt32(_newQty);
            wal.NUnitCost = _newUnitCost;
            wal.NTotalCost = _newTotalCost;

            if (!Double.IsNaN(_priceDifference))
                wal.PriceDifference = _priceDifference;
            wal.Margin = Margin;
            wal.Price = NewSellingPrice;
            wal.Date = DateTimeHelper.ServerDateTime;
            //wal.Remark = Remark;P
            wal.Save();
        }

        public double GetSellingPrice(double Margin)
        {
            return Math.Round(Math.Round(_newUnitCost, BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero) * (1 + Margin), BLL.Settings.NoOfDigitsAfterTheDecimalPoint, MidpointRounding.AwayFromZero);
        }


    }
}
