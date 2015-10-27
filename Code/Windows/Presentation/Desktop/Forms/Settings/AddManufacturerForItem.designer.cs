using DevExpress.XtraEditors;
namespace HCMIS.Desktop.Dialogs
{
    partial class AddManufacturerForItem
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
            this.lstAddManufacturers = new System.Windows.Forms.ListBox();
            this.btnActualAddManufacturer = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelManufacturer = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lstAddManufacturers
            // 
            this.lstAddManufacturers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAddManufacturers.DisplayMember = "Name";
            this.lstAddManufacturers.FormattingEnabled = true;
            this.lstAddManufacturers.Location = new System.Drawing.Point(12, 12);
            this.lstAddManufacturers.Name = "lstAddManufacturers";
            this.lstAddManufacturers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAddManufacturers.Size = new System.Drawing.Size(322, 225);
            this.lstAddManufacturers.TabIndex = 0;
            this.lstAddManufacturers.ValueMember = "ID";
            this.lstAddManufacturers.SelectedValueChanged += new System.EventHandler(this.lstAddManufacturers_SelectedValueChanged);
            // 
            // btnActualAddManufacturer
            // 
            this.btnActualAddManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualAddManufacturer.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualAddManufacturer.Appearance.Options.UseFont = true;
            this.btnActualAddManufacturer.Image = global::HCMIS.Desktop.Properties.Resources.add_16;
            this.btnActualAddManufacturer.Location = new System.Drawing.Point(154, 241);
            this.btnActualAddManufacturer.Name = "btnActualAddManufacturer";
            this.btnActualAddManufacturer.Size = new System.Drawing.Size(87, 23);
            this.btnActualAddManufacturer.TabIndex = 10;
            this.btnActualAddManufacturer.Text = "Add";
            this.btnActualAddManufacturer.Click += new System.EventHandler(this.btnActualAddManufacturer_Click);
            // 
            // btnCancelManufacturer
            // 
            this.btnCancelManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelManufacturer.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelManufacturer.Appearance.Options.UseFont = true;
            this.btnCancelManufacturer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelManufacturer.Image = global::HCMIS.Desktop.Properties.Resources.cross;
            this.btnCancelManufacturer.Location = new System.Drawing.Point(247, 241);
            this.btnCancelManufacturer.Name = "btnCancelManufacturer";
            this.btnCancelManufacturer.Size = new System.Drawing.Size(87, 23);
            this.btnCancelManufacturer.TabIndex = 11;
            this.btnCancelManufacturer.Text = "Cancel";
            // 
            // AddManufacturerForItem
            // 
            this.AcceptButton = this.btnActualAddManufacturer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelManufacturer;
            this.ClientSize = new System.Drawing.Size(346, 276);
            this.Controls.Add(this.btnCancelManufacturer);
            this.Controls.Add(this.btnActualAddManufacturer);
            this.Controls.Add(this.lstAddManufacturers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddManufacturerForItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Manufacturer";
            this.Load += new System.EventHandler(this.AddManufacturerForItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButton btnCancelManufacturer;
        private SimpleButton btnActualAddManufacturer;
        private System.Windows.Forms.ListBox lstAddManufacturers;
    }
}