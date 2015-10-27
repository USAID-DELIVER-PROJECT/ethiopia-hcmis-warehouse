namespace HCMIS.Security.UserManagement.Views
{
    partial class MenuItemsLookupView
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
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.resourceTypeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.resourceTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colText = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colURL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colToolTip = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIcon = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAllowed = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colOrdering = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.menuItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnAddNewMenuItem = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resourceTypeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnAddNewMenuItem);
            this.layoutControl1.Controls.Add(this.resourceTypeLookUpEdit);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.treeList1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(566, 131, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(596, 318);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // resourceTypeLookUpEdit
            // 
            this.resourceTypeLookUpEdit.Location = new System.Drawing.Point(119, 12);
            this.resourceTypeLookUpEdit.Name = "resourceTypeLookUpEdit";
            this.resourceTypeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.resourceTypeLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.resourceTypeLookUpEdit.Properties.DataSource = this.resourceTypesBindingSource;
            this.resourceTypeLookUpEdit.Properties.DisplayMember = "Name";
            this.resourceTypeLookUpEdit.Properties.ValueMember = "ResourceTypeID";
            this.resourceTypeLookUpEdit.Size = new System.Drawing.Size(105, 20);
            this.resourceTypeLookUpEdit.StyleController = this.layoutControl1;
            this.resourceTypeLookUpEdit.TabIndex = 6;
            this.resourceTypeLookUpEdit.EditValueChanged += new System.EventHandler(this.resourceTypeLookUpEdit_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(498, 284);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 22);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(405, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 22);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colText,
            this.colURL,
            this.colToolTip,
            this.colIcon,
            this.colAllowed,
            this.colOrdering});
            this.treeList1.DataSource = this.menuItemsBindingSource;
            this.treeList1.KeyFieldName = "MenuItemID";
            this.treeList1.Location = new System.Drawing.Point(12, 36);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsPrint.UsePrintStyles = true;
            this.treeList1.ParentFieldName = "ParentMenuItemID";
            this.treeList1.PreviewFieldName = "Text";
            this.treeList1.Size = new System.Drawing.Size(572, 244);
            this.treeList1.TabIndex = 1;
            // 
            // colText
            // 
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 0;
            this.colText.Width = 30;
            // 
            // colURL
            // 
            this.colURL.FieldName = "URL";
            this.colURL.Name = "colURL";
            this.colURL.Visible = true;
            this.colURL.VisibleIndex = 1;
            this.colURL.Width = 30;
            // 
            // colToolTip
            // 
            this.colToolTip.FieldName = "ToolTip";
            this.colToolTip.Name = "colToolTip";
            this.colToolTip.Visible = true;
            this.colToolTip.VisibleIndex = 2;
            this.colToolTip.Width = 30;
            // 
            // colIcon
            // 
            this.colIcon.FieldName = "Icon";
            this.colIcon.Name = "colIcon";
            this.colIcon.Visible = true;
            this.colIcon.VisibleIndex = 3;
            this.colIcon.Width = 30;
            // 
            // colAllowed
            // 
            this.colAllowed.FieldName = "Allowed";
            this.colAllowed.Name = "colAllowed";
            this.colAllowed.Visible = true;
            this.colAllowed.VisibleIndex = 5;
            this.colAllowed.Width = 31;
            // 
            // colOrdering
            // 
            this.colOrdering.Caption = "Order";
            this.colOrdering.FieldName = "Order";
            this.colOrdering.Name = "colOrdering";
            this.colOrdering.Visible = true;
            this.colOrdering.VisibleIndex = 4;
            this.colOrdering.Width = 50;
            // 
            // menuItemsBindingSource
            // 
            this.menuItemsBindingSource.DataSource = typeof(HCMIS.Security.UserManagement.ViewModels.MenuViewModel);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem3,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(596, 318);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.treeList1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(576, 248);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 272);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(311, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnSave;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(393, 272);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(93, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(93, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(93, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnClose;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(486, 272);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(90, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(90, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(90, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.resourceTypeLookUpEdit;
            this.layoutControlItem4.CustomizationFormText = "Select Resource Type";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(216, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(216, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(216, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Select Resource Type";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(104, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(216, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(360, 24);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnAddNewMenuItem
            // 
            this.btnAddNewMenuItem.Location = new System.Drawing.Point(323, 284);
            this.btnAddNewMenuItem.Name = "btnAddNewMenuItem";
            this.btnAddNewMenuItem.Size = new System.Drawing.Size(78, 22);
            this.btnAddNewMenuItem.StyleController = this.layoutControl1;
            this.btnAddNewMenuItem.TabIndex = 7;
            this.btnAddNewMenuItem.Text = "Add New";
            this.btnAddNewMenuItem.Click += new System.EventHandler(this.btnAddNewMenuItem_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnAddNewMenuItem;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(311, 272);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // MenuItemsLookupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 318);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuItemsLookupView";
            this.Text = "MenuItemsLookupView";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resourceTypeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colText;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colURL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colToolTip;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIcon;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAllowed;
        private System.Windows.Forms.BindingSource menuItemsBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LookUpEdit resourceTypeLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.BindingSource resourceTypesBindingSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOrdering;
        private DevExpress.XtraEditors.SimpleButton btnAddNewMenuItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}