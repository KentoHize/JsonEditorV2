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
            this.btnHelpDefaultValue = new System.Windows.Forms.Button();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.lblDefalutValue = new System.Windows.Forms.Label();
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
            this.lblColumnIsNullable = new System.Windows.Forms.Label();
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
            this.dtpMain = new JsonEditorV2.SimpleDateTimePicker();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.tmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiNewJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiScanJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiScan = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiScanCSVFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLoadJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiSaveJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSaveAsJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCloseAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExportFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiExportToCsvFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiExportToXmlFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExportToCSFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiPrintList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLatestFolderStart = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSortList = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLanguages = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLanguageENUS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiLanguageZHCN = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLanguageZHTW = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiArinaYear = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiJsonEditorBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiTestDataBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAritiafelBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiRunSomething = new System.Windows.Forms.ToolStripMenuItem();
            this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
            this.cmsJsonFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiNewJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRenameDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiEditDatabaseDescription = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tmiExportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiExportCsvFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiExportXmlFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExportCSFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExportToLangaugeFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCloseJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiEditSortInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiClearSortInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiAddIDColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAddColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiDisplayAllColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiInsertFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsColumnSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiRenameColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiColumnShowOnList = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiColumnMoveTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiColumnMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiColumnMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiColumnMoveBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewLine = new System.Windows.Forms.Button();
            this.btnDeleteLine = new System.Windows.Forms.Button();
            this.btnLineMoveUp = new System.Windows.Forms.Button();
            this.btnLineMoveDown = new System.Windows.Forms.Button();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.cobFindColumnName = new System.Windows.Forms.ComboBox();
            this.txtFindValue = new System.Windows.Forms.TextBox();
            this.btnFindConfirm = new System.Windows.Forms.Button();
            this.btnCopyLine = new System.Windows.Forms.Button();
            this.tltMain = new System.Windows.Forms.ToolTip(this.components);
            this.sfdMain = new System.Windows.Forms.SaveFileDialog();
            this.btnRegenerateKey = new System.Windows.Forms.Button();
            this.cobCheckMethod = new System.Windows.Forms.ComboBox();
            this.lblCheckMethod = new System.Windows.Forms.Label();
            this.prdMain = new System.Windows.Forms.PrintDialog();
            this.btnResetValue = new System.Windows.Forms.Button();
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
            this.btnClearColumn.Location = new System.Drawing.Point(1, 716);
            this.btnClearColumn.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearColumn.Name = "btnClearColumn";
            this.btnClearColumn.Size = new System.Drawing.Size(75, 38);
            this.btnClearColumn.TabIndex = 19;
            this.btnClearColumn.Text = "-";
            this.btnClearColumn.UseVisualStyleBackColor = true;
            this.btnClearColumn.Click += new System.EventHandler(this.btnClearColumn_Click);
            // 
            // btnClearMain
            // 
            this.btnClearMain.Enabled = false;
            this.btnClearMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearMain.Location = new System.Drawing.Point(840, 716);
            this.btnClearMain.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearMain.Name = "btnClearMain";
            this.btnClearMain.Size = new System.Drawing.Size(122, 38);
            this.btnClearMain.TabIndex = 18;
            this.btnClearMain.Text = "-";
            this.btnClearMain.UseVisualStyleBackColor = true;
            this.btnClearMain.Click += new System.EventHandler(this.btnClearMain_Click);
            // 
            // btnUpdateMain
            // 
            this.btnUpdateMain.Enabled = false;
            this.btnUpdateMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateMain.Location = new System.Drawing.Point(1383, 716);
            this.btnUpdateMain.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateMain.Name = "btnUpdateMain";
            this.btnUpdateMain.Size = new System.Drawing.Size(122, 38);
            this.btnUpdateMain.TabIndex = 17;
            this.btnUpdateMain.Text = "-";
            this.btnUpdateMain.UseVisualStyleBackColor = true;
            this.btnUpdateMain.Click += new System.EventHandler(this.btnUpdateMain_Click);
            // 
            // btnUpdateColumn
            // 
            this.btnUpdateColumn.Enabled = false;
            this.btnUpdateColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateColumn.Location = new System.Drawing.Point(332, 716);
            this.btnUpdateColumn.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateColumn.Name = "btnUpdateColumn";
            this.btnUpdateColumn.Size = new System.Drawing.Size(90, 38);
            this.btnUpdateColumn.TabIndex = 16;
            this.btnUpdateColumn.Text = "-";
            this.btnUpdateColumn.UseVisualStyleBackColor = true;
            this.btnUpdateColumn.Click += new System.EventHandler(this.btnUpdateColumn_Click);
            // 
            // pnlFileInfo
            // 
            this.pnlFileInfo.AutoScroll = true;
            this.pnlFileInfo.Controls.Add(this.btnHelpDefaultValue);
            this.pnlFileInfo.Controls.Add(this.txtDefaultValue);
            this.pnlFileInfo.Controls.Add(this.lblDefalutValue);
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
            this.pnlFileInfo.Controls.Add(this.lblColumnIsNullable);
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
            this.pnlFileInfo.Location = new System.Drawing.Point(1, 406);
            this.pnlFileInfo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFileInfo.Name = "pnlFileInfo";
            this.pnlFileInfo.Size = new System.Drawing.Size(420, 304);
            this.pnlFileInfo.TabIndex = 15;
            // 
            // btnHelpDefaultValue
            // 
            this.btnHelpDefaultValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelpDefaultValue.Location = new System.Drawing.Point(168, 510);
            this.btnHelpDefaultValue.Name = "btnHelpDefaultValue";
            this.btnHelpDefaultValue.Size = new System.Drawing.Size(27, 27);
            this.btnHelpDefaultValue.TabIndex = 40;
            this.btnHelpDefaultValue.Text = "?";
            this.btnHelpDefaultValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHelpDefaultValue.UseVisualStyleBackColor = true;
            this.btnHelpDefaultValue.Click += new System.EventHandler(this.btnHelpDefaultValue_Click);
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefaultValue.Location = new System.Drawing.Point(199, 510);
            this.txtDefaultValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(184, 27);
            this.txtDefaultValue.TabIndex = 76;
            this.txtDefaultValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDefaultValue.Enter += new System.EventHandler(this.txtDefaultValue_Enter);
            this.txtDefaultValue.Leave += new System.EventHandler(this.txtDefaultValue_Leave);
            // 
            // lblDefalutValue
            // 
            this.lblDefalutValue.AutoSize = true;
            this.lblDefalutValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefalutValue.Location = new System.Drawing.Point(10, 513);
            this.lblDefalutValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefalutValue.Name = "lblDefalutValue";
            this.lblDefalutValue.Size = new System.Drawing.Size(15, 20);
            this.lblDefalutValue.TabIndex = 75;
            this.lblDefalutValue.Text = "-";
            // 
            // lblColumnChoiceName
            // 
            this.lblColumnChoiceName.AutoSize = true;
            this.lblColumnChoiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnChoiceName.Location = new System.Drawing.Point(239, 84);
            this.lblColumnChoiceName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnChoiceName.Name = "lblColumnChoiceName";
            this.lblColumnChoiceName.Size = new System.Drawing.Size(15, 20);
            this.lblColumnChoiceName.TabIndex = 74;
            this.lblColumnChoiceName.Text = "-";
            // 
            // lblColumnChoicesCount
            // 
            this.lblColumnChoicesCount.AutoSize = true;
            this.lblColumnChoicesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnChoicesCount.Location = new System.Drawing.Point(201, 84);
            this.lblColumnChoicesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnChoicesCount.Name = "lblColumnChoicesCount";
            this.lblColumnChoicesCount.Size = new System.Drawing.Size(15, 20);
            this.lblColumnChoicesCount.TabIndex = 73;
            this.lblColumnChoicesCount.Text = "-";
            // 
            // btnColumnEditChoices
            // 
            this.btnColumnEditChoices.Enabled = false;
            this.btnColumnEditChoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColumnEditChoices.Location = new System.Drawing.Point(335, 81);
            this.btnColumnEditChoices.Margin = new System.Windows.Forms.Padding(4);
            this.btnColumnEditChoices.Name = "btnColumnEditChoices";
            this.btnColumnEditChoices.Size = new System.Drawing.Size(50, 33);
            this.btnColumnEditChoices.TabIndex = 72;
            this.btnColumnEditChoices.Text = "...";
            this.btnColumnEditChoices.UseVisualStyleBackColor = true;
            this.btnColumnEditChoices.Click += new System.EventHandler(this.btnColumnEditChoices_Click);
            // 
            // lblColumnChoices
            // 
            this.lblColumnChoices.AutoSize = true;
            this.lblColumnChoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnChoices.Location = new System.Drawing.Point(10, 84);
            this.lblColumnChoices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnChoices.Name = "lblColumnChoices";
            this.lblColumnChoices.Size = new System.Drawing.Size(15, 20);
            this.lblColumnChoices.TabIndex = 71;
            this.lblColumnChoices.Text = "-";
            // 
            // ckbColumnAutoGenerateKey
            // 
            this.ckbColumnAutoGenerateKey.AutoSize = true;
            this.ckbColumnAutoGenerateKey.Location = new System.Drawing.Point(363, 416);
            this.ckbColumnAutoGenerateKey.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnAutoGenerateKey.Name = "ckbColumnAutoGenerateKey";
            this.ckbColumnAutoGenerateKey.Size = new System.Drawing.Size(18, 17);
            this.ckbColumnAutoGenerateKey.TabIndex = 70;
            this.ckbColumnAutoGenerateKey.UseVisualStyleBackColor = true;
            this.ckbColumnAutoGenerateKey.CheckedChanged += new System.EventHandler(this.ckbAutoGenerateKey_CheckedChanged);
            // 
            // lblAutoGenerateKey
            // 
            this.lblAutoGenerateKey.AutoSize = true;
            this.lblAutoGenerateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoGenerateKey.Location = new System.Drawing.Point(10, 414);
            this.lblAutoGenerateKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutoGenerateKey.Name = "lblAutoGenerateKey";
            this.lblAutoGenerateKey.Size = new System.Drawing.Size(15, 20);
            this.lblAutoGenerateKey.TabIndex = 69;
            this.lblAutoGenerateKey.Text = "-";
            // 
            // ckbColumnIsUnique
            // 
            this.ckbColumnIsUnique.AutoSize = true;
            this.ckbColumnIsUnique.Location = new System.Drawing.Point(363, 383);
            this.ckbColumnIsUnique.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnIsUnique.Name = "ckbColumnIsUnique";
            this.ckbColumnIsUnique.Size = new System.Drawing.Size(18, 17);
            this.ckbColumnIsUnique.TabIndex = 68;
            this.ckbColumnIsUnique.UseVisualStyleBackColor = true;
            // 
            // lblColumnIsUnique
            // 
            this.lblColumnIsUnique.AutoSize = true;
            this.lblColumnIsUnique.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnIsUnique.Location = new System.Drawing.Point(10, 381);
            this.lblColumnIsUnique.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnIsUnique.Name = "lblColumnIsUnique";
            this.lblColumnIsUnique.Size = new System.Drawing.Size(15, 20);
            this.lblColumnIsUnique.TabIndex = 67;
            this.lblColumnIsUnique.Text = "-";
            // 
            // txtColumnMaxLength
            // 
            this.txtColumnMaxLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnMaxLength.Location = new System.Drawing.Point(199, 345);
            this.txtColumnMaxLength.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnMaxLength.Name = "txtColumnMaxLength";
            this.txtColumnMaxLength.Size = new System.Drawing.Size(184, 27);
            this.txtColumnMaxLength.TabIndex = 66;
            this.txtColumnMaxLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnMaxLength
            // 
            this.lblColumnMaxLength.AutoSize = true;
            this.lblColumnMaxLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnMaxLength.Location = new System.Drawing.Point(10, 348);
            this.lblColumnMaxLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnMaxLength.Name = "lblColumnMaxLength";
            this.lblColumnMaxLength.Size = new System.Drawing.Size(15, 20);
            this.lblColumnMaxLength.TabIndex = 65;
            this.lblColumnMaxLength.Text = "-";
            // 
            // lblColumnDescription
            // 
            this.lblColumnDescription.AutoSize = true;
            this.lblColumnDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnDescription.Location = new System.Drawing.Point(10, 546);
            this.lblColumnDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnDescription.Name = "lblColumnDescription";
            this.lblColumnDescription.Size = new System.Drawing.Size(15, 20);
            this.lblColumnDescription.TabIndex = 64;
            this.lblColumnDescription.Text = "-";
            // 
            // txtColumnDescription
            // 
            this.txtColumnDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnDescription.Location = new System.Drawing.Point(199, 546);
            this.txtColumnDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnDescription.Name = "txtColumnDescription";
            this.txtColumnDescription.Size = new System.Drawing.Size(184, 27);
            this.txtColumnDescription.TabIndex = 63;
            this.txtColumnDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtColumnMaxValue
            // 
            this.txtColumnMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnMaxValue.Location = new System.Drawing.Point(199, 279);
            this.txtColumnMaxValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnMaxValue.Name = "txtColumnMaxValue";
            this.txtColumnMaxValue.Size = new System.Drawing.Size(184, 27);
            this.txtColumnMaxValue.TabIndex = 62;
            this.txtColumnMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtColumnMinValue
            // 
            this.txtColumnMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnMinValue.Location = new System.Drawing.Point(199, 246);
            this.txtColumnMinValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnMinValue.Name = "txtColumnMinValue";
            this.txtColumnMinValue.Size = new System.Drawing.Size(184, 27);
            this.txtColumnMinValue.TabIndex = 61;
            this.txtColumnMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnMaxValue
            // 
            this.lblColumnMaxValue.AutoSize = true;
            this.lblColumnMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnMaxValue.Location = new System.Drawing.Point(10, 282);
            this.lblColumnMaxValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnMaxValue.Name = "lblColumnMaxValue";
            this.lblColumnMaxValue.Size = new System.Drawing.Size(15, 20);
            this.lblColumnMaxValue.TabIndex = 60;
            this.lblColumnMaxValue.Text = "-";
            // 
            // lblColumnMinValue
            // 
            this.lblColumnMinValue.AutoSize = true;
            this.lblColumnMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnMinValue.Location = new System.Drawing.Point(10, 249);
            this.lblColumnMinValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnMinValue.Name = "lblColumnMinValue";
            this.lblColumnMinValue.Size = new System.Drawing.Size(15, 20);
            this.lblColumnMinValue.TabIndex = 59;
            this.lblColumnMinValue.Text = "-";
            // 
            // ckbColumnIsNullable
            // 
            this.ckbColumnIsNullable.AutoSize = true;
            this.ckbColumnIsNullable.Location = new System.Drawing.Point(363, 152);
            this.ckbColumnIsNullable.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnIsNullable.Name = "ckbColumnIsNullable";
            this.ckbColumnIsNullable.Size = new System.Drawing.Size(18, 17);
            this.ckbColumnIsNullable.TabIndex = 58;
            this.ckbColumnIsNullable.UseVisualStyleBackColor = true;
            // 
            // lblColumnIsNullable
            // 
            this.lblColumnIsNullable.AutoSize = true;
            this.lblColumnIsNullable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnIsNullable.Location = new System.Drawing.Point(10, 150);
            this.lblColumnIsNullable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnIsNullable.Name = "lblColumnIsNullable";
            this.lblColumnIsNullable.Size = new System.Drawing.Size(15, 20);
            this.lblColumnIsNullable.TabIndex = 57;
            this.lblColumnIsNullable.Text = "-";
            // 
            // txtColumnRegex
            // 
            this.txtColumnRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnRegex.Location = new System.Drawing.Point(199, 312);
            this.txtColumnRegex.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnRegex.Name = "txtColumnRegex";
            this.txtColumnRegex.Size = new System.Drawing.Size(184, 27);
            this.txtColumnRegex.TabIndex = 56;
            this.txtColumnRegex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnRegex
            // 
            this.lblColumnRegex.AutoSize = true;
            this.lblColumnRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnRegex.Location = new System.Drawing.Point(10, 315);
            this.lblColumnRegex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnRegex.Name = "lblColumnRegex";
            this.lblColumnRegex.Size = new System.Drawing.Size(15, 20);
            this.lblColumnRegex.TabIndex = 55;
            this.lblColumnRegex.Text = "-";
            // 
            // cobColumnFKColumn
            // 
            this.cobColumnFKColumn.DisplayMember = "Name";
            this.cobColumnFKColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobColumnFKColumn.FormattingEnabled = true;
            this.cobColumnFKColumn.Location = new System.Drawing.Point(199, 476);
            this.cobColumnFKColumn.Margin = new System.Windows.Forms.Padding(4);
            this.cobColumnFKColumn.Name = "cobColumnFKColumn";
            this.cobColumnFKColumn.Size = new System.Drawing.Size(184, 28);
            this.cobColumnFKColumn.TabIndex = 54;
            this.cobColumnFKColumn.ValueMember = "Name";
            this.cobColumnFKColumn.SelectedIndexChanged += new System.EventHandler(this.cobColumnFKColumn_SelectedIndexChanged);
            // 
            // lblColumnFKColumn
            // 
            this.lblColumnFKColumn.AutoSize = true;
            this.lblColumnFKColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnFKColumn.Location = new System.Drawing.Point(10, 480);
            this.lblColumnFKColumn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnFKColumn.Name = "lblColumnFKColumn";
            this.lblColumnFKColumn.Size = new System.Drawing.Size(15, 20);
            this.lblColumnFKColumn.TabIndex = 53;
            this.lblColumnFKColumn.Text = "-";
            // 
            // cobColumnFKTable
            // 
            this.cobColumnFKTable.DisplayMember = "Name";
            this.cobColumnFKTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobColumnFKTable.FormattingEnabled = true;
            this.cobColumnFKTable.Location = new System.Drawing.Point(199, 443);
            this.cobColumnFKTable.Margin = new System.Windows.Forms.Padding(4);
            this.cobColumnFKTable.Name = "cobColumnFKTable";
            this.cobColumnFKTable.Size = new System.Drawing.Size(184, 28);
            this.cobColumnFKTable.TabIndex = 52;
            this.cobColumnFKTable.ValueMember = "Name";
            this.cobColumnFKTable.SelectedIndexChanged += new System.EventHandler(this.cobColumnFKTable_SelectedIndexChanged);
            // 
            // txtColumnNumberOfRows
            // 
            this.txtColumnNumberOfRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnNumberOfRows.Location = new System.Drawing.Point(345, 213);
            this.txtColumnNumberOfRows.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnNumberOfRows.Name = "txtColumnNumberOfRows";
            this.txtColumnNumberOfRows.Size = new System.Drawing.Size(36, 27);
            this.txtColumnNumberOfRows.TabIndex = 51;
            this.txtColumnNumberOfRows.Text = "0";
            this.txtColumnNumberOfRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnNumberOfRows
            // 
            this.lblColumnNumberOfRows.AutoSize = true;
            this.lblColumnNumberOfRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnNumberOfRows.Location = new System.Drawing.Point(10, 216);
            this.lblColumnNumberOfRows.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnNumberOfRows.Name = "lblColumnNumberOfRows";
            this.lblColumnNumberOfRows.Size = new System.Drawing.Size(15, 20);
            this.lblColumnNumberOfRows.TabIndex = 50;
            this.lblColumnNumberOfRows.Text = "-";
            // 
            // ckbColumnDisplay
            // 
            this.ckbColumnDisplay.AutoSize = true;
            this.ckbColumnDisplay.Location = new System.Drawing.Point(363, 185);
            this.ckbColumnDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnDisplay.Name = "ckbColumnDisplay";
            this.ckbColumnDisplay.Size = new System.Drawing.Size(18, 17);
            this.ckbColumnDisplay.TabIndex = 49;
            this.ckbColumnDisplay.UseVisualStyleBackColor = true;
            // 
            // ckbColumnIsKey
            // 
            this.ckbColumnIsKey.AutoSize = true;
            this.ckbColumnIsKey.Location = new System.Drawing.Point(363, 119);
            this.ckbColumnIsKey.Margin = new System.Windows.Forms.Padding(4);
            this.ckbColumnIsKey.Name = "ckbColumnIsKey";
            this.ckbColumnIsKey.Size = new System.Drawing.Size(18, 17);
            this.ckbColumnIsKey.TabIndex = 43;
            this.ckbColumnIsKey.UseVisualStyleBackColor = true;
            // 
            // cobColumnType
            // 
            this.cobColumnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobColumnType.FormattingEnabled = true;
            this.cobColumnType.Location = new System.Drawing.Point(199, 47);
            this.cobColumnType.Margin = new System.Windows.Forms.Padding(4);
            this.cobColumnType.Name = "cobColumnType";
            this.cobColumnType.Size = new System.Drawing.Size(184, 28);
            this.cobColumnType.TabIndex = 44;
            this.cobColumnType.SelectedIndexChanged += new System.EventHandler(this.cobColumnType_SelectedIndexChanged);
            // 
            // txtColumnName
            // 
            this.txtColumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnName.Location = new System.Drawing.Point(199, 15);
            this.txtColumnName.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(184, 27);
            this.txtColumnName.TabIndex = 41;
            this.txtColumnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnFKTable
            // 
            this.lblColumnFKTable.AutoSize = true;
            this.lblColumnFKTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnFKTable.Location = new System.Drawing.Point(10, 447);
            this.lblColumnFKTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnFKTable.Name = "lblColumnFKTable";
            this.lblColumnFKTable.Size = new System.Drawing.Size(15, 20);
            this.lblColumnFKTable.TabIndex = 48;
            this.lblColumnFKTable.Text = "-";
            // 
            // lblColumnDisplay
            // 
            this.lblColumnDisplay.AutoSize = true;
            this.lblColumnDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnDisplay.Location = new System.Drawing.Point(10, 183);
            this.lblColumnDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnDisplay.Name = "lblColumnDisplay";
            this.lblColumnDisplay.Size = new System.Drawing.Size(15, 20);
            this.lblColumnDisplay.TabIndex = 47;
            this.lblColumnDisplay.Text = "-";
            // 
            // lblColumnIsKey
            // 
            this.lblColumnIsKey.AutoSize = true;
            this.lblColumnIsKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnIsKey.Location = new System.Drawing.Point(10, 117);
            this.lblColumnIsKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnIsKey.Name = "lblColumnIsKey";
            this.lblColumnIsKey.Size = new System.Drawing.Size(15, 20);
            this.lblColumnIsKey.TabIndex = 46;
            this.lblColumnIsKey.Text = "-";
            // 
            // lblColumnType
            // 
            this.lblColumnType.AutoSize = true;
            this.lblColumnType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnType.Location = new System.Drawing.Point(10, 51);
            this.lblColumnType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnType.Name = "lblColumnType";
            this.lblColumnType.Size = new System.Drawing.Size(15, 20);
            this.lblColumnType.TabIndex = 45;
            this.lblColumnType.Text = "-";
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnName.Location = new System.Drawing.Point(10, 18);
            this.lblColumnName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(15, 20);
            this.lblColumnName.TabIndex = 42;
            this.lblColumnName.Text = "-";
            // 
            // trvJsonFiles
            // 
            this.trvJsonFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvJsonFiles.HideSelection = false;
            this.trvJsonFiles.ImageIndex = 0;
            this.trvJsonFiles.ImageList = this.imlMain;
            this.trvJsonFiles.Location = new System.Drawing.Point(1, 29);
            this.trvJsonFiles.Margin = new System.Windows.Forms.Padding(4);
            this.trvJsonFiles.Name = "trvJsonFiles";
            this.trvJsonFiles.SelectedImageIndex = 0;
            this.trvJsonFiles.ShowNodeToolTips = true;
            this.trvJsonFiles.Size = new System.Drawing.Size(420, 372);
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
            this.imlMain.Images.SetKeyName(7, "Copy.png");
            // 
            // stsMain
            // 
            this.stsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslMain});
            this.stsMain.Location = new System.Drawing.Point(0, 758);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(1509, 22);
            this.stsMain.TabIndex = 11;
            this.stsMain.Text = "sspMain";
            // 
            // sslMain
            // 
            this.sslMain.Name = "sslMain";
            this.sslMain.Size = new System.Drawing.Size(0, 16);
            // 
            // tbcMain
            // 
            this.tbcMain.ContextMenuStrip = this.cmsTabSelected;
            this.tbcMain.Controls.Add(this.tbpStart);
            this.tbcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcMain.Location = new System.Drawing.Point(429, 29);
            this.tbcMain.Margin = new System.Windows.Forms.Padding(4);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1071, 29);
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
            this.cmsTabSelected.Size = new System.Drawing.Size(89, 28);
            // 
            // tmiCloseTab
            // 
            this.tmiCloseTab.Name = "tmiCloseTab";
            this.tmiCloseTab.Size = new System.Drawing.Size(88, 24);
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
            this.pnlMain.Location = new System.Drawing.Point(840, 61);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(665, 649);
            this.pnlMain.TabIndex = 21;
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
            // 
            // pnlDateTimePicker
            // 
            this.pnlDateTimePicker.AutoSize = true;
            this.pnlDateTimePicker.BackColor = System.Drawing.Color.White;
            this.pnlDateTimePicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDateTimePicker.Controls.Add(this.dtpMain);
            this.pnlDateTimePicker.Location = new System.Drawing.Point(21, 304);
            this.pnlDateTimePicker.Name = "pnlDateTimePicker";
            this.pnlDateTimePicker.Size = new System.Drawing.Size(569, 104);
            this.pnlDateTimePicker.TabIndex = 0;
            this.pnlDateTimePicker.Visible = false;
            // 
            // dtpMain
            // 
            this.dtpMain.AutoSize = true;
            this.dtpMain.BackColor = System.Drawing.SystemColors.Window;
            this.dtpMain.BindingControl = null;
            this.dtpMain.CanNegative = true;
            this.dtpMain.Location = new System.Drawing.Point(4, 4);
            this.dtpMain.Margin = new System.Windows.Forms.Padding(4);
            this.dtpMain.Name = "dtpMain";
            this.dtpMain.Size = new System.Drawing.Size(435, 78);
            this.dtpMain.Style = JsonEditorV2.DateTimePickerStyle.DateTime;
            this.dtpMain.TabIndex = 0;
            this.dtpMain.UseArinaYear = false;
            // 
            // mnsMain
            // 
            this.mnsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiFile,
            this.tmiFunction,
            this.tmiLanguages,
            this.tmiSetting,
            this.tmiHelp,
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
            this.tmiScan,
            this.tmiLoadJsonFiles,
            this.toolStripMenuItem4,
            this.tmiSaveJsonFiles,
            this.tmiSaveAsJsonFiles,
            this.tmiCloseAllFiles,
            this.toolStripMenuItem2,
            this.tmiExportFiles,
            this.tmiPrintList,
            this.tsmLatestFolderStart,
            this.tmiExit});
            this.tmiFile.Name = "tmiFile";
            this.tmiFile.ShortcutKeyDisplayString = "";
            this.tmiFile.Size = new System.Drawing.Size(33, 24);
            this.tmiFile.Text = "X";
            // 
            // tmiNewJsonFiles
            // 
            this.tmiNewJsonFiles.Name = "tmiNewJsonFiles";
            this.tmiNewJsonFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tmiNewJsonFiles.Size = new System.Drawing.Size(224, 26);
            this.tmiNewJsonFiles.Text = "X";
            this.tmiNewJsonFiles.Click += new System.EventHandler(this.tmiNewJsonFiles_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(221, 6);
            // 
            // tmiScanJsonFiles
            // 
            this.tmiScanJsonFiles.Name = "tmiScanJsonFiles";
            this.tmiScanJsonFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tmiScanJsonFiles.Size = new System.Drawing.Size(224, 26);
            this.tmiScanJsonFiles.Text = "X";
            this.tmiScanJsonFiles.Click += new System.EventHandler(this.tmiScanJsonFiles_Click);
            // 
            // tmiScan
            // 
            this.tmiScan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiScanCSVFiles});
            this.tmiScan.Name = "tmiScan";
            this.tmiScan.Size = new System.Drawing.Size(224, 26);
            this.tmiScan.Text = "X";
            // 
            // tmiScanCSVFiles
            // 
            this.tmiScanCSVFiles.Name = "tmiScanCSVFiles";
            this.tmiScanCSVFiles.Size = new System.Drawing.Size(102, 26);
            this.tmiScanCSVFiles.Text = "X";
            this.tmiScanCSVFiles.Click += new System.EventHandler(this.tmiScanCSVFile_Click);
            // 
            // tmiLoadJsonFiles
            // 
            this.tmiLoadJsonFiles.Name = "tmiLoadJsonFiles";
            this.tmiLoadJsonFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tmiLoadJsonFiles.Size = new System.Drawing.Size(224, 26);
            this.tmiLoadJsonFiles.Text = "X";
            this.tmiLoadJsonFiles.Click += new System.EventHandler(this.tmiLoadJsonFiles_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(221, 6);
            // 
            // tmiSaveJsonFiles
            // 
            this.tmiSaveJsonFiles.Enabled = false;
            this.tmiSaveJsonFiles.Name = "tmiSaveJsonFiles";
            this.tmiSaveJsonFiles.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tmiSaveJsonFiles.Size = new System.Drawing.Size(224, 26);
            this.tmiSaveJsonFiles.Text = "X";
            this.tmiSaveJsonFiles.Click += new System.EventHandler(this.tmiSaveJsonFiles_Click);
            // 
            // tmiSaveAsJsonFiles
            // 
            this.tmiSaveAsJsonFiles.Enabled = false;
            this.tmiSaveAsJsonFiles.Name = "tmiSaveAsJsonFiles";
            this.tmiSaveAsJsonFiles.Size = new System.Drawing.Size(224, 26);
            this.tmiSaveAsJsonFiles.Text = "X";
            this.tmiSaveAsJsonFiles.Click += new System.EventHandler(this.tmiSaveAsJsonFiles_Click);
            // 
            // tmiCloseAllFiles
            // 
            this.tmiCloseAllFiles.Enabled = false;
            this.tmiCloseAllFiles.Name = "tmiCloseAllFiles";
            this.tmiCloseAllFiles.Size = new System.Drawing.Size(224, 26);
            this.tmiCloseAllFiles.Text = "X";
            this.tmiCloseAllFiles.Click += new System.EventHandler(this.tmiCloseAllFiles_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // tmiExportFiles
            // 
            this.tmiExportFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiExportToCsvFiles,
            this.tmiExportToXmlFiles,
            this.toolStripMenuItem11,
            this.tmiExportToCSFiles});
            this.tmiExportFiles.Enabled = false;
            this.tmiExportFiles.Name = "tmiExportFiles";
            this.tmiExportFiles.Size = new System.Drawing.Size(224, 26);
            this.tmiExportFiles.Text = "X";
            // 
            // tmiExportToCsvFiles
            // 
            this.tmiExportToCsvFiles.Name = "tmiExportToCsvFiles";
            this.tmiExportToCsvFiles.Size = new System.Drawing.Size(102, 26);
            this.tmiExportToCsvFiles.Text = "X";
            this.tmiExportToCsvFiles.Click += new System.EventHandler(this.tmiExportToCsvFiles_Click);
            // 
            // tmiExportToXmlFiles
            // 
            this.tmiExportToXmlFiles.Name = "tmiExportToXmlFiles";
            this.tmiExportToXmlFiles.Size = new System.Drawing.Size(102, 26);
            this.tmiExportToXmlFiles.Text = "X";
            this.tmiExportToXmlFiles.Click += new System.EventHandler(this.tmiExportToXmlFiles_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(99, 6);
            // 
            // tmiExportToCSFiles
            // 
            this.tmiExportToCSFiles.Name = "tmiExportToCSFiles";
            this.tmiExportToCSFiles.Size = new System.Drawing.Size(102, 26);
            this.tmiExportToCSFiles.Text = "X";
            this.tmiExportToCSFiles.Click += new System.EventHandler(this.tmiExportToCSFiles_Click);
            // 
            // tmiPrintList
            // 
            this.tmiPrintList.Enabled = false;
            this.tmiPrintList.Name = "tmiPrintList";
            this.tmiPrintList.Size = new System.Drawing.Size(224, 26);
            this.tmiPrintList.Text = "X";
            this.tmiPrintList.Click += new System.EventHandler(this.tmiPrintList_Click);
            // 
            // tsmLatestFolderStart
            // 
            this.tsmLatestFolderStart.Name = "tsmLatestFolderStart";
            this.tsmLatestFolderStart.Size = new System.Drawing.Size(221, 6);
            // 
            // tmiExit
            // 
            this.tmiExit.Name = "tmiExit";
            this.tmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tmiExit.Size = new System.Drawing.Size(224, 26);
            this.tmiExit.Text = "X";
            this.tmiExit.Click += new System.EventHandler(this.tmiExit_Click);
            // 
            // tmiFunction
            // 
            this.tmiFunction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiSortList});
            this.tmiFunction.Name = "tmiFunction";
            this.tmiFunction.Size = new System.Drawing.Size(33, 26);
            this.tmiFunction.Text = "X";
            this.tmiFunction.Visible = false;
            // 
            // tmiSortList
            // 
            this.tmiSortList.Name = "tmiSortList";
            this.tmiSortList.Size = new System.Drawing.Size(102, 26);
            this.tmiSortList.Text = "X";
            // 
            // tmiLanguages
            // 
            this.tmiLanguages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiLanguageENUS,
            this.toolStripMenuItem10,
            this.tmiLanguageZHCN,
            this.tmiLanguageZHTW});
            this.tmiLanguages.Name = "tmiLanguages";
            this.tmiLanguages.Size = new System.Drawing.Size(33, 26);
            this.tmiLanguages.Text = "X";
            // 
            // tmiLanguageENUS
            // 
            this.tmiLanguageENUS.Name = "tmiLanguageENUS";
            this.tmiLanguageENUS.Size = new System.Drawing.Size(207, 26);
            this.tmiLanguageENUS.Text = "English(en-US)";
            this.tmiLanguageENUS.Click += new System.EventHandler(this.tmiLanguageENUS_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(204, 6);
            // 
            // tmiLanguageZHCN
            // 
            this.tmiLanguageZHCN.Name = "tmiLanguageZHCN";
            this.tmiLanguageZHCN.Size = new System.Drawing.Size(207, 26);
            this.tmiLanguageZHCN.Text = "简体中文(zh-CN)";
            this.tmiLanguageZHCN.Click += new System.EventHandler(this.tmiLanguageZHCN_Click);
            // 
            // tmiLanguageZHTW
            // 
            this.tmiLanguageZHTW.Name = "tmiLanguageZHTW";
            this.tmiLanguageZHTW.Size = new System.Drawing.Size(207, 26);
            this.tmiLanguageZHTW.Text = "繁體中文(zh-TW)";
            this.tmiLanguageZHTW.Click += new System.EventHandler(this.tmiLanguageZHTW_Click);
            // 
            // tmiSetting
            // 
            this.tmiSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiArinaYear});
            this.tmiSetting.Name = "tmiSetting";
            this.tmiSetting.Size = new System.Drawing.Size(33, 26);
            this.tmiSetting.Text = "X";
            // 
            // tmiArinaYear
            // 
            this.tmiArinaYear.Name = "tmiArinaYear";
            this.tmiArinaYear.Size = new System.Drawing.Size(102, 26);
            this.tmiArinaYear.Text = "X";
            this.tmiArinaYear.Click += new System.EventHandler(this.tmiArinaYear_Click);
            // 
            // tmiHelp
            // 
            this.tmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiAbout});
            this.tmiHelp.Name = "tmiHelp";
            this.tmiHelp.Size = new System.Drawing.Size(33, 26);
            this.tmiHelp.Text = "X";
            // 
            // tmiAbout
            // 
            this.tmiAbout.Name = "tmiAbout";
            this.tmiAbout.Size = new System.Drawing.Size(102, 26);
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
            this.tmiBackup.Size = new System.Drawing.Size(73, 26);
            this.tmiBackup.Text = "Backup";
            // 
            // tmiJsonEditorBackup
            // 
            this.tmiJsonEditorBackup.Name = "tmiJsonEditorBackup";
            this.tmiJsonEditorBackup.Size = new System.Drawing.Size(199, 26);
            this.tmiJsonEditorBackup.Text = "Json Editor";
            this.tmiJsonEditorBackup.Click += new System.EventHandler(this.tmiJsonEditorBackup_Click);
            // 
            // tmiTestDataBackup
            // 
            this.tmiTestDataBackup.Name = "tmiTestDataBackup";
            this.tmiTestDataBackup.Size = new System.Drawing.Size(199, 26);
            this.tmiTestDataBackup.Text = "Test Data";
            this.tmiTestDataBackup.Click += new System.EventHandler(this.tmiTestDataBackup_Click);
            // 
            // tmiAritiafelBackup
            // 
            this.tmiAritiafelBackup.Name = "tmiAritiafelBackup";
            this.tmiAritiafelBackup.Size = new System.Drawing.Size(199, 26);
            this.tmiAritiafelBackup.Text = "Aritiafel";
            this.tmiAritiafelBackup.Click += new System.EventHandler(this.tmiAritiafelBackup_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(196, 6);
            // 
            // tmiRunSomething
            // 
            this.tmiRunSomething.Name = "tmiRunSomething";
            this.tmiRunSomething.Size = new System.Drawing.Size(199, 26);
            this.tmiRunSomething.Text = "Run something";
            this.tmiRunSomething.Click += new System.EventHandler(this.tmiRunSomething_Click);
            // 
            // cmsJsonFiles
            // 
            this.cmsJsonFiles.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsJsonFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiNewJsonFile,
            this.tmiRenameDatabase,
            this.tmiEditDatabaseDescription,
            this.toolStripMenuItem6,
            this.tmiOpenFolder,
            this.tmiViewJFIFile,
            this.tmiRefreshFiles,
            this.toolStripMenuItem8,
            this.tmiExpandAll,
            this.tmiCollapseAll});
            this.cmsJsonFiles.Name = "cmsMain";
            this.cmsJsonFiles.Size = new System.Drawing.Size(89, 208);
            // 
            // tmiNewJsonFile
            // 
            this.tmiNewJsonFile.Enabled = false;
            this.tmiNewJsonFile.Name = "tmiNewJsonFile";
            this.tmiNewJsonFile.Size = new System.Drawing.Size(88, 24);
            this.tmiNewJsonFile.Text = "X";
            this.tmiNewJsonFile.Click += new System.EventHandler(this.tmiNewJsonFile_Click);
            // 
            // tmiRenameDatabase
            // 
            this.tmiRenameDatabase.Name = "tmiRenameDatabase";
            this.tmiRenameDatabase.Size = new System.Drawing.Size(88, 24);
            this.tmiRenameDatabase.Text = "X";
            this.tmiRenameDatabase.Click += new System.EventHandler(this.tmiRenameDatabase_Click);
            // 
            // tmiEditDatabaseDescription
            // 
            this.tmiEditDatabaseDescription.Name = "tmiEditDatabaseDescription";
            this.tmiEditDatabaseDescription.Size = new System.Drawing.Size(88, 24);
            this.tmiEditDatabaseDescription.Text = "X";
            this.tmiEditDatabaseDescription.Click += new System.EventHandler(this.tmiEditDatabaseDescription_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(85, 6);
            // 
            // tmiOpenFolder
            // 
            this.tmiOpenFolder.Enabled = false;
            this.tmiOpenFolder.Name = "tmiOpenFolder";
            this.tmiOpenFolder.Size = new System.Drawing.Size(88, 24);
            this.tmiOpenFolder.Text = "X";
            this.tmiOpenFolder.Click += new System.EventHandler(this.tmiOpenFolder_Click);
            // 
            // tmiViewJFIFile
            // 
            this.tmiViewJFIFile.Name = "tmiViewJFIFile";
            this.tmiViewJFIFile.Size = new System.Drawing.Size(88, 24);
            this.tmiViewJFIFile.Text = "X";
            this.tmiViewJFIFile.Click += new System.EventHandler(this.tmiViewJFIFile_Click);
            // 
            // tmiRefreshFiles
            // 
            this.tmiRefreshFiles.Name = "tmiRefreshFiles";
            this.tmiRefreshFiles.Size = new System.Drawing.Size(88, 24);
            this.tmiRefreshFiles.Text = "X";
            this.tmiRefreshFiles.Click += new System.EventHandler(this.tmiRefreshFiles_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(85, 6);
            // 
            // tmiExpandAll
            // 
            this.tmiExpandAll.Name = "tmiExpandAll";
            this.tmiExpandAll.Size = new System.Drawing.Size(88, 24);
            this.tmiExpandAll.Text = "X";
            this.tmiExpandAll.Click += new System.EventHandler(this.tmiExpandAll_Click);
            // 
            // tmiCollapseAll
            // 
            this.tmiCollapseAll.Name = "tmiCollapseAll";
            this.tmiCollapseAll.Size = new System.Drawing.Size(88, 24);
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
            this.tmiExportFile,
            this.tmiCloseJsonFile,
            this.toolStripMenuItem5,
            this.tmiEditSortInfo,
            this.tmiClearSortInfo,
            this.toolStripSeparator1,
            this.tmiAddIDColumn,
            this.tmiAddColumn,
            this.toolStripMenuItem13,
            this.tmiDisplayAllColumn,
            this.tmiInsertFirst});
            this.cmsJsonFileSelected.Name = "cmsMain";
            this.cmsJsonFileSelected.Size = new System.Drawing.Size(89, 310);
            // 
            // tmiOpenJsonFile
            // 
            this.tmiOpenJsonFile.Name = "tmiOpenJsonFile";
            this.tmiOpenJsonFile.Size = new System.Drawing.Size(88, 24);
            this.tmiOpenJsonFile.Text = "X";
            this.tmiOpenJsonFile.Click += new System.EventHandler(this.tmiOpenJsonFile_Click);
            // 
            // tmiViewJsonFile
            // 
            this.tmiViewJsonFile.Name = "tmiViewJsonFile";
            this.tmiViewJsonFile.Size = new System.Drawing.Size(88, 24);
            this.tmiViewJsonFile.Text = "X";
            this.tmiViewJsonFile.Click += new System.EventHandler(this.tmiViewJsonFile_Click);
            // 
            // tmiRenameJsonFile
            // 
            this.tmiRenameJsonFile.Name = "tmiRenameJsonFile";
            this.tmiRenameJsonFile.Size = new System.Drawing.Size(88, 24);
            this.tmiRenameJsonFile.Text = "X";
            this.tmiRenameJsonFile.Click += new System.EventHandler(this.tmiRenameJsonFile_Click);
            // 
            // tmiDeleteJsonFile
            // 
            this.tmiDeleteJsonFile.Name = "tmiDeleteJsonFile";
            this.tmiDeleteJsonFile.Size = new System.Drawing.Size(88, 24);
            this.tmiDeleteJsonFile.Text = "X";
            this.tmiDeleteJsonFile.Click += new System.EventHandler(this.tmiDeleteJsonFile_Click);
            // 
            // tmiExportFile
            // 
            this.tmiExportFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiExportCsvFile,
            this.tmiExportXmlFile,
            this.toolStripMenuItem12,
            this.tmiExportCSFile,
            this.toolStripMenuItem1,
            this.tmiExportToLangaugeFiles});
            this.tmiExportFile.Name = "tmiExportFile";
            this.tmiExportFile.Size = new System.Drawing.Size(88, 24);
            this.tmiExportFile.Text = "X";
            // 
            // tmiExportCsvFile
            // 
            this.tmiExportCsvFile.Name = "tmiExportCsvFile";
            this.tmiExportCsvFile.Size = new System.Drawing.Size(102, 26);
            this.tmiExportCsvFile.Text = "X";
            this.tmiExportCsvFile.Click += new System.EventHandler(this.tmiExportCsvFile_Click);
            // 
            // tmiExportXmlFile
            // 
            this.tmiExportXmlFile.Name = "tmiExportXmlFile";
            this.tmiExportXmlFile.Size = new System.Drawing.Size(102, 26);
            this.tmiExportXmlFile.Text = "X";
            this.tmiExportXmlFile.Click += new System.EventHandler(this.tmiExportXmlFile_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(99, 6);
            // 
            // tmiExportCSFile
            // 
            this.tmiExportCSFile.Name = "tmiExportCSFile";
            this.tmiExportCSFile.Size = new System.Drawing.Size(102, 26);
            this.tmiExportCSFile.Text = "X";
            this.tmiExportCSFile.Click += new System.EventHandler(this.tmiExportCSFile_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(99, 6);
            // 
            // tmiExportToLangaugeFiles
            // 
            this.tmiExportToLangaugeFiles.Name = "tmiExportToLangaugeFiles";
            this.tmiExportToLangaugeFiles.Size = new System.Drawing.Size(102, 26);
            this.tmiExportToLangaugeFiles.Text = "X";
            this.tmiExportToLangaugeFiles.Click += new System.EventHandler(this.tmiExportLangaugeFiles_Click);
            // 
            // tmiCloseJsonFile
            // 
            this.tmiCloseJsonFile.Enabled = false;
            this.tmiCloseJsonFile.Name = "tmiCloseJsonFile";
            this.tmiCloseJsonFile.Size = new System.Drawing.Size(88, 24);
            this.tmiCloseJsonFile.Text = "X";
            this.tmiCloseJsonFile.Click += new System.EventHandler(this.tmiCloseJsonFile_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(85, 6);
            // 
            // tmiEditSortInfo
            // 
            this.tmiEditSortInfo.Name = "tmiEditSortInfo";
            this.tmiEditSortInfo.Size = new System.Drawing.Size(88, 24);
            this.tmiEditSortInfo.Text = "X";
            this.tmiEditSortInfo.Click += new System.EventHandler(this.tmiEditSortInfo_Click);
            // 
            // tmiClearSortInfo
            // 
            this.tmiClearSortInfo.Enabled = false;
            this.tmiClearSortInfo.Name = "tmiClearSortInfo";
            this.tmiClearSortInfo.Size = new System.Drawing.Size(88, 24);
            this.tmiClearSortInfo.Text = "X";
            this.tmiClearSortInfo.Visible = false;
            this.tmiClearSortInfo.Click += new System.EventHandler(this.tmiClearSortInfo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(85, 6);
            // 
            // tmiAddIDColumn
            // 
            this.tmiAddIDColumn.Name = "tmiAddIDColumn";
            this.tmiAddIDColumn.Size = new System.Drawing.Size(88, 24);
            this.tmiAddIDColumn.Text = "X";
            this.tmiAddIDColumn.Click += new System.EventHandler(this.tmiAddIDColumn_Click);
            // 
            // tmiAddColumn
            // 
            this.tmiAddColumn.Name = "tmiAddColumn";
            this.tmiAddColumn.Size = new System.Drawing.Size(88, 24);
            this.tmiAddColumn.Text = "X";
            this.tmiAddColumn.Click += new System.EventHandler(this.tmiAddColumn_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(85, 6);
            // 
            // tmiDisplayAllColumn
            // 
            this.tmiDisplayAllColumn.Name = "tmiDisplayAllColumn";
            this.tmiDisplayAllColumn.Size = new System.Drawing.Size(88, 24);
            this.tmiDisplayAllColumn.Text = "X";
            this.tmiDisplayAllColumn.Click += new System.EventHandler(this.tmiDisplayAllColumn_Click);
            // 
            // tmiInsertFirst
            // 
            this.tmiInsertFirst.Name = "tmiInsertFirst";
            this.tmiInsertFirst.Size = new System.Drawing.Size(88, 24);
            this.tmiInsertFirst.Text = "X";
            this.tmiInsertFirst.Click += new System.EventHandler(this.tmiInsertFirst_Click);
            // 
            // cmsColumnSelected
            // 
            this.cmsColumnSelected.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsColumnSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiRenameColumn,
            this.tmiColumnShowOnList,
            this.tmiDeleteColumn,
            this.toolStripMenuItem7,
            this.tmiColumnMoveTop,
            this.tmiColumnMoveUp,
            this.tmiColumnMoveDown,
            this.tmiColumnMoveBottom});
            this.cmsColumnSelected.Name = "cmsMain";
            this.cmsColumnSelected.Size = new System.Drawing.Size(89, 178);
            // 
            // tmiRenameColumn
            // 
            this.tmiRenameColumn.Name = "tmiRenameColumn";
            this.tmiRenameColumn.Size = new System.Drawing.Size(88, 24);
            this.tmiRenameColumn.Text = "X";
            this.tmiRenameColumn.Click += new System.EventHandler(this.tmiRenameColumn_Click);
            // 
            // tmiColumnShowOnList
            // 
            this.tmiColumnShowOnList.Name = "tmiColumnShowOnList";
            this.tmiColumnShowOnList.Size = new System.Drawing.Size(88, 24);
            this.tmiColumnShowOnList.Text = "X";
            this.tmiColumnShowOnList.Click += new System.EventHandler(this.tmiColumnShowOnList_Click);
            // 
            // tmiDeleteColumn
            // 
            this.tmiDeleteColumn.Name = "tmiDeleteColumn";
            this.tmiDeleteColumn.Size = new System.Drawing.Size(88, 24);
            this.tmiDeleteColumn.Text = "X";
            this.tmiDeleteColumn.Click += new System.EventHandler(this.tmiDeleteColumn_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(85, 6);
            // 
            // tmiColumnMoveTop
            // 
            this.tmiColumnMoveTop.Name = "tmiColumnMoveTop";
            this.tmiColumnMoveTop.Size = new System.Drawing.Size(88, 24);
            this.tmiColumnMoveTop.Text = "X";
            this.tmiColumnMoveTop.Click += new System.EventHandler(this.tmiColumnMoveTop_Click);
            // 
            // tmiColumnMoveUp
            // 
            this.tmiColumnMoveUp.Name = "tmiColumnMoveUp";
            this.tmiColumnMoveUp.Size = new System.Drawing.Size(88, 24);
            this.tmiColumnMoveUp.Text = "X";
            this.tmiColumnMoveUp.Click += new System.EventHandler(this.tmiColumnMoveUp_Click);
            // 
            // tmiColumnMoveDown
            // 
            this.tmiColumnMoveDown.Name = "tmiColumnMoveDown";
            this.tmiColumnMoveDown.Size = new System.Drawing.Size(88, 24);
            this.tmiColumnMoveDown.Text = "X";
            this.tmiColumnMoveDown.Click += new System.EventHandler(this.tmiColumnMoveDown_Click);
            // 
            // tmiColumnMoveBottom
            // 
            this.tmiColumnMoveBottom.Name = "tmiColumnMoveBottom";
            this.tmiColumnMoveBottom.Size = new System.Drawing.Size(88, 24);
            this.tmiColumnMoveBottom.Text = "X";
            this.tmiColumnMoveBottom.Click += new System.EventHandler(this.tmiColumnMoveBottom_Click);
            // 
            // btnNewLine
            // 
            this.btnNewLine.Enabled = false;
            this.btnNewLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLine.Location = new System.Drawing.Point(714, 716);
            this.btnNewLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewLine.Name = "btnNewLine";
            this.btnNewLine.Size = new System.Drawing.Size(122, 38);
            this.btnNewLine.TabIndex = 26;
            this.btnNewLine.Text = "-";
            this.btnNewLine.UseVisualStyleBackColor = true;
            this.btnNewLine.Click += new System.EventHandler(this.btnNewLine_Click);
            // 
            // btnDeleteLine
            // 
            this.btnDeleteLine.Enabled = false;
            this.btnDeleteLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLine.Location = new System.Drawing.Point(429, 716);
            this.btnDeleteLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteLine.Name = "btnDeleteLine";
            this.btnDeleteLine.Size = new System.Drawing.Size(122, 38);
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
            this.btnLineMoveUp.Location = new System.Drawing.Point(662, 716);
            this.btnLineMoveUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnLineMoveUp.Name = "btnLineMoveUp";
            this.btnLineMoveUp.Size = new System.Drawing.Size(50, 38);
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
            this.btnLineMoveDown.Location = new System.Drawing.Point(556, 716);
            this.btnLineMoveDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnLineMoveDown.Name = "btnLineMoveDown";
            this.btnLineMoveDown.Size = new System.Drawing.Size(50, 38);
            this.btnLineMoveDown.TabIndex = 29;
            this.btnLineMoveDown.Text = "-";
            this.btnLineMoveDown.UseVisualStyleBackColor = true;
            this.btnLineMoveDown.Click += new System.EventHandler(this.btnLineMoveDown_Click);
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AllowUserToOrderColumns = true;
            this.dgvLines.AllowUserToResizeRows = false;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Location = new System.Drawing.Point(429, 92);
            this.dgvLines.MultiSelect = false;
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.RowHeadersWidth = 51;
            this.dgvLines.RowTemplate.Height = 18;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.ShowEditingIcon = false;
            this.dgvLines.Size = new System.Drawing.Size(407, 618);
            this.dgvLines.TabIndex = 31;
            this.dgvLines.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLines_CellFormatting);
            this.dgvLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvLines_DataBindingComplete);
            this.dgvLines.SelectionChanged += new System.EventHandler(this.dgvLines_SelectionChanged);
            // 
            // cobFindColumnName
            // 
            this.cobFindColumnName.DisplayMember = "Name";
            this.cobFindColumnName.FormattingEnabled = true;
            this.cobFindColumnName.Location = new System.Drawing.Point(428, 64);
            this.cobFindColumnName.Name = "cobFindColumnName";
            this.cobFindColumnName.Size = new System.Drawing.Size(145, 23);
            this.cobFindColumnName.TabIndex = 32;
            this.cobFindColumnName.ValueMember = "Name";
            // 
            // txtFindValue
            // 
            this.txtFindValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindValue.Location = new System.Drawing.Point(579, 63);
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
            this.btnFindConfirm.Location = new System.Drawing.Point(796, 62);
            this.btnFindConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnFindConfirm.Name = "btnFindConfirm";
            this.btnFindConfirm.Size = new System.Drawing.Size(41, 27);
            this.btnFindConfirm.TabIndex = 34;
            this.btnFindConfirm.UseVisualStyleBackColor = true;
            this.btnFindConfirm.Click += new System.EventHandler(this.btnFindConfirm_Click);
            // 
            // btnCopyLine
            // 
            this.btnCopyLine.Enabled = false;
            this.btnCopyLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyLine.ImageIndex = 7;
            this.btnCopyLine.ImageList = this.imlMain;
            this.btnCopyLine.Location = new System.Drawing.Point(609, 716);
            this.btnCopyLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyLine.Name = "btnCopyLine";
            this.btnCopyLine.Size = new System.Drawing.Size(50, 38);
            this.btnCopyLine.TabIndex = 35;
            this.btnCopyLine.UseVisualStyleBackColor = true;
            this.btnCopyLine.Click += new System.EventHandler(this.btnCopyLine_Click);
            // 
            // btnRegenerateKey
            // 
            this.btnRegenerateKey.Enabled = false;
            this.btnRegenerateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegenerateKey.Location = new System.Drawing.Point(210, 716);
            this.btnRegenerateKey.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegenerateKey.Name = "btnRegenerateKey";
            this.btnRegenerateKey.Size = new System.Drawing.Size(120, 38);
            this.btnRegenerateKey.TabIndex = 36;
            this.btnRegenerateKey.Text = "-";
            this.btnRegenerateKey.UseVisualStyleBackColor = true;
            this.btnRegenerateKey.Click += new System.EventHandler(this.btnRegenerateKey_Click);
            // 
            // cobCheckMethod
            // 
            this.cobCheckMethod.DisplayMember = "Value";
            this.cobCheckMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobCheckMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cobCheckMethod.FormattingEnabled = true;
            this.cobCheckMethod.Location = new System.Drawing.Point(1189, 721);
            this.cobCheckMethod.Margin = new System.Windows.Forms.Padding(4);
            this.cobCheckMethod.Name = "cobCheckMethod";
            this.cobCheckMethod.Size = new System.Drawing.Size(167, 28);
            this.cobCheckMethod.TabIndex = 37;
            this.cobCheckMethod.ValueMember = "Key";
            this.cobCheckMethod.SelectedIndexChanged += new System.EventHandler(this.cobCheckMethod_SelectedIndexChanged);
            // 
            // lblCheckMethod
            // 
            this.lblCheckMethod.AutoSize = true;
            this.lblCheckMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckMethod.Location = new System.Drawing.Point(1007, 725);
            this.lblCheckMethod.Name = "lblCheckMethod";
            this.lblCheckMethod.Size = new System.Drawing.Size(20, 20);
            this.lblCheckMethod.TabIndex = 38;
            this.lblCheckMethod.Text = "X";
            // 
            // prdMain
            // 
            this.prdMain.UseEXDialog = true;
            // 
            // btnResetValue
            // 
            this.btnResetValue.Enabled = false;
            this.btnResetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetValue.Location = new System.Drawing.Point(78, 716);
            this.btnResetValue.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetValue.Name = "btnResetValue";
            this.btnResetValue.Size = new System.Drawing.Size(130, 38);
            this.btnResetValue.TabIndex = 39;
            this.btnResetValue.Text = "-";
            this.btnResetValue.UseVisualStyleBackColor = true;
            this.btnResetValue.Click += new System.EventHandler(this.btnResetValue_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1509, 780);
            this.Controls.Add(this.btnResetValue);
            this.Controls.Add(this.lblCheckMethod);
            this.Controls.Add(this.cobCheckMethod);
            this.Controls.Add(this.btnRegenerateKey);
            this.Controls.Add(this.btnCopyLine);
            this.Controls.Add(this.btnFindConfirm);
            this.Controls.Add(this.txtFindValue);
            this.Controls.Add(this.cobFindColumnName);
            this.Controls.Add(this.dgvLines);
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
        private System.Windows.Forms.ToolStripSeparator tsmLatestFolderStart;
        private System.Windows.Forms.ToolStripMenuItem tmiExit;
        private System.Windows.Forms.ToolStripMenuItem tmiHelp;
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem tmiOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tmiViewJsonFile;
        private System.Windows.Forms.ToolStripMenuItem tmiViewJFIFile;
        private System.Windows.Forms.ToolStripMenuItem tmiRefreshFiles;
        private System.Windows.Forms.ToolStripMenuItem tmiRenameColumn;
        private System.Windows.Forms.Button btnLineMoveUp;
        private System.Windows.Forms.Button btnLineMoveDown;
        private System.Windows.Forms.ToolStripMenuItem tmiJsonEditorBackup;
        private System.Windows.Forms.ToolStripMenuItem tmiTestDataBackup;
        private System.Windows.Forms.ToolStripMenuItem tmiAritiafelBackup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem tmiRunSomething;
        private System.Windows.Forms.ToolStripMenuItem tmiLanguageZHCN;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.ComboBox cobFindColumnName;
        private System.Windows.Forms.TextBox txtFindValue;
        private System.Windows.Forms.Button btnFindConfirm;
        private System.Windows.Forms.ToolStripMenuItem tmiColumnShowOnList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem tmiRenameDatabase;
        private System.Windows.Forms.Panel pnlDateTimePicker;
        private SimpleDateTimePicker dtpMain;
        private System.Windows.Forms.Button btnCopyLine;
        private System.Windows.Forms.ToolTip tltMain;
        private System.Windows.Forms.SaveFileDialog sfdMain;
        private System.Windows.Forms.ToolStripMenuItem tmiExportFiles;
        private System.Windows.Forms.ToolStripMenuItem tmiExportToXmlFiles;
        private System.Windows.Forms.ToolStripMenuItem tmiExportToCsvFiles;
        private System.Windows.Forms.Button btnRegenerateKey;
        private System.Windows.Forms.ToolStripMenuItem tmiScan;
        private System.Windows.Forms.ToolStripMenuItem tmiScanCSVFiles;
        private System.Windows.Forms.ToolStripMenuItem tmiDisplayAllColumn;
        private System.Windows.Forms.ToolStripMenuItem tmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tmiExportFile;
        private System.Windows.Forms.ToolStripMenuItem tmiExportCsvFile;
        private System.Windows.Forms.ToolStripMenuItem tmiExportXmlFile;
        private System.Windows.Forms.ComboBox cobCheckMethod;
        private System.Windows.Forms.Label lblCheckMethod;
        private System.Windows.Forms.ToolStripMenuItem tmiPrintList;
        private System.Windows.Forms.PrintDialog prdMain;
        private System.Windows.Forms.ToolStripMenuItem tmiColumnMoveTop;
        private System.Windows.Forms.ToolStripMenuItem tmiColumnMoveBottom;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem tmiExportToCSFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem tmiExportCSFile;
        private System.Windows.Forms.ToolStripMenuItem tmiAddIDColumn;
        private System.Windows.Forms.ToolStripMenuItem tmiEditDatabaseDescription;
        private System.Windows.Forms.Button btnResetValue;
        private System.Windows.Forms.ToolStripMenuItem tmiFunction;
        private System.Windows.Forms.ToolStripMenuItem tmiSortList;
        private System.Windows.Forms.ToolStripMenuItem tmiEditSortInfo;
        private System.Windows.Forms.ToolStripMenuItem tmiClearSortInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tmiExportToLangaugeFiles;
        private System.Windows.Forms.ToolStripMenuItem tmiInsertFirst;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.Label lblDefalutValue;
        private System.Windows.Forms.Label lblColumnChoiceName;
        private System.Windows.Forms.Label lblColumnChoicesCount;
        private System.Windows.Forms.Button btnColumnEditChoices;
        private System.Windows.Forms.Label lblColumnChoices;
        private System.Windows.Forms.CheckBox ckbColumnAutoGenerateKey;
        private System.Windows.Forms.Label lblAutoGenerateKey;
        private System.Windows.Forms.CheckBox ckbColumnIsUnique;
        private System.Windows.Forms.Label lblColumnIsUnique;
        private System.Windows.Forms.TextBox txtColumnMaxLength;
        private System.Windows.Forms.Label lblColumnMaxLength;
        private System.Windows.Forms.Label lblColumnDescription;
        private System.Windows.Forms.TextBox txtColumnDescription;
        private System.Windows.Forms.TextBox txtColumnMaxValue;
        private System.Windows.Forms.TextBox txtColumnMinValue;
        private System.Windows.Forms.Label lblColumnMaxValue;
        private System.Windows.Forms.Label lblColumnMinValue;
        private System.Windows.Forms.CheckBox ckbColumnIsNullable;
        private System.Windows.Forms.Label lblColumnIsNullable;
        private System.Windows.Forms.TextBox txtColumnRegex;
        private System.Windows.Forms.Label lblColumnRegex;
        private System.Windows.Forms.ComboBox cobColumnFKColumn;
        private System.Windows.Forms.Label lblColumnFKColumn;
        private System.Windows.Forms.ComboBox cobColumnFKTable;
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
        private System.Windows.Forms.ToolStripMenuItem tmiSetting;
        private System.Windows.Forms.ToolStripMenuItem tmiArinaYear;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.Button btnHelpDefaultValue;
    }
}
