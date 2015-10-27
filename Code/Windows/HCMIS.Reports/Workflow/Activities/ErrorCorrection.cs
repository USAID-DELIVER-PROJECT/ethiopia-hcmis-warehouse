using System;
using BLL;

namespace HCMIS.Desktop.Reports
{
    public partial class ErrorCorrection : DevExpress.XtraReports.UI.XtraReport
    {
        public ErrorCorrection(int IDPRINTED,string stockCodeTo,string ItemIDTo, string unitIdTo, string manufacturerIdTo
            ,string stockCodeFrom, string ItemIdFrom, string unitIdFrom, string manufacturerIdFrom
            , bool changeExpiryDate = false, DateTime? expiryDate = null, bool changeBatchNo = false, string batchNo = null)
        {
            InitializeComponent();
            xrIDPrinted.Text = IDPRINTED.ToString("00000");
            xrStockCodeTo.Text = stockCodeTo;
            xrItemTo.Text = ItemIDTo; 
            xrItemUnitTo.Text = unitIdTo;
            xrManufacturerTo.Text = manufacturerIdTo;
            xrBatchNo.Text = batchNo;
            xrExpiryDate.Text = expiryDate.HasValue ? expiryDate.Value.ToShortDateString() : "";
            xrStockCodeFrom.Text = stockCodeFrom;
            xrItemFrom.Text = ItemIdFrom;
            xrUnitFrom.Text = unitIdFrom;
            xrManufacturerFrom.Text = manufacturerIdFrom;
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
            xrBatchNo.Visible = xrlblBatchNo.Visible = changeBatchNo;
            xrExpiryDate.Visible = xrlbExpiryDate.Visible = changeExpiryDate;
        }

    }
}
