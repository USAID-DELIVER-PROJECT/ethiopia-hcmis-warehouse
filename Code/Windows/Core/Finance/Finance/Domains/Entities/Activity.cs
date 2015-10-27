using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Specification.Finance.Domain.Entities;
using HCMIS.Core.Finance.Domain;
using HCMIS.Concrete.Repository;
using HCMIS.Concrete.Models;

namespace HCMIS.Core.Finance.Domain.Entities
{
   public class Activity:DomainBase,IActivity
    {
        public static int RDF;
        public static int HEALTH_PROGRAM;
        public Activity(IRepositoryFactory Repository) : base(Repository) { }

        public int ID
        {
            get;
            set;
        }

        public bool IsFreeStore
        {
            get;
            private set;
        }

        public int MovingAverageGroupID
        {
            get;
            set;
        }

        public IEnumerable<IActivity> RelatedActivities
        {
            get;
            set;
        }

        public void Load(int ID)
        {
            Store Activity;
            StoreGroup Account;
            StoreGroupDivision SubAccount;
            Activity = _Repository.Stores.Single(s => s.ID == ID);
            this.ID = Activity.ID;
            SubAccount = _Repository.StoreGroupDivisions.Single(s => s.ID == Activity.StoreGroupDivisionID.Value);
            Account = _Repository.StoreGroups.Single(s => s.ID == SubAccount.StoreGroupID.Value);
            MovingAverageGroupID = Account.ID;
        
            IsFreeStore = (Account.StoreTypeID.Value != RDF);
            
        }
    }
}
