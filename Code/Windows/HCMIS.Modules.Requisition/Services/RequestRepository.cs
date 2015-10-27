using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BLL;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Modules.Requisition.Services
{
    public class RequestRepository
    {
        private readonly ClientRepository _clientRepository;
        private readonly ItemRepository _itemRepository;
        private readonly UnitRepository _unitOfIssueRepository;
        private readonly ModeService _modeService;
        private readonly OrderStatusService _orderStatusService;
        private readonly PaymentTermRepository _paymentTermService;
        private readonly ManufacturerRepository _manufacturerRepository;
        private readonly PhysicalStoreRepository _physicalStoreRepository;
        private readonly ActivityRepository _activityRepository;

        public RequestRepository()
        {
            _clientRepository = new ClientRepository();
            _itemRepository = new ItemRepository();
            _unitOfIssueRepository = new UnitRepository();
            _modeService = new ModeService();
            _paymentTermService = new PaymentTermRepository();
            _orderStatusService = new OrderStatusService();
            _manufacturerRepository = new ManufacturerRepository();
            _physicalStoreRepository = new PhysicalStoreRepository();
            _activityRepository = new ActivityRepository();
        }

        public Domain.Request FindSingle(int requestID)
        {
            var request = new Domain.Request();
            var order = new Order();
            order.LoadByPrimaryKey(requestID);

            request.RequestID = order.ID;
            request.OrderNumber = order.RefNo;
            request.LetterNumber = !order.IsColumnNull("LetterNo") ? order.LetterNo : "";
            request.RequestedDate = order.EurDate;

            request.Client = _clientRepository.FindSingle(order.RequestedBy);
            request.Mode = _modeService.GetEnum(order.FromStore);
            request.PaymentTerm = _paymentTermService.FindSingle(order.PaymentTypeID);
            request.OrderStatus = _orderStatusService.GetEnum(order.OrderStatusID);

            var orderDetail = new OrderDetail();
            orderDetail.LoadAllByOrderID(requestID);
            orderDetail.Rewind();
            request.RequestDetails = new Collection<Domain.RequestDetail>();
            while (!orderDetail.EOF)
            {
                var item = _itemRepository.FindSingle(orderDetail.ItemID);
                var unitOfIssue = _unitOfIssueRepository.FindSingle(orderDetail.UnitID);
                var requestDetail = new Domain.RequestDetail()
                                        {

                                            RequestDetailId = orderDetail.ID,
                                            Item = item,
                                            Unit = unitOfIssue,
                                            RequestedQuantity = orderDetail.Pack,
                                            ApprovedQuantity = !orderDetail.IsColumnNull("ApprovedQuantity") ? orderDetail.ApprovedQuantity : orderDetail.Pack,
                                            IsFirstLoad = orderDetail.IsColumnNull("ApprovedQuantity"),
                                            ActivityGroup = orderDetail.IsColumnNull(OrderDetail.ColumnNames.StoreID)?null:_activityRepository.FindSingle(orderDetail.StoreID,orderDetail.DeliveryNote),
                                            ExpiryDate =
                                                !orderDetail.IsColumnNull("PreferredExpiryDate")
                                                    ? orderDetail.PreferredExpiryDate
                                                    : (DateTime?)null,
                                            Manufacturer =
                                                !orderDetail.IsColumnNull("PreferredManufacturerID")
                                                    ? _manufacturerRepository.FindSingle(
                                                        orderDetail.PreferredManufacturerID)
                                                    : null,
                                            physicalStore =
                                                !orderDetail.IsColumnNull("PreferredPhysicalStoreID")
                                                    ? _physicalStoreRepository.FindSingle(
                                                        orderDetail.PreferredPhysicalStoreID)
                                                    : null
                                            
                                        };
                request.RequestDetails.Add(requestDetail);
            orderDetail.MoveNext();
            }




            return request;

        }




        public ICollection<Domain.Request> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Request _request,int userID, Domain.OrderStatus orderStatus = Domain.OrderStatus.Submitted)
        {
            var order = new Order();
            order.LoadByPrimaryKey(_request.RequestID);
            
            var dborderStatus = new BLL.OrderStatus();
            dborderStatus.LoadByCode(EnumService<Domain.OrderStatus>.GetCode(orderStatus));
            
            order.ChangeStatus(dborderStatus.ID,CurrentContext.UserId);
            order.ApprovedBy = userID;
            order.ApprovedDate = DateTimeHelper.ServerDateTime;
            
            var orderDetail = new OrderDetail();
            orderDetail.LoadAllByOrderID(_request.RequestID);
            while (!orderDetail.EOF)
            {
                var requestDetail = _request.RequestDetails.SingleOrDefault(r => r.RequestDetailId == orderDetail.ID);
                if(requestDetail== null)
                {
                    orderDetail.MarkAsDeleted();    
                }
                else
                {
                    
                    //Set Activity
                    if (requestDetail.ActivityGroup != null)
                    {
                        orderDetail.StoreID = requestDetail.ActivityGroup.Activity.ActivityID;
                        orderDetail.DeliveryNote = requestDetail.ActivityGroup.IsDeliveryNote;
                    }
                    else
                    {
                        orderDetail.SetColumnNull("StoreID");
                    }
                    //Set Manufacturer 
                    if (requestDetail.Manufacturer != null)
                    {
                        orderDetail.PreferredManufacturerID = requestDetail.Manufacturer.ManufacturerID;
                    }
                    else
                    {
                        orderDetail.SetColumnNull("PreferredManufacturerID");
                    }

                    //Set PhysicalStore
                    if (requestDetail.physicalStore != null)
                    {
                        orderDetail.PreferredPhysicalStoreID = requestDetail.physicalStore.PhysicalStoreID;
                    }
                    else
                    {
                        orderDetail.SetColumnNull("PreferredPhysicalStoreID");
                    }

                    //Set ExpiryDate
                    if (requestDetail.ExpiryDate.HasValue)
                    {
                        orderDetail.PreferredExpiryDate = requestDetail.ExpiryDate.Value;
                    }
                    else
                    {
                        orderDetail.SetColumnNull("PreferredExpiryDate");
                    }
                        orderDetail.ApprovedQuantity = requestDetail.ApprovedQuantity;
                    orderDetail.StockedOut = requestDetail.StockedOut;
                }
           
                orderDetail.MoveNext();
            }
            foreach (var requestDetail in _request.RequestDetails.Where(r => r.RequestDetailId == 0).ToList())
            {
                orderDetail.AddNew();
                orderDetail.ItemID = requestDetail.Item.ItemID;
                orderDetail.UnitID = requestDetail.Unit.UnitID;
                orderDetail.Pack = requestDetail.RequestedQuantity;
                orderDetail.OrderID = order.ID;
                orderDetail.QtyPerPack = 1;
                orderDetail.Quantity = requestDetail.RequestedQuantity;
                orderDetail.ApprovedQuantity = requestDetail.ApprovedQuantity;
                orderDetail.StockedOut = requestDetail.StockedOut;
                if (requestDetail.ActivityGroup != null)
                {
                    orderDetail.StoreID = requestDetail.ActivityGroup.Activity.ActivityID;
                    orderDetail.DeliveryNote = requestDetail.ActivityGroup.IsDeliveryNote;
                }
                else
                {
                    orderDetail.SetColumnNull("StoreID");
                }
                //Set Manufacturer 
                if (requestDetail.Manufacturer != null)
                {
                    orderDetail.PreferredManufacturerID = requestDetail.Manufacturer.ManufacturerID;
                }
                else
                {
                    orderDetail.SetColumnNull("PreferredManufacturerID");
                }

                //Set PhysicalStore
                if (requestDetail.physicalStore != null)
                {
                    orderDetail.PreferredPhysicalStoreID = requestDetail.physicalStore.PhysicalStoreID;
                }
                else
                {
                    orderDetail.SetColumnNull("PreferredPhysicalStoreID");
                }

                //Set ExpiryDate
                if (requestDetail.ExpiryDate.HasValue)
                {
                    orderDetail.PreferredExpiryDate = requestDetail.ExpiryDate.Value;
                }
                else
                {
                    orderDetail.SetColumnNull("PreferredExpiryDate");
                }

            }
            

            order.Save();
            orderDetail.Save();
           
        }
    }
}
