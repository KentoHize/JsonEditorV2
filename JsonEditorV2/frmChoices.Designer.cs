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
            this.txtItemText = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnItemMoveUp = new System.Windows.Forms.Button();
            this.btnItemMoveDown = new System.Windows.Forms.Button();
            this.imlChoices = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lsbItems
            // 
            this.lsbItems.FormattingEnabled = true;
            this.lsbItems.ItemHeight = 16;
            this.lsbItems.Location = new System.Drawing.Point(12, 12);
            this.lsbItems.Name = "lsbItems";
            this.lsbItems.Size = new System.Drawing.Size(370, 244);
            this.lsbItems.TabIndex = 0;
            // 
            // txtItemText
            // 
            this.txtItemText.Location = new System.Drawing.Point(12, 302);
            this.txtItemText.Name = "txtItemText";
            this.txtItemText.Size = new System.Drawing.Size(274, 22);
            this.txtItemText.TabIndex = 1;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(305, 298);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(77, 30);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "-";
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(167, 262);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(77, 30);
            this.btnRemoveItem.TabIndex = 2;
            this.btnRemoveItem.Text = "-";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // btnItemMoveUp
            // 
            this.btnItemMoveUp.ImageIndex = 0;
            this.btnItemMoveUp.ImageList = this.imlChoices;
            this.btnItemMoveUp.Location = new System.Drawing.Point(12, 262);
            this.btnItemMoveUp.Name = "btnItemMoveUp";
            this.btnItemMoveUp.Size = new System.Drawing.Size(77, 30);
            this.btnItemMoveUp.TabIndex = 3;
            this.btnItemMoveUp.Text = "-";
            this.btnItemMoveUp.UseVisualStyleBackColor = true;
            // 
            // btnItemMoveDown
            // 
            this.btnItemMoveDown.ImageIndex = 1;
            this.btnItemMoveDown.ImageList = this.imlChoices;
            this.btnItemMoveDown.Location = new System.Drawing.Point(310, 262);
            this.btnItemMoveDown.Name = "btnItemMoveDown";
            this.btnItemMoveDown.Size = new System.Drawing.Size(77, 30);
            this.btnItemMoveDown.TabIndex = 4;
            this.btnItemMoveDown.Text = "-";
            this.btnItemMoveDown.UseVisualStyleBackColor = true;
            // 
            // imlChoices
            // 
            this.imlChoices.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlChoices.ImageStream")));
            this.imlChoices.TransparentColor = System.Drawing.Color.Transparent;
            this.imlChoices.Images.SetKeyName(0, "UpArrow.png");
            this.imlChoices.Images.SetKeyName(1, "DownArrow.png");
            // 
            // frmChoices
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(399, 336);
            this.Controls.Add(this.btnItemMoveDown);
            this.Controls.Add(this.btnItemMoveUp);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.txtItemText);
            this.Controls.Add(this.lsbItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "-";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbItems;
        private System.Windows.Forms.TextBox txtItemText;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnItemMoveUp;
        private System.Windows.Forms.Button btnItemMoveDown;
        private System.Windows.Forms.ImageList imlChoices;
    }
}