using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
  [Table("logaudit",Schema = "dbo")]
  public class LogAudit
    {
      [Key]
      public int LogAuditID { get; set; }
      public string TableName { get; set; }
      [Column("PrimaryKeyField")]
      public string PrimaryKeyFielD { get; set; }
    
      public string PrimaryKeyValue { get; set; }
     
      public string FieldName { get; set; }
     
      public string OldValue { get; set; }
     
      public string NewValue { get; set; }
    
      public int LogChangeSetID { get; set; }
      [Column("Type")]      
      public char LogType { get; set; }

      public string SchemaName { get; set; }

    }
}

