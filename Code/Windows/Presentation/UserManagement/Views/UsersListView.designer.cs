namespace HCMIS.Security.UserManagement.Views
{
    partial class UsersListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usersbindingSource = new System.Windows.Forms.BindingSource();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridSplitContainer1 = new DevExpress.XtraGrid.GridSplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridUserListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colConsolidate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repConsolidate = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDelete = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastLogin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowedAccounts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowedStores = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowedGroups = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddNewUser = new DevExpress.XtraEditors.SimpleButton();
            this.brnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.txtFilterUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.usersbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).BeginInit();
            this.gridSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUserListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repConsolidate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // usersbindingSource
            // 
            this.usersbindingSource.DataSource = typeof(HCMIS.Security.UserManagement.ViewModels.UserViewModel);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridSplitContainer1);
            this.layoutControl1.Controls.Add(this.btnAddNewUser);
            this.layoutControl1.Controls.Add(this.brnRefresh);
            this.layoutControl1.Controls.Add(this.txtFilterUserName);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(284, 175, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1035, 544);
            this.layoutControl1.TabIndex = 9;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridSplitContainer1
            // 
            this.gridSplitContainer1.Grid = this.gridControl1;
            this.gridSplitContainer1.Location = new System.Drawing.Point(12, 38);
            this.gridSplitContainer1.Name = "gridSplitContainer1";
            this.gridSplitContainer1.Panel1.Controls.Add(this.gridControl1);
            this.gridSplitContainer1.Size = new System.Drawing.Size(1011, 468);
            this.gridSplitContainer1.TabIndex = 17;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.usersbindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridUserListView;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repDelete,
            this.repConsolidate});
            this.gridControl1.Size = new System.Drawing.Size(1011, 468);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridUserListView});
            // 
            // gridUserListView
            // 
            this.gridUserListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colConsolidate,
            this.colDelete,
            this.gridColumn1,
            this.colUsername,
            this.colFirstName,
            this.colLastName,
            this.colIsActive,
            this.colLastLogin,
            this.colAllowedAccounts,
            this.colAllowedStores,
            this.colAllowedGroups,
            this.gridColumn2});
            this.gridUserListView.GridControl = this.gridControl1;
            this.gridUserListView.Name = "gridUserListView";
            this.gridUserListView.OptionsView.ShowAutoFilterRow = true;
            this.gridUserListView.OptionsView.ShowGroupPanel = false;
            // 
            // colConsolidate
            // 
            this.colConsolidate.Caption = "Consolidate";
            this.colConsolidate.ColumnEdit = this.repConsolidate;
            this.colConsolidate.Name = "colConsolidate";
            this.colConsolidate.Width = 50;
            // 
            // repConsolidate
            // 
            this.repConsolidate.AutoHeight = false;
            this.repConsolidate.Caption = "Consolidate";
            this.repConsolidate.Name = "repConsolidate";
            this.repConsolidate.NullText = "Consolidate";
            this.repConsolidate.NullValuePrompt = "Consolidate";
            this.repConsolidate.Click += new System.EventHandler(this.repConsolidate_Click);
            // 
            // colDelete
            // 
            this.colDelete.Caption = "Delete";
            this.colDelete.ColumnEdit = this.repDelete;
            this.colDelete.Name = "colDelete";
            this.colDelete.Width = 50;
            // 
            // repDelete
            // 
            this.repDelete.AutoHeight = false;
            this.repDelete.Caption = "Delete";
            this.repDelete.Name = "repDelete";
            this.repDelete.NullText = "Delete";
            this.repDelete.NullValuePrompt = "Delete";
            this.repDelete.Click += new System.EventHandler(this.repDelete_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.Caption = "Action";
            this.gridColumn1.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn1.FieldName = "UserID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 50;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemHyperLinkEdit1.Caption = "View Detail";
            this.repositoryItemHyperLinkEdit1.HideSelection = false;
            this.repositoryItemHyperLinkEdit1.ImageAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.repositoryItemHyperLinkEdit1.LinkColor = System.Drawing.Color.Blue;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.SingleClick = true;
            this.repositoryItemHyperLinkEdit1.StartKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
            // 
            // colUsername
            // 
            this.colUsername.Caption = "User Name";
            this.colUsername.FieldName = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.OptionsColumn.AllowEdit = false;
            this.colUsername.Visible = true;
            this.colUsername.VisibleIndex = 1;
            this.colUsername.Width = 137;
            // 
            // colFirstName
            // 
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.OptionsColumn.AllowEdit = false;
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 2;
            this.colFirstName.Width = 137;
            // 
            // colLastName
            // 
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.OptionsColumn.AllowEdit = false;
            this.colLastName.OptionsFilter.AllowAutoFilter = false;
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 3;
            this.colLastName.Width = 137;
            // 
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.OptionsColumn.AllowEdit = false;
            this.colIsActive.OptionsFilter.AllowAutoFilter = false;
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 4;
            this.colIsActive.Width = 137;
            // 
            // colLastLogin
            // 
            this.colLastLogin.DisplayFormat.FormatString = "dd-MMM-yyyy hh:MM ss tt";
            this.colLastLogin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastLogin.FieldName = "LastLogin";
            this.colLastLogin.Name = "colLastLogin";
            this.colLastLogin.OptionsColumn.AllowEdit = false;
            this.colLastLogin.OptionsFilter.AllowAutoFilter = false;
            this.colLastLogin.Visible = true;
            this.colLastLogin.VisibleIndex = 6;
            this.colLastLogin.Width = 158;
            // 
            // colAllowedAccounts
            // 
            this.colAllowedAccounts.AppearanceCell.Options.UseTextOptions = true;
            this.colAllowedAccounts.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAllowedAccounts.FieldName = "AllowedAccounts";
            this.colAllowedAccounts.Name = "colAllowedAccounts";
            this.colAllowedAccounts.OptionsColumn.AllowEdit = false;
            this.colAllowedAccounts.OptionsColumn.ReadOnly = true;
            this.colAllowedAccounts.OptionsFilter.AllowAutoFilter = false;
            // 
            // colAllowedStores
            // 
            this.colAllowedStores.AppearanceCell.Options.UseTextOptions = true;
            this.colAllowedStores.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAllowedStores.FieldName = "AllowedStores";
            this.colAllowedStores.Name = "colAllowedStores";
            this.colAllowedStores.OptionsColumn.AllowEdit = false;
            this.colAllowedStores.OptionsColumn.ReadOnly = true;
            this.colAllowedStores.OptionsFilter.AllowAutoFilter = false;
            // 
            // colAllowedGroups
            // 
            this.colAllowedGroups.AppearanceCell.Options.UseTextOptions = true;
            this.colAllowedGroups.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAllowedGroups.FieldName = "AllowedGroups";
            this.colAllowedGroups.Name = "colAllowedGroups";
            this.colAllowedGroups.OptionsColumn.AllowEdit = false;
            this.colAllowedGroups.OptionsColumn.ReadOnly = true;
            this.colAllowedGroups.OptionsFilter.AllowAutoFilter = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Created Date";
            this.gridColumn2.DisplayFormat.FormatString = "d";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "CreatedDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 137;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Image = global::HCMIS.Security.UserManagement.Properties.Resources.AddNewTab;
            this.btnAddNewUser.Location = new System.Drawing.Point(874, 510);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(77, 22);
            this.btnAddNewUser.StyleController = this.layoutControl1;
            this.btnAddNewUser.TabIndex = 7;
            this.btnAddNewUser.Text = "Add User ";
            this.btnAddNewUser.Click += new System.EventHandler(this.BtnAddNewUserClick);
            // 
            // brnRefresh
            // 
            this.brnRefresh.Image = global::HCMIS.Security.UserManagement.Properties.Resources.Refresh_16x16;
            this.brnRefresh.Location = new System.Drawing.Point(955, 510);
            this.brnRefresh.Name = "brnRefresh";
            this.brnRefresh.Size = new System.Drawing.Size(68, 22);
            this.brnRefresh.StyleController = this.layoutControl1;
            this.brnRefresh.TabIndex = 8;
            this.brnRefresh.Text = "Refresh";
            this.brnRefresh.Click += new System.EventHandler(this.BrnRefreshClick);
            // 
            // txtFilterUserName
            // 
            this.txtFilterUserName.EditValue = global::HCMIS.Security.UserManagement.Properties.Resources.SUCCESS_MESSAGE;
            this.txtFilterUserName.Location = new System.Drawing.Point(185, 12);
            this.txtFilterUserName.Name = "txtFilterUserName";
            this.txtFilterUserName.Properties.NullText = "Username ,FirstName";
            this.txtFilterUserName.Properties.ValidateOnEnterKey = true;
            this.txtFilterUserName.Size = new System.Drawing.Size(230, 20);
            this.txtFilterUserName.StyleController = this.layoutControl1;
            this.txtFilterUserName.TabIndex = 10;
            this.txtFilterUserName.EditValueChanged += new System.EventHandler(this.txtFilterUserName_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Search ";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.labelControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(10, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(40, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem3,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.emptySpaceItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1035, 544);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridSplitContainer1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(50, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1015, 472);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(407, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(608, 26);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtFilterUserName;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(407, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(407, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(407, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Search By User Name or First Name";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(170, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnAddNewUser;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(862, 498);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(81, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(81, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(81, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.brnRefresh;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(943, 498);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(72, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(72, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(72, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(181, 498);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(681, 26);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 498);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(181, 26);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // UsersListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 544);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UsersListView";
            this.Text = "Users";
            ((System.ComponentModel.ISupportInitialize)(this.usersbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).EndInit();
            this.gridSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUserListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repConsolidate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource usersbindingSource;
        private DevExpress.XtraEditors.SimpleButton btnAddNewUser;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridUserListView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton brnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.TextEdit txtFilterUserName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colLastLogin;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowedAccounts;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowedStores;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowedGroups;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colConsolidate;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repConsolidate;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repDelete;
    }
}