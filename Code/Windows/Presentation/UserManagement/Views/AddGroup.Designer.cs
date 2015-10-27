using DevExpress.XtraEditors;

namespace HCMIS.Security.UserManagement.Views
{
    partial class AddGroup
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
            this.grouplistbox = new ListBoxControl();
            this.grouplistbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSaveGroup = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnAddClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.usergroupbindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grouplistbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usergroupbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grouplistbox
            // 
            this.grouplistbox.DataSource = this.grouplistbindingSource;
            this.grouplistbox.DisplayMember = "Name";
            this.grouplistbox.Location = new System.Drawing.Point(12, 28);
            this.grouplistbox.Name = "grouplistbox";
            this.grouplistbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.grouplistbox.Size = new System.Drawing.Size(288, 199);
            this.grouplistbox.TabIndex = 0;
            this.grouplistbox.ValueMember = "GroupID";
            // 
            // grouplistbindingSource
            // 
            this.grouplistbindingSource.DataSource = typeof(HCMIS.Security.Models.Group);
            // 
            // btnSaveGroup
            // 
            this.btnSaveGroup.Image = global::HCMIS.Security.UserManagement.Properties.Resources.Add_16x16;
            this.btnSaveGroup.Location = new System.Drawing.Point(124, 242);
            this.btnSaveGroup.Name = "btnSaveGroup";
            this.btnSaveGroup.Size = new System.Drawing.Size(85, 22);
            this.btnSaveGroup.StyleController = this.layoutControl1;
            this.btnSaveGroup.TabIndex = 2;
            this.btnSaveGroup.Text = "Add";
            this.btnSaveGroup.Click += new System.EventHandler(this.BtnSaveGroupClick);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSaveGroup);
            this.layoutControl1.Controls.Add(this.grouplistbox);
            this.layoutControl1.Controls.Add(this.btnAddClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(343, 60, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(312, 276);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnAddClose
            // 
            this.btnAddClose.Image = global::HCMIS.Security.UserManagement.Properties.Resources.CloseButton;
            this.btnAddClose.Location = new System.Drawing.Point(213, 242);
            this.btnAddClose.Name = "btnAddClose";
            this.btnAddClose.Size = new System.Drawing.Size(87, 22);
            this.btnAddClose.StyleController = this.layoutControl1;
            this.btnAddClose.TabIndex = 3;
            this.btnAddClose.Text = "Close";
            this.btnAddClose.Click += new System.EventHandler(this.btnAddClose_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(312, 276);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grouplistbox;
            this.layoutControlItem1.CustomizationFormText = "Select Group:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(292, 230);
            this.layoutControlItem1.Text = "Select Group:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(65, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnSaveGroup;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(112, 230);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(53, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnAddClose;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(201, 230);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(59, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(91, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 230);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(112, 26);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(112, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(112, 26);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // usergroupbindingSource
            // 
            this.usergroupbindingSource.DataSource = typeof(HCMIS.Security.Models.UserGroup);
            // 
            // NewGroupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 276);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGroupView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Group";
            this.Load += new System.EventHandler(this.NewGroupView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grouplistbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usergroupbindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBoxControl grouplistbox;
        private DevExpress.XtraEditors.SimpleButton btnSaveGroup;
        private DevExpress.XtraEditors.SimpleButton btnAddClose;
        private System.Windows.Forms.BindingSource grouplistbindingSource;
        private System.Windows.Forms.BindingSource usergroupbindingSource;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}