using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("CoreAccountCategory", Schema = "Core")]
    public class CoreAccountCategory
    {
        [Key]
        public int CoreAccountCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoreAccountCategoryCode { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

       

    }
}
