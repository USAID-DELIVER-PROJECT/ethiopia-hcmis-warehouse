using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class Category
    {
        public Category()
        {
            this.SubCategories = new List<SubCategory>();
        }

        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
