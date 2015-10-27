using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HCMIS.Modules.Requisition.Services
{
    public class ConsumptionSettingRespository : CachedRepository<Domain.ConsumptionSetting, int>
    {

        protected override ICollection<Domain.ConsumptionSetting> GetData()
        {

            ICollection<Domain.ConsumptionSetting> consumptionSettings = new Collection<Domain.ConsumptionSetting>();
            var generalinfo = new BLL.GeneralInfo();
            generalinfo.LoadAll();

            consumptionSettings.Add(new Domain.ConsumptionSetting
                                {
                                    Min = generalinfo.Min,
                                    Max = generalinfo.Max,
                                    LeadTime = generalinfo.LeadTime,
                                    SafetyStock = generalinfo.SafteyStock,
                                    EOP = (decimal) generalinfo.EOP
                                });
            generalinfo.MoveNext();

            return consumptionSettings;
        }

        public Domain.ConsumptionSetting FindCurrentSetting()
        {
            return FindAll().First();
        }

        public override Domain.ConsumptionSetting FindSingle(int id = 0)
        {
            return FindAll().FirstOrDefault();
        }
    }
}
