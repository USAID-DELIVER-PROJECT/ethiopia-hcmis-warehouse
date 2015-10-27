using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Modules.Requisition.Services
{
    public class ActivityRepository : CachedRepository<Domain.ActivityGroup, string>
    {

        protected override ICollection<ActivityGroup> GetData()
        {

            ICollection<Domain.ActivityGroup> activities = new Collection<Domain.ActivityGroup>();
            var dbActivities = new BLL.Activity();
            dbActivities.LoadAll();
            while (!dbActivities.EOF)
            {
                activities.Add(new ActivityGroup { Activity = new Activity { ActivityID = dbActivities.ID, Name = dbActivities.FullActivityName }, IsDeliveryNote = true });
                activities.Add(new ActivityGroup { Activity = new Activity { ActivityID = dbActivities.ID, Name = dbActivities.FullActivityName }, IsDeliveryNote = false });
                dbActivities.MoveNext();
            }
            return activities;
        }

        public ActivityGroup FindSingle(int id, bool isDeliveryNote)
        {

            return FindAll().SingleOrDefault(i => i.Activity.ActivityID == id && i.IsDeliveryNote ==isDeliveryNote);
        }

        public override ActivityGroup FindSingle(string id)
        {
            return FindAll().SingleOrDefault(i => i.ActivityGroupID == id && !i.IsDeliveryNote);
        }
    }
}
