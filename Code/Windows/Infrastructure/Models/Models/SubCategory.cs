using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class SubCategory
    {
        public SubCategory()
        {
            this.ProductsCategories = new List<ProductsCategory>();
        }

        public int ID { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryCode { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParentID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductsCategory> ProductsCategories { get; set; }
    }
}
