using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HCMIS.Enums;
using HCMIS.Extensions;
using HCMIS.Warehouse.Models;
using System.Windows;

namespace HCMIS.Desktop.Helpers
{
    public class ConstantsHelper
    {

        public static void LoadAllConstants()
        {
                LoadModeConstants();
                LoadABCConstants();
                LoadVENConstants();
                LoadDocumentTypeConstants();
                LoadInstitutionTypeConstants();
                LoadOwnershipTypeConstants();
                LoadPaymentTypeConstants();
                LoadOrderStatusConstants();
                LoadReceiptConfirmationStatusConstants();
                LoadReceiptTypeConstants();
                LoadShortageReasonsConstants();
                LoadTransferConstants();
                LoadInventoryPeriodConstants();
                LoadRequisitionTypeConstants();
                LoadActivityConstants();
                LoadOrderTypeConstants();
                LoadPurchaseOrderTypeConstants();
                LoadPurchaseOrderParentTypeConstants();
                LoadReceiptInvoiceTypeConstants();
                LoadInstitutionITypeConstants();
                LoadPlitsIntegrationConstants();
                LoadCommodityTypeConstants();
         
        }

        public static void LoadModeConstants()
        {
            BLL.Mode.Constants.HEALTH_PROGRAM = Program.LookupKernel.GetLookup(Modes.HealthProgram).ID;
            BLL.Mode.Constants.RDF = Program.LookupKernel.GetLookup(Modes.RDF).ID;
           
        }

        public static void LoadABCConstants()
        {
            BLL.ABC.Constants.A = Program.LookupKernel.GetLookup(ABCs.A).ID;
            BLL.ABC.Constants.B = Program.LookupKernel.GetLookup(ABCs.B).ID;
            BLL.ABC.Constants.C = Program.LookupKernel.GetLookup(ABCs.C).ID;
        }

        public static void LoadVENConstants()
        {
            BLL.VEN.Constants.VITAL = Program.LookupKernel.GetLookup(VENs.V).ID;
            BLL.VEN.Constants.ESSENTIAL = Program.LookupKernel.GetLookup(VENs.E).ID;
            BLL.VEN.Constants.NON_ESSENTIAL = Program.LookupKernel.GetLookup(VENs.N).ID;
        }

        public static void LoadDocumentTypeConstants()
        {
            BLL.DocumentType.CONSTANTS.PO = Program.LookupKernel.GetLookup(DocumentTypes.PurchaseOrder).ID;
            BLL.DocumentType.CONSTANTS.RI = Program.LookupKernel.GetLookup(DocumentTypes.ReceiptInvoice).ID;
            BLL.DocumentType.CONSTANTS.STV = Program.LookupKernel.GetLookup(DocumentTypes.STV).ID;           
            BLL.DocumentType.CONSTANTS.CASH = Program.LookupKernel.GetLookup(DocumentTypes.Cash).ID;
            BLL.DocumentType.CONSTANTS.CRDT = Program.LookupKernel.GetLookup(DocumentTypes.Credit).ID;
            BLL.DocumentType.CONSTANTS.DLVN = Program.LookupKernel.GetLookup(DocumentTypes.DeliveryNote).ID;
            BLL.DocumentType.CONSTANTS.ENDB = Program.LookupKernel.GetLookup(DocumentTypes.EndingBalance).ID;
            BLL.DocumentType.CONSTANTS.ERRC = Program.LookupKernel.GetLookup(DocumentTypes.ErrorCorrection).ID;
            BLL.DocumentType.CONSTANTS.GRNF = Program.LookupKernel.GetLookup(DocumentTypes.GRNF).ID;
            BLL.DocumentType.CONSTANTS.GRV = Program.LookupKernel.GetLookup(DocumentTypes.GRV).ID;
            BLL.DocumentType.CONSTANTS.IGRV = Program.LookupKernel.GetLookup(DocumentTypes.IGRV).ID;
            BLL.DocumentType.CONSTANTS.SRM = Program.LookupKernel.GetLookup(DocumentTypes.SRM).ID;

        }

