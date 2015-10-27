using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Desktop.ViewModels.Approval
{
    public class ConsumptionSettingViewModel
    {
        private readonly ConsumptionSetting _consumptionSetting;

        public ConsumptionSettingViewModel(ConsumptionSetting consumptionSetting)
        {
            _consumptionSetting = consumptionSetting;
        }
        public decimal Min { get { return _consumptionSetting.Min; } }
        public decimal Max { get { return _consumptionSetting.Max; } }
        public decimal SafetyStock { get { return _consumptionSetting.SafetyStock; } }
        public decimal EOP { get { return _consumptionSetting.EOP; } }
        public decimal LeadTime { get { return _consumptionSetting.LeadTime; } }

        public string Excess { get { return string.Format("> {0}", _consumptionSetting.Max); } }
        public string Normal { get { return string.Format("{0} - {1}", _consumptionSetting.Min,_consumptionSetting.Max); } }
        public string NearEOP { get { return string.Format("{0} - {1}", _consumptionSetting.EOP, _consumptionSetting.Min); } }
        public string BelowEOP { get { return string.Format("{0} - {1}", 0, _consumptionSetting.EOP); } }
        public string StockOut { get { return "0"; } }
       


    }
}
