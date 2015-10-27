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
using DevExpress.XtraEditors.Repository;

namespace HCMIS.Desktop.Forms.Modals
{
    // Declare Requisition Type
    public enum RequisitionType
    {
        Demand = 3,
        Consumption = 4,
        History = 5,
        Population = 6,
    }
    public partial class MultiFacilityRequisition : XtraForm
    {
        
        private int? orderID;
        private int facilityID;
        private int paymentType;
        private int modeID;
        private string remarks;
        private string letterNumber;
        private string contactPerson;
        private DataView _dvOrderTable ;
        private DataTable _selectedFacilities; 
        public MultiFacilityRequisition( int? orderID, int facilityID, int paymentType, int modeID, string remarks, string letterNumber, string contactPerson, DataView _dvOrderTable)
        {
            this.orderID = orderID;
            this.facilityID = facilityID;
            this.paymentType = paymentType;
            this.modeID = modeID;
            this.remarks = remarks;
            this.contactPerson = contactPerson;
            this._dvOrderTable = _dvOrderTable;
            this.letterNumber = letterNumber;
            InitializeComponent();
        }

        private void MultiFacilityRequisition_Load(object sender, EventArgs e)
        {
            BLL.Institution institution = new Institution();
            institution.LoadAll();
            institution.AddColumn("IsSelected", typeof (bool));

            // bind the selected faciliteies to the selected grid
            _selectedFacilities = institution.DefaultView.Table.Clone();
            gridSelected.DataSource = _selectedFacilities;

            // bind the source table
            gridChoices.DataSource = institution.DefaultView;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSaveAsDraft_Click(object sender, EventArgs e)
        {
            if (SaveOrderForFacilities(OrderStatus.Constant.DRAFT_WISHLIST)) return;
            DialogResult = DialogResult.OK;
        }

        private void btnSaveAndForward_Click(object sender, EventArgs e)
        {
            if (SaveOrderForFacilities(OrderStatus.Constant.ORDER_FILLED)) return;
            DialogResult = DialogResult.OK;
        }

        private bool SaveOrderForFacilities(int status)
        {
            if(_selectedFacilities.Rows.Count == 0){
              DialogResult = DialogResult.Cancel;
                return true;
            }
            foreach (var item in _selectedFacilities.Rows)
            {
                DataRow drv = (DataRow) item;
                int facility = Convert.ToInt32(drv["ID"]);
                Order.SaveOrderToDatabase(status, CurrentContext.UserId,
                                          (facility == this.facilityID) ? orderID : null,(int)RequisitionType.Demand, facility, paymentType, modeID,
                                          remarks, letterNumber, contactPerson, _dvOrderTable);
            }
            return false;
        }

        

        private void gridViewChoices_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridViewChoices.GetFocusedDataRow();
            if (dr != null)
            {
                bool b = (dr["IsSelected"] != DBNull.Value) ? Convert.ToBoolean(dr["IsSelected"]) : false;
                dr["IsSelected"] = !b;

                if (!b)
                {
                    // copy the row in the selected rows
                    _selectedFacilities.ImportRow(dr);
                    gridSelected.DataSource = _selectedFacilities;
                }
                else 
                {
                    // Remove the row from the selected rows on the right.                    
                    _selectedFacilities.PrimaryKey = new DataColumn[] { _selectedFacilities.Columns["ID"]};

                    DataRow rw = _selectedFacilities.Rows.Find(new Object[] {
                        dr["ID"]
                    });

                    if (rw != null)
                    {
                        _selectedFacilities.Rows.Remove(rw);
                    }
                }
            }
        }

        private void gridViewChoices_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridViewChoices_RowClick(null, null);
        }

        
    }
}
