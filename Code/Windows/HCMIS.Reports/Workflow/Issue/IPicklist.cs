using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UI;

namespace HCMIS.Reports.Workflow
{
    public interface IPicklist
    {

        string ToLabel { get; set; }
        string IDLabel { get; set; }
        string DateLabel { get; set; }
        string PreparedByLabel { get; set; }
        string ApprovedByLabel { get; set; }
        string ContactPersonNameLabel { get; set; }
  
    }
}
