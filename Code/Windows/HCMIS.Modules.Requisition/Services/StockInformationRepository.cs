using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using BLL;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Modules.Requisition.Services
{
    public class StockInformationRepository
    {
        private readonly ItemRepository _itemRepository;
        private readonly UnitRepository _unitOfIssueRepository;
        private readonly ManufacturerRepository _manufacturerRepository;
        private readonly PhysicalStoreRepository _physicalStoreRepository;
        private readonly ActivityRepository _activityRepository;

        public StockInformationRepository()
        {
            _itemRepository = new ItemRepository();
            _unitOfIssueRepository = new UnitRepository();
            _manufacturerRepository = new ManufacturerRepository();
            _physicalStoreRepository = new PhysicalStoreRepository();
            _activityRepository = new ActivityRepository();
        }
        public ICollection<StockInformation> GetStockInformationByOrderID(int orderId)
        {
            var balance = new Balance();
            var stockInformationTable = balance.GetBalanceByOrder(orderId, CurrentContext.UserId);
            ICollection<StockInformation> stockInformations = new Collection<StockInformation>();

            foreach (DataRowView stockInformationRow in stockInformationTable)
            {
                var itemID = Convert.ToInt32(stockInformationRow["ItemID"]);
                var unitID = Convert.ToInt32(stockInformationRow["UnitID"]);

                var stockInformation = new StockInformation
                                           {
                                               Item = _itemRepository.FindSingle(Convert.ToInt32(itemID)),
                                               Unit = _unitOfIssueRepository.FindSingle(Convert.ToInt32(unitID)),
                                               Manufacturer =
                                                   DBNull.Value != stockInformationRow["ManufacturerId"]
                                                       ? _manufacturerRepository.FindSingle(
                                                           Convert.ToInt32(stockInformationRow["ManufacturerId"]))
                                                       : null,
                                               Activity =
                                                   _activityRepository.FindSingle(
                                                       Convert.ToInt32(stockInformationRow["ActivityID"]),
                                                       Convert.ToBoolean(stockInformationRow["DeliveryNote"])),
                                               ExpiryDate =
                                                   DBNull.Value != stockInformationRow["ExpiryDate"]
                                                       ? Convert.ToDateTime(stockInformationRow["ExpiryDate"])
                                                       : (DateTime?) null,
                                               PhysicalStore =
                                                   DBNull.Value != stockInformationRow["PhysicalStoreID"]
                                                       ? _physicalStoreRepository.FindSingle(
                                                           Convert.ToInt32(stockInformationRow["PhysicalStoreID"]))
                                                       : null,
                                               Quantity = Convert.ToDecimal(stockInformationRow["Usable"])

                                           };
                stockInformations.Add(stockInformation);
            }
            return stockInformations;
        }

        public ICollection<ApprovedDetail> GetApprovedDetail(int orderId)
        {

            ICollection<ApprovedDetail> stockInformations = new Collection<ApprovedDetail>();
            var balance = new Balance();
            var approvedInformationTable = balance.GetApprovedByOrderID(orderId);

            foreach (DataRowView approvedInformationRow in approvedInformationTable)
            {
                var itemID = Convert.ToInt32(approvedInformationRow["ItemID"]);
                var unitID = Convert.ToInt32(approvedInformationRow["UnitID"]);

                var stockInformation = new ApprovedDetail
                {
                    Item = _itemRepository.FindSingle(Convert.ToInt32(itemID)),
                    Unit = _unitOfIssueRepository.FindSingle(Convert.ToInt32(unitID)),
                    Manufacturer = DBNull.Value != approvedInformationRow["ManufacturerId"] ? _manufacturerRepository.FindSingle(Convert.ToInt32(approvedInformationRow["ManufacturerId"])) : null,
                    ActivityGroup = _activityRepository.FindSingle(Convert.ToInt32(approvedInformationRow["ActivityID"]), Convert.ToBoolean(approvedInformationRow["IsDeliveryNote"])),
                    ExpiryDate = DBNull.Value != approvedInformationRow["ExpiryDate"] ? Convert.ToDateTime(approvedInformationRow["ExpiryDate"]) : (DateTime?)null,
                    physicalStore = DBNull.Value != approvedInformationRow["PhysicalStoreID"] ? _physicalStoreRepository.FindSingle(Convert.ToInt32(approvedInformationRow["PhysicalStoreID"])) : null,
                    Quantity = Convert.ToDecimal(approvedInformationRow["ApprovedQuantity"])

                };
                stockInformations.Add(stockInformation);
            }

            return stockInformations;
        }
    }
}
