
using DAL;
using System.Data;

namespace BLL
{
    /// <summary>
    /// Business logic class for ABC Analysis
    /// </summary>
	public class ABC : _ABC
	{
        public class Constants
        {
            public static int A;
            public static int B;
            public static int C;
        }

        /// <summary>
        /// Runs any sql query on the database and returns the resulting data table.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public DataView RunQuery(string query)
        {
            this.FlushData();
            this.LoadFromRawSql(query);
            return this.DefaultView;
        }

    }
}
