using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Sales", Schema = "ExportUtility")]
    public class Sales:SageAccount
    {
        public int CommodityTypeID { get; set; }
        public Guid? AccountGuid { get; set; }
        public Guid? CommodityTypeGuid { get; set; }
    }
}