        public static void LoadInstitutionTypeConstants()
        {
            BLL.InstitutionType.Constants.OTHERS = Program.LookupKernel.GetLookup(InstitutionTypes.Others).ID;
            BLL.InstitutionType.Constants.OTHERS = Program.LookupKernel.GetLookup(InstitutionTypes.Others).ID;
            BLL.InstitutionType.Constants.CENTER = Program.LookupKernel.GetLookup(InstitutionTypes.Center).ID;
            BLL.InstitutionType.Constants.CLINIC = Program.LookupKernel.GetLookup(InstitutionTypes.Clinic).ID;
            BLL.InstitutionType.Constants.DIAGNOSTIC_LABORATORY = Program.LookupKernel.GetLookup(InstitutionTypes.DiagnosticLaboratory).ID;
            BLL.InstitutionType.Constants.DRUG_STORE = Program.LookupKernel.GetLookup(InstitutionTypes.DrugStore).ID;
            BLL.InstitutionType.Constants.ESCROW = Program.LookupKernel.GetLookup(InstitutionTypes.Escrow).ID;
            BLL.InstitutionType.Constants.HEALTH_CENTER = Program.LookupKernel.GetLookup(InstitutionTypes.HealthCenter).ID;
            BLL.InstitutionType.Constants.HOSPITAL = Program.LookupKernel.GetLookup(InstitutionTypes.Hospital).ID;
            BLL.InstitutionType.Constants.HUB = Program.LookupKernel.GetLookup(InstitutionTypes.Hub).ID;
            BLL.InstitutionType.Constants.IMPORT_AND_WHOLE_SALE = Program.LookupKernel.GetLookup(InstitutionTypes.Importandwholesale).ID;
            BLL.InstitutionType.Constants.INDIVIDUALS = Program.LookupKernel.GetLookup(InstitutionTypes.Individuals).ID;
            BLL.InstitutionType.Constants.MACHINE = Program.LookupKernel.GetLookup(InstitutionTypes.Machine).ID;
            BLL.InstitutionType.Constants.PHARMACY = Program.LookupKernel.GetLookup(InstitutionTypes.Pharmacy).ID;
            BLL.InstitutionType.Constants.REGION = Program.LookupKernel.GetLookup(InstitutionTypes.Region).ID;
            BLL.InstitutionType.Constants.REGIONAL_LAB = Program.LookupKernel.GetLookup(InstitutionTypes.RegionalLab).ID;
            BLL.InstitutionType.Constants.RESEARCH_CENTER = Program.LookupKernel.GetLookup(InstitutionTypes.ResearchCenter).ID;
            BLL.InstitutionType.Constants.RURAL_DRUG_VENDOR = Program.LookupKernel.GetLookup(InstitutionTypes.RuralDrugStore).ID;
            BLL.InstitutionType.Constants.SUPPLIER = Program.LookupKernel.GetLookup(InstitutionTypes.Supplier).ID;
            BLL.InstitutionType.Constants.WOREDA = Program.LookupKernel.GetLookup(InstitutionTypes.Woreda).ID;
            BLL.InstitutionType.Constants.ZONE = Program.LookupKernel.GetLookup(InstitutionTypes.Zone).ID;

        }

        public static void LoadOwnershipTypeConstants()
        {
            BLL.OwnershipType.Constants.NGO = Program.LookupKernel.GetLookup(OwnershipTypes.NGO).ID;
            BLL.OwnershipType.Constants.OGA = Program.LookupKernel.GetLookup(OwnershipTypes.OGA).ID;
            BLL.OwnershipType.Constants.Private = Program.LookupKernel.GetLookup(OwnershipTypes.Private).ID;
            BLL.OwnershipType.Constants.Public = Program.LookupKernel.GetLookup(OwnershipTypes.Public).ID;
            BLL.OwnershipType.Constants.UNFR = Program.LookupKernel.GetLookup(OwnershipTypes.Uniformed).ID;
        }

        public static void LoadPaymentTypeConstants()
        {
            BLL.PaymentType.Constants.CASH = Program.LookupKernel.GetLookup(PaymentTypes.Cash).ID;
            BLL.PaymentType.Constants.CREDIT = Program.LookupKernel.GetLookup(PaymentTypes.Credit).ID;
            BLL.PaymentType.Constants.DELIVERY_NOTE = Program.LookupKernel.GetLookup(PaymentTypes.DeliveryNote).ID;
            BLL.PaymentType.Constants.ERROR_CORRECTION = Program.LookupKernel.GetLookup(PaymentTypes.ErrorCorrection).ID;
            BLL.PaymentType.Constants.INVENTORY = Program.LookupKernel.GetLookup(PaymentTypes.EndingInventory).ID;
            BLL.PaymentType.Constants.STV = Program.LookupKernel.GetLookup(PaymentTypes.STV).ID;
            BLL.PaymentType.Constants.DISPOSAL = Program.LookupKernel.GetLookup(PaymentTypes.Disposal).ID;
        }

