using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Helpers;

namespace HCMIS.Desktop.Forms.Controls
{
    public partial class ModeActivityTree : XtraUserControl
    {

        #region Proprties
       
            private string _SelectedID;
        
            public string SelectedID
            {
                get { return _SelectedID; }
                set { _SelectedID = value; }
            }

            public int? EditValue { get; set; }
            public string SelectedType { get; set; }
        #endregion

        #region Event Handlers

        private EventHandler _SomeEvent;
        public event EventHandler OnSelectionChanged
        {
            add
            {
                _SomeEvent += value;
            }
            remove
            {
                _SomeEvent -= value;
            }
        }
        #endregion

        public ModeActivityTree()
        {
            InitializeComponent();
            lkAccounts.EditValueChanged += new EventHandler(lkAccounts_EditValueChanged);
            
        }

        void lkAccounts_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView o = (DataRowView)accountTree.GetDataRecordByNode(accountTree.FocusedNode);
            if (o != null)
            {
                lkAccounts.Text = o["Name"].ToString();
                lkAccounts.ClosePopup();
                EditValue = Convert.ToInt32(o["ID"]);

                SelectedType = o["Type"].ToString();

                if (_SomeEvent != null)
                {
                    _SomeEvent.Invoke(this, null);
                }
                lkAccounts.ClosePopup();
                //lkAccounts.CancelPopup();
                
            }
            
        }

        public void LoadControl()
        {
            if (!DesignMode)
            {

                DataView dataView = Activity.GetAccountTree(CurrentContext.UserId);
                accountTree.DataSource = dataView;
                // select the first entry in the tree as a default selection
                DataRowView firstRow = dataView[0];
                lkAccounts.Text = firstRow["Name"].ToString();
                EditValue = Convert.ToInt32(firstRow["ID"]);
                SelectedType = firstRow["Type"].ToString();

                // Raise the seletion changed 

                //if (_SomeEvent != null)
                //{
                //    _SomeEvent.Invoke(this, null);
                //}

                // Now do the opening ... the list to the 3rd level.
                TreeListOperationCollapseExpandToLevel op = new TreeListOperationCollapseExpandToLevel(true, 3);
                accountTree.NodesIterator.DoOperation(op);
            }
        }

        private void accountTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

            DataRowView o = (DataRowView)accountTree.GetDataRecordByNode(accountTree.FocusedNode);
            lkAccounts.Text = o["Name"].ToString();


            lkAccounts.ClosePopup();

            if (EditValue != Convert.ToInt32(o["ID"]))
            {
                lkAccounts_EditValueChanged(null,null);
            }
        }

        private void accountTree_SelectionChanged(object sender, EventArgs e)
        {
            if (accountTree.Selection.Count > 0)
            {
                DataRowView o = (DataRowView)accountTree.GetDataRecordByNode(accountTree.Selection[0]);
                lkAccounts.EditValue = o["TextID"];

                lkAccounts_EditValueChanged(null, null);
            }
           
        }
    }
}
