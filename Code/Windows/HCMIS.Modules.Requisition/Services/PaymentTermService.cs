using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BLL;
using HCMIS.Modules.Requisition.Domain;
using PaymentTerm = HCMIS.Modules.Requisition.Domain.PaymentTerm;

namespace HCMIS.Modules.Requisition.Services
{
    public class PaymentTermRepository : CachedRepository<Domain.PaymentTerm, int>
    {
        protected override ICollection<Domain.PaymentTerm> GetData()
        {

            ICollection<Domain.PaymentTerm> paymentTerms = new Collection<Domain.PaymentTerm>();
            var paymentType = new BLL.PaymentType();
            paymentType.LoadAll();
            while (!paymentType.EOF)
            {
                paymentTerms.Add(new Domain.PaymentTerm { PaymentTermID = paymentType.ID, Name = paymentType.Name });
                paymentType.MoveNext();
            }
            return paymentTerms;
        }

        public override PaymentTerm FindSingle(int id)
        {
            return FindAll().SingleOrDefault(i => i.PaymentTermID == id);
        }
    }
}

