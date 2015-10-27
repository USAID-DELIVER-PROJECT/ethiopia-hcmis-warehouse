using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Helpers;
using HCMIS.Security.Models;

namespace HCMIS.Security
{
    public class Settings
    {
        private static string _connectionString="";
        private static EncryptionAlgorithms _encryptionAlgorithms = EncryptionAlgorithms.SHA256;

        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public static EncryptionAlgorithms EncryptionAlgorithm
        {
            get { return _encryptionAlgorithms; }
            set { _encryptionAlgorithms = value; }
        }
    }
}
