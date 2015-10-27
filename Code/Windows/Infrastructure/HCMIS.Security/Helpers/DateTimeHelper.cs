using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using HCMIS.Logging.Models;
using HCMIS.Security.DataContext;

namespace HCMIS.Security.Helpers
{
    public class DateTimeHelper
    {

        /// <summary>
        /// Gets the server date time.
        /// </summary>
        /// <value>
        /// The server date time.
        /// </value>
        public static DateTime ServerDateTime
        {
            get
            {
                const string query = "SELECT GETDATE() as PresentDateTime";

                var context = new SecurityContext();
                var date = (context as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<ServerParameters>(query).FirstOrDefault();
                return date.PresentDateTime;
            }
        }

    }
}
