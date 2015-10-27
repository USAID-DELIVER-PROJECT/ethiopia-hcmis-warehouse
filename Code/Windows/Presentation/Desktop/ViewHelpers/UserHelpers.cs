using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace HCMIS.Desktop.ViewHelpers
{
    public static class UserHelpers
    {
        #region Mode LookUpEdit Binding

        public static LookUpEdit SetupModeEditor(this LookUpEdit editor)
        {
            editor.Properties.DisplayMember = "TypeName";
            editor.Properties.NullText = "Select Mode";
            editor.Properties.ValueMember = "ID";
            editor.EditValue = null;
            editor.Properties.Columns.Clear();
            editor.Properties.Columns.AddRange(new[] { new LookUpColumnInfo("TypeName", "Name") });

            var modes = new Mode();
            modes.LoadByUser(CurrentContext.UserId);
            editor.Properties.DataSource = modes.DefaultView;
            return editor;
        }

        public static LookUpEditBase SetDefaultMode(this LookUpEditBase editor)
        {
            if (_activity == null)
            {
                _activity = new Activity();
                _activity.LoadDefaultByUser(CurrentContext.UserId);
            }

            if (_activity.RowCount > 0)
            {
                editor.EditValue = _activity.ModeID;
            }
            return editor;
        }

        #endregion

        #region Account LookUpEdit Binding

        public static GridLookUpEditBase SetupAccountEditor(this GridLookUpEditBase editor)
        {
       
            editor.Properties.DisplayMember = "AccountName";
            editor.Properties.NullText = "Select Account";
            editor.Properties.ValueMember = "AccountID";
            editor.EditValue = null;
            editor.Properties.View = InitializeAccountGridView();
            
            var accounts = new Account();
            accounts.LoadByUser(CurrentContext.UserId);
            editor.Properties.DataSource = accounts.DefaultView;
            return editor;
        }

        public static GridView InitializeAccountGridView()
        {
            var gridView = new GridView
                               {
                                   FocusRectStyle = DrawFocusRectStyle.RowFocus,
                                   GroupCount = 1,
                                   Name = "gridView"
                               };
            var colMode = new GridColumn
                              {
                                  Caption = "Mode",
                                  FieldName = "ModeName",
                                  Name = "colMode"
                              };
           
            var colAccount = new GridColumn
                                 {
                                      Caption = "Account",
                                      FieldName = "AccountName",
                                      Name = "colAccount"
                                 };
            colAccount.Visible = true;
            colAccount.VisibleIndex = 0;
            colAccount.Width = 83;

            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsView.ShowColumnHeaders = false;

            gridView.Columns.AddRange(new[] {colMode,colAccount});

            gridView.SortInfo.AddRange(new[] 
            {
                new GridColumnSortInfo(colMode, DevExpress.Data.ColumnSortOrder.Ascending),
                new GridColumnSortInfo(colAccount, DevExpress.Data.ColumnSortOrder.Ascending)
            });

            return gridView;
        }

        public static LookUpEditBase SetDefaultAccount(this LookUpEditBase editor)
        {
            if (_activity == null)
            {
                _activity = new Activity();
                _activity.LoadDefaultByUser(CurrentContext.UserId);
            }

            if (_activity.RowCount > 0)
            {
                editor.EditValue = _activity.AccountID;
            }
            return editor;
        }

        #endregion

        #region Activities LookUpEdit binding

        private static Activity _activities;
        private static Activity _activity;

        private static void BindAllowedActivities(this LookUpEditBase editor)
        {
            if (_activities == null)
            {
                _activities = new Activity();
                _activities.LoadByUserID(CurrentContext.UserId);
            }
            editor.Properties.DataSource = _activities.DefaultView;
        }

        public static BaseEdit SetDefaultActivity(this BaseEdit editor)
        {
            if (_activity == null)
            {
                _activity = new Activity();
                _activity.LoadDefaultByUser(CurrentContext.UserId);
            }

            if (_activity.RowCount > 0)
            {
                editor.EditValue = _activity.ID;
            }
            return editor;
        }

        public static LookUpEditBase SetupActivityEditor(this GridLookUpEditBase editor)
        {
            editor.Properties.DisplayMember = "FullActivityName";
            editor.Properties.NullText = "Select Activity";
            editor.Properties.ValueMember = "ActivityID";
            editor.EditValue = null;
            editor.Properties.View = InitializeActivityGridView();
            editor.BindAllowedActivities();
            return editor;
        }

        public static GridView InitializeActivityGridView()
        {
            var gridView = new GridView();
            var colId = new GridColumn();
            var colSubAccount = new GridColumn();
            var colMode = new GridColumn();
            var colAccount = new GridColumn();
            var colActivity = new GridColumn();

            gridView.Columns.AddRange(new[] {colId,
            colSubAccount,
            colMode,
            colAccount,
            colActivity});
            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView.GroupCount = 3;
            gridView.Name = "gridView";
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.SortInfo.AddRange(new[] {
            new GridColumnSortInfo(colMode, DevExpress.Data.ColumnSortOrder.Ascending),
            new GridColumnSortInfo(colAccount, DevExpress.Data.ColumnSortOrder.Ascending),
            new GridColumnSortInfo(colSubAccount, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn27
            // 
            colId.Caption = "ID";
            colId.FieldName = "ActivityID";
            colId.Name = "colID";
            // 
            // gridColumn33
            // ActivityName		AccountName		MovingAverageName	ActivityFullName

            colSubAccount.Caption = "Sub Account";
            colSubAccount.FieldName = "SubAccountName";
            colSubAccount.Name = "colSubAccount";
            colSubAccount.Visible = true;
            colSubAccount.VisibleIndex = 0;
            // 
            // gridColumn36
            // 
            colMode.Caption = "Mode";
            colMode.FieldName = "ModeName";
            colMode.Name = "colMode";
            // 
            // gridColumn37
            // 
            colAccount.Caption = "Account";
            colAccount.FieldName = "AccountName";
            colAccount.Name = "colAccount";
            // 
            // gridColumn38
            // 
            colActivity.Caption = "Activity";
            colActivity.FieldName = "ActivityName";
            colActivity.Name = "colActivity";
            colActivity.Visible = true;
            colActivity.VisibleIndex = 0;
            colActivity.Width = 83;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsView.ShowColumnHeaders = false;
            return gridView;
        }

        #endregion

        #region PhysicalStores LookUpEdit binding

        public static LookUpEditBase BindAllowedPhysicalStores(this LookUpEditBase editor)
        {
            editor.Properties.DataSource = PhysicalStore.GetAllowedPhysicalStoresForUser(CurrentContext.UserId);
            return editor;
        }

        public static BaseEdit SetDefaultPhysicalStore(this BaseEdit editor)
        {
            var defaultPhysicalStore = PhysicalStore.GetDefaultPhysicalStoreFor(CurrentContext.UserId);
            if (defaultPhysicalStore != null && defaultPhysicalStore.RowCount > 0 && !defaultPhysicalStore.IsColumnNull("ID"))
            {
                editor.EditValue = defaultPhysicalStore.ID;
            }
            return editor;
        }

        public static LookUpEditBase SetupAllowedPhysicalStores(this GridLookUpEdit editor)
        {
            editor.Properties.DisplayMember = "Name";
            editor.Properties.NullText = "Select Store";
            editor.Properties.ValueMember = "ID";
            editor.EditValue = null;
            editor.Properties.View = InitializePhysicalStoreGridView();
            editor.BindAllowedPhysicalStores();
            return editor;
        }

        private static GridView InitializePhysicalStoreGridView()
        {
            var gridView = new GridView();
            var gridColumn39 = new GridColumn();
            var gridColumn40 = new GridColumn();
            var gridColumn41 = new GridColumn();
            var gridColumn42 = new GridColumn();

            gridView.Columns.AddRange(new[]
                                          {
                                              gridColumn39,
                                              gridColumn40,
                                              gridColumn41,
                                              gridColumn42
                                          });
            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView.GroupCount = 2;
            gridView.Name = "gridView4";
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.SortInfo.AddRange(new[]
                                           {
                                               new GridColumnSortInfo(gridColumn41,
                                                                                                  DevExpress.Data.
                                                                                                      ColumnSortOrder.Ascending)
                                               ,
                                               new GridColumnSortInfo(gridColumn42,
                                                                                                  DevExpress.Data.
                                                                                                      ColumnSortOrder.Ascending)
                                           });
            // 
            // gridColumn39
            // 
            gridColumn39.Caption = "ID";
            gridColumn39.FieldName = "ID";
            gridColumn39.Name = "gridColumn39";
            // 
            // gridColumn40
            // 
            gridColumn40.Caption = "Name";
            gridColumn40.FieldName = "Name";
            gridColumn40.Name = "gridColumn40";
            gridColumn40.Visible = true;
            gridColumn40.VisibleIndex = 0;
            // 
            // gridColumn41
            // 
            gridColumn41.Caption = "Cluster";
            gridColumn41.FieldName = "Cluster";
            gridColumn41.Name = "gridColumn41";
            gridColumn41.Visible = true;
            gridColumn41.VisibleIndex = 1;
            // 
            // gridColumn42
            // 
            gridColumn42.Caption = "Warehouse";
            gridColumn42.FieldName = "Warehouse";
            gridColumn42.Name = "gridColumn42";
            gridColumn42.Visible = true;
            gridColumn42.VisibleIndex = 1;
            return gridView;
        }

        #endregion
    }
}
