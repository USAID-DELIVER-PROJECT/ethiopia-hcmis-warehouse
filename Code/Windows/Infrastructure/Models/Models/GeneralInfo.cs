using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class GeneralInfo
    {
        public GeneralInfo()
        {
            this.Stores = new List<Store>();
        }

        public int ID { get; set; }
        public string HospitalName { get; set; }
        public Nullable<int> Woreda { get; set; }
        public Nullable<int> Zone { get; set; }
        public Nullable<int> Region { get; set; }
        public string Telephone { get; set; }
        public string HospitalContact { get; set; }
        public Nullable<int> LeadTime { get; set; }
        public Nullable<int> Min { get; set; }
        public Nullable<int> Max { get; set; }
        public Nullable<int> SafteyStock { get; set; }
        public Nullable<int> AMCRange { get; set; }
        public Nullable<int> ReviewPeriod { get; set; }
        public Nullable<double> EOP { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsEven { get; set; }
        public string Logo { get; set; }
        public Nullable<double> DUMin { get; set; }
        public Nullable<double> DUMax { get; set; }
        public Nullable<int> DUAMCRange { get; set; }
        public Nullable<System.DateTime> LastBackUp { get; set; }
        public Nullable<int> FacilityID { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
