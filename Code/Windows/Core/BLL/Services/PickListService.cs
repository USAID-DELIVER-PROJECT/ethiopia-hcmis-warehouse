using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    class PickListService
    {
        
   

        /// <summary>
        /// This generates picklist for everything in the receivepallet entry.
        /// </summary>
        /// <param name="receiveDoc"></param>
        /// <param name="receivePallet"></param>
        /// <param name="order"></param>
        /// <param name="picklist"></param>
        /// <returns></returns>
        public PickListDetail CreatePicklistDetailWithOrder(ReceiveDoc receiveDoc, ReceivePallet receivePallet, Order order, PickList picklist)
        {
            double? cost = null;
            decimal pack = receivePallet.Balance/receiveDoc.QtyPerPack;
            OrderService orderService = new OrderService();
            orderService.CreateOrderDetail(receiveDoc,order,pack);
            if (!receiveDoc.IsColumnNull("Cost"))
                cost = receiveDoc.Cost;
            PickListDetail pickListDetail = PickListDetail.GeneratePickListDetail(pack, cost, receiveDoc.ID,
                                                                                  receiveDoc.ManufacturerId,
                                                                                  receivePallet.ID,
                                                                                  receiveDoc.QtyPerPack,
                                                                                  receiveDoc.StoreID, receiveDoc.UnitID,
                                                                                  receiveDoc.ItemID, picklist.ID,
                                                                                  receivePallet.PalletID,
                                                                                  receiveDoc.ExpDate.ToString(),
                                                                                  receiveDoc.BatchNo);
            ReceivePallet.ReserveQty(pack, receivePallet.ID);

            return pickListDetail;
        }

        public PickListDetail CreatePicklistDetailWithOrder(ReceiveDoc receiveDoc, ReceivePallet receivePallet, Order order, PickList picklist, decimal pack)
        {
            double? cost = null;
            OrderService orderService = new OrderService();
            orderService.CreateOrderDetail(receiveDoc, order, pack);
            if (!receiveDoc.IsColumnNull("Cost"))
                cost = receiveDoc.Cost;
            PickListDetail pickListDetail = PickListDetail.GeneratePickListDetail(pack, cost, receiveDoc.ID, receiveDoc.ManufacturerId, receivePallet.ID,
                receiveDoc.QtyPerPack, receiveDoc.StoreID, receiveDoc.UnitID, receiveDoc.ItemID, picklist.ID, receivePallet.PalletID, receiveDoc.IsColumnNull("ExpDate")?"":receiveDoc.ExpDate.ToString(),  receiveDoc.IsColumnNull("BatchNo")?"":receiveDoc.BatchNo);
            ReceivePallet.ReserveQty(pack, receivePallet.ID);

            return pickListDetail;
        }
    }
}
