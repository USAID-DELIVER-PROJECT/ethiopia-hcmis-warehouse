using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Concrete.Models
{
    
    public class StoreType
    {
        public StoreType()
        {
            this.Stores = new List<Store>();
        }
      
        public int ID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
