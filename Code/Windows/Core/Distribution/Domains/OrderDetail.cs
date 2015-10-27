using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Models;
using HCMIS.Core.Distribution.Domains;
using HCMIS.Concrete.Repository;

namespace HCMIS.Core.Distribution
{
    public class OrderDetailModel : OrderDetail
    {
        RepositoryFactory repo = null;
        public OrderDetailModel(RepositoryFactory _repo){
            repo = _repo;
        }
        
        public OrderDetailApprovalOptions GetApprovalOptions(User User)
        {
            OrderDetailApprovalOptions option = new OrderDetailApprovalOptions((OrderDetail)this);
            // populate the options
 
            // populate the text views

            // populate
           return option;
        }
    }
}
