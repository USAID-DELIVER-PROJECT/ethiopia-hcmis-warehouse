using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BLL;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Modules.Requisition.Services
{
    class UnitRepository:CachedRepository<Unit,int>
    {
        protected override ICollection<Unit> GetData()
        {
           
             ICollection<Domain.Unit> units = new Collection<Domain.Unit>();
            var dbUnit = new BLL.ItemUnit();
            dbUnit.LoadAll();
            while (!dbUnit.EOF)
            {
                units.Add(new Unit { UnitID = dbUnit.ID, Text = dbUnit.Text });
                dbUnit.MoveNext();
            }
            return units;
        }

        public override Unit FindSingle(int id)
        {
            return FindAll().SingleOrDefault(i => i.UnitID == id);
        }
    }
}
