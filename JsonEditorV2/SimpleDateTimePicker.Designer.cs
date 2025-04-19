namespace JsonEditorV2
{
    partial class SimpleDateTimePicker
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
            this.lblDot = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.dud100Year = new System.Windows.Forms.DomainUpDown();
            this.cobYear = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblMinute = new System.Windows.Forms.Label();
            this.cobMonth = new System.Windows.Forms.ComboBox();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.cobDay = new System.Windows.Forms.ComboBox();
            this.cobHour = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cobMinute = new System.Windows.Forms.ComboBox();
            this.txtDecimalSecond = new System.Windows.Forms.TextBox();
            this.cobSecond = new System.Windows.Forms.ComboBox();
            this.cobSign = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblDot
            // 
            this.lblDot.AutoSize = true;
            this.lblDot.Location = new System.Drawing.Point(295, 48);
            this.lblDot.Name = "lblDot";
            this.lblDot.Size = new System.Drawing.Size(11, 15);
            this.lblDot.TabIndex = 14;
            this.lblDot.Text = ".";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(406, 47);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(12, 15);
            this.lblSecond.TabIndex = 13;
            this.lblSecond.Text = "-";
            // 
            // dud100Year
            // 
            this.dud100Year.Location = new System.Drawing.Point(68, 12);
            this.dud100Year.Name = "dud100Year";
            this.dud100Year.ReadOnly = true;
            this.dud100Year.Size = new System.Drawing.Size(53, 25);
            this.dud100Year.TabIndex = 0;
            this.dud100Year.Text = "00";
            this.dud100Year.SelectedItemChanged += new System.EventHandler(this.dud100Year_SelectedItemChanged);
            // 
            // cobYear
            // 
            this.cobYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobYear.Enabled = false;
            this.cobYear.FormattingEnabled = true;
            this.cobYear.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cobYear.Location = new System.Drawing.Point(127, 10);
            this.cobYear.Name = "cobYear";
            this.cobYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cobYear.Size = new System.Drawing.Size(45, 23);
            this.cobYear.TabIndex = 1;
            this.cobYear.SelectedIndexChanged += new System.EventHandler(this.cobYear_SelectedIndexChanged);
            this.cobYear.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cobYear_Format);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(286, 14);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(12, 15);
            this.lblMonth.TabIndex = 2;
            this.lblMonth.Text = "-";
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.Location = new System.Drawing.Point(172, 48);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(12, 15);
            this.lblMinute.TabIndex = 12;
            this.lblMinute.Text = "-";
            // 
            // cobMonth
            // 
            this.cobMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobMonth.Enabled = false;
            this.cobMonth.FormattingEnabled = true;
            this.cobMonth.Location = new System.Drawing.Point(235, 10);
            this.cobMonth.Name = "cobMonth";
            this.cobMonth.Size = new System.Drawing.Size(45, 23);
            this.cobMonth.TabIndex = 3;
            this.cobMonth.SelectedIndexChanged += new System.EventHandler(this.cobMonth_SelectedIndexChanged);
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Location = new System.Drawing.Point(62, 48);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(12, 15);
            this.lblHour.TabIndex = 11;
            this.lblHour.Text = "-";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(406, 14);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(12, 15);
            this.lblDay.TabIndex = 4;
            this.lblDay.Text = "-";
            // 
            // cobDay
            // 
            this.cobDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobDay.Enabled = false;
            this.cobDay.FormattingEnabled = true;
            this.cobDay.Location = new System.Drawing.Point(352, 10);
            this.cobDay.Name = "cobDay";
            this.cobDay.Size = new System.Drawing.Size(45, 23);
            this.cobDay.TabIndex = 10;
            this.cobDay.SelectedIndexChanged += new System.EventHandler(this.cobDay_SelectedIndexChanged);
            // 
            // cobHour
            // 
            this.cobHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobHour.Enabled = false;
            this.cobHour.FormattingEnabled = true;
            this.cobHour.Location = new System.Drawing.Point(10, 44);
            this.cobHour.Name = "cobHour";
            this.cobHour.Size = new System.Drawing.Size(45, 23);
            this.cobHour.TabIndex = 5;
            this.cobHour.SelectedIndexChanged += new System.EventHandler(this.cobHour_SelectedIndexChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(178, 14);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(12, 15);
            this.lblYear.TabIndex = 9;
            this.lblYear.Text = "-";
            // 
            // cobMinute
            // 
            this.cobMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobMinute.Enabled = false;
            this.cobMinute.FormattingEnabled = true;
            this.cobMinute.Location = new System.Drawing.Point(120, 44);
            this.cobMinute.Name = "cobMinute";
            this.cobMinute.Size = new System.Drawing.Size(45, 23);
            this.cobMinute.TabIndex = 6;
            this.cobMinute.SelectedIndexChanged += new System.EventHandler(this.cobMinute_SelectedIndexChanged);
            // 
            // txtDecimalSecond
            // 
            this.txtDecimalSecond.Enabled = false;
            this.txtDecimalSecond.Location = new System.Drawing.Point(308, 44);
            this.txtDecimalSecond.MaxLength = 7;
            this.txtDecimalSecond.Name = "txtDecimalSecond";
            this.txtDecimalSecond.Size = new System.Drawing.Size(89, 25);
            this.txtDecimalSecond.TabIndex = 8;
            this.txtDecimalSecond.Click += new System.EventHandler(this.txtDecimalSecond_Click);
            this.txtDecimalSecond.TextChanged += new System.EventHandler(this.txtDecimalSecond_TextChanged);
            // 
            // cobSecond
            // 
            this.cobSecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSecond.Enabled = false;
            this.cobSecond.FormattingEnabled = true;
            this.cobSecond.Location = new System.Drawing.Point(249, 44);
            this.cobSecond.Name = "cobSecond";
            this.cobSecond.Size = new System.Drawing.Size(45, 23);
            this.cobSecond.TabIndex = 7;
            this.cobSecond.SelectedIndexChanged += new System.EventHandler(this.cobSecond_SelectedIndexChanged);
            // 
            // cobSign
            // 
            this.cobSign.FormattingEnabled = true;
            this.cobSign.Location = new System.Drawing.Point(10, 12);
            this.cobSign.Name = "cobSign";
            this.cobSign.Size = new System.Drawing.Size(45, 23);
            this.cobSign.TabIndex = 15;
            this.cobSign.SelectedIndexChanged += new System.EventHandler(this.cobSign_SelectedIndexChanged);
            // 
            // SimpleDateTimePicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.cobSign);
            this.Controls.Add(this.lblDot);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.dud100Year);
            this.Controls.Add(this.cobYear);
            this.Controls.Add(this.cobSecond);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.txtDecimalSecond);
            this.Controls.Add(this.lblMinute);
            this.Controls.Add(this.cobMinute);
            this.Controls.Add(this.cobMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.cobHour);
            this.Controls.Add(this.cobDay);
            this.Name = "SimpleDateTimePicker";
            this.Size = new System.Drawing.Size(529, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDot;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.DomainUpDown dud100Year;
        private System.Windows.Forms.ComboBox cobYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.ComboBox cobMonth;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.ComboBox cobDay;
        private System.Windows.Forms.ComboBox cobHour;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cobMinute;
        private System.Windows.Forms.TextBox txtDecimalSecond;
        private System.Windows.Forms.ComboBox cobSecond;
        private System.Windows.Forms.ComboBox cobSign;
    }
}
