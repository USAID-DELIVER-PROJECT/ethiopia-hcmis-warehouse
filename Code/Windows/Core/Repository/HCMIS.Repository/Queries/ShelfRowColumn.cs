using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ShelfRowColumn
    {
        [SelectQuery]
        public static string SelectLoadRowsForShelf(int id)
        {
            return String.Format("select * from ShelfRowColumn where Type = 'Row' and ShelfID = {0} Order By [Index] Desc", id);
        }

        [SelectQuery]
        public static string SelectLoadColumnsForShelf(int id)
        {
            return String.Format("select * from ShelfRowColumn where Type = 'Column' and ShelfID = {0}", id);
        }

        [SelectQuery]
        public static string SelectLoadColumnsForShelf(int shelfID, int column)
        {
            return String.Format("select * from ShelfRowColumn where Type = 'Column' and ShelfID = {0} and [Index] = {1}", shelfID, column);
        }

        [SelectQuery]
        public static string SelectLoadRowForShelf(int shelfID, int row)
        {
            return String.Format("select * from ShelfRowColumn where Type = 'Row' and ShelfID = {0} and [Index] = {1}", shelfID, row);
        }
    }
}
