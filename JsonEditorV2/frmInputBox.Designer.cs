namespace JsonEditorV2
{
    partial class frmInputBox
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
            this.lblDescirption = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblExtensionName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDescirption
            // 
            this.lblDescirption.AutoSize = true;
            this.lblDescirption.Location = new System.Drawing.Point(12, 9);
            this.lblDescirption.Name = "lblDescirption";
            this.lblDescirption.Size = new System.Drawing.Size(13, 17);
            this.lblDescirption.TabIndex = 0;
            this.lblDescirption.Text = "-";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(120, 8);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(135, 22);
            this.txtInput.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(315, 6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(77, 27);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "-";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(398, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "-";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblExtensionName
            // 
            this.lblExtensionName.AutoSize = true;
            this.lblExtensionName.Location = new System.Drawing.Point(261, 11);
            this.lblExtensionName.Name = "lblExtensionName";
            this.lblExtensionName.Size = new System.Drawing.Size(38, 17);
            this.lblExtensionName.TabIndex = 4;
            this.lblExtensionName.Text = ".json";
            // 
            // frmInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 39);
            this.Controls.Add(this.lblExtensionName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblDescirption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "-";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescirption;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblExtensionName;
    }
}