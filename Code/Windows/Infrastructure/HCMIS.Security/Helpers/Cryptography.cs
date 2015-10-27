using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Helpers
{
    public enum EncryptionAlgorithms
    {
        MD5=0,
        SHA1,
        SHA256,
        SHA384,
        SHA512
    }
    public class Cryptography
    {
        public static string EncryptPassword(EncryptionAlgorithms algorithm,string rawPassword)
        {
            byte[] buffer = ASCIIEncoding.ASCII.GetBytes(rawPassword);
            byte[] hash = System.Security.Cryptography.HashAlgorithm.Create(algorithm.ToString()).ComputeHash(buffer);
            return Convert.ToBase64String(hash);
        }
    }
}
