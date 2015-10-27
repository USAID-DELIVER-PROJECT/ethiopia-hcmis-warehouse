using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Modules.Requisition.Services
{
    public class PreferenceCalculator
    {
       
        public static ICollection<StockInformation> GetAvailableStock(ICollection<StockInformation> stockInformations, ICollection<ApprovedDetail> approvedDetails,ActivityGroup activityGroup,Manufacturer manufacturer,PhysicalStore physicalStore,DateTime? expiryDate)
        {
            var approvedDetailClone = approvedDetails.Select(a => new ApprovedDetail(a)).ToList();
           
            var nonPreferredStockInformation = stockInformations
                .Where(s => ((activityGroup != null && activityGroup.ActivityGroupID != s.Activity.ActivityGroupID)
                             || ((manufacturer != null) && (manufacturer.ManufacturerID != s.Manufacturer.ManufacturerID))
                             || (physicalStore != null && (physicalStore.PhysicalStoreID != s.PhysicalStore.PhysicalStoreID))
                             || (expiryDate != null && expiryDate != s.ExpiryDate))).Select(s => new StockInformation(s)).ToList();

            SubstractApprovedQuantityFromStock(nonPreferredStockInformation, approvedDetailClone);


            //Substract Then From Preferred if Non Prefered cannot satisfy approvedDetail
            
            var preferredStockInformation = stockInformations
                .Where(s => ((activityGroup == null     || activityGroup.ActivityGroupID == s.Activity.ActivityGroupID)
                             && ((manufacturer == null) || ( manufacturer.ManufacturerID == s.Manufacturer.ManufacturerID))
                             && (physicalStore == null  ||  ( physicalStore.PhysicalStoreID == s.PhysicalStore.PhysicalStoreID))
                             && (expiryDate == null     || expiryDate == s.ExpiryDate))).Select(s=> new StockInformation(s)).ToList();

            SubstractApprovedQuantityFromStock(preferredStockInformation, approvedDetailClone);

            return preferredStockInformation;
        }

        private static void SubstractApprovedQuantityFromStock(ICollection<StockInformation> stock, ICollection<ApprovedDetail> approvedDetails)
        { 
             approvedDetails = approvedDetails.Where(s=>s.Quantity > 0).OrderBy(s => s.Priority).ToList();
            foreach (var approvedDetail in approvedDetails)
            {
                var stockInformations =
                    stock.Where(
                        s =>
                        ((approvedDetail.ActivityGroup == null ||
                          approvedDetail.ActivityGroup.ActivityGroupID == s.Activity.ActivityGroupID)
                         &&
                         ((approvedDetail.Manufacturer == null) ||
                          (approvedDetail.Manufacturer.ManufacturerID == s.Manufacturer.ManufacturerID))
                         &&
                         (approvedDetail.physicalStore == null ||
                          (approvedDetail.physicalStore.PhysicalStoreID == s.PhysicalStore.PhysicalStoreID))
                         && (approvedDetail.ExpiryDate == null || approvedDetail.ExpiryDate == s.ExpiryDate))).ToList();
                var i = 0;
                while (approvedDetail.Quantity > 0 && i < stockInformations.Count)
                {
                    var stockInformation = stockInformations[i];
                    if (stockInformation.Quantity >= approvedDetail.Quantity)
                    {
                        stockInformation.Quantity = stockInformation.Quantity - approvedDetail.Quantity;
                        approvedDetail.Quantity = 0;
                    }
                    else
                    {
                        approvedDetail.Quantity = approvedDetail.Quantity - stockInformation.Quantity;
                        stockInformation.Quantity = 0;
                    }
                    i++;
                }
            }
        }

    }
}
