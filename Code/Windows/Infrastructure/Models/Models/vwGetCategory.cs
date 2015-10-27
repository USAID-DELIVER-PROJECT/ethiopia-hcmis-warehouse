using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwGetCategory
    {
        public string SubCategoryName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ID { get; set; }
        public string CategoryCode { get; set; }
        public string SubCategoryCode { get; set; }
        public Nullable<int> ParentID { get; set; }
    }
}
