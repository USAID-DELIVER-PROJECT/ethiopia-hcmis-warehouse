using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Helpers;
using HCMIS.Desktop.ViewHelpers;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-RS-RS-RP", "Receipt Status", "")]
    public partial class ReceiveStatusReport : XtraForm
    {
        private string FilterString = "";

        public ReceiveStatusReport()
        {
            InitializeComponent();
        }

        private void ReceiveStatusReport_Load(object sender, EventArgs e)
        {
            gridOrders.DataSource = BLL.Receipt.GetReceiptStatusList();
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            if (User.GetUserType(CurrentContext.UserId) == UserType.Constants.SUPER_ADMINISTRATOR || User.GetUserType(CurrentContext.UserId) == UserType.Constants.ADMIN)
            {
                colReceiptID.Visible = colReceiveDocID.Visible = true;
            }
        }

        private void gridOrderListView_FocusedRowChanged(object sender,
                                                         DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridOrderListView.GetFocusedDataRow();
            if (dr != null)
            {
                int receiptID = Convert.ToInt32(dr["ID"]);
                ReceiveDoc receiveDoc = new ReceiveDoc();
                receiveDoc.LoadAllByReceiptID(receiptID);
                DataTable tbl = receiveDoc.DefaultView.ToTable();
                ReceiveDocDeleted receiveDocDeleted = new ReceiveDocDeleted();
                receiveDocDeleted.LoadAllByReceiptID(receiptID);

                LogReceiptStatus logReceiptStatus = new LogReceiptStatus();
                gridHistory.DataSource = logReceiptStatus.GetLogHistory(receiptID);

                if (receiveDocDeleted.RowCount > 0)
                {
                    tbl.Merge(receiveDocDeleted.DefaultView.ToTable());
                    BLL.User user = new User();
                    user.LoadByPrimaryKey(receiveDocDeleted.DeletedBy);
                    if (user.RowCount > 0)
                    {
                        lblDeletedBy.Text = string.Format("Deleted By {0}",
                                                          string.IsNullOrEmpty(user.FullName)
                                                              ? user.UserName
                                                              : user.FullName);
                    }
                }

                gridOrderDetail.DataSource = tbl;
            }
        }

     private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            FilterString = "";
            if (lkAccount.EditValue != null)
            {
                FilterString = String.Format("ActivityID = {0}", lkAccount.EditValue);
                gridOrderListView.ActiveFilterString = FilterString;
                chkActive_CheckedChanged(null, null);
            }
        }
    

    private void chkActive_CheckedChanged(object sender, EventArgs e)
    {
            FilterString = FilterString + FilterString != ""?" And ":"";
            if(chkActive.Checked)
            {
                FilterString = String.Format("[ActiveGRNF]  = [GRNF]  AND [ActiveGRV]  = [GRV] And IsDeleted = 0");
            }
            gridOrderListView.ActiveFilterString = FilterString;

    }
    }
}