namespace HCMIS.Security.UserManagement.Views
{
    partial class CreateUserView
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label userNameLabel;
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            this.jobtitlebindingSource = new System.Windows.Forms.BindingSource();
            this.departmentbindingSource = new System.Windows.Forms.BindingSource();
            this.departmentlookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.userBindingSource = new System.Windows.Forms.BindingSource();
            this.expirationdateEdit = new DevExpress.XtraEditors.DateEdit();
            this.jobtitlelookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.lastNametextEdit = new DevExpress.XtraEditors.TextEdit();
            this.createCommand = new DevExpress.XtraEditors.SimpleButton();
            this.closeCommand = new DevExpress.XtraEditors.SimpleButton();
            this.passwordTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.firstNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.userNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NewUserValidation = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            userNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobtitlebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentlookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expirationdateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expirationdateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobtitlelookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastNametextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewUserValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 110);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(68, 13);
            label5.TabIndex = 58;
            label5.Text = "Department:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 158);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 13);
            label4.TabIndex = 57;
            label4.Text = "Expiration Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 133);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 13);
            label2.TabIndex = 56;
            label2.Text = "Job Title:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 61);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 13);
            label1.TabIndex = 55;
            label1.Text = "Last Name";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(12, 88);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(57, 13);
            passwordLabel.TabIndex = 49;
            passwordLabel.Text = "Password:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(12, 35);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(62, 13);
            fullNameLabel.TabIndex = 45;
            fullNameLabel.Text = "First Name:";
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new System.Drawing.Point(12, 9);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new System.Drawing.Size(63, 13);
            userNameLabel.TabIndex = 42;
            userNameLabel.Text = "User Name:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // jobtitlebindingSource
            // 
            this.jobtitlebindingSource.DataSource = typeof(HCMIS.Security.Models.JobTitle);
            // 
            // departmentbindingSource
            // 
            this.departmentbindingSource.DataSource = typeof(HCMIS.Security.Models.Department);
            // 
            // departmentlookUpEdit
            // 
            this.departmentlookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "DepartmentID", true));
            this.departmentlookUpEdit.Location = new System.Drawing.Point(81, 107);
            this.departmentlookUpEdit.Name = "departmentlookUpEdit";
            this.departmentlookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.departmentlookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.departmentlookUpEdit.Properties.DataSource = this.departmentbindingSource;
            this.departmentlookUpEdit.Properties.DisplayMember = "Name";
            this.departmentlookUpEdit.Properties.NullText = "[Select Department]";
            this.departmentlookUpEdit.Properties.ValueMember = "DepartmentID";
            this.departmentlookUpEdit.Size = new System.Drawing.Size(177, 20);
            this.departmentlookUpEdit.TabIndex = 48;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(HCMIS.Security.Models.User);
            // 
            // expirationdateEdit
            // 
            this.expirationdateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "ExpirationDate", true));
            this.expirationdateEdit.EditValue = null;
            this.expirationdateEdit.Location = new System.Drawing.Point(103, 156);
            this.expirationdateEdit.Name = "expirationdateEdit";
            this.expirationdateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.expirationdateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.expirationdateEdit.Size = new System.Drawing.Size(155, 20);
            this.expirationdateEdit.TabIndex = 51;
            // 
            // jobtitlelookUpEdit
            // 
            this.jobtitlelookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "JobTitleID", true));
            this.jobtitlelookUpEdit.Location = new System.Drawing.Point(81, 130);
            this.jobtitlelookUpEdit.Name = "jobtitlelookUpEdit";
            this.jobtitlelookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.jobtitlelookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Title", "Job Title")});
            this.jobtitlelookUpEdit.Properties.DataSource = this.jobtitlebindingSource;
            this.jobtitlelookUpEdit.Properties.DisplayMember = "Title";
            this.jobtitlelookUpEdit.Properties.NullText = "[Select Job Title]";
            this.jobtitlelookUpEdit.Properties.ValueMember = "JobTitleID";
            this.jobtitlelookUpEdit.Size = new System.Drawing.Size(177, 20);
            this.jobtitlelookUpEdit.TabIndex = 50;
            // 
            // lastNametextEdit
            // 
            this.lastNametextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "LastName", true));
            this.lastNametextEdit.Location = new System.Drawing.Point(81, 58);
            this.lastNametextEdit.Name = "lastNametextEdit";
            this.lastNametextEdit.Size = new System.Drawing.Size(177, 20);
            this.lastNametextEdit.TabIndex = 46;
            // 
            // createCommand
            // 
            this.createCommand.Location = new System.Drawing.Point(49, 187);
            this.createCommand.Name = "createCommand";
            this.createCommand.Size = new System.Drawing.Size(75, 23);
            this.createCommand.TabIndex = 53;
            this.createCommand.Text = "Create";
            this.createCommand.Click += new System.EventHandler(this.createCommand_Click);
            // 
            // closeCommand
            // 
            this.closeCommand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeCommand.Location = new System.Drawing.Point(139, 187);
            this.closeCommand.Name = "closeCommand";
            this.closeCommand.Size = new System.Drawing.Size(75, 23);
            this.closeCommand.TabIndex = 54;
            this.closeCommand.Text = "Close";
            this.closeCommand.Click += new System.EventHandler(this.closeCommand_Click);
            // 
            // passwordTextEdit
            // 
            this.passwordTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "Password", true));
            this.passwordTextEdit.Location = new System.Drawing.Point(81, 85);
            this.passwordTextEdit.Name = "passwordTextEdit";
            this.passwordTextEdit.Properties.PasswordChar = '*';
            this.passwordTextEdit.Size = new System.Drawing.Size(177, 20);
            this.passwordTextEdit.TabIndex = 47;
            // 
            // firstNameTextEdit
            // 
            this.firstNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "FirstName", true));
            this.firstNameTextEdit.Location = new System.Drawing.Point(81, 32);
            this.firstNameTextEdit.Name = "firstNameTextEdit";
            this.firstNameTextEdit.Size = new System.Drawing.Size(177, 20);
            this.firstNameTextEdit.TabIndex = 44;
            // 
            // userNameTextEdit
            // 
            this.userNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "Username", true));
            this.userNameTextEdit.Location = new System.Drawing.Point(81, 6);
            this.userNameTextEdit.Name = "userNameTextEdit";
            this.userNameTextEdit.Size = new System.Drawing.Size(177, 20);
            this.userNameTextEdit.TabIndex = 43;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.NewUserValidation.SetValidationRule(this.userNameTextEdit, conditionValidationRule1);
            // 
            // CreateUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 216);
            this.Controls.Add(label5);
            this.Controls.Add(this.departmentlookUpEdit);
            this.Controls.Add(this.expirationdateEdit);
            this.Controls.Add(label4);
            this.Controls.Add(label2);
            this.Controls.Add(this.jobtitlelookUpEdit);
            this.Controls.Add(label1);
            this.Controls.Add(this.lastNametextEdit);
            this.Controls.Add(this.createCommand);
            this.Controls.Add(this.closeCommand);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(this.passwordTextEdit);
            this.Controls.Add(fullNameLabel);
            this.Controls.Add(this.firstNameTextEdit);
            this.Controls.Add(userNameLabel);
            this.Controls.Add(this.userNameTextEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateUserView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Information";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobtitlebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentlookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expirationdateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expirationdateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobtitlelookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastNametextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewUserValidation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource departmentbindingSource;
        private System.Windows.Forms.BindingSource jobtitlebindingSource;
        private DevExpress.XtraEditors.LookUpEdit departmentlookUpEdit;
        private DevExpress.XtraEditors.DateEdit expirationdateEdit;
        private DevExpress.XtraEditors.LookUpEdit jobtitlelookUpEdit;
        private DevExpress.XtraEditors.TextEdit lastNametextEdit;
        private DevExpress.XtraEditors.SimpleButton createCommand;
        private DevExpress.XtraEditors.SimpleButton closeCommand;
        private DevExpress.XtraEditors.TextEdit passwordTextEdit;
        private DevExpress.XtraEditors.TextEdit firstNameTextEdit;
        private DevExpress.XtraEditors.TextEdit userNameTextEdit;
        private System.Windows.Forms.BindingSource userBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider NewUserValidation;
    }
}