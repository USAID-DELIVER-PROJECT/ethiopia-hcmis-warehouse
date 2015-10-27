using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class ReceivingUnitIssueHistory : Form
    {
        private int receivingUnitID;
        private string receivingUnitName;

        public ReceivingUnitIssueHistory(int recUnitID)
        {
            InitializeComponent();
            receivingUnitID = recUnitID;
        }

        private string ReceivingUnitName
        {
            get
            {
                if (receivingUnitName == null)
                {
                    BLL.Institution recU = new BLL.Institution();
                    recU.LoadByPrimaryKey(receivingUnitID);
                    if (recU.RowCount > 0 && !recU.IsColumnNull("Name"))
                        receivingUnitName = recU.Name;
                }
                return receivingUnitName;
            }
        }

        private void ReceivingUnitIssueHistory_Load(object sender, EventArgs e)
        {
            lblFacilityName.Text = ReceivingUnitName;
            grdIssueHistory.DataSource = BLL.IssueDoc.GetIssueHistoryForFacility(receivingUnitID, EthiopianDate.EthiopianDate.Now.StartOfFiscalYear.ToGregorianDate(), DateTimeHelper.ServerDateTime);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            grdIssueHistory.Print();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                grdIssueHistory.ExportToXlsx(sfd.FileName + ".xlsx");
            }
        }

        
    }
}
