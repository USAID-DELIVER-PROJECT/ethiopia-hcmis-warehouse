using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Modules.Requisition.Domain
{
    public class Request
    {
        public Request()
        {
            RequestDetails = new Collection<RequestDetail>();
        }
        public int RequestID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime RequestedDate { get; set; }
        public string LetterNumber { get; set; }
        public Client Client { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
        public Modes Mode { get; set; }
        public OrderStatus OrderStatus { get; set; } 
        public ICollection<RequestDetail> RequestDetails { get; set; }
      }
}
