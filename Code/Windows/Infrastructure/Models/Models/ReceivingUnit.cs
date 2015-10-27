using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class ReceivingUnit
    {
        public ReceivingUnit()
        {
            this.IssueDocs = new List<IssueDoc>();
            this.Orders = new List<Order>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Woreda { get; set; }
        public Nullable<int> Route { get; set; }
        public Nullable<int> RouteSequence { get; set; }
        public Nullable<int> PaymentTypeID { get; set; }
        public string LicenseNo { get; set; }
        public string VATNo { get; set; }
        public string TinNo { get; set; }
        public Nullable<System.DateTime> DateOfRegistration { get; set; }
        public string Town { get; set; }
        public string Kebele { get; set; }
        public Nullable<int> RUType { get; set; }
        public Nullable<int> Ownership { get; set; }
        public Nullable<int> Zone { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> InProcess { get; set; }
        public virtual ICollection<IssueDoc> IssueDocs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ReceivingUnitType ReceivingUnitType { get; set; }
        public virtual RUOwnershipType RUOwnershipType { get; set; }
        public virtual Woreda Woreda1 { get; set; }
        public virtual Zone Zone1 { get; set; }
    }
}
