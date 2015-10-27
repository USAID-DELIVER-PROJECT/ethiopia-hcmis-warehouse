using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace HCMIS.Modules.Requisition.Services
{
    public class OrderStatusService:EnumService<Domain.OrderStatus>
    {
        public Domain.OrderStatus GetEnum(int orderStatusID)
        {
            var orderStatus = new OrderStatus();
            orderStatus.LoadByPrimaryKey(orderStatusID);
            return GetEnum(orderStatus.OrderStatusCode);

        }     
    }
}
