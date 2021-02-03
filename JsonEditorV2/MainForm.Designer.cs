namespace JsonEditorV2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnClearColumn = new System.Windows.Forms.Button();
            this.btnClearMain = new System.Windows.Forms.Button();
            this.btnUpdateMain = new System.Windows.Forms.Button();
            this.btnUpdateColumn = new System.Windows.Forms.Button();
            this.pnlFileInfo = new System.Windows.Forms.Panel();
            this.lblColumnChoiceName = new System.Windows.Forms.Label();
            this.lblColumnChoicesCount = new System.Windows.Forms.Label();
            this.btnColumnEditChoices = new System.Windows.Forms.Button();
            this.lblColumnChoices = new System.Windows.Forms.Label();
            this.ckbColumnAutoGenerateKey = new System.Windows.Forms.CheckBox();
            this.lblAutoGenerateKey = new System.Windows.Forms.Label();
            this.ckbColumnIsUnique = new System.Windows.Forms.CheckBox();
            this.lblColumnIsUnique = new System.Windows.Forms.Label();
            this.txtColumnMaxLength = new System.Windows.Forms.TextBox();
            this.lblColumnMaxLength = new System.Windows.Forms.Label();
            this.lblColumnDescription = new System.Windows.Forms.Label();
            this.txtColumnDescription = new System.Windows.Forms.TextBox();
            this.txtColumnMaxValue = new System.Windows.Forms.TextBox();
            this.txtColumnMinValue = new System.Windows.Forms.TextBox();
            this.lblColumnMaxValue = new System.Windows.Forms.Label();
            this.lblColumnMinValue = new System.Windows.Forms.Label();
            this.ckbColumnIsNullable = new System.Windows.Forms.CheckBox();
            this.lblColumnlIsNullable = new System.Windows.Forms.Label();
            this.txtColumnRegex = new System.Windows.Forms.TextBox();
            this.lblColumnRegex = new System.Windows.Forms.Label();
            this.cobColumnFKColumn = new System.Windows.Forms.ComboBox();
            this.lblColumnFKColumn = new System.Windows.Forms.Label();
            this.cobColumnFKTable = new System.Windows.Forms.ComboBox();
            this.txtColumnNumberOfRows = new System.Windows.Forms.TextBox();
            this.lblColumnNumberOfRows = new System.Windows.Forms.Label();
            this.ckbColumnDisplay = new System.Windows.Forms.CheckBox();
            this.ckbColumnIsKey = new System.Windows.Forms.CheckBox();
            this.cobColumnType = new System.Windows.Forms.ComboBox();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.lblColumnFKTable = new System.Windows.Forms.Label();
            this.lblColumnDisplay = new System.Windows.Forms.Label();
            this.lblColumnIsKey = new System.Windows.Forms.Label();
            this.lblColumnType = new System.Windows.Forms.Label();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.trvJsonFiles = new System.Windows.Forms.TreeView();
            this.imlMain = new System.Windows.Forms.ImageList(this.components);
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.sslMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.cmsTabSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiCloseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.tbpStart = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDateTimePicker = new System.Windows.Forms.Panel();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.tmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiNewJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiScanJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLoadJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiSaveJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSaveAsJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiCloseAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLanguages = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLanguageENUS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiLanguageZHCN = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLanguageZHTW = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiJsonEditorBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiTestDataBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAritiafelBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiRunSomething = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
            this.cmsJsonFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiNewJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRenameDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiViewJFIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRefreshFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsJsonFileSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiOpenJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiViewJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRenameJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDeleteJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCloseJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiAddColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsColumnSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiRenameColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiColumnShowOnList = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiColumnMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiColumnMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewLine = new System.Windows.Forms.Button();
            this.btnDeleteLine = new System.Windows.Forms.Button();
            this.btnLineMoveUp = new System.Windows.Forms.Button();
            this.btnLineMoveDown = new System.Windows.Forms.Button();
            this.ckbQuickCheck = new System.Windows.Forms.CheckBox();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.cobFindColumnName = new System.Windows.Forms.ComboBox();
            this.txtFindValue = new System.Windows.Forms.TextBox();
            this.btnFindConfirm = new System.Windows.Forms.Button();
            this.dtpMain = new JsonEditorV2.SimpleDateTimePicker();
            this.pnlFileInfo.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.cmsTabSelected.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlDateTimePicker.SuspendLayout();
            this.mnsMain.SuspendLayout();
            this.cmsJsonFiles.SuspendLayout();
            this.cmsJsonFileSelected.SuspendLayout();
            this.cmsColumnSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClearColumn
            // 
            this.btnClearColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearColumn.Location = new System.Drawing.Point(1, 764);
            this.btnClearColumn.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearColumn.Name = "btnClearColumn";
            this.btnClearColumn.Size = new System.Drawing.Size(122, 40);
            this.btnClearColumn.TabIndex = 19;
            this.btnClearColumn.Text = "-";
            this.btnClearColumn.UseVisualStyleBackColor = true;
            this.btnClearColumn.Click += new System.EventHandler(this.btnClearColumn_Click);
            // 
            // btnClearMain
            // 
            this.btnClearMain.Enabled = false;
            this.btnClearMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearMain.Location = new System.Drawing.Point(840, 764);
            this.btnClearMain.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearMain.Name = "btnClearMain";
            this.btnClearMain.Size = new System.Drawing.Size(122, 40);
            this.btnClearMain.TabIndex = 18;
            this.btnClearMain.Text = "-";
            this.btnClearMain.UseVisualStyleBackColor = true;
            this.btnClearMain.Click += new System.EventHandler(this.btnClearMain_Click);
            // 
            // btnUpdateMain
            // 
            this.btnUpdateMain.Enabled = false;
            this.btnUpdateMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateMain.Location = new System.Drawing.Point(1383, 764);
            this.btnUpdateMain.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateMain.Name = "btnUpdateMain";
            this.btnUpdateMain.Size = new System.Drawing.Size(122, 40);
            this.btnUpdateMain.TabIndex = 17;
            this.btnUpdateMain.Text = "-";
            this.btnUpdateMain.UseVisualStyleBackColor = true;
            this.btnUpdateMain.Click += new System.EventHandler(this.btnUpdateMain_Click);
            // 
            // btnUpdateColumn
            // 
            this.btnUpdateColumn.Enabled = false;
            this.btnUpdateColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateColumn.Location = new System.Drawing.Point(299, 764);
            this.btnUpdateColumn.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateColumn.Name = "btnUpdateColumn";
            this.btnUpdateColumn.Size = new System.Drawing.Size(122, 40);
            this.btnUpdateColumn.TabIndex = 16;
            this.btnUpdateColumn.Text = "-";
            this.btnUpdateColumn.UseVisualStyleBackColor = true;
            this.btnUpdateColumn.Click += new System.EventHandler(this.btnUpdateColumn_Click);
            // 
            // pnlFileInfo
            // 
            this.pnlFileInfo.AutoScroll = true;
            this.pnlFileInfo.Controls.Add(this.lblColumnChoiceName);
            this.pnlFileInfo.Controls.Add(this.lblColumnChoicesCount);
            this.pnlFileInfo.Controls.Add(this.btnColumnEditChoices);
            this.pnlFileInfo.Controls.Add(this.lblColumnChoices);
            this.pnlFileInfo.Controls.Add(this.ckbColumnAutoGenerateKey);
            this.pnlFileInfo.Controls.Add(this.lblAutoGenerateKey);
            this.pnlFileInfo.Controls.Add(this.ckbColumnIsUnique);
            this.pnlFileInfo.Controls.Add(this.lblColumnIsUnique);
            this.pnlFileInfo.Controls.Add(this.txtColumnMaxLength);
            this.pnlFileInfo.Controls.Add(this.lblColumnMaxLength);
            this.pnlFileInfo.Controls.Add(this.lblColumnDescription);
            this.pnlFileInfo.Controls.Add(this.txtColumnDescription);
            this.pnlFileInfo.Controls.Add(this.txtColumnMaxValue);
            this.pnlFileInfo.Controls.Add(this.txtColumnMinValue);
            this.pnlFileInfo.Controls.Add(this.lblColumnMaxValue);
            this.pnlFileInfo.Controls.Add(this.lblColumnMinValue);
            this.pnlFileInfo.Controls.Add(this.ckbColumnIsNullable);
            this.pnlFileInfo.Controls.Add(this.lblColumnlIsNullable);
            this.pnlFileInfo.Controls.Add(this.txtColumnRegex);
            this.pnlFileInfo.Controls.Add(this.lblColumnRegex);
            this.pnlFileInfo.Controls.Add(this.cobColumnFKColumn);
            this.pnlFileInfo.Controls.Add(this.lblColumnFKColumn);
            this.pnlFileInfo.Controls.Add(this.cobColumnFKTable);
            this.pnlFileInfo.Controls.Add(this.txtColumnNumberOfRows);
            this.pnlFileInfo.Controls.Add(this.lblColumnNumberOfRows);
            this.pnlFileInfo.Controls.Add(this.ckbColumnDisplay);
            this.pnlFileInfo.Controls.Add(this.ckbColumnIsKey);
            this.pnlFileInfo.Controls.Add(this.cobColumnType);
            this.pnlFileInfo.Controls.Add(this.txtColumnName);
            this.pnlFileInfo.Controls.Add(this.lblColumnFKTable);
            this.pnlFileInfo.Controls.Add(this.lblColumnDisplay);
            this.pnlFileInfo.Controls.Add(this.lblColumnIsKey);
            this.pnlFileInfo.Controls.Add(this.lblColumnType);
            this.pnlFileInfo.Controls.Add(this.lblColumnName);
            this.pnlFileInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFileInfo.Location = new System.Drawing.Point(1, 433);
            this.pnlFileInfo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFileInfo.Name = "pnlFileInfo";
            this.pnlFileInfo.Size = new System.Drawing.Size(420, 324);
            this.pnlFileInfo.TabIndex = 15;
            // 
            // lblColumnChoiceName
            // 
            this.lblColumnChoiceName.AutoSize = true;
            this.lblColumnChoiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnChoiceName.Location = new System.Drawing.Point(247, 82);
            this.lblColumnChoiceName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnChoiceName.Name = "lblColumnChoiceName";
            this.lblColumnChoiceName.Size = new System.Drawing.Size(15, 20);
            this.lblColumnChoiceName.TabIndex = 38;
            this.lblColumnChoiceName.Text = "-";
            // 
            // lblColumnChoicesCount
            // 
            this.lblColumnChoicesCount.AutoSize = true;
            this.lblColumnChoicesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnChoicesCount.Location = new System.Drawing.Point(209, 82);
            this.lblColumnChoicesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnChoicesCount.Name = "lblColumnChoicesCount";
            this.lblColumnChoicesCount.Size = new System.Drawing.Size(15, 20);
            this.lblColumnChoicesCount.TabIndex = 37;
            this.lblColumnChoicesCount.Text = "-";
            // 
            // btnColumnEditChoices
            // 
            this.btnColumnEditChoices.Enabled = false;
            this.btnColumnEditChoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColumnEditChoices.Location = new System.Drawing.Point(343, 77);
            this.btnColumnEditChoices.Margin = new System.Windows.Forms.Padding(4);
            this.btnColumnEditChoices.Name = "btnColumnEditChoices";
            this.btnColumnEditChoices.Size = new System.Drawing.Size(50, 35);
            this.btnColumnEditChoices.TabIndex = 36;
            this.btnColumnEditChoices.Text = "...";
            this.btnColumnEditChoices.UseVisualStyleBackColor = true;
            this.btnColumnEditChoices.Click += new System.EventHandler(this.btnColumnEditChoices_Click);
            // 
            // lblColumnChoices
            // 
            this.lblColumnChoices.AutoSize = true;
            this.lblColumnChoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnChoices.Location = new System.Drawing.Point(18, 82);
            this.lblColumnChoices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnChoices.Name = "lblColumnChoices";
            this.lblColumnChoices.Size = new System.Drawing.Size(15, 20);
            this.lblColumnChoices.TabIndex = 35;
            this.lblColumnChoices.Text = "-";
            // 
            // ckbColumnAutoGenerateKey
            // 
            this.ckbColumnAutoGenerateKey.AutoSize = true;
            this.ckbColumnAutoGenerateKey.Location = new System.Drawing.Point(371, 434);
            this.ckbColumnAutoGenerateKey.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnAutoGenerateKey.Name = "ckbColumnAutoGenerateKey";
            this.ckbColumnAutoGenerateKey.Size = new System.Drawing.Size(18, 17);
            this.ckbColumnAutoGenerateKey.TabIndex = 34;
            this.ckbColumnAutoGenerateKey.UseVisualStyleBackColor = true;
            this.ckbColumnAutoGenerateKey.CheckedChanged += new System.EventHandler(this.ckbAutoGenerateKey_CheckedChanged);
            // 
            // lblAutoGenerateKey
            // 
            this.lblAutoGenerateKey.AutoSize = true;
            this.lblAutoGenerateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoGenerateKey.Location = new System.Drawing.Point(18, 432);
            this.lblAutoGenerateKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutoGenerateKey.Name = "lblAutoGenerateKey";
            this.lblAutoGenerateKey.Size = new System.Drawing.Size(15, 20);
            this.lblAutoGenerateKey.TabIndex = 33;
            this.lblAutoGenerateKey.Text = "-";
            // 
            // ckbColumnIsUnique
            // 
            this.ckbColumnIsUnique.AutoSize = true;
            this.ckbColumnIsUnique.Location = new System.Drawing.Point(371, 399);
            this.ckbColumnIsUnique.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnIsUnique.Name = "ckbColumnIsUnique";
            this.ckbColumnIsUnique.Size = new System.Drawing.Size(18, 17);
            this.ckbColumnIsUnique.TabIndex = 32;
            this.ckbColumnIsUnique.UseVisualStyleBackColor = true;
            // 
            // lblColumnIsUnique
            // 
            this.lblColumnIsUnique.AutoSize = true;
            this.lblColumnIsUnique.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnIsUnique.Location = new System.Drawing.Point(18, 397);
            this.lblColumnIsUnique.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnIsUnique.Name = "lblColumnIsUnique";
            this.lblColumnIsUnique.Size = new System.Drawing.Size(15, 20);
            this.lblColumnIsUnique.TabIndex = 31;
            this.lblColumnIsUnique.Text = "-";
            // 
            // txtColumnMaxLength
            // 
            this.txtColumnMaxLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnMaxLength.Location = new System.Drawing.Point(207, 359);
            this.txtColumnMaxLength.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnMaxLength.Name = "txtColumnMaxLength";
            this.txtColumnMaxLength.Size = new System.Drawing.Size(184, 27);
            this.txtColumnMaxLength.TabIndex = 30;
            this.txtColumnMaxLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnMaxLength
            // 
            this.lblColumnMaxLength.AutoSize = true;
            this.lblColumnMaxLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnMaxLength.Location = new System.Drawing.Point(18, 362);
            this.lblColumnMaxLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnMaxLength.Name = "lblColumnMaxLength";
            this.lblColumnMaxLength.Size = new System.Drawing.Size(15, 20);
            this.lblColumnMaxLength.TabIndex = 29;
            this.lblColumnMaxLength.Text = "-";
            // 
            // lblColumnDescription
            // 
            this.lblColumnDescription.AutoSize = true;
            this.lblColumnDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnDescription.Location = new System.Drawing.Point(18, 537);
            this.lblColumnDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnDescription.Name = "lblColumnDescription";
            this.lblColumnDescription.Size = new System.Drawing.Size(15, 20);
            this.lblColumnDescription.TabIndex = 28;
            this.lblColumnDescription.Text = "-";
            // 
            // txtColumnDescription
            // 
            this.txtColumnDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnDescription.Location = new System.Drawing.Point(207, 534);
            this.txtColumnDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnDescription.Name = "txtColumnDescription";
            this.txtColumnDescription.Size = new System.Drawing.Size(184, 27);
            this.txtColumnDescription.TabIndex = 27;
            this.txtColumnDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtColumnMaxValue
            // 
            this.txtColumnMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnMaxValue.Location = new System.Drawing.Point(207, 289);
            this.txtColumnMaxValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnMaxValue.Name = "txtColumnMaxValue";
            this.txtColumnMaxValue.Size = new System.Drawing.Size(184, 27);
            this.txtColumnMaxValue.TabIndex = 26;
            this.txtColumnMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtColumnMinValue
            // 
            this.txtColumnMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnMinValue.Location = new System.Drawing.Point(207, 254);
            this.txtColumnMinValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnMinValue.Name = "txtColumnMinValue";
            this.txtColumnMinValue.Size = new System.Drawing.Size(184, 27);
            this.txtColumnMinValue.TabIndex = 25;
            this.txtColumnMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnMaxValue
            // 
            this.lblColumnMaxValue.AutoSize = true;
            this.lblColumnMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnMaxValue.Location = new System.Drawing.Point(18, 292);
            this.lblColumnMaxValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnMaxValue.Name = "lblColumnMaxValue";
            this.lblColumnMaxValue.Size = new System.Drawing.Size(15, 20);
            this.lblColumnMaxValue.TabIndex = 24;
            this.lblColumnMaxValue.Text = "-";
            // 
            // lblColumnMinValue
            // 
            this.lblColumnMinValue.AutoSize = true;
            this.lblColumnMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnMinValue.Location = new System.Drawing.Point(18, 257);
            this.lblColumnMinValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnMinValue.Name = "lblColumnMinValue";
            this.lblColumnMinValue.Size = new System.Drawing.Size(15, 20);
            this.lblColumnMinValue.TabIndex = 23;
            this.lblColumnMinValue.Text = "-";
            // 
            // ckbColumnIsNullable
            // 
            this.ckbColumnIsNullable.AutoSize = true;
            this.ckbColumnIsNullable.Location = new System.Drawing.Point(371, 154);
            this.ckbColumnIsNullable.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnIsNullable.Name = "ckbColumnIsNullable";
            this.ckbColumnIsNullable.Size = new System.Drawing.Size(18, 17);
            this.ckbColumnIsNullable.TabIndex = 22;
            this.ckbColumnIsNullable.UseVisualStyleBackColor = true;
            // 
            // lblColumnlIsNullable
            // 
            this.lblColumnlIsNullable.AutoSize = true;
            this.lblColumnlIsNullable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnlIsNullable.Location = new System.Drawing.Point(18, 152);
            this.lblColumnlIsNullable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnlIsNullable.Name = "lblColumnlIsNullable";
            this.lblColumnlIsNullable.Size = new System.Drawing.Size(15, 20);
            this.lblColumnlIsNullable.TabIndex = 21;
            this.lblColumnlIsNullable.Text = "-";
            // 
            // txtColumnRegex
            // 
            this.txtColumnRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnRegex.Location = new System.Drawing.Point(207, 324);
            this.txtColumnRegex.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnRegex.Name = "txtColumnRegex";
            this.txtColumnRegex.Size = new System.Drawing.Size(184, 27);
            this.txtColumnRegex.TabIndex = 20;
            this.txtColumnRegex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnRegex
            // 
            this.lblColumnRegex.AutoSize = true;
            this.lblColumnRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnRegex.Location = new System.Drawing.Point(18, 327);
            this.lblColumnRegex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnRegex.Name = "lblColumnRegex";
            this.lblColumnRegex.Size = new System.Drawing.Size(15, 20);
            this.lblColumnRegex.TabIndex = 19;
            this.lblColumnRegex.Text = "-";
            // 
            // cobColumnFKColumn
            // 
            this.cobColumnFKColumn.DisplayMember = "Name";
            this.cobColumnFKColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobColumnFKColumn.FormattingEnabled = true;
            this.cobColumnFKColumn.Location = new System.Drawing.Point(207, 498);
            this.cobColumnFKColumn.Margin = new System.Windows.Forms.Padding(4);
            this.cobColumnFKColumn.Name = "cobColumnFKColumn";
            this.cobColumnFKColumn.Size = new System.Drawing.Size(184, 28);
            this.cobColumnFKColumn.TabIndex = 18;
            this.cobColumnFKColumn.ValueMember = "Name";
            this.cobColumnFKColumn.SelectedIndexChanged += new System.EventHandler(this.cobColumnFKColumn_SelectedIndexChanged);
            // 
            // lblColumnFKColumn
            // 
            this.lblColumnFKColumn.AutoSize = true;
            this.lblColumnFKColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnFKColumn.Location = new System.Drawing.Point(18, 502);
            this.lblColumnFKColumn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnFKColumn.Name = "lblColumnFKColumn";
            this.lblColumnFKColumn.Size = new System.Drawing.Size(15, 20);
            this.lblColumnFKColumn.TabIndex = 17;
            this.lblColumnFKColumn.Text = "-";
            // 
            // cobColumnFKTable
            // 
            this.cobColumnFKTable.DisplayMember = "Name";
            this.cobColumnFKTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobColumnFKTable.FormattingEnabled = true;
            this.cobColumnFKTable.Location = new System.Drawing.Point(207, 463);
            this.cobColumnFKTable.Margin = new System.Windows.Forms.Padding(4);
            this.cobColumnFKTable.Name = "cobColumnFKTable";
            this.cobColumnFKTable.Size = new System.Drawing.Size(184, 28);
            this.cobColumnFKTable.TabIndex = 16;
            this.cobColumnFKTable.ValueMember = "Name";
            this.cobColumnFKTable.SelectedIndexChanged += new System.EventHandler(this.cobColumnFKTable_SelectedIndexChanged);
            // 
            // txtColumnNumberOfRows
            // 
            this.txtColumnNumberOfRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnNumberOfRows.Location = new System.Drawing.Point(353, 219);
            this.txtColumnNumberOfRows.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnNumberOfRows.Name = "txtColumnNumberOfRows";
            this.txtColumnNumberOfRows.Size = new System.Drawing.Size(36, 27);
            this.txtColumnNumberOfRows.TabIndex = 15;
            this.txtColumnNumberOfRows.Text = "0";
            this.txtColumnNumberOfRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnNumberOfRows
            // 
            this.lblColumnNumberOfRows.AutoSize = true;
            this.lblColumnNumberOfRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnNumberOfRows.Location = new System.Drawing.Point(18, 222);
            this.lblColumnNumberOfRows.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnNumberOfRows.Name = "lblColumnNumberOfRows";
            this.lblColumnNumberOfRows.Size = new System.Drawing.Size(15, 20);
            this.lblColumnNumberOfRows.TabIndex = 14;
            this.lblColumnNumberOfRows.Text = "-";
            // 
            // ckbColumnDisplay
            // 
            this.ckbColumnDisplay.AutoSize = true;
            this.ckbColumnDisplay.Location = new System.Drawing.Point(371, 189);
            this.ckbColumnDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnDisplay.Name = "ckbColumnDisplay";
            this.ckbColumnDisplay.Size = new System.Drawing.Size(18, 17);
            this.ckbColumnDisplay.TabIndex = 13;
            this.ckbColumnDisplay.UseVisualStyleBackColor = true;
            // 
            // ckbColumnIsKey
            // 
            this.ckbColumnIsKey.AutoSize = true;
            this.ckbColumnIsKey.Location = new System.Drawing.Point(371, 119);
            this.ckbColumnIsKey.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnIsKey.Name = "ckbColumnIsKey";
            this.ckbColumnIsKey.Size = new System.Drawing.Size(18, 17);
            this.ckbColumnIsKey.TabIndex = 8;
            this.ckbColumnIsKey.UseVisualStyleBackColor = true;
            // 
            // cobColumnType
            // 
            this.cobColumnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobColumnType.FormattingEnabled = true;
            this.cobColumnType.Location = new System.Drawing.Point(207, 44);
            this.cobColumnType.Margin = new System.Windows.Forms.Padding(4);
            this.cobColumnType.Name = "cobColumnType";
            this.cobColumnType.Size = new System.Drawing.Size(184, 28);
            this.cobColumnType.TabIndex = 8;
            this.cobColumnType.SelectedIndexChanged += new System.EventHandler(this.cobColumnType_SelectedIndexChanged);
            // 
            // txtColumnName
            // 
            this.txtColumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnName.Location = new System.Drawing.Point(207, 9);
            this.txtColumnName.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(184, 27);
            this.txtColumnName.TabIndex = 0;
            this.txtColumnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnFKTable
            // 
            this.lblColumnFKTable.AutoSize = true;
            this.lblColumnFKTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnFKTable.Location = new System.Drawing.Point(18, 467);
            this.lblColumnFKTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnFKTable.Name = "lblColumnFKTable";
            this.lblColumnFKTable.Size = new System.Drawing.Size(15, 20);
            this.lblColumnFKTable.TabIndex = 12;
            this.lblColumnFKTable.Text = "-";
            // 
            // lblColumnDisplay
            // 
            this.lblColumnDisplay.AutoSize = true;
            this.lblColumnDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnDisplay.Location = new System.Drawing.Point(18, 187);
            this.lblColumnDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnDisplay.Name = "lblColumnDisplay";
            this.lblColumnDisplay.Size = new System.Drawing.Size(15, 20);
            this.lblColumnDisplay.TabIndex = 11;
            this.lblColumnDisplay.Text = "-";
            // 
            // lblColumnIsKey
            // 
            this.lblColumnIsKey.AutoSize = true;
            this.lblColumnIsKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnIsKey.Location = new System.Drawing.Point(18, 117);
            this.lblColumnIsKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnIsKey.Name = "lblColumnIsKey";
            this.lblColumnIsKey.Size = new System.Drawing.Size(15, 20);
            this.lblColumnIsKey.TabIndex = 10;
            this.lblColumnIsKey.Text = "-";
            // 
            // lblColumnType
            // 
            this.lblColumnType.AutoSize = true;
            this.lblColumnType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnType.Location = new System.Drawing.Point(18, 47);
            this.lblColumnType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnType.Name = "lblColumnType";
            this.lblColumnType.Size = new System.Drawing.Size(15, 20);
            this.lblColumnType.TabIndex = 9;
            this.lblColumnType.Text = "-";
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnName.Location = new System.Drawing.Point(18, 12);
            this.lblColumnName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(15, 20);
            this.lblColumnName.TabIndex = 8;
            this.lblColumnName.Text = "-";
            // 
            // trvJsonFiles
            // 
            this.trvJsonFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvJsonFiles.HideSelection = false;
            this.trvJsonFiles.ImageIndex = 0;
            this.trvJsonFiles.ImageList = this.imlMain;
            this.trvJsonFiles.Location = new System.Drawing.Point(1, 31);
            this.trvJsonFiles.Margin = new System.Windows.Forms.Padding(4);
            this.trvJsonFiles.Name = "trvJsonFiles";
            this.trvJsonFiles.SelectedImageIndex = 0;
            this.trvJsonFiles.ShowNodeToolTips = true;
            this.trvJsonFiles.Size = new System.Drawing.Size(420, 396);
            this.trvJsonFiles.TabIndex = 12;
            this.trvJsonFiles.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvJsonFiles_BeforeCollapse);
            this.trvJsonFiles.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvJsonFiles_BeforeExpand);
            this.trvJsonFiles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvJsonFiles_NodeMouseClick);
            this.trvJsonFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvJsonFiles_NodeMouseDoubleClick);
            this.trvJsonFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvJsonFiles_MouseDown);
            // 
            // imlMain
            // 
            this.imlMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMain.ImageStream")));
            this.imlMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMain.Images.SetKeyName(0, "Directory.png");
            this.imlMain.Images.SetKeyName(1, "JsonIcon.png");
            this.imlMain.Images.SetKeyName(2, "ObjectIcon.png");
            this.imlMain.Images.SetKeyName(3, "Key.png");
            this.imlMain.Images.SetKeyName(4, "UpArrow.png");
            this.imlMain.Images.SetKeyName(5, "DownArrow.png");
            this.imlMain.Images.SetKeyName(6, "Find.png");
            // 
            // stsMain
            // 
            this.stsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslMain});
            this.stsMain.Location = new System.Drawing.Point(0, 810);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(1509, 22);
            this.stsMain.TabIndex = 11;
            this.stsMain.Text = "sspMain";
            // 
            // sslMain
            // 
            this.sslMain.Name = "sslMain";
            this.sslMain.Size = new System.Drawing.Size(0, 17);
            // 
            // tbcMain
            // 
            this.tbcMain.ContextMenuStrip = this.cmsTabSelected;
            this.tbcMain.Controls.Add(this.tbpStart);
            this.tbcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcMain.Location = new System.Drawing.Point(429, 31);
            this.tbcMain.Margin = new System.Windows.Forms.Padding(4);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1071, 31);
            this.tbcMain.TabIndex = 20;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            this.tbcMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbcMain_MouseDown);
            // 
            // cmsTabSelected
            // 
            this.cmsTabSelected.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTabSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiCloseTab});
            this.cmsTabSelected.Name = "cmsMain";
            this.cmsTabSelected.Size = new System.Drawing.Size(88, 28);
            // 
            // tmiCloseTab
            // 
            this.tmiCloseTab.Name = "tmiCloseTab";
            this.tmiCloseTab.Size = new System.Drawing.Size(87, 24);
            this.tmiCloseTab.Text = "X";
            this.tmiCloseTab.Click += new System.EventHandler(this.tmiCloseTab_Click);
            // 
            // tbpStart
            // 
            this.tbpStart.Location = new System.Drawing.Point(4, 29);
            this.tbpStart.Margin = new System.Windows.Forms.Padding(4);
            this.tbpStart.Name = "tbpStart";
            this.tbpStart.Size = new System.Drawing.Size(1063, 0);
            this.tbpStart.TabIndex = 0;
            this.tbpStart.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.pnlDateTimePicker);
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(840, 65);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(665, 692);
            this.pnlMain.TabIndex = 21;
            // 
            // pnlDateTimePicker
            // 
            this.pnlDateTimePicker.AutoSize = true;
            this.pnlDateTimePicker.BackColor = System.Drawing.Color.White;
            this.pnlDateTimePicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDateTimePicker.Controls.Add(this.dtpMain);
            this.pnlDateTimePicker.Location = new System.Drawing.Point(21, 324);
            this.pnlDateTimePicker.Name = "pnlDateTimePicker";
            this.pnlDateTimePicker.Size = new System.Drawing.Size(569, 111);
            this.pnlDateTimePicker.TabIndex = 0;
            this.pnlDateTimePicker.Visible = false;
            // 
            // mnsMain
            // 
            this.mnsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFile,
            this.tmiLanguages,
            this.tmiAbout,
            this.tmiBackup});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(1509, 28);
            this.mnsMain.TabIndex = 24;
            this.mnsMain.Text = "menuStrip1";
            // 
            // tmiFile
            // 
            this.tmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiNewJsonFiles,
            this.toolStripMenuItem3,
            this.tmiScanJsonFiles,
            this.tmiLoadJsonFiles,
            this.toolStripMenuItem4,
            this.tmiSaveJsonFiles,
            this.tmiSaveAsJsonFiles,
            this.toolStripMenuItem2,
            this.tmiCloseAllFiles,
            this.toolStripMenuItem1,
            this.tmiExit});
            this.tmiFile.Name = "tmiFile";
            this.tmiFile.Size = new System.Drawing.Size(30, 24);
            this.tmiFile.Text = "X";
            // 
            // tmiNewJsonFiles
            // 
            this.tmiNewJsonFiles.Name = "tmiNewJsonFiles";
            this.tmiNewJsonFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tmiNewJsonFiles.Size = new System.Drawing.Size(146, 26);
            this.tmiNewJsonFiles.Text = "X";
            this.tmiNewJsonFiles.Click += new System.EventHandler(this.tmiNewJsonFiles_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(143, 6);
            // 
            // tmiScanJsonFiles
            // 
            this.tmiScanJsonFiles.Name = "tmiScanJsonFiles";
            this.tmiScanJsonFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tmiScanJsonFiles.Size = new System.Drawing.Size(146, 26);
            this.tmiScanJsonFiles.Text = "X";
            this.tmiScanJsonFiles.Click += new System.EventHandler(this.tmiScanJsonFiles_Click);
            // 
            // tmiLoadJsonFiles
            // 
            this.tmiLoadJsonFiles.Name = "tmiLoadJsonFiles";
            this.tmiLoadJsonFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tmiLoadJsonFiles.Size = new System.Drawing.Size(146, 26);
            this.tmiLoadJsonFiles.Text = "X";
            this.tmiLoadJsonFiles.Click += new System.EventHandler(this.tmiLoadJsonFiles_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(143, 6);
            // 
            // tmiSaveJsonFiles
            // 
            this.tmiSaveJsonFiles.Enabled = false;
            this.tmiSaveJsonFiles.Name = "tmiSaveJsonFiles";
            this.tmiSaveJsonFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tmiSaveJsonFiles.Size = new System.Drawing.Size(146, 26);
            this.tmiSaveJsonFiles.Text = "X";
            this.tmiSaveJsonFiles.Click += new System.EventHandler(this.tmiSaveJsonFiles_Click);
            // 
            // tmiSaveAsJsonFiles
            // 
            this.tmiSaveAsJsonFiles.Enabled = false;
            this.tmiSaveAsJsonFiles.Name = "tmiSaveAsJsonFiles";
            this.tmiSaveAsJsonFiles.Size = new System.Drawing.Size(146, 26);
            this.tmiSaveAsJsonFiles.Text = "X";
            this.tmiSaveAsJsonFiles.Click += new System.EventHandler(this.tmiSaveAsJsonFiles_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
            // 
            // tmiCloseAllFiles
            // 
            this.tmiCloseAllFiles.Enabled = false;
            this.tmiCloseAllFiles.Name = "tmiCloseAllFiles";
            this.tmiCloseAllFiles.Size = new System.Drawing.Size(146, 26);
            this.tmiCloseAllFiles.Text = "X";
            this.tmiCloseAllFiles.Click += new System.EventHandler(this.tmiCloseAllFiles_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // tmiExit
            // 
            this.tmiExit.Name = "tmiExit";
            this.tmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tmiExit.Size = new System.Drawing.Size(146, 26);
            this.tmiExit.Text = "X";
            this.tmiExit.Click += new System.EventHandler(this.tmiExit_Click);
            // 
            // tmiLanguages
            // 
            this.tmiLanguages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiLanguageENUS,
            this.toolStripMenuItem10,
            this.tmiLanguageZHCN,
            this.tmiLanguageZHTW});
            this.tmiLanguages.Name = "tmiLanguages";
            this.tmiLanguages.Size = new System.Drawing.Size(30, 24);
            this.tmiLanguages.Text = "X";
            // 
            // tmiLanguageENUS
            // 
            this.tmiLanguageENUS.Name = "tmiLanguageENUS";
            this.tmiLanguageENUS.Size = new System.Drawing.Size(196, 26);
            this.tmiLanguageENUS.Text = "English(en-US)";
            this.tmiLanguageENUS.Click += new System.EventHandler(this.tmiLanguageENUS_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(193, 6);
            // 
            // tmiLanguageZHCN
            // 
            this.tmiLanguageZHCN.Name = "tmiLanguageZHCN";
            this.tmiLanguageZHCN.Size = new System.Drawing.Size(196, 26);
            this.tmiLanguageZHCN.Text = "简体中文(zh-CN)";
            this.tmiLanguageZHCN.Click += new System.EventHandler(this.tmiLanguageZHCN_Click);
            // 
            // tmiLanguageZHTW
            // 
            this.tmiLanguageZHTW.Name = "tmiLanguageZHTW";
            this.tmiLanguageZHTW.Size = new System.Drawing.Size(196, 26);
            this.tmiLanguageZHTW.Text = "繁體中文(zh-TW)";
            this.tmiLanguageZHTW.Click += new System.EventHandler(this.tmiLanguageZHTW_Click);
            // 
            // tmiAbout
            // 
            this.tmiAbout.Name = "tmiAbout";
            this.tmiAbout.Size = new System.Drawing.Size(30, 24);
            this.tmiAbout.Text = "X";
            this.tmiAbout.Click += new System.EventHandler(this.tmiAbout_Click);
            // 
            // tmiBackup
            // 
            this.tmiBackup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiJsonEditorBackup,
            this.tmiTestDataBackup,
            this.tmiAritiafelBackup,
            this.toolStripMenuItem9,
            this.tmiRunSomething});
            this.tmiBackup.Name = "tmiBackup";
            this.tmiBackup.Size = new System.Drawing.Size(69, 24);
            this.tmiBackup.Text = "Backup";
            // 
            // tmiJsonEditorBackup
            // 
            this.tmiJsonEditorBackup.Name = "tmiJsonEditorBackup";
            this.tmiJsonEditorBackup.Size = new System.Drawing.Size(216, 26);
            this.tmiJsonEditorBackup.Text = "Json Editor";
            this.tmiJsonEditorBackup.Click += new System.EventHandler(this.tmiJsonEditorBackup_Click);
            // 
            // tmiTestDataBackup
            // 
            this.tmiTestDataBackup.Name = "tmiTestDataBackup";
            this.tmiTestDataBackup.Size = new System.Drawing.Size(216, 26);
            this.tmiTestDataBackup.Text = "Test Data";
            this.tmiTestDataBackup.Click += new System.EventHandler(this.tmiTestDataBackup_Click);
            // 
            // tmiAritiafelBackup
            // 
            this.tmiAritiafelBackup.Name = "tmiAritiafelBackup";
            this.tmiAritiafelBackup.Size = new System.Drawing.Size(216, 26);
            this.tmiAritiafelBackup.Text = "Aritiafel";
            this.tmiAritiafelBackup.Click += new System.EventHandler(this.tmiAritiafelBackup_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(213, 6);
            // 
            // tmiRunSomething
            // 
            this.tmiRunSomething.Name = "tmiRunSomething";
            this.tmiRunSomething.Size = new System.Drawing.Size(216, 26);
            this.tmiRunSomething.Text = "Run something";
            this.tmiRunSomething.Click += new System.EventHandler(this.tmiRunSomething_Click);
            // 
            // ofdMain
            // 
            this.ofdMain.FileName = "openFileDialog1";
            // 
            // cmsJsonFiles
            // 
            this.cmsJsonFiles.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsJsonFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiNewJsonFile,
            this.tmiRenameDatabase,
            this.toolStripMenuItem6,
            this.tmiOpenFolder,
            this.tmiViewJFIFile,
            this.tmiRefreshFiles,
            this.toolStripMenuItem8,
            this.tmiExpandAll,
            this.tmiCollapseAll});
            this.cmsJsonFiles.Name = "cmsMain";
            this.cmsJsonFiles.Size = new System.Drawing.Size(88, 184);
            // 
            // tmiNewJsonFile
            // 
            this.tmiNewJsonFile.Enabled = false;
            this.tmiNewJsonFile.Name = "tmiNewJsonFile";
            this.tmiNewJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiNewJsonFile.Text = "X";
            this.tmiNewJsonFile.Click += new System.EventHandler(this.tmiNewJsonFile_Click);
            // 
            // tmiRenameDatabase
            // 
            this.tmiRenameDatabase.Name = "tmiRenameDatabase";
            this.tmiRenameDatabase.Size = new System.Drawing.Size(87, 24);
            this.tmiRenameDatabase.Text = "X";
            this.tmiRenameDatabase.Click += new System.EventHandler(this.tmiRenameDatabase_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(84, 6);
            // 
            // tmiOpenFolder
            // 
            this.tmiOpenFolder.Enabled = false;
            this.tmiOpenFolder.Name = "tmiOpenFolder";
            this.tmiOpenFolder.Size = new System.Drawing.Size(87, 24);
            this.tmiOpenFolder.Text = "X";
            this.tmiOpenFolder.Click += new System.EventHandler(this.tmiOpenFolder_Click);
            // 
            // tmiViewJFIFile
            // 
            this.tmiViewJFIFile.Name = "tmiViewJFIFile";
            this.tmiViewJFIFile.Size = new System.Drawing.Size(87, 24);
            this.tmiViewJFIFile.Text = "X";
            this.tmiViewJFIFile.Click += new System.EventHandler(this.tmiViewJFIFile_Click);
            // 
            // tmiRefreshFiles
            // 
            this.tmiRefreshFiles.Name = "tmiRefreshFiles";
            this.tmiRefreshFiles.Size = new System.Drawing.Size(87, 24);
            this.tmiRefreshFiles.Text = "X";
            this.tmiRefreshFiles.Click += new System.EventHandler(this.tmiRefreshFiles_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(84, 6);
            // 
            // tmiExpandAll
            // 
            this.tmiExpandAll.Name = "tmiExpandAll";
            this.tmiExpandAll.Size = new System.Drawing.Size(87, 24);
            this.tmiExpandAll.Text = "X";
            this.tmiExpandAll.Click += new System.EventHandler(this.tmiExpandAll_Click);
            // 
            // tmiCollapseAll
            // 
            this.tmiCollapseAll.Name = "tmiCollapseAll";
            this.tmiCollapseAll.Size = new System.Drawing.Size(87, 24);
            this.tmiCollapseAll.Text = "X";
            this.tmiCollapseAll.Click += new System.EventHandler(this.tmiCollapseAll_Click);
            // 
            // cmsJsonFileSelected
            // 
            this.cmsJsonFileSelected.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsJsonFileSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiOpenJsonFile,
            this.tmiViewJsonFile,
            this.tmiRenameJsonFile,
            this.tmiDeleteJsonFile,
            this.tmiCloseJsonFile,
            this.toolStripMenuItem5,
            this.tmiAddColumn});
            this.cmsJsonFileSelected.Name = "cmsMain";
            this.cmsJsonFileSelected.Size = new System.Drawing.Size(88, 154);
            // 
            // tmiOpenJsonFile
            // 
            this.tmiOpenJsonFile.Name = "tmiOpenJsonFile";
            this.tmiOpenJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiOpenJsonFile.Text = "X";
            this.tmiOpenJsonFile.Click += new System.EventHandler(this.tmiOpenJsonFile_Click);
            // 
            // tmiViewJsonFile
            // 
            this.tmiViewJsonFile.Name = "tmiViewJsonFile";
            this.tmiViewJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiViewJsonFile.Text = "X";
            this.tmiViewJsonFile.Click += new System.EventHandler(this.tmiViewJsonFile_Click);
            // 
            // tmiRenameJsonFile
            // 
            this.tmiRenameJsonFile.Name = "tmiRenameJsonFile";
            this.tmiRenameJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiRenameJsonFile.Text = "X";
            this.tmiRenameJsonFile.Click += new System.EventHandler(this.tmiRenameJsonFile_Click);
            // 
            // tmiDeleteJsonFile
            // 
            this.tmiDeleteJsonFile.Name = "tmiDeleteJsonFile";
            this.tmiDeleteJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiDeleteJsonFile.Text = "X";
            this.tmiDeleteJsonFile.Click += new System.EventHandler(this.tmiDeleteJsonFile_Click);
            // 
            // tmiCloseJsonFile
            // 
            this.tmiCloseJsonFile.Enabled = false;
            this.tmiCloseJsonFile.Name = "tmiCloseJsonFile";
            this.tmiCloseJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiCloseJsonFile.Text = "X";
            this.tmiCloseJsonFile.Click += new System.EventHandler(this.tmiCloseJsonFile_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(84, 6);
            // 
            // tmiAddColumn
            // 
            this.tmiAddColumn.Name = "tmiAddColumn";
            this.tmiAddColumn.Size = new System.Drawing.Size(87, 24);
            this.tmiAddColumn.Text = "X";
            this.tmiAddColumn.Click += new System.EventHandler(this.tmiAddColumn_Click);
            // 
            // cmsColumnSelected
            // 
            this.cmsColumnSelected.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsColumnSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiRenameColumn,
            this.tmiColumnShowOnList,
            this.tmiDeleteColumn,
            this.toolStripMenuItem7,
            this.tmiColumnMoveUp,
            this.tmiColumnMoveDown});
            this.cmsColumnSelected.Name = "cmsMain";
            this.cmsColumnSelected.Size = new System.Drawing.Size(88, 130);
            // 
            // tmiRenameColumn
            // 
            this.tmiRenameColumn.Name = "tmiRenameColumn";
            this.tmiRenameColumn.Size = new System.Drawing.Size(87, 24);
            this.tmiRenameColumn.Text = "X";
            this.tmiRenameColumn.Click += new System.EventHandler(this.tmiRenameColumn_Click);
            // 
            // tmiColumnShowOnList
            // 
            this.tmiColumnShowOnList.Name = "tmiColumnShowOnList";
            this.tmiColumnShowOnList.Size = new System.Drawing.Size(87, 24);
            this.tmiColumnShowOnList.Text = "X";
            this.tmiColumnShowOnList.Click += new System.EventHandler(this.tmiColumnShowOnList_Click);
            // 
            // tmiDeleteColumn
            // 
            this.tmiDeleteColumn.Name = "tmiDeleteColumn";
            this.tmiDeleteColumn.Size = new System.Drawing.Size(87, 24);
            this.tmiDeleteColumn.Text = "X";
            this.tmiDeleteColumn.Click += new System.EventHandler(this.tmiDeleteColumn_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(84, 6);
            // 
            // tmiColumnMoveUp
            // 
            this.tmiColumnMoveUp.Name = "tmiColumnMoveUp";
            this.tmiColumnMoveUp.Size = new System.Drawing.Size(87, 24);
            this.tmiColumnMoveUp.Text = "X";
            this.tmiColumnMoveUp.Click += new System.EventHandler(this.tmiColumnMoveUp_Click);
            // 
            // tmiColumnMoveDown
            // 
            this.tmiColumnMoveDown.Name = "tmiColumnMoveDown";
            this.tmiColumnMoveDown.Size = new System.Drawing.Size(87, 24);
            this.tmiColumnMoveDown.Text = "X";
            this.tmiColumnMoveDown.Click += new System.EventHandler(this.tmiColumnMoveDown_Click);
            // 
            // btnNewLine
            // 
            this.btnNewLine.Enabled = false;
            this.btnNewLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLine.Location = new System.Drawing.Point(714, 764);
            this.btnNewLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewLine.Name = "btnNewLine";
            this.btnNewLine.Size = new System.Drawing.Size(122, 40);
            this.btnNewLine.TabIndex = 26;
            this.btnNewLine.Text = "-";
            this.btnNewLine.UseVisualStyleBackColor = true;
            this.btnNewLine.Click += new System.EventHandler(this.btnNewLine_Click);
            // 
            // btnDeleteLine
            // 
            this.btnDeleteLine.Enabled = false;
            this.btnDeleteLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLine.Location = new System.Drawing.Point(429, 764);
            this.btnDeleteLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteLine.Name = "btnDeleteLine";
            this.btnDeleteLine.Size = new System.Drawing.Size(122, 40);
            this.btnDeleteLine.TabIndex = 27;
            this.btnDeleteLine.Text = "-";
            this.btnDeleteLine.UseVisualStyleBackColor = true;
            this.btnDeleteLine.Click += new System.EventHandler(this.btnDeleteLine_Click);
            // 
            // btnLineMoveUp
            // 
            this.btnLineMoveUp.Enabled = false;
            this.btnLineMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineMoveUp.ImageIndex = 4;
            this.btnLineMoveUp.ImageList = this.imlMain;
            this.btnLineMoveUp.Location = new System.Drawing.Point(656, 764);
            this.btnLineMoveUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnLineMoveUp.Name = "btnLineMoveUp";
            this.btnLineMoveUp.Size = new System.Drawing.Size(50, 40);
            this.btnLineMoveUp.TabIndex = 28;
            this.btnLineMoveUp.Text = "-";
            this.btnLineMoveUp.UseVisualStyleBackColor = true;
            this.btnLineMoveUp.Click += new System.EventHandler(this.btnLineMoveUp_Click);
            // 
            // btnLineMoveDown
            // 
            this.btnLineMoveDown.Enabled = false;
            this.btnLineMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineMoveDown.ImageIndex = 5;
            this.btnLineMoveDown.ImageList = this.imlMain;
            this.btnLineMoveDown.Location = new System.Drawing.Point(564, 764);
            this.btnLineMoveDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnLineMoveDown.Name = "btnLineMoveDown";
            this.btnLineMoveDown.Size = new System.Drawing.Size(50, 40);
            this.btnLineMoveDown.TabIndex = 29;
            this.btnLineMoveDown.Text = "-";
            this.btnLineMoveDown.UseVisualStyleBackColor = true;
            this.btnLineMoveDown.Click += new System.EventHandler(this.btnLineMoveDown_Click);
            // 
            // ckbQuickCheck
            // 
            this.ckbQuickCheck.AutoSize = true;
            this.ckbQuickCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbQuickCheck.Location = new System.Drawing.Point(1258, 776);
            this.ckbQuickCheck.Name = "ckbQuickCheck";
            this.ckbQuickCheck.Size = new System.Drawing.Size(35, 21);
            this.ckbQuickCheck.TabIndex = 30;
            this.ckbQuickCheck.Text = "-";
            this.ckbQuickCheck.UseVisualStyleBackColor = true;
            this.ckbQuickCheck.CheckedChanged += new System.EventHandler(this.ckbQuickCheck_CheckedChanged);
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AllowUserToOrderColumns = true;
            this.dgvLines.AllowUserToResizeColumns = false;
            this.dgvLines.AllowUserToResizeRows = false;
            this.dgvLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Location = new System.Drawing.Point(429, 98);
            this.dgvLines.MultiSelect = false;
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.RowTemplate.Height = 18;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.ShowEditingIcon = false;
            this.dgvLines.Size = new System.Drawing.Size(407, 659);
            this.dgvLines.TabIndex = 31;
            this.dgvLines.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLines_CellFormatting);
            this.dgvLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvLines_DataBindingComplete);
            this.dgvLines.SelectionChanged += new System.EventHandler(this.dgvLines_SelectionChanged);
            this.dgvLines.Sorted += new System.EventHandler(this.dgvLines_Sorted);
            // 
            // cobFindColumnName
            // 
            this.cobFindColumnName.DisplayMember = "Name";
            this.cobFindColumnName.FormattingEnabled = true;
            this.cobFindColumnName.Location = new System.Drawing.Point(428, 68);
            this.cobFindColumnName.Name = "cobFindColumnName";
            this.cobFindColumnName.Size = new System.Drawing.Size(145, 24);
            this.cobFindColumnName.TabIndex = 32;
            this.cobFindColumnName.ValueMember = "Name";
            // 
            // txtFindValue
            // 
            this.txtFindValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindValue.Location = new System.Drawing.Point(579, 67);
            this.txtFindValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtFindValue.Name = "txtFindValue";
            this.txtFindValue.Size = new System.Drawing.Size(213, 27);
            this.txtFindValue.TabIndex = 33;
            this.txtFindValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFindValue.Click += new System.EventHandler(this.txtFindValue_Click);
            // 
            // btnFindConfirm
            // 
            this.btnFindConfirm.Enabled = false;
            this.btnFindConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindConfirm.ImageIndex = 6;
            this.btnFindConfirm.ImageList = this.imlMain;
            this.btnFindConfirm.Location = new System.Drawing.Point(796, 66);
            this.btnFindConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnFindConfirm.Name = "btnFindConfirm";
            this.btnFindConfirm.Size = new System.Drawing.Size(41, 29);
            this.btnFindConfirm.TabIndex = 34;
            this.btnFindConfirm.UseVisualStyleBackColor = true;
            this.btnFindConfirm.Click += new System.EventHandler(this.btnFindConfirm_Click);
            // 
            // dtpMain
            // 
            this.dtpMain.AutoSize = true;
            this.dtpMain.BackColor = System.Drawing.SystemColors.Window;
            this.dtpMain.BindingControl = null;
            this.dtpMain.Location = new System.Drawing.Point(4, 4);
            this.dtpMain.Margin = new System.Windows.Forms.Padding(4);
            this.dtpMain.Name = "dtpMain";
            this.dtpMain.Size = new System.Drawing.Size(406, 78);
            this.dtpMain.Style = JsonEditorV2.DateTimePickerStyle.DateTime;
            this.dtpMain.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1509, 832);
            this.Controls.Add(this.btnFindConfirm);
            this.Controls.Add(this.txtFindValue);
            this.Controls.Add(this.cobFindColumnName);
            this.Controls.Add(this.dgvLines);
            this.Controls.Add(this.ckbQuickCheck);
            this.Controls.Add(this.btnLineMoveDown);
            this.Controls.Add(this.btnLineMoveUp);
            this.Controls.Add(this.btnDeleteLine);
            this.Controls.Add(this.btnNewLine);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.mnsMain);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.btnClearColumn);
            this.Controls.Add(this.btnClearMain);
            this.Controls.Add(this.btnUpdateMain);
            this.Controls.Add(this.btnUpdateColumn);
            this.Controls.Add(this.pnlFileInfo);
            this.Controls.Add(this.trvJsonFiles);
            this.Controls.Add(this.stsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlFileInfo.ResumeLayout(false);
            this.pnlFileInfo.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.tbcMain.ResumeLayout(false);
            this.cmsTabSelected.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlDateTimePicker.ResumeLayout(false);
            this.pnlDateTimePicker.PerformLayout();
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.cmsJsonFiles.ResumeLayout(false);
            this.cmsJsonFileSelected.ResumeLayout(false);
            this.cmsColumnSelected.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearColumn;
        private System.Windows.Forms.Button btnClearMain;
        private System.Windows.Forms.Button btnUpdateMain;
        private System.Windows.Forms.Button btnUpdateColumn;
        private System.Windows.Forms.Panel pnlFileInfo;
        private System.Windows.Forms.TextBox txtColumnNumberOfRows;
        private System.Windows.Forms.Label lblColumnNumberOfRows;
        private System.Windows.Forms.CheckBox ckbColumnDisplay;
        private System.Windows.Forms.CheckBox ckbColumnIsKey;
        private System.Windows.Forms.ComboBox cobColumnType;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Label lblColumnFKTable;
        private System.Windows.Forms.Label lblColumnDisplay;
        private System.Windows.Forms.Label lblColumnIsKey;
        private System.Windows.Forms.Label lblColumnType;
        private System.Windows.Forms.Label lblColumnName;
        private System.Windows.Forms.TreeView trvJsonFiles;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel sslMain;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem tmiFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tmiLoadJsonFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tmiSaveJsonFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tmiCloseAllFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tmiExit;
        private System.Windows.Forms.ToolStripMenuItem tmiAbout;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.FolderBrowserDialog fbdMain;
        private System.Windows.Forms.ImageList imlMain;
        private System.Windows.Forms.ContextMenuStrip cmsJsonFiles;
        private System.Windows.Forms.ToolStripMenuItem tmiNewJsonFile;
        private System.Windows.Forms.ContextMenuStrip cmsJsonFileSelected;
        private System.Windows.Forms.ToolStripMenuItem tmiOpenJsonFile;
        private System.Windows.Forms.ToolStripMenuItem tmiRenameJsonFile;
        private System.Windows.Forms.ToolStripMenuItem tmiCloseJsonFile;
        private System.Windows.Forms.ToolStripMenuItem tmiDeleteJsonFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tmiAddColumn;
        private System.Windows.Forms.ToolStripMenuItem tmiNewJsonFiles;
        private System.Windows.Forms.ToolStripMenuItem tmiScanJsonFiles;
        private System.Windows.Forms.ToolStripMenuItem tmiBackup;
        private System.Windows.Forms.ComboBox cobColumnFKTable;
        private System.Windows.Forms.ComboBox cobColumnFKColumn;
        private System.Windows.Forms.Label lblColumnFKColumn;
        private System.Windows.Forms.ToolStripMenuItem tmiLanguages;
        private System.Windows.Forms.ToolStripMenuItem tmiLanguageZHTW;
        private System.Windows.Forms.ToolStripMenuItem tmiLanguageENUS;
        private System.Windows.Forms.ToolStripMenuItem tmiSaveAsJsonFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem tmiExpandAll;
        private System.Windows.Forms.ToolStripMenuItem tmiCollapseAll;
        private System.Windows.Forms.ContextMenuStrip cmsColumnSelected;
        private System.Windows.Forms.ToolStripMenuItem tmiDeleteColumn;
        private System.Windows.Forms.Button btnNewLine;
        private System.Windows.Forms.TabPage tbpStart;
        private System.Windows.Forms.ContextMenuStrip cmsTabSelected;
        private System.Windows.Forms.ToolStripMenuItem tmiCloseTab;
        private System.Windows.Forms.Button btnDeleteLine;
        private System.Windows.Forms.ToolStripMenuItem tmiColumnMoveUp;
        private System.Windows.Forms.ToolStripMenuItem tmiColumnMoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.TextBox txtColumnRegex;
        private System.Windows.Forms.Label lblColumnRegex;
        private System.Windows.Forms.CheckBox ckbColumnIsNullable;
        private System.Windows.Forms.Label lblColumnlIsNullable;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem tmiOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tmiViewJsonFile;
        private System.Windows.Forms.Label lblColumnDescription;
        private System.Windows.Forms.TextBox txtColumnMaxValue;
        private System.Windows.Forms.TextBox txtColumnMinValue;
        private System.Windows.Forms.Label lblColumnMaxValue;
        private System.Windows.Forms.Label lblColumnMinValue;
        private System.Windows.Forms.ToolStripMenuItem tmiViewJFIFile;
        private System.Windows.Forms.ToolStripMenuItem tmiRefreshFiles;
        private System.Windows.Forms.ToolStripMenuItem tmiRenameColumn;
        private System.Windows.Forms.Button btnLineMoveUp;
        private System.Windows.Forms.Button btnLineMoveDown;
        private System.Windows.Forms.TextBox txtColumnMaxLength;
        private System.Windows.Forms.Label lblColumnMaxLength;
        private System.Windows.Forms.CheckBox ckbColumnIsUnique;
        private System.Windows.Forms.Label lblColumnIsUnique;
        private System.Windows.Forms.TextBox txtColumnDescription;
        private System.Windows.Forms.CheckBox ckbQuickCheck;
        private System.Windows.Forms.ToolStripMenuItem tmiJsonEditorBackup;
        private System.Windows.Forms.ToolStripMenuItem tmiTestDataBackup;
        private System.Windows.Forms.ToolStripMenuItem tmiAritiafelBackup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem tmiRunSomething;
        private System.Windows.Forms.ToolStripMenuItem tmiLanguageZHCN;
        private System.Windows.Forms.CheckBox ckbColumnAutoGenerateKey;
        private System.Windows.Forms.Label lblAutoGenerateKey;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.ComboBox cobFindColumnName;
        private System.Windows.Forms.TextBox txtFindValue;
        private System.Windows.Forms.Button btnFindConfirm;
        private System.Windows.Forms.ToolStripMenuItem tmiColumnShowOnList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem tmiRenameDatabase;
        private System.Windows.Forms.Label lblColumnChoicesCount;
        private System.Windows.Forms.Button btnColumnEditChoices;
        private System.Windows.Forms.Label lblColumnChoices;
        private System.Windows.Forms.Label lblColumnChoiceName;
        private System.Windows.Forms.Panel pnlDateTimePicker;
        private SimpleDateTimePicker dtpMain;
    }
}