        public static void LoadOrderStatusConstants()
        {
            BLL.OrderStatus.Constant.CANCELED = Program.LookupKernel.GetLookup(HCMIS.Enums.OrderStatus.Canceled).ID;
            BLL.OrderStatus.Constant.DISPATCH_CONFIRMED = Program.LookupKernel.GetLookup(HCMIS.Enums.OrderStatus.DispatchConfirmed).ID;
            BLL.OrderStatus.Constant.DRAFT_WISHLIST = Program.LookupKernel.GetLookup(HCMIS.Enums.OrderStatus.Draft).ID;
            BLL.OrderStatus.Constant.ISSUED = Program.LookupKernel.GetLookup(HCMIS.Enums.OrderStatus.Issued).ID;
            BLL.OrderStatus.Constant.ORDER_APPROVED = Program.LookupKernel.GetLookup(HCMIS.Enums.OrderStatus.Approved).ID;
            BLL.OrderStatus.Constant.ORDER_FILLED = Program.LookupKernel.GetLookup(HCMIS.Enums.OrderStatus.OrderFilled).ID;
            BLL.OrderStatus.Constant.PICK_LIST_CONFIRMED = Program.LookupKernel.GetLookup(HCMIS.Enums.OrderStatus.PicklistConfirmed).ID;
            BLL.OrderStatus.Constant.PICK_LIST_GENERATED = Program.LookupKernel.GetLookup(HCMIS.Enums.OrderStatus.PickListed).ID;
        }

        public static void LoadReceiptConfirmationStatusConstants()
        {            
            BLL.ReceiptConfirmationStatus.Constants.DRAFT_RECEIPT = Program.LookupKernel.GetLookup(HCMIS.Enums.ReceiptConfirmationStatus.DraftReceive).ID;
            BLL.ReceiptConfirmationStatus.Constants.GRV_PRINTED = Program.LookupKernel.GetLookup(HCMIS.Enums.ReceiptConfirmationStatus.GRVPrinted).ID;
            BLL.ReceiptConfirmationStatus.Constants.PRICE_CALCULATED = Program.LookupKernel.GetLookup(HCMIS.Enums.ReceiptConfirmationStatus.PriceCalculated).ID;
            BLL.ReceiptConfirmationStatus.Constants.PRICE_CONFIRMED = Program.LookupKernel.GetLookup(HCMIS.Enums.ReceiptConfirmationStatus.PriceConfirmed).ID;
            BLL.ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED = Program.LookupKernel.GetLookup(HCMIS.Enums.ReceiptConfirmationStatus.ReceiveEntered).ID;
            BLL.ReceiptConfirmationStatus.Constants.RECEIVE_QUANTITY_CONFIRMED = Program.LookupKernel.GetLookup(HCMIS.Enums.ReceiptConfirmationStatus.ReceiveConfirmed).ID;
            BLL.ReceiptConfirmationStatus.Constants.GRNF_PRINTED = Program.LookupKernel.GetLookup(HCMIS.Enums.ReceiptConfirmationStatus.GRNFPrinted).ID;
        }

        public static void LoadReceiptTypeConstants()
        {
            BLL.ReceiptType.CONSTANTS.ACCOUNT_TO_ACCOUNT_TRANSFER = Program.LookupKernel.GetLookup(ReceiptTypes.AccountTransfer).ID;
            BLL.ReceiptType.CONSTANTS.BEGINNING_BALANCE = Program.LookupKernel.GetLookup(ReceiptTypes.BeginningBalance).ID;
            BLL.ReceiptType.CONSTANTS.DELIVERY_NOTE = Program.LookupKernel.GetLookup(ReceiptTypes.DeliveryNote).ID;
            BLL.ReceiptType.CONSTANTS.ERROR_CORRECTION = Program.LookupKernel.GetLookup(ReceiptTypes.ErrorCorrection).ID;
            BLL.ReceiptType.CONSTANTS.STANDARD_RECEIPT = Program.LookupKernel.GetLookup(ReceiptTypes.StandardReceipt).ID;
            BLL.ReceiptType.CONSTANTS.STOCK_RETURN = Program.LookupKernel.GetLookup(ReceiptTypes.StockReturnMemoSRM).ID;
            BLL.ReceiptType.CONSTANTS.STORE_TO_STORE_TRANSFER = Program.LookupKernel.GetLookup(ReceiptTypes.StoreTransfer).ID;
            BLL.ReceiptType.CONSTANTS.MANUAL_DELIVERY_NOTE = Program.LookupKernel.GetLookup(ReceiptTypes.ManualDeliveryNote).ID;
            BLL.ReceiptType.CONSTANTS.LOCAL_PURCHASE = Program.LookupKernel.GetLookup(ReceiptTypes.LocalPurchase).ID;
        }

