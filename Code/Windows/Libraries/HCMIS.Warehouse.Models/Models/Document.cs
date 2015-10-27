using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace HCMIS.Warehouse.Models
{
    [Table("Document", Schema = "MessageBroker")]
    public class Document
    {
        [Key]
        public int DocumentID { get; set; }
        public int DocumentTypeID { get; set; }
        public int SenderID { get; set; }
        public int RecipientID { get; set; }
        public XmlDocument Type { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
