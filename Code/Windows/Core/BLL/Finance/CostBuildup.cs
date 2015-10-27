using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class CostBuildup
    {

        enum ProrationType
        {
            PO = 1,
            Invoice = 2,
            None = 3
        }

        private Activity _activity;
        string Supplier, OrderNo, InvoiceNo, GRVNo, AWBNo, ShippedBy;
        //Settings
        public bool ProrateUsingFreightOnPO;
        public bool ProrateUsingFreightOnInvoice;
        public bool IncludeDamageOnFOB;
        public bool AutoProrate;
        public bool UsePOFreight;
        public bool UseSeaFreight;
        public bool UseTransitServiceCharge;
        public bool UseCustomDutyTax;
        public bool UseProvison;

        //For Proration
        private double POGRVProrationCoefficient;
        private double InvoiceGRVProrationCoefficient;

        public double CIF = 0;
        public double Provision = 0;
        private double _TotalLandedCost;
        private double _CostCoefficient;


        //PO Cost Elements;
        private double PurchaseOrderTotal = 0;
        private double PurchaseOrderAirFreight = 0;
        private double PurchaseOrderSeaFreight = 0;
        private double PurchaseOrderInsurance = 0;
        private double PurcahseOrderNBE = 0;

        //Invoice Cost Elements;
        private double InvoiceTotal = 0;
        private double InvoiceAirFreight = 0;
        private double InvoiceSeaFreight = 0;
        private double InvoiceInlandFreight = 0;
        private double InvoiceInsurance = 0;
        private double InvoiceNBE = 0;
        private double InvoiceCBE = 0;
        private double InvoiceCustomDutyTax = 0;


        //GRV Cost Elements
        private double GRVTotal = 0;
        private double GRVAirFreight = 0;
        private double GRVSeaFreight = 0;
        private double GRVInlandFreight = 0;
        private double GRVInsurance = 0;
        private double GRVNBE = 0;
        private double GRVCBE = 0;
        private double GRVCustomDutyTax = 0;
        private double GRVTransit = 0;
        private double GRVOtherExpense = 0;

        //Exchange rate
        private double FOBExchangeRate = 0;
        private double FreightExchangeRate = 0;

        public double CostCoefficient
        {
            get
            {
                return _CostCoefficient;
            }
        }
        public double TotalLandedCost
        {
            get
            {
                return _TotalLandedCost;
            }
        }

        //Variable for Calculations(Cost elements)
        //PO
        public PO purchaseOrder = new PO();
        public ReceiptInvoice Invoice = new ReceiptInvoice();
        public Receipt GRV = new Receipt();

        public CostBuildup()
        {
            Initialize();
        }


        public DataTable DataTable { get; set; }


        private void Initialize()
        {
            DataTable = new DataTable();
            //Variable Name
            DataTable.Columns.Add("Variable");
            //Displayed Name
            DataTable.Columns.Add("Name");
            DataTable.Columns.Add("POValue", System.Type.GetType("System.Double"));
            DataTable.Columns.Add("InvoiceValue", System.Type.GetType("System.Double"));
            DataTable.Columns.Add("ExchangeRate", System.Type.GetType("System.Double"));
            DataTable.Columns.Add("GRVValue", System.Type.GetType("System.Double"));
            DataTable.Columns.Add("Value", System.Type.GetType("System.Double"));

            DataTable.Columns.Add("Account", System.Type.GetType("System.String"));
            DataTable.Columns.Add("SubAccount", System.Type.GetType("System.String"));
            DataTable.Columns.Add("Activity", System.Type.GetType("System.String"));
            DataTable.Columns.Add("Supplier", System.Type.GetType("System.String"));
            DataTable.Columns.Add("Order No", System.Type.GetType("System.String"));
            DataTable.Columns.Add("Invoice No", System.Type.GetType("System.String"));
            DataTable.Columns.Add("GRV No", System.Type.GetType("System.String"));
            DataTable.Columns.Add("Shipped by", System.Type.GetType("System.String"));
            DataTable.Columns.Add("AWB No", System.Type.GetType("System.String"));
            DataTable.Columns.Add("Date", System.Type.GetType("System.String"));
            DataTable.Columns.Add("Voucher", System.Type.GetType("System.String"));
            DataTable.Columns.Add("InsuredSum", System.Type.GetType("System.Double"));
            DataTable.Columns.Add("AmountInBirr", System.Type.GetType("System.Double"));
        }



        public void SetEditedValue(string Variable, double Value)
        {

            BLL.Receipt ReceiptToSave = new BLL.Receipt();

            ReceiptToSave.LoadByPrimaryKey(GRV.ID);
            switch (Variable)
            {
                case "GRVTotal":
                    GRVTotal = Value;
                    ReceiptToSave.TotalValue = Value;
                    break;
                case "GRVAirFreight":
                    GRVAirFreight = Value;
                    ReceiptToSave.AirFreight = Value;
                    break;
                case "GRVSeaFreight":
                    GRVSeaFreight = Value;
                    ReceiptToSave.SeaFreight = Value;
                    break;
                case "GRVInlandFreight":
                    GRVInlandFreight = Value;
                    ReceiptToSave.InlandFreight = Value;
                    break;
                case "GRVInsurance":
                    GRVInsurance = Value;
                    ReceiptToSave.Insurance = Value;
                    break;
                case "GRVNBE":
                    GRVNBE = Value;
                    ReceiptToSave.NBE = Value;
                    break;
                case "GRVCBE":
                    GRVCBE = Value;
                    ReceiptToSave.CBE = Value;
                    break;

                case "GRVCustomDutyTax":
                    GRVCustomDutyTax = Value;

                    ReceiptToSave.CustomDutyTax = Value;
                    break;
                case "GRVTransit":
                    GRVTransit = Value;
                    ReceiptToSave.TransitServiceCharge = Value;
                    break;
            }
            ReceiptToSave.Save();
            CalculateCostCoefficient();
            PopulateDataTable();
        }


        public void LoadByReceiptIDInvoiceIDAndPoID(int ReceiptID, int InvoiceID, int PoID, string GRNString,double GRVTotalValue)
        {
            purchaseOrder = new PO();
            Invoice = new ReceiptInvoice();
            GRV = new Receipt();
         
            //Load 
     
            this.GRVTotal = GRVTotalValue;
            LoadData(ReceiptID, InvoiceID, PoID);
               
            _activity = new Activity();
            _activity.LoadByPrimaryKey(Invoice.ActivityID);
            
            
            Supplier = purchaseOrder.Supplier.CompanyName;
            OrderNo = purchaseOrder.PONumber;
            InvoiceNo = Invoice.STVOrInvoiceNo;
            GRVNo = GRNString;
            AWBNo = Invoice.WayBillNo;
            ShippedBy = Invoice.ShippedBy;
            if (Invoice.IsColumnNull("InvoiceTypeID") || GRV.ReceiptTypeID == ReceiptType.CONSTANTS.STOCK_RETURN)
            {
                AutoProrate = false;
                purchaseOrder.ExhangeRate = FOBExchangeRate = 1;
            }
            else if (Invoice.InvoiceTypeID == ReceiptInvoiceType.InvoiceType.NON_STANDARD)
            {
                AutoProrate = false;
                purchaseOrder.ExhangeRate = FOBExchangeRate = 1;
            }
            else
            {

                if (purchaseOrder.PurchaseType == POType.COST_AND_EST_FREIGHT)
                {
                    ProrateUsingFreightOnPO = true;
                    ProrateUsingFreightOnInvoice = true;
                    UsePOFreight = true;
                }
                else if (purchaseOrder.PurchaseType == POType.COST_AND_FREIGHT)
                {
                    ProrateUsingFreightOnPO = true;
                    ProrateUsingFreightOnInvoice = true;
                    UsePOFreight = false;
                }
            }



                if (!_activity.IsHealthProgram())
                    UseCustomDutyTax = true;
                if (AutoProrate && Invoice.InvoiceTypeID != -255 && Invoice.InvoiceTypeID != InvoiceType.Internal)
                    Prorate();

                if (Invoice.IsColumnNull("InvoiceTypeID") || Invoice.InvoiceTypeID == ReceiptInvoiceType.InvoiceType.LOCAL_PURCHASE || Invoice.InvoiceTypeID == ReceiptInvoiceType.InvoiceType.CIP || Invoice.InvoiceTypeID == ReceiptInvoiceType.InvoiceType.NON_STANDARD || _activity.IsHealthProgram())
                UseProvison = false;
            else
                UseProvison = true;

            CalculateCostCoefficient();
            PopulateDataTable();
        }
        private void LoadData(int ReceiptID, int InvoiceID, int PoID)
        {
         

            //PO Cost Elements;
            purchaseOrder.LoadByPrimaryKey(PoID);
            Invoice.LoadByPrimaryKey(InvoiceID);
            GRV.LoadByPrimaryKey(ReceiptID);

            if (Invoice.IsColumnNull("InvoiceTypeID"))
            {
                Invoice.InvoiceTypeID = ReceiptInvoiceType.InvoiceType.NON_STANDARD;
            }
            if (Invoice.InvoiceTypeID == ReceiptInvoiceType.InvoiceType.INVOICE_SEA)
                UseSeaFreight = true;
            else
                UseSeaFreight = false;

            if (!purchaseOrder.IsColumnNull("TotalValue"))
                PurchaseOrderTotal = purchaseOrder.TotalValue;
            if (!purchaseOrder.IsColumnNull("AirFreight"))
                PurchaseOrderAirFreight = purchaseOrder.AirFreight;
            if (!purchaseOrder.IsColumnNull("SeaFreight"))
                PurchaseOrderSeaFreight = purchaseOrder.SeaFreight;
            if (!purchaseOrder.IsColumnNull("Insurance"))
                PurchaseOrderInsurance = purchaseOrder.Insurance;
            if (!purchaseOrder.IsColumnNull("NBE"))
                PurcahseOrderNBE = purchaseOrder.NBE;

            //Invoice Cost Elements;
            if (!Invoice.IsColumnNull("TotalValue"))
                InvoiceTotal = Invoice.TotalValue;
            if (!Invoice.IsColumnNull("AirFreight"))
                InvoiceAirFreight = Invoice.AirFreight;
            if (!Invoice.IsColumnNull("SeaFreight"))
                InvoiceSeaFreight = Invoice.SeaFreight;
            if (!Invoice.IsColumnNull("InlandFreight"))
                InvoiceInlandFreight = Invoice.InlandFreight;
            if (!Invoice.IsColumnNull("Insurance"))
                InvoiceInsurance = Invoice.Insurance;
            if (!Invoice.IsColumnNull("NBE"))
                InvoiceNBE = Invoice.NBE;
            if (!Invoice.IsColumnNull("CBE"))
                InvoiceCBE = Invoice.CBE;
            if (!Invoice.IsColumnNull("CustomDutyTax"))
                InvoiceCustomDutyTax = Invoice.CustomDutyTax;


            //GRV Cost Elements


           
            if (UseSeaFreight)
            {
                if (!GRV.IsColumnNull("SeaFreight"))
                    GRVSeaFreight = GRV.SeaFreight;
            }
            else
            {
                if (!GRV.IsColumnNull("AirFreight"))
                    GRVAirFreight = GRV.AirFreight;
            }

            if (!GRV.IsColumnNull("InlandFreight"))
                GRVInlandFreight = GRV.InlandFreight;

            if (!GRV.IsColumnNull("Insurance"))
                GRVInsurance = GRV.Insurance;

            if (!GRV.IsColumnNull("NBE"))
                GRVNBE = GRV.NBE;

            if (!GRV.IsColumnNull("CBE"))
                GRVCBE = GRV.CBE;

            if (!GRV.IsColumnNull("CustomDutyTax"))
                GRVCustomDutyTax = GRV.CustomDutyTax;

            if (!GRV.IsColumnNull("TransitServiceCharge"))
                GRVTransit = GRV.TransitServiceCharge;
            else
                GRVTransit = UseTransitServiceCharge ? 250 : 0;

            //if (!GRV.IsColumnNull("OtherExpenses"))
            //  GRVOtherExpense = GRV;

            //Exchange rate
            if (!purchaseOrder.IsColumnNull("ExhangeRate"))
                FOBExchangeRate = purchaseOrder.ExhangeRate;
            if (!Invoice.IsColumnNull("ExchangeRate"))
                FreightExchangeRate = Invoice.ExchangeRate;


        }

        private void Prorate()
        {
            if (UseSeaFreight)
            {
                SetProrationForPO(PurchaseOrderTotal, GRVTotal, PurchaseOrderSeaFreight, InvoiceSeaFreight,InvoiceTotal);
                SetProrationForInvoice(InvoiceTotal, GRVTotal, InvoiceSeaFreight);

            }
            else
            {
                SetProrationForPO(PurchaseOrderTotal, GRVTotal, PurchaseOrderAirFreight,InvoiceAirFreight,InvoiceTotal);
                SetProrationForInvoice(InvoiceTotal, GRVTotal, InvoiceAirFreight);
            }

            //Porate from PurchaseOrder to GRV

            //PO Level

            GRVInsurance = Math.Round(purchaseOrder.Insurance * POGRVProrationCoefficient, 2);
            GRVNBE = Math.Round(purchaseOrder.NBE * POGRVProrationCoefficient, 2);
                    GRVSeaFreight = Math.Round(InvoiceSeaFreight * InvoiceGRVProrationCoefficient, 2);
                    GRVAirFreight = Math.Round(InvoiceAirFreight * InvoiceGRVProrationCoefficient, 2);
                    GRVInlandFreight = Math.Round(InvoiceInlandFreight * InvoiceGRVProrationCoefficient, 2);
                if (UseSeaFreight)
                    GRVAirFreight = 0;
                else
                    GRVSeaFreight = 0;
                


            GRVCBE = Math.Round(InvoiceCBE * InvoiceGRVProrationCoefficient, 2);
            GRVCustomDutyTax = Math.Round(UseCustomDutyTax ? InvoiceCustomDutyTax * InvoiceGRVProrationCoefficient : 0, 2);

            GRVOtherExpense = 0;
        }

        private void CalculateProvision()
        {
            CIF = GRVTotal * FOBExchangeRate + GRVInsurance + (GRVAirFreight + GRVSeaFreight) * FreightExchangeRate + GRVInlandFreight;// +GRVOtherExpenses;
            Provision = 0.07 * CIF;
        }

        private void CalculateCostCoefficient()
        {
            if (UseProvison)
                CalculateProvision();

            _TotalLandedCost = Math.Round(GRVTotal * FOBExchangeRate + GRVInsurance + (GRVAirFreight + GRVSeaFreight) * FreightExchangeRate + GRVInlandFreight + GRVNBE + GRVCBE + GRVCustomDutyTax + GRVTransit + Provision, Settings.NoOfDigitsAfterTheDecimalPoint);
            _CostCoefficient = Math.Round(TotalLandedCost / GRVTotal, 6);
        }

        private void PopulateDataTable()
        {
            Initialize();
            AddEntryToCostBuildUp("GRVTotal", "FOB Value", PurchaseOrderTotal, InvoiceTotal, FOBExchangeRate, GRVTotal, GRVTotal * FOBExchangeRate);
            AddEntryToCostBuildUp("GRVInsurance", "Insurance", PurchaseOrderInsurance, InvoiceInsurance, 0, GRVInsurance, GRVInsurance);
            if (UseSeaFreight)
            {
                AddEntryToCostBuildUp("GRVSeaFreight", "Freight(Sea)", PurchaseOrderSeaFreight, InvoiceSeaFreight, FreightExchangeRate, GRVSeaFreight, (GRVSeaFreight) * FreightExchangeRate);
                AddEntryToCostBuildUp("GRVInlandFreight", "   - Inland Freight", 0, InvoiceInlandFreight, 0, GRVInlandFreight, GRVInlandFreight);
            }
            else
            {
                AddEntryToCostBuildUp("GRVAirFreight", "Freight(Air)", PurchaseOrderAirFreight, InvoiceAirFreight, FreightExchangeRate, GRVAirFreight, (GRVAirFreight) * FreightExchangeRate);
            }
            AddEntryToCostBuildUp("GRVOtherExpense", "OtherExpense", 0, 0, 0, 0, GRVOtherExpense);

            if (UseProvison)
            {
                AddEntryToCostBuildUp("GRVTotal", "CIF", 0, 0, 0, CIF, -1);
                AddEntryToCostBuildUp("GRVTotal", "   7% Provision ", 0, 0, 0, Provision, Provision);
            }

            AddEntryToCostBuildUp("GRVNBE", "Ethiopian National Bank S/C", PurcahseOrderNBE, InvoiceNBE, 0, GRVNBE, GRVNBE);
            AddEntryToCostBuildUp("GRVCBE", "Commercial Bank S/C", 0, InvoiceCBE, 0, GRVCBE, GRVCBE);
            AddEntryToCostBuildUp("GRVCustomDutyTax", "Customs", 0, InvoiceCustomDutyTax, 0, GRVCustomDutyTax, GRVCustomDutyTax);
            AddEntryToCostBuildUp("GRVTransit", "Transit Service Charge", 0, 0, 0, GRVTransit, GRVTransit);
            AddEntryToCostBuildUp("TotalLandedCost", "TotalLandedCost", 0, 0, 0, -1, TotalLandedCost);
            AddEntryToCostBuildUp("CostCoefficient", "Cost Coefficient", 0, 0, CostCoefficient, -1, -1);
        }

        private void SetProrationForPO(double TotalPOValue, double TotalGRVValue, double POFreight,double InvoiceFreight,double TotalInvoiceValue)
        {
           double ProratedGRVSeaFreight = 0;
           double ProratedGRVAirFreight = 0;
            POGRVProrationCoefficient = TotalGRVValue / TotalPOValue;

            if (!ProrateUsingFreightOnPO && !UsePOFreight)
                POGRVProrationCoefficient = TotalGRVValue / TotalPOValue;
            else if (!UsePOFreight) //Depending on the OrderType we can say UsePOFreight
            {
                SetProrationForInvoice(TotalInvoiceValue, TotalGRVValue, InvoiceFreight);
                //We use the Freight we found on the Invoice
                if (UseSeaFreight)
                    POGRVProrationCoefficient = (TotalGRVValue + GRVSeaFreight) / (TotalPOValue + POFreight);
                else
                    POGRVProrationCoefficient = (TotalGRVValue + GRVAirFreight) / (TotalPOValue + POFreight);


            }
            else if (UseSeaFreight)
            {
                ProratedGRVSeaFreight = POFreight * POGRVProrationCoefficient;
                ProratedGRVAirFreight = 0;
                POGRVProrationCoefficient = (TotalGRVValue + ProratedGRVSeaFreight) / (TotalPOValue + POFreight);

            }
            else
            {
                ProratedGRVAirFreight = POFreight * POGRVProrationCoefficient;
                ProratedGRVSeaFreight = 0;
                POGRVProrationCoefficient = (TotalGRVValue + ProratedGRVAirFreight) / (TotalPOValue + POFreight);

            }
        }

        private void SetProrationForInvoice(double TotalInvoiceValue, double TotalGRVValue, double InvoiceFreight)
        {

            InvoiceGRVProrationCoefficient = TotalGRVValue / TotalInvoiceValue; 
            if (!ProrateUsingFreightOnInvoice)
                InvoiceGRVProrationCoefficient = TotalGRVValue / TotalInvoiceValue;
            else if (UseSeaFreight)
            {
                GRVSeaFreight = InvoiceFreight * InvoiceGRVProrationCoefficient;
                GRVAirFreight = 0;
                InvoiceGRVProrationCoefficient = (TotalGRVValue + GRVSeaFreight) / (TotalInvoiceValue + InvoiceFreight);
   
            }
            else
            {
                GRVAirFreight = InvoiceFreight * InvoiceGRVProrationCoefficient;
                GRVSeaFreight = 0;
                InvoiceGRVProrationCoefficient = (TotalGRVValue + GRVAirFreight) / (TotalInvoiceValue + InvoiceFreight);
            }
        }

        public void AddEntryToCostBuildUp(string Variable, string CostElement, double POValue, double InvoiceValue, double ExchangeRate, double GRVValue, double Value)
        {
            DataRow NewRow = DataTable.NewRow();
            //Variable Name




            NewRow["Account"] = _activity.AccountName;
            
            NewRow["SubAccount"] = _activity.SubAccountName;
            NewRow["Activity"] = _activity.Name;
            NewRow["Supplier"] = Supplier;
            NewRow["Order No"] = OrderNo;
            NewRow["Invoice No"] = InvoiceNo;
            NewRow["GRV No"] = GRVNo;
            NewRow["AWB No"] = AWBNo;
            NewRow["Shipped by"] = ShippedBy;

            NewRow["Variable"] = Variable;
            NewRow["Name"] = CostElement;
            if (POValue != 0)
                NewRow["POValue"] = POValue;
            if (InvoiceValue != 0)
                NewRow["InvoiceValue"] = InvoiceValue;
            if (ExchangeRate != 0)
                NewRow["ExchangeRate"] = ExchangeRate;
            if (GRVValue != -1)
                NewRow["GRVValue"] = GRVValue;
            if (Value != -1)
                NewRow["Value"] = Value;
            DataTable.Rows.Add(NewRow);
        }
    
        public void SaveChange()
        {

            BLL.Receipt ReceiptToSave = new BLL.Receipt();

            ReceiptToSave.LoadByPrimaryKey(GRV.ID);

            ReceiptToSave.TotalValue = GRVTotal;
            ReceiptToSave.AirFreight = GRVAirFreight;
            ReceiptToSave.SeaFreight = GRVSeaFreight;
            ReceiptToSave.InlandFreight = GRVInlandFreight;
            ReceiptToSave.Insurance = GRVInsurance;
            ReceiptToSave.NBE = GRVNBE;
            ReceiptToSave.CBE = GRVCBE;
            ReceiptToSave.CustomDutyTax = GRVCustomDutyTax;
            ReceiptToSave.TransitServiceCharge = GRVTransit;
            ReceiptToSave.Provision = Provision;
            ReceiptToSave.Save();
        }

    }
}
