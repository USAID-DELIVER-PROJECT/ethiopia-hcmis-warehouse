using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class Category
    {
        [SelectQuery]
        public static string SelectGetCategoryTreeCategory()
        {
            string query =
                String.Format(
                    "select 'C' + cast(ID as varchar) as ID , CategoryName Name, 'P999' Parent  from Category order by Name");
            return query;
        }

        [SelectQuery]
        public static string SelectGetCategoryTreeSubCategory()
        {
            return String.Format(
                    "select 'S' + cast(ID as varchar) as ID , SubCategoryName Name, 'C' + cast(CategoryId as varchar) Parent  from SubCategory");
        }
    }
}