        public static void LoadShortageReasonsConstants()
        {
            BLL.ShortageReasons.Constants.DAMAGED = Program.LookupKernel.GetLookup(HCMIS.Enums.ShortageReasons.Damaged).ID;
            BLL.ShortageReasons.Constants.NOT_RECEIVED = Program.LookupKernel.GetLookup(HCMIS.Enums.ShortageReasons.NotReceived).ID;
            BLL.ShortageReasons.Constants.OTHERS = Program.LookupKernel.GetLookup(HCMIS.Enums.ShortageReasons.Others).ID;
            BLL.ShortageReasons.Constants.SAMPLE = Program.LookupKernel.GetLookup(HCMIS.Enums.ShortageReasons.FMHACASample).ID;
            BLL.ShortageReasons.Constants.SHORT_LANDED = Program.LookupKernel.GetLookup(HCMIS.Enums.ShortageReasons.ShortLanded).ID;           
        }

        public static void LoadTransferConstants()
        {
            BLL.Transfer.Constants.ACCOUNT_TO_ACCOUNT = Program.LookupKernel.GetLookup(TransferTypes.AccountToAccount).ID;
            BLL.Transfer.Constants.HUB_TO_HUB = Program.LookupKernel.GetLookup(TransferTypes.HubToHub).ID;
            BLL.Transfer.Constants.STORE_TO_STORE = Program.LookupKernel.GetLookup(TransferTypes.StoreToStore).ID;
        }

        public static void LoadInventoryPeriodConstants()
        {
            BLL.InventoryPeriod.Constants.BEGIN_INVENTORY = Program.LookupKernel.GetLookup(HCMIS.Enums.InventoryStatus.BeginInventory).ID;
            BLL.InventoryPeriod.Constants.DRAFT_INVENTORY_SAVED = Program.LookupKernel.GetLookup(HCMIS.Enums.InventoryStatus.DraftInventorySaved).ID;
            BLL.InventoryPeriod.Constants.PRINT_INVENTORY_SHEET = Program.LookupKernel.GetLookup(HCMIS.Enums.InventoryStatus.PrintCountSheet).ID;
        }

        public static void LoadRequisitionTypeConstants()
        {
            BLL.RequisitionType.CONSTANTS.CONSUMPTION = Program.LookupKernel.GetLookup(RequisitionTypes.Consumption).ID;
            BLL.RequisitionType.CONSTANTS.DEMAND = Program.LookupKernel.GetLookup(RequisitionTypes.Demand).ID;
            BLL.RequisitionType.CONSTANTS.HISTORY = Program.LookupKernel.GetLookup(RequisitionTypes.History).ID;
            BLL.RequisitionType.CONSTANTS.POPULATION = Program.LookupKernel.GetLookup(RequisitionTypes.Population).ID;
        }

        public static void LoadActivityConstants()
        {
            BLL.Activity.Constants.RDF_MDG = Program.LookupKernel.GetLookup(Activities.RDFMDG).ID;
            BLL.Activity.Constants.RDF_PBS = Program.LookupKernel.GetLookup(Activities.RDFPBS).ID;
            BLL.Activity.Constants.RDF_REGULAR = Program.LookupKernel.GetLookup(Activities.RDFRegular).ID;
        }

