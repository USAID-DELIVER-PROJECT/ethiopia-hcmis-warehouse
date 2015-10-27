using System;
using System.Collections.Generic;
using System.Linq;
using HCMIS.Specification.Finance.Domain.Entities;

namespace HCMIS.Specification.Finance.Domain.Aggregates
{
    public interface ICostElement:IDomainBase
    {
        
        IActivity Activity
        {
            get;
        }

        int ItemID
        {

            get;
        }
        
        int UnitID
        {
          
            get;
        }
        
        int ManufacturerID
        {
          
            get;
        }

        int SupplierID
        {
            get;
        }

        IPreviousStock PreviousStock
        {
           
            get;
        }

         double ReceivedQuantity {get;}
         double ShortlandedQuantity{get;}
         double DamagedQuantity{get;}
         double NotReceivedQuantity{get;}
         double InvoiceQuantity { get; }
        
         double InsuranceClaim  { get; }
         double SupplierClaim {get; }

         double InvoiceValue { get; }
         double UnitCost { get; }
         double AvgCost { get; }
         double Margin { get; }
         double SellingPrice { get; }

         double TotalCost { get; }
         double TotalInvoice { get; }
         
         bool HasDamaged { get; }
         bool HasShortlanded { get; }
         bool HasNotReceived { get; }

         void HoldForCosting();
         void ReleaseForIssue();
         void Save();
         void Load(int ItemID,int UnitID,int Manufacturer ,int ActivityID,int SupplierID,int ReceiptID);

    }
}
