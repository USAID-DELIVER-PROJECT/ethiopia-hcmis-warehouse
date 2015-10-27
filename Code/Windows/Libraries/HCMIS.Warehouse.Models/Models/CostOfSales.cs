using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("CostOfSales", Schema = "ExportUtility")]
    public class CostOfSales:SageAccount
    {
       
        public int CommodityTypeID { get; set; }
        public Guid? AccountGuid { get; set; }
        public Guid? CommodityTypeGuid { get; set; }
    }
}
