using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using HCMIS.Logging.Models;

namespace HCMIS.Logging.Helpers
{
    class Helper
    {
        /// <summary>
        /// Gets the IP address of the local machine where the app is running.
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            //string strHostName = "";
            //strHostName = System.Net.Dns.GetHostName();
            //IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            //IPAddress[] addr = ipEntry.AddressList;
            //return addr[addr.Length - 1].ToString();

            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        /// <summary>
        /// Gets the line number that raised the exception
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns></returns>
        public static int GetLineNumber(Exception ex)
        {
            var st = new StackTrace(ex, true);
            // Get the top stack frame
            var frame = st.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();
            return line;
        }

        internal static string GetHostName()
        {
           return System.Net.Dns.GetHostName();
        }

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

                var context = new LoggingContext();
                var date = (context as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<ServerParameters>(query).FirstOrDefault();
                return date.PresentDateTime;
            }
        }

    }
}
