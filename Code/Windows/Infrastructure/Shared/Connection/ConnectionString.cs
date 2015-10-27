using System.Collections.Generic;
using HCMIS.Shared.Connection;
namespace HCMIS.Shared
{
    public class ConnectionString
    {
        private string _OrigionalString { get; set; }

        private List<string> OtherAttributes { get; set; }

        public string Name { get; set; }
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string ServerAddress { get; set; }

        public string ServerName
        {
            get
            {
                string[] serverName = DataSource.Split('\\');
                if (serverName.Length > 0)
                {
                    return serverName[0];
                }
                return "";
            }
        }

        public string UserID { get; set; }
        public string Password { get; set; }

        private string _IntegratedSecurity = "False";

        public string IntegratedSecurity
        {
            get { return _IntegratedSecurity; }
            set { _IntegratedSecurity = value; }
        }
        private string _MultipleActiveResultsets="True";
        public string MultipleActiveResultsets
        {
            get { return _MultipleActiveResultsets; }
            set { _MultipleActiveResultsets = value; }
        }
        //TODO: Remove this Hardcoded code
        private string _ApplicationName = "HCMIS";
        public string ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }

        public void Parse(string str)
        {
            // check if this was encrypted or not, if it is ... decrypt it.
            if(!str.Contains("Data"))
            {
                str = EncriptionHelper.DecryptString(str, ConnectionHelper.Salt);
            }

            _OrigionalString = str;
            OtherAttributes= new List<string>();
            
            string []arr = _OrigionalString.Split(';');
            foreach (string entry in arr)
            {
                if (!string.IsNullOrEmpty(entry.Trim()))
                {
                    string []keyValue = entry.Trim().Split('=');
                    string key = keyValue[0];
                    string value = keyValue[1];

                    switch(key.ToUpper())
                    {
                        case "DATA SOURCE":
                            DataSource = value;
                            break;
                        case "INITIAL CATALOG":
                            InitialCatalog = value;
                            break;
                        case "INTEGRATED SECURITY":
                            IntegratedSecurity = value;
                            break;
                        case "USER ID":
                        case "UID":
                            UserID = value;
                            break;
                        case "PASSWORD":
                        case "PWD":
                            Password = value;
                            break;
                        case "APPLICATION NAME":
                            ApplicationName = value;
                            break;
                        case "MULTIPLEACTIVERESULTSETS":
                            MultipleActiveResultsets = value;
                            break;
                            // enable custom attributes on the connection string
                        default:
                            if (OtherAttributes.IndexOf(entry) < 0)
                            {
                                OtherAttributes.Add(entry);
                            }
                            break;
                            // Dont allow for the application name and Multiple Active resultset to be changed from the configuration.

                    }

                }
               
            }
        }

        public override string ToString()
        {
            string str = string.Format("Data Source={0};Network=DBMSSOCN;Initial Catalog={1};Integrated Security={2};UID={3};PWD={4};MultipleActiveResultSets={5};Application Name={6}", DataSource, InitialCatalog, IntegratedSecurity, UserID,
                                      Password, MultipleActiveResultsets, ApplicationName);
            if (IntegratedSecurity.ToUpper() == "TRUE")
            {
                str = string.Format("Data Source={0};Initial Catalog={1};Integrated Security={2};MultipleActiveResultSets={5};Application Name={6}", DataSource, InitialCatalog, IntegratedSecurity, UserID,
                                     Password, MultipleActiveResultsets, ApplicationName);
            }
            if (OtherAttributes != null)
            {
                foreach (string attr in OtherAttributes)
                {
                    str += ";" + attr;
                }
            }
            return str;
        }

        public string ToVisibleString()
        {
            string str = string.Format("Data Source={0};Network=DBMSSOCN;Initial Catalog={1};Integrated Security={2};UID={3};PWD=******;MultipleActiveResultSets={5};Application Name={6}", DataSource, InitialCatalog, IntegratedSecurity, UserID,
                                      Password, MultipleActiveResultsets, ApplicationName);
            if (IntegratedSecurity.ToUpper() == "TRUE")
            {
                str = string.Format("Data Source={0};Initial Catalog={1};Integrated Security={2};MultipleActiveResultSets={5};Application Name={6}", DataSource, InitialCatalog, IntegratedSecurity, UserID,
                                     Password, MultipleActiveResultsets, ApplicationName);
            }
            if (OtherAttributes != null)
            {
                foreach (string attr in OtherAttributes)
                {
                    str += ";" + attr;
                }
            }
            return str;
        }

        public void LoadFromRegistry(string key)
        {
            RegistryHelper registry= new RegistryHelper();
            _OrigionalString = registry.Read(key,"ConnectionString");

            // check if the read string was encrypted or not. 
            // this is not a very reliable check as the database name could be different
            if(!_OrigionalString.Contains("Data"))
            {
                //
                _OrigionalString = EncriptionHelper.DecryptString(_OrigionalString, ConnectionHelper.Salt);
            }else
            {
                // write the ecrypted version instead of the version that is plain text. 
                registry.Write(key, "ConnectionString",
                               EncriptionHelper.EncryptString(_OrigionalString, ConnectionHelper.Salt));
            }

            Parse(_OrigionalString);
            Name = registry.Read(key, "ConnectionName");
        }

        internal void SaveAsDefault()
        {
            RegistryHelper registry = new RegistryHelper();
            registry.Write(ConnectionHelper.ConnectionKey, "ConnectionName", Name);

            // encrypt and save the default connection string.
            registry.Write(ConnectionHelper.ConnectionKey, "ConnectionString", EncriptionHelper.EncryptString(ToString(), ConnectionHelper.Salt));
        }
    }
}
