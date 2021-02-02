namespace JsonEditorV2
{
    partial class frmChoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChoices));
            this.lsbItems = new System.Windows.Forms.ListBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnItemMoveUp = new System.Windows.Forms.Button();
            this.imlChoices = new System.Windows.Forms.ImageList(this.components);
            this.btnItemMoveDown = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsbItems
            // 
            this.lsbItems.DisplayMember = "Name";
            this.lsbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbItems.FormattingEnabled = true;
            this.lsbItems.ItemHeight = 20;
            this.lsbItems.Location = new System.Drawing.Point(12, 47);
            this.lsbItems.Name = "lsbItems";
            this.lsbItems.Size = new System.Drawing.Size(370, 244);
            this.lsbItems.TabIndex = 0;
            this.lsbItems.SelectedIndexChanged += new System.EventHandler(this.lsbItems_SelectedIndexChanged);
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(12, 14);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(274, 27);
            this.txtItemName.TabIndex = 1;
            this.txtItemName.Click += new System.EventHandler(this.txtItemName_Click);
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(305, 12);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(77, 30);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "-";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Enabled = false;
            this.btnDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.Location = new System.Drawing.Point(109, 299);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(77, 30);
            this.btnDeleteItem.TabIndex = 2;
            this.btnDeleteItem.Text = "-";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnItemMoveUp
            // 
            this.btnItemMoveUp.Enabled = false;
            this.btnItemMoveUp.ImageIndex = 0;
            this.btnItemMoveUp.ImageList = this.imlChoices;
            this.btnItemMoveUp.Location = new System.Drawing.Point(12, 299);
            this.btnItemMoveUp.Name = "btnItemMoveUp";
            this.btnItemMoveUp.Size = new System.Drawing.Size(77, 30);
            this.btnItemMoveUp.TabIndex = 3;
            this.btnItemMoveUp.Text = "-";
            this.btnItemMoveUp.UseVisualStyleBackColor = true;
            this.btnItemMoveUp.Click += new System.EventHandler(this.btnItemMoveUp_Click);
            // 
            // imlChoices
            // 
            this.imlChoices.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlChoices.ImageStream")));
            this.imlChoices.TransparentColor = System.Drawing.Color.Transparent;
            this.imlChoices.Images.SetKeyName(0, "UpArrow.png");
            this.imlChoices.Images.SetKeyName(1, "DownArrow.png");
            // 
            // btnItemMoveDown
            // 
            this.btnItemMoveDown.Enabled = false;
            this.btnItemMoveDown.ImageIndex = 1;
            this.btnItemMoveDown.ImageList = this.imlChoices;
            this.btnItemMoveDown.Location = new System.Drawing.Point(206, 299);
            this.btnItemMoveDown.Name = "btnItemMoveDown";
            this.btnItemMoveDown.Size = new System.Drawing.Size(77, 30);
            this.btnItemMoveDown.TabIndex = 4;
            this.btnItemMoveDown.Text = "-";
            this.btnItemMoveDown.UseVisualStyleBackColor = true;
            this.btnItemMoveDown.Click += new System.EventHandler(this.btnItemMoveDown_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(303, 299);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(77, 30);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "-";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // frmChoices
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(394, 336);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnItemMoveDown);
            this.Controls.Add(this.btnItemMoveUp);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.lsbItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "-";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChoices_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbItems;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnItemMoveUp;
        private System.Windows.Forms.Button btnItemMoveDown;
        private System.Windows.Forms.ImageList imlChoices;
        private System.Windows.Forms.Button btnConfirm;
    }
}