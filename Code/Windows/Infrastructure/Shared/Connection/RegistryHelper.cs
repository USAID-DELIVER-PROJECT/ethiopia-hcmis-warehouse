using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace HCMIS.Shared.Connection
{
    public class RegistryHelper
    {
        public string Read(string KeyName, string valueName)
        {
            
            // Open a subKey as read-only
            RegistryKey sk1 = Registry.CurrentUser.OpenSubKey(KeyName);
            // If the RegistrySubKey doesn't exist -> (null)
            if (sk1 == null)
            {
                return null;
            }
            try
            {
                // If the RegistryKey exists I get its value
                // or null is returned.
                return (string)sk1.GetValue(valueName.ToUpper());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Write(string KeyName, string valueName , object Value)
        {
            try
            {
                // if the sub key doesn't exsit ... create it.
                RegistryKey sk1 = Registry.CurrentUser.CreateSubKey(KeyName);
                // Save the value
                sk1.SetValue(valueName, Value);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    
        public bool Delete(string KeyName, string valueName)
        {
            try
            {
                RegistryKey sk1 = Registry.CurrentUser.CreateSubKey(KeyName);
                sk1.DeleteValue(valueName);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public Dictionary<string,string> GetSubKeys(string KeyName)
        {
            Dictionary<string,string> result = new Dictionary<string, string>();
            // Open a subKey as read-only
            RegistryKey sk1 = Registry.CurrentUser.OpenSubKey(KeyName);
            // If the RegistrySubKey doesn't exist -> (null)
            if (sk1 != null)
            {
                string[] arr = sk1.GetValueNames();
                foreach (string key in arr)
                {
                    result.Add(key, Registry.CurrentUser.OpenSubKey(KeyName).GetValue(key).ToString());
                }

            }
            return result;
        } 

    }
}
