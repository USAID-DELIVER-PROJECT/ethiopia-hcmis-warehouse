using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    class OrderService
    {
        public void CreateOrderDetail(ReceiveDoc receiveDoc, Order order, decimal pack)
        {
            OrderDetail.GenerateOrderDetail(receiveDoc.UnitID, receiveDoc.StoreID, pack,order.ID, receiveDoc.QtyPerPack,
                                            receiveDoc.ItemID);
        }
    }
}