        public static void LoadOrderTypeConstants()
        {
            BLL.OrderType.CONSTANTS.ACCOUNT_TO_ACCOUNT_TRANSFER = Program.LookupKernel.GetLookup(OrderTypes.ACCOUNT_TO_ACCOUNT_TRANSFER).ID;
            BLL.OrderType.CONSTANTS.BACK_ORDER = Program.LookupKernel.GetLookup(OrderTypes.BACK_ORDER).ID;
            BLL.OrderType.CONSTANTS.CUSTOM_ISSUE_ORDER = Program.LookupKernel.GetLookup(OrderTypes.CUSTOM_ISSUE_ORDER).ID;
            BLL.OrderType.CONSTANTS.ERROR_CORRECTION_TRANSFER = Program.LookupKernel.GetLookup(OrderTypes.ERROR_CORRECTION_TRANSFER).ID;
            BLL.OrderType.CONSTANTS.HUB_TO_HUB_TRANSFER = Program.LookupKernel.GetLookup(OrderTypes.HUB_TO_HUB_TRANSFER).ID;
            BLL.OrderType.CONSTANTS.INVENTORY = Program.LookupKernel.GetLookup(OrderTypes.INVENTORY).ID;
            BLL.OrderType.CONSTANTS.PLITS = Program.LookupKernel.GetLookup(OrderTypes.PLITS).ID;
            BLL.OrderType.CONSTANTS.STANDARD_ORDER = Program.LookupKernel.GetLookup(OrderTypes.STANDARD_ORDER).ID;
            BLL.OrderType.CONSTANTS.STORE_TO_STORE_TRANSFER = Program.LookupKernel.GetLookup(OrderTypes.STORE_TO_STORE_TRANSFER).ID;
      
        }

        public static void LoadPurchaseOrderTypeConstants()
        {

            BLL.POType.FOB = Program.LookupKernel.GetLookup(PurchaseOrderTypes.FOB).ID;
            BLL.POType.COST_AND_FREIGHT = Program.LookupKernel.GetLookup(PurchaseOrderTypes.CostandFreight).ID;
            BLL.POType.CIP = Program.LookupKernel.GetLookup(PurchaseOrderTypes.CIP).ID;
            BLL.POType.COST_AND_EST_FREIGHT = Program.LookupKernel.GetLookup(PurchaseOrderTypes.CostandEstimatedFreight).ID;
            BLL.POType.LONG_TERM = Program.LookupKernel.GetLookup(PurchaseOrderTypes.LongTermContract).ID;
            BLL.POType.CONSIGNMENT = Program.LookupKernel.GetLookup(PurchaseOrderTypes.Consignment).ID;
            BLL.POType.DONATION = Program.LookupKernel.GetLookup(PurchaseOrderTypes.Donation).ID;
            BLL.POType.INTERNAL = Program.LookupKernel.GetLookup(PurchaseOrderTypes.Internal).ID;
            BLL.POType.INVENTORY = Program.LookupKernel.GetLookup(PurchaseOrderTypes.Inventory).ID;

            BLL.POType.DIRECT_VENDOR_TRANSFER = Program.LookupKernel.GetLookup(PurchaseOrderTypes.LocalPurchase).ID;
            BLL.POType.MANUAL_DELIVERYNOTE = Program.LookupKernel.GetLookup(PurchaseOrderTypes.ManualDeliveryNote).ID;
            BLL.POType.E_PURCHASE_ORDER = Program.LookupKernel.GetLookup(PurchaseOrderTypes.EPurchaseOrder).ID;
            BLL.POType.ACCOUNT_TO_ACCOUNT_TRANSFER = Program.LookupKernel.GetLookup(PurchaseOrderTypes.TransferAccount).ID;
            BLL.POType.STORE_TO_STORE_TRANSFER = Program.LookupKernel.GetLookup(PurchaseOrderTypes.TransferStore).ID;
            BLL.POType.HUB_TO_HUB_TRANSFER = Program.LookupKernel.GetLookup(PurchaseOrderTypes.TransferHub).ID;
            BLL.POType.ERROR_CORRECTION_TRANSFER = Program.LookupKernel.GetLookup(PurchaseOrderTypes.ErrorCorrection).ID;
            BLL.POType.STOCK_RETURN_MEMO = Program.LookupKernel.GetLookup(PurchaseOrderTypes.StockReturnMemo).ID;

        }

        public static void LoadPurchaseOrderParentTypeConstants()
        {
            BLL.POType.NON_STANDARD = Program.LookupKernel.GetLookup(PurchaseOrderParentTypes.NonStandard).ID;
            BLL.POType.STANDARD = Program.LookupKernel.GetLookup(PurchaseOrderParentTypes.Standard).ID;
            //BLL.POType.HUB_ONLY = Program.LookupKernel.GetLookup(PurchaseOrderParentTypes.HubOnly).ID;
        }

