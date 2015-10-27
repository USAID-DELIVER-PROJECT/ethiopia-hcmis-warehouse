using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ProductsCategory
    {
        public int ID { get; set; }
        public Nullable<int> SubCategoryID { get; set; }
        public Nullable<int> ItemId { get; set; }
        public virtual Item Item { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
