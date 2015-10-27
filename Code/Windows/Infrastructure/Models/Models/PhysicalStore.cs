using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class PhysicalStore
    {
        public PhysicalStore()
        {
            this.OrderDetails = new List<OrderDetail>();
            this.Shelves = new List<Shelf>();
            this.Transfers = new List<Transfer>();
            this.Transfers1 = new List<Transfer>();
            this.UserPhysicalStores = new List<UserPhysicalStore>();
            this.YearEnds = new List<YearEnd>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<double> Width { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<double> Length { get; set; }
        public Nullable<int> DoorSide { get; set; }
        public Nullable<double> DoorSize { get; set; }
        public Nullable<double> DistanceFromCornor { get; set; }
        public Nullable<int> PhysicalStoreTypeID { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual PhysicalStoreType PhysicalStoreType { get; set; }
        public virtual ICollection<Shelf> Shelves { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
        public virtual ICollection<Transfer> Transfers1 { get; set; }
        public virtual ICollection<UserPhysicalStore> UserPhysicalStores { get; set; }
        public virtual ICollection<YearEnd> YearEnds { get; set; }
    }
}
