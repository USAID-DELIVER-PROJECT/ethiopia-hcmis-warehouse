namespace HCMIS.Desktop.Forms.Controls
{
    partial class ModeActivityTree
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lkAccounts = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.accountTree = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccounts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountTree)).BeginInit();
            this.SuspendLayout();
            // 
            // lkAccounts
            // 
            this.lkAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lkAccounts.Location = new System.Drawing.Point(0, 0);
            this.lkAccounts.Name = "lkAccounts";
            this.lkAccounts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkAccounts.Properties.HideSelection = false;
            this.lkAccounts.Properties.PopupControl = this.popupContainerControl1;
            this.lkAccounts.Properties.ShowPopupCloseButton = false;
            this.lkAccounts.Size = new System.Drawing.Size(211, 20);
            this.lkAccounts.TabIndex = 62;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.accountTree);
            this.popupContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(352, 253);
            this.popupContainerControl1.TabIndex = 63;
            // 
            // accountTree
            // 
            this.accountTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName});
            this.accountTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountTree.KeyFieldName = "TextID";
            this.accountTree.Location = new System.Drawing.Point(0, 0);
            this.accountTree.Name = "accountTree";
            this.accountTree.PreviewFieldName = "Name";
            this.accountTree.Size = new System.Drawing.Size(352, 253);
            this.accountTree.TabIndex = 0;
            this.accountTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.accountTree_FocusedNodeChanged);
            this.accountTree.SelectionChanged += new System.EventHandler(this.accountTree_SelectionChanged);
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // ModeActivityTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.lkAccounts);
            this.Name = "ModeActivityTree";
            this.Size = new System.Drawing.Size(211, 178);
            ((System.ComponentModel.ISupportInitialize)(this.lkAccounts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accountTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerEdit lkAccounts;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraTreeList.TreeList accountTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
    }
}
