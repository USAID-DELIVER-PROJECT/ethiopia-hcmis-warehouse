using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwItemsReadyForDispatch
    {
        public Nullable<long> DispatchableStock { get; set; }
        public int ReceivePalletID { get; set; }
        public Nullable<int> ReceiveID { get; set; }
        public Nullable<int> PalletID { get; set; }
        public Nullable<long> ReceivedQuantity { get; set; }
        public Nullable<long> Balance { get; set; }
        public int ReservedStock { get; set; }
        public Nullable<int> ReserveOrderID { get; set; }
        public int ReceiveDocID { get; set; }
        public string BatchNo { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> ExpDate { get; set; }
        public Nullable<bool> Out { get; set; }
        public Nullable<int> ReceivedStatus { get; set; }
        public Nullable<bool> Confirmed { get; set; }
        public string ReceivedBy { get; set; }
        public string Remark { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string LocalBatchNo { get; set; }
        public string RefNo { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
        public Nullable<long> QuantityLeft { get; set; }
        public Nullable<int> NoOfPack { get; set; }
        public Nullable<int> QtyPerPack { get; set; }
        public Nullable<System.DateTime> EurDate { get; set; }
        public Nullable<int> BoxSize { get; set; }
        public Nullable<int> BoxLevel { get; set; }
        public Nullable<double> SellingPrice { get; set; }
        public bool DeliveryNote { get; set; }
        public int PalletLocationID { get; set; }
        public string Label { get; set; }
        public Nullable<int> ShelfID { get; set; }
        public Nullable<int> Row { get; set; }
        public Nullable<int> Column { get; set; }
        public Nullable<int> StorageTypeID { get; set; }
        public bool IsFullSize { get; set; }
        public Nullable<bool> IsEnabled { get; set; }
        public Nullable<int> RackStatusID { get; set; }
        public Nullable<int> Expr3 { get; set; }
        public Nullable<double> PercentUsed { get; set; }
        public Nullable<double> Width { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<double> Length { get; set; }
        public bool IsExtended { get; set; }
        public Nullable<int> ExtendedRows { get; set; }
        public double AvailableVolume { get; set; }
        public double UsedVolume { get; set; }
        public string FullItemName { get; set; }
        public string ItemName { get; set; }
        public string Strength { get; set; }
        public Nullable<int> ABCID { get; set; }
        public Nullable<int> VENID { get; set; }
        public Nullable<bool> IsFree { get; set; }
        public Nullable<int> DosageFormID { get; set; }
        public string DosageForm { get; set; }
        public string Unit { get; set; }
        public string StockCode { get; set; }
        public Nullable<int> IINID { get; set; }
        public int Expr4 { get; set; }
        public Nullable<bool> IsInHospitalList { get; set; }
        public Nullable<int> TypeID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<bool> IsStackStored { get; set; }
        public Nullable<bool> NeedExpiryBatch { get; set; }
        public Nullable<int> Expr5 { get; set; }
        public Nullable<double> NearExpiryTrigger { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryID { get; set; }
        public int Expr6 { get; set; }
        public Nullable<int> PalletNo { get; set; }
        public Nullable<int> StorageTypeID2 { get; set; }
        public string ManufacturerName { get; set; }
    }
}
