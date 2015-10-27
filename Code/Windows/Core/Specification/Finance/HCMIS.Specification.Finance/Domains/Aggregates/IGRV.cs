using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Specification.Finance.Domain.Entities;

namespace HCMIS.Specification.Finance.Domain.Aggregates
{
    public interface IGRV
    {
        int ID
        {
            get;
            set;
        }

        IInvoice Invoice
        {
            get;
            set;
        }

        IEnumerable<ICostElement> Detail
        {
            get;
            set;
        }

         void MoveToNextStep();
         void ReturnToPreviousStep();
         void Save();
         void Void();
         void Delete();
    }
}
