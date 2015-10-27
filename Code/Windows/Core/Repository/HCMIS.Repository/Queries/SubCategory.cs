using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class SubCategory
    {
        public static string SelectGetSubCategoryByID(int categoryId)
        {
            string query = String.Format("SELECT * FROM vwGetCategory WHERE ID = {0}", categoryId);
            return query;
        }

        public static string SelectGetSubCategoryOfItem(int itemId)
        {
            string query = String.Format("SELECT * FROM vwGetItemsByCategory WHERE ID = {0}", itemId);
            return query;
        }
    }
}
