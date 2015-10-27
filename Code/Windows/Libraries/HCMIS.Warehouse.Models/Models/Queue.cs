using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Queue", Schema = "MessageBroker")]
    public class Queue
    {
        [Key]
        public int QueueID { get; set; }

        public int DocumentID { get; set; }
        public int QueueReasonID { get; set; }
        public bool? IsSent { get; set; }
        public DateTime? QueuedDate { get; set; }
    }
}
