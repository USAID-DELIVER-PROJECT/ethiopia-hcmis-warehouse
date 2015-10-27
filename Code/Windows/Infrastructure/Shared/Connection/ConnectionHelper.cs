using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HCMIS.Shared.Connection
{
    public class ConnectionHelper
    {
        internal static string ConnectionKey { get; set; }
        internal static string SavedConnectionKey { get; set; }

        public static ConnectionString CurrentConnection { get; set; }
        
        public static bool IsRemote
        {
            get { return !LocalAddresses.Contains(CurrentConnection.ServerName); }
        }

        private static List<string> LocalAddresses
        {
            get
            {
                IPHostEntry host;
                List<string> localIPs = new List<string>(){".","localhost"};
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                       localIPs.Add(ip.ToString());
                    }
                }
                return localIPs;
            }
        } 


        public static void Configure(string connectionKey, string savedConnectionsKey)
        {
            ConnectionKey = connectionKey;
            
            SavedConnectionKey = savedConnectionsKey;
            CurrentConnection = new ConnectionString();
            // Load from Registry if it exists
            try
            {
                CurrentConnection.LoadFromRegistry(connectionKey);
            }
            catch
            {
               RegistryHelper helper = new RegistryHelper();
               helper.Write(ConnectionKey, "ConnectionString", "");
            }
            
        }

        internal static Dictionary<string, string>  GetHistoricConnections()
        {
            // Load all options as necessary.
            RegistryHelper registryHelper = new RegistryHelper();
            CheckEncryption(registryHelper);
           var HistoricConnectionStrings = registryHelper.GetSubKeys(SavedConnectionKey);
            return HistoricConnectionStrings;
        }

        private static void CheckEncryption(RegistryHelper registryHelper)
        {
            var HistoricConnectionStrings = registryHelper.GetSubKeys(SavedConnectionKey);

            // Do the encrption if the strings were not encrypted already.

            foreach (var x in HistoricConnectionStrings)
            {
                if (x.Value.Contains("Data"))
                {
                    RegistryHelper helper = new RegistryHelper();
                    if (!string.IsNullOrEmpty(x.Key))
                    {
                        helper.Delete(ConnectionHelper.SavedConnectionKey, x.Key);
                    }
                    helper.Write(ConnectionHelper.SavedConnectionKey, x.Key,
                                 EncriptionHelper.EncryptString(x.Value, ConnectionHelper.Salt));
                }
            }
           
        }

        public static bool IsLiveInstallation { get
        {
            RegistryHelper registryHelper = new RegistryHelper();
            string IsLive = registryHelper.Read(ConnectionKey, "IsLive");
            if (!string.IsNullOrEmpty(IsLive))
            {
                return Convert.ToBoolean(IsLive);
            }
            return true;
        } 
        set
        {
            RegistryHelper registryHelper = new RegistryHelper();
            registryHelper.Write(ConnectionKey, "IsLive", value.ToString());
        } 
        }

        public static string Salt { get { return "hcmis-warehouse"; } }
    }
}
