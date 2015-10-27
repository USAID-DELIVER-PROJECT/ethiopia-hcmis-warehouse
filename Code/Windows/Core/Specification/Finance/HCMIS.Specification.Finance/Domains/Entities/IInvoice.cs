using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Specification.Finance.Domain.Entities
{
    public interface IInvoice:IDomainBase
    {
        int InvoiceTypeID { get; }
        
    }
}
