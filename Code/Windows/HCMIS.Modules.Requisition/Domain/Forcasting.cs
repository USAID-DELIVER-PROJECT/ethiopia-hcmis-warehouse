using System;

namespace HCMIS.Modules.Requisition.Domain
{
    public class Forcasting
    {
        public Item Item { get; set; }
        public Unit Unit { get; set; }
        public decimal TotalIssued { get; set; }
        public decimal Dos { get; set; }
        public int FiscalYearDays { get; set; }

        public decimal getAmc()
        {
            var Consumptiondates = FiscalYearDays - Dos;
            if (Consumptiondates > 0)
            {
                var amc = (TotalIssued/Consumptiondates)*30;
                return Math.Round(amc,2, MidpointRounding.AwayFromZero);
            }
            return 0;
        }

        public decimal getMos(decimal Soh)
        {
            var amc = getAmc();
            if (amc > 0)
            {
                return (Soh/amc);
            }
            
            if(Soh == 0)
            {
                return 0;
            }
            return (decimal) Math.Round((FiscalYearDays/30.0),2,MidpointRounding.AwayFromZero);
        }

        public Stockstatus getStockStatus(decimal Soh,ConsumptionSetting consumptionSetting )
        {
            var mos = getMos(Soh);
           if(mos > consumptionSetting.Max)
           {
               return Stockstatus.Excess;
           } 
            if(mos > consumptionSetting.Min && mos < consumptionSetting.Max)
            {
                return Stockstatus.Normal;
            }
            if (mos > consumptionSetting.EOP && mos < consumptionSetting.Min)
            {
                return Stockstatus.NearEOP;
            }
            if (mos > 0 && mos < consumptionSetting.EOP)
            {
                return Stockstatus.BelowEOP;
            }

            return Stockstatus.StockOut;
           
        }

    }
}