        public static void LoadReceiptInvoiceTypeConstants()
        {
            BLL.ReceiptInvoiceType.InvoiceType.CIP = Program.LookupKernel.GetLookup(InvoiceTypes.CIP).ID;
            BLL.ReceiptInvoiceType.InvoiceType.INVENTORY = Program.LookupKernel.GetLookup(InvoiceTypes.Inventory).ID;
            BLL.ReceiptInvoiceType.InvoiceType.INVOICE_AIR = Program.LookupKernel.GetLookup(InvoiceTypes.InvoiceTransportationbyAir).ID;
            BLL.ReceiptInvoiceType.InvoiceType.INVOICE_SEA = Program.LookupKernel.GetLookup(InvoiceTypes.InvoiceTransportationbySea).ID;
            BLL.ReceiptInvoiceType.InvoiceType.LOCAL_PURCHASE = Program.LookupKernel.GetLookup(InvoiceTypes.LocalPurchase).ID;
            BLL.ReceiptInvoiceType.InvoiceType.NON_STANDARD = Program.LookupKernel.GetLookup(InvoiceTypes.NonStandard).ID;
            BLL.ReceiptInvoiceType.InvoiceType.STV = Program.LookupKernel.GetLookup(InvoiceTypes.STV).ID;
            BLL.ReceiptInvoiceType.InvoiceType.ERROR_CORRECTION = Program.LookupKernel.GetLookup(InvoiceTypes.ErrorCorrection).ID;
            BLL.ReceiptInvoiceType.InvoiceType.INTERNAL = Program.LookupKernel.GetLookup(InvoiceTypes.Internal).ID;
        }

        public static void LoadInstitutionITypeConstants()
        {
            BLL.InstitutionIType.PfsaHub = Program.LookupKernel.GetLookup(InstitutionITypes.PFSAHub).ID;
            BLL.InstitutionIType.Vaccine = Program.LookupKernel.GetLookup(InstitutionITypes.VaccineHub).ID;       
        }

        public static void LoadPlitsIntegrationConstants()
        {
            HCMIS.Desktop.Helpers.RRFServiceIntegration.PharmacitucalsCommodityType = Program.LookupKernel.GetLookup(CommodityTypes.Pharmaceuticals).ID;
        }

        public static void LoadCommodityTypeConstants()
        {
            BLL.CommodityType.Constants.PHARMACEUTICALS = Program.LookupKernel.GetLookup(CommodityTypes.Pharmaceuticals).ID;
            BLL.CommodityType.Constants.MEDICAL_SUPPLIES = Program.LookupKernel.GetLookup(CommodityTypes.MedicalSupplies).ID;
            BLL.CommodityType.Constants.MEDICAL_EQUIPMENTS = Program.LookupKernel.GetLookup(CommodityTypes.MedicalEquipments).ID;
            BLL.CommodityType.Constants.CHEMICAL_AND_REAGENTS = Program.LookupKernel.GetLookup(CommodityTypes.ChemicalsandReagents).ID;
        }

        public static void LoadSupplierTypeConstants()
        {
            BLL.SupplierType.CONSTANTS.HOME_OFFICE = Program.LookupKernel.From<SupplierType>().Get(SupplierTypes.HomeOffice).SupplierTypeID;
            BLL.SupplierType.CONSTANTS.HUBS = Program.LookupKernel.From<SupplierType>().Get(SupplierTypes.Hubs).SupplierTypeID;
            BLL.SupplierType.CONSTANTS.FACILITIES = Program.LookupKernel.From<SupplierType>().Get(SupplierTypes.Facilities).SupplierTypeID;
            BLL.SupplierType.CONSTANTS.ACCOUNTS = Program.LookupKernel.From<SupplierType>().Get(SupplierTypes.Accounts).SupplierTypeID;
            BLL.SupplierType.CONSTANTS.STORES = Program.LookupKernel.From<SupplierType>().Get(SupplierTypes.Stores).SupplierTypeID;
            BLL.SupplierType.CONSTANTS.EXTERNAL_SUPPLIERS = Program.LookupKernel.From<SupplierType>().Get(SupplierTypes.ExternalSuppliers).SupplierTypeID;
        }
           
    }
}
