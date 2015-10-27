using System;
using System.Collections.Generic;
using System.Linq;

namespace HCMIS.Specification.Finance.Domain.Entities
{
    public interface IActivity
    {
        int ID { get; set; }

        bool IsFreeStore { get; }
        int MovingAverageGroupID { get; set; }
     //   IEnumerable<IActivity> RelatedActivities { get; }
        void Load(int ID);
    }
}
