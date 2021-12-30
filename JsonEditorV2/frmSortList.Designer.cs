namespace JsonEditorV2
{
    partial class frmSortList
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
            this.pnlSortMain = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSort_M_1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlSortMain
            // 
            this.pnlSortMain.AutoScroll = true;
            this.pnlSortMain.Location = new System.Drawing.Point(27, 61);
            this.pnlSortMain.Name = "pnlSortMain";
            this.pnlSortMain.Size = new System.Drawing.Size(737, 535);
            this.pnlSortMain.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(173, 619);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(102, 35);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "-";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(443, 619);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "-";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSort_M_1
            // 
            this.lblSort_M_1.AutoSize = true;
            this.lblSort_M_1.Location = new System.Drawing.Point(24, 21);
            this.lblSort_M_1.Name = "lblSort_M_1";
            this.lblSort_M_1.Size = new System.Drawing.Size(17, 15);
            this.lblSort_M_1.TabIndex = 3;
            this.lblSort_M_1.Text = "X";
            // 
            // frmSortList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 676);
            this.Controls.Add(this.lblSort_M_1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.pnlSortMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSortList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSortList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSortMain;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSort_M_1;
    }
}