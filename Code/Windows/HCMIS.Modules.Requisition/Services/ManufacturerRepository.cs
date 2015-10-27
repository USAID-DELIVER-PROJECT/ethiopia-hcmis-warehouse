using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Manufacturer = HCMIS.Modules.Requisition.Domain.Manufacturer;

namespace HCMIS.Modules.Requisition.Services
{
    public class ManufacturerRepository:CachedRepository<Domain.Manufacturer,int>
    {
        protected override ICollection<Domain.Manufacturer> GetData()
        {

            ICollection<Domain.Manufacturer> manufacturers = new Collection<Domain.Manufacturer>();
            var dbManufacturers = new BLL.Manufacturer();
            dbManufacturers.LoadAll();
            while (!dbManufacturers.EOF)
            {
                manufacturers.Add(new Domain.Manufacturer { ManufacturerID = dbManufacturers.ID, Name = dbManufacturers.Name, CountryOfOrigin = dbManufacturers.CountryOfOrigin});
                dbManufacturers.MoveNext();
            }
            return manufacturers;
        }

        public override Manufacturer FindSingle(int id)
        {

            return FindAll().SingleOrDefault(i => i.ManufacturerID == id);
        }
    
    }
}
