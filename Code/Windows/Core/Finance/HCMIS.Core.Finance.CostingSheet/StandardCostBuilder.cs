
using System;
using HCMIS.Specification.Finance.CostingSheet;


namespace HCMIS.Core.Finance.CostingSheet
{
    public class StandardCostBuilder:ICostBuilder
    {
        private decimal _initalCost;
        private decimal _totalCost;
        private decimal _costCoefficient;

        public decimal CostCoefficient
        {
            get { return _costCoefficient; }
            private set { _costCoefficient = value; }
        }

        public decimal TotalCost
        {
            get { return _totalCost; }
            private set { _totalCost = value; }
        }

        public decimal InitalCost
        {
            get { return _initalCost; }
            set
            {
                _initalCost = value;
                _totalCost = value;
            }
        }

        public decimal GetUnitCost(decimal unitCost)
        {
            return CostCoefficient * unitCost;
        }

        public decimal AddToTotalCost(decimal cost)
        {
            TotalCost += cost;
            CostCoefficient = TotalCost/InitalCost;
            return TotalCost; 
        }
    }
}
