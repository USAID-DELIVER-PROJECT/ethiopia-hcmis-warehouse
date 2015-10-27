using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Specification.Finance.Domain.Aggregates;

namespace HCMIS.Specification.Finance.Domain.Entities
{
    public interface IPreviousStock:IDomainBase
    {
        double Quantity { get; }
        double UnitCost { get; }
        double TotalCost { get; }

        void Load(ICostElement CostElement);
    }
}
