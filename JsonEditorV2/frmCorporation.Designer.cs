namespace JsonEditorV2
{
    partial class frmCorporation
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
            this.lblCorporationName = new System.Windows.Forms.Label();
            this.txtCorporationName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtCorporationID = new System.Windows.Forms.TextBox();
            this.lblCorporationID = new System.Windows.Forms.Label();
            this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
            this.lblConvertTo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCorporationName
            // 
            this.lblCorporationName.AutoSize = true;
            this.lblCorporationName.Location = new System.Drawing.Point(18, 102);
            this.lblCorporationName.Name = "lblCorporationName";
            this.lblCorporationName.Size = new System.Drawing.Size(17, 15);
            this.lblCorporationName.TabIndex = 0;
            this.lblCorporationName.Text = "X";
            // 
            // txtCorporationName
            // 
            this.txtCorporationName.Location = new System.Drawing.Point(154, 97);
            this.txtCorporationName.Name = "txtCorporationName";
            this.txtCorporationName.Size = new System.Drawing.Size(144, 25);
            this.txtCorporationName.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(173, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "-";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(66, 144);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(77, 28);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "-";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Enabled = false;
            this.txtOutputFolder.Location = new System.Drawing.Point(93, 15);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(174, 25);
            this.txtOutputFolder.TabIndex = 6;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(273, 15);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 25);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtCorporationID
            // 
            this.txtCorporationID.Location = new System.Drawing.Point(178, 57);
            this.txtCorporationID.Name = "txtCorporationID";
            this.txtCorporationID.Size = new System.Drawing.Size(120, 25);
            this.txtCorporationID.TabIndex = 9;
            // 
            // lblCorporationID
            // 
            this.lblCorporationID.AutoSize = true;
            this.lblCorporationID.Location = new System.Drawing.Point(18, 62);
            this.lblCorporationID.Name = "lblCorporationID";
            this.lblCorporationID.Size = new System.Drawing.Size(17, 15);
            this.lblCorporationID.TabIndex = 8;
            this.lblCorporationID.Text = "X";
            // 
            // lblConvertTo
            // 
            this.lblConvertTo.AutoSize = true;
            this.lblConvertTo.Location = new System.Drawing.Point(18, 20);
            this.lblConvertTo.Name = "lblConvertTo";
            this.lblConvertTo.Size = new System.Drawing.Size(17, 15);
            this.lblConvertTo.TabIndex = 10;
            this.lblConvertTo.Text = "X";
            // 
            // frmCorporation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 185);
            this.Controls.Add(this.lblConvertTo);
            this.Controls.Add(this.txtCorporationID);
            this.Controls.Add(this.lblCorporationID);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtCorporationName);
            this.Controls.Add(this.lblCorporationName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCorporation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCorporationName;
        private System.Windows.Forms.TextBox txtCorporationName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtCorporationID;
        private System.Windows.Forms.Label lblCorporationID;
        private System.Windows.Forms.FolderBrowserDialog fbdMain;
        private System.Windows.Forms.Label lblConvertTo;
    }
}