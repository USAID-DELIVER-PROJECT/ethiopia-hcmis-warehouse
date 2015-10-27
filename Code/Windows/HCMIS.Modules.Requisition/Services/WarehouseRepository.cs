using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using HCMIS.Modules.Requisition.Domain;
using PhysicalStore = HCMIS.Modules.Requisition.Domain.PhysicalStore;

namespace HCMIS.Modules.Requisition.Services
{
    public class PhysicalStoreRepository : CachedRepository<Domain.PhysicalStore, int>
    {
        protected override ICollection<Domain.PhysicalStore> GetData()
        {

            ICollection<Domain.PhysicalStore> physicalStores = new Collection<Domain.PhysicalStore>();
            var dbPhysicalStores = new BLL.PhysicalStore();
            dbPhysicalStores.LoadAll();
            while (!dbPhysicalStores.EOF)
            {
                physicalStores.Add(new Domain.PhysicalStore { PhysicalStoreID = dbPhysicalStores.ID, Name = dbPhysicalStores.Name });
                dbPhysicalStores.MoveNext();
            }
            return physicalStores;
        }

        public override PhysicalStore FindSingle(int id)
        {

            return FindAll().SingleOrDefault(i => i.PhysicalStoreID == id);
        }
    }
}
