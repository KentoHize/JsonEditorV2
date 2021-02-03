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
            this.txtMillisecond = new System.Windows.Forms.TextBox();
            this.cobSecond = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblDot
            // 
            this.lblDot.AutoSize = true;
            this.lblDot.Location = new System.Drawing.Point(293, 51);
            this.lblDot.Name = "lblDot";
            this.lblDot.Size = new System.Drawing.Size(12, 17);
            this.lblDot.TabIndex = 14;
            this.lblDot.Text = ".";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(375, 51);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(13, 17);
            this.lblSecond.TabIndex = 13;
            this.lblSecond.Text = "-";
            // 
            // dud100Year
            // 
            this.dud100Year.Location = new System.Drawing.Point(13, 14);
            this.dud100Year.Name = "dud100Year";
            this.dud100Year.ReadOnly = true;
            this.dud100Year.Size = new System.Drawing.Size(53, 22);
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
            this.cobYear.Location = new System.Drawing.Point(75, 13);
            this.cobYear.Name = "cobYear";
            this.cobYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cobYear.Size = new System.Drawing.Size(45, 24);
            this.cobYear.TabIndex = 1;
            this.cobYear.SelectedIndexChanged += new System.EventHandler(this.cobYear_SelectedIndexChanged);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(243, 17);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(13, 17);
            this.lblMonth.TabIndex = 2;
            this.lblMonth.Text = "-";
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.Location = new System.Drawing.Point(175, 51);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(13, 17);
            this.lblMinute.TabIndex = 12;
            this.lblMinute.Text = "-";
            // 
            // cobMonth
            // 
            this.cobMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobMonth.Enabled = false;
            this.cobMonth.FormattingEnabled = true;
            this.cobMonth.Location = new System.Drawing.Point(189, 13);
            this.cobMonth.Name = "cobMonth";
            this.cobMonth.Size = new System.Drawing.Size(45, 24);
            this.cobMonth.TabIndex = 3;
            this.cobMonth.SelectedIndexChanged += new System.EventHandler(this.cobMonth_SelectedIndexChanged);
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Location = new System.Drawing.Point(65, 51);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(13, 17);
            this.lblHour.TabIndex = 11;
            this.lblHour.Text = "-";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(377, 17);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(13, 17);
            this.lblDay.TabIndex = 4;
            this.lblDay.Text = "-";
            // 
            // cobDay
            // 
            this.cobDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobDay.Enabled = false;
            this.cobDay.FormattingEnabled = true;
            this.cobDay.Location = new System.Drawing.Point(323, 13);
            this.cobDay.Name = "cobDay";
            this.cobDay.Size = new System.Drawing.Size(45, 24);
            this.cobDay.TabIndex = 10;
            this.cobDay.SelectedIndexChanged += new System.EventHandler(this.cobDay_SelectedIndexChanged);
            // 
            // cobHour
            // 
            this.cobHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobHour.Enabled = false;
            this.cobHour.FormattingEnabled = true;
            this.cobHour.Location = new System.Drawing.Point(13, 47);
            this.cobHour.Name = "cobHour";
            this.cobHour.Size = new System.Drawing.Size(45, 24);
            this.cobHour.TabIndex = 5;
            this.cobHour.SelectedIndexChanged += new System.EventHandler(this.cobHour_SelectedIndexChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(129, 17);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(13, 17);
            this.lblYear.TabIndex = 9;
            this.lblYear.Text = "-";
            // 
            // cobMinute
            // 
            this.cobMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobMinute.Enabled = false;
            this.cobMinute.FormattingEnabled = true;
            this.cobMinute.Location = new System.Drawing.Point(123, 47);
            this.cobMinute.Name = "cobMinute";
            this.cobMinute.Size = new System.Drawing.Size(45, 24);
            this.cobMinute.TabIndex = 6;
            this.cobMinute.SelectedIndexChanged += new System.EventHandler(this.cobMinute_SelectedIndexChanged);
            // 
            // txtMillisecond
            // 
            this.txtMillisecond.Enabled = false;
            this.txtMillisecond.Location = new System.Drawing.Point(306, 48);
            this.txtMillisecond.MaxLength = 3;
            this.txtMillisecond.Name = "txtMillisecond";
            this.txtMillisecond.Size = new System.Drawing.Size(60, 22);
            this.txtMillisecond.TabIndex = 8;
            this.txtMillisecond.TextChanged += new System.EventHandler(this.txtMillisecond_TextChanged);
            // 
            // cobSecond
            // 
            this.cobSecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSecond.Enabled = false;
            this.cobSecond.FormattingEnabled = true;
            this.cobSecond.Location = new System.Drawing.Point(247, 47);
            this.cobSecond.Name = "cobSecond";
            this.cobSecond.Size = new System.Drawing.Size(45, 24);
            this.cobSecond.TabIndex = 7;
            this.cobSecond.SelectedIndexChanged += new System.EventHandler(this.cobSecond_SelectedIndexChanged);
            // 
            // SimpleDateTimePicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lblDot);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.dud100Year);
            this.Controls.Add(this.cobYear);
            this.Controls.Add(this.cobSecond);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.txtMillisecond);
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
        private System.Windows.Forms.TextBox txtMillisecond;
        private System.Windows.Forms.ComboBox cobSecond;
    }
}
