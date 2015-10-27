using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class JournalEntry
    {
        private DataTable dtJournal = new DataTable();
        string Account, SubAccount, Activity, SupplierName, CommodityType, PONumber, RefNo, STVOrInvoice, TransitTransferNo, WayBillNo, InsurancePolicyNo;
        public JournalEntry()
        {
            dtJournal.Columns.Add("Credit", System.Type.GetType("System.Double"));
            dtJournal.Columns.Add("EntryName", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("Debit", System.Type.GetType("System.Double"));
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalEntry" /> class.
        /// </summary>
        /// <param name="Account">The account.</param>
        /// <param name="SubAccount">The sub account.</param>
        /// <param name="Activity">The activity.</param>
        /// <param name="SupplierName">Name of the supplier.</param>
        /// <param name="CommodityType">Type of the commodity.</param>
        /// <param name="PONumber">The PO number.</param>
        /// <param name="RefNo">The ref no.</param>
        /// <param name="STVOrInvoice">The STV or invoice.</param>
        /// <param name="TransitTransferNo">The transit transfer no.</param>
        /// <param name="WayBillNo">The way bill no.</param>
        /// <param name="InsurancePolicyNo">The insurance policy no.</param>
        public JournalEntry(string Account, string SubAccount, string Activity, string SupplierName, string CommodityType, string PONumber, string RefNo, string STVOrInvoice, string TransitTransferNo, string WayBillNo, string InsurancePolicyNo)
        {

            dtJournal.Columns.Add("Account", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("Activity", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("CommodityType", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("Credit", System.Type.GetType("System.Double"));
            dtJournal.Columns.Add("EntryName", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("Debit", System.Type.GetType("System.Double"));
            dtJournal.Columns.Add("InsurancePolicyNo", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("PONumber", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("PrintedGRVNumber", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("ReceiveDate", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("RefNo", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("STVOrInvoiceNo", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("SubAccount", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("TransitTransferNo", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("WayBillNo", System.Type.GetType("System.String"));
            dtJournal.Columns.Add("SupplierName", System.Type.GetType("System.String"));
            this.Account = Account;
            this.SubAccount = SubAccount;
            this.Activity = Activity;
            this.SupplierName = SupplierName;
            this.CommodityType = CommodityType;
            this.PONumber = PONumber; this.RefNo = RefNo; this.STVOrInvoice = STVOrInvoice; this.TransitTransferNo = TransitTransferNo; this.WayBillNo = WayBillNo; this.InsurancePolicyNo = InsurancePolicyNo;
        }

        /// <summary>
        /// Adds the new entry.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Debit">The debit.</param>
        /// <param name="Credit">The credit.</param>
        public void AddNewEntry(String Name, double? Debit, double? Credit)
        {


            DataRow drEntry = dtJournal.NewRow();
            if (Debit != null)
            {
                drEntry["EntryName"] = Name;
                drEntry["Debit"] = Debit;
            }
            else if (Credit != null)
            {
                drEntry["EntryName"] = "            " + Name;
                drEntry["Credit"] = Credit;
            }
            drEntry["Account"] = Account;
            drEntry["SubAccount"] = SubAccount;
            drEntry["Activity"] = Activity;
            drEntry["SupplierName"] = SupplierName;
            drEntry["PONumber"] = PONumber;
            drEntry["RefNo"] = RefNo;
            drEntry["STVOrInvoiceNo"] = STVOrInvoice;
            drEntry["TransitTransferNo"] = TransitTransferNo;
            drEntry["WayBillNo"] = WayBillNo;
            drEntry["InsurancePolicyNo"] = InsurancePolicyNo;
            drEntry["CommodityType"] = CommodityType;


            dtJournal.Rows.Add(drEntry);

        }

        /// <summary>
        /// Defaults the view.
        /// </summary>
        /// <returns></returns>
        public DataView DefaultView()
        {
            return new DataView(dtJournal);

        }
    }
}
