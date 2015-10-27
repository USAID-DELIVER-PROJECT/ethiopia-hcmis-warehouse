using System;
using System.Drawing;
using System.IO;
using HCMIS.Desktop.Reports.Helpers;

namespace HCMIS.Desktop
{
    public class ReportHelper
    {

        public static ReportHelper Instance;

        private string _HeaderName;

        public string HeaderName
        {
            get { return _HeaderName; }
            set { _HeaderName = value; }
        }

        private string _HubName;

        public string HubName
        {
            get { return _HubName; }
            set { _HubName = value; }
        }

        public byte[] _imageData;
        public Image ImageStream
        {
            get
            {
                return Image.FromStream(new MemoryStream(_imageData));
            }
        }    
        private string _ToName;

        public string ToName
        {
            get { return _ToName; }
            set { _ToName = value; }
        }

        private DateTime _Date1;

        public DateTime Date1
        {
            get { return _Date1; }
            set { _Date1 = value; }
        }


        private DateTime _Date2;

        public DateTime Date2
        {
            get { return _Date2; }
            set { _Date2 = value; }
        }



        private TheDataSet.PickListDataTable _MainTable;

        public TheDataSet.PickListDataTable MainTable
        {
            get { return _MainTable; }
            set { _MainTable = value; }
        }

        private HCMIS.Desktop.Reports.ExpiryReport _MainNearExpiryReport;

        public HCMIS.Desktop.Reports.ExpiryReport MainNearExpiryReport
        {
            get { return _MainNearExpiryReport; }
            set { _MainNearExpiryReport = value; }
        }

    }
}
