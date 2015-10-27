using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Repository;

namespace HCMIS.Core.Distribution.Services
{
    public class SoftwareSettingService
    {
        private static RepositoryFactory repo = new RepositoryFactory();
        
        public static bool IssueFromUnPricedCommodities
        {
            get
            {
                return Convert.ToBoolean(repo.SoftwareSettings.First(s => s.Name == "IssueUnPricedCommodities").Value);
            }
        }

        public static bool IssueDeliveryNote
        {
            get
            {
                return Convert.ToBoolean(repo.SoftwareSettings.First(s => s.Name == "HandleDeliveryNotes").Value); 
            }
        }

        public static bool AllowPreferredManufacturer
        {
            get
            {
                return Convert.ToBoolean(repo.SoftwareSettings.First(s => s.Name == "AllowPreferredManufacturers").Value); 
            }
        }

        public static bool AllowPreferredLocation
        {
            get
            {
                return Convert.ToBoolean(repo.SoftwareSettings.First(s => s.Name == "AllowPreferredPhysicalStore").Value); 
            }
        }

        public static bool AllowPreferredExpiryDate
        {
            get
            {
                return Convert.ToBoolean(repo.SoftwareSettings.First(s => s.Name == "AllowPreferredExpiry").Value); 
            }
        }
    }
}
