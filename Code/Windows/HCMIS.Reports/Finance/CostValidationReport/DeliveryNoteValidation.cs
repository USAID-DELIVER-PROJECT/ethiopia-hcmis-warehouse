
using System;
namespace HCMIS.Desktop.Reports
{
    public partial class DeliveryNoteValidation: DevExpress.XtraReports.UI.XtraReport
    {
        public DeliveryNoteValidation()
        {
            InitializeComponent();
            pxLogo.ImageUrl = BLL.GeneralInfo.Current.LogoUrl;
        }
    }
}