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
            this.lbColumnFKColumn = new System.Windows.Forms.Panel();
            this.cobColumnFKColumn = new System.Windows.Forms.ComboBox();
            this.lblColumnFKColumn = new System.Windows.Forms.Label();
            this.cobColumnFKTable = new System.Windows.Forms.ComboBox();
            this.txtColumnNumberOfRows = new System.Windows.Forms.TextBox();
            this.lblColumnNumberOfRows = new System.Windows.Forms.Label();
            this.chbColumnDisplay = new System.Windows.Forms.CheckBox();
            this.chbColumnIsKey = new System.Windows.Forms.CheckBox();
            this.cobColumnType = new System.Windows.Forms.ComboBox();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.lblColumnFKTable = new System.Windows.Forms.Label();
            this.lblColumnDisplay = new System.Windows.Forms.Label();
            this.lblColumnIsKey = new System.Windows.Forms.Label();
            this.lblColumnType = new System.Windows.Forms.Label();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.lsbLines = new System.Windows.Forms.ListBox();
            this.trvJsonFiles = new System.Windows.Forms.TreeView();
            this.imlMain = new System.Windows.Forms.ImageList(this.components);
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.sslMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpStart = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.tmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiNewJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiLoadJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiScanJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiSaveJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSaveAsJsonFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiCloseAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLanguages = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLanguageZHTW = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiLanguageENUS = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
            this.cmsJsonFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiNewJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsJsonFileSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiOpenJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRenameJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCloseJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDeleteJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiAddColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsColumnSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiDeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewLine = new System.Windows.Forms.Button();
            this.lbColumnFKColumn.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.mnsMain.SuspendLayout();
            this.cmsJsonFiles.SuspendLayout();
            this.cmsJsonFileSelected.SuspendLayout();
            this.cmsColumnSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearColumn
            // 
            this.btnClearColumn.Location = new System.Drawing.Point(12, 730);
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
            this.btnClearMain.Location = new System.Drawing.Point(770, 730);
            this.btnClearMain.Name = "btnClearMain";
            this.btnClearMain.Size = new System.Drawing.Size(122, 40);
            this.btnClearMain.TabIndex = 18;
            this.btnClearMain.Text = "-";
            this.btnClearMain.UseVisualStyleBackColor = true;
            // 
            // btnUpdateMain
            // 
            this.btnUpdateMain.Enabled = false;
            this.btnUpdateMain.Location = new System.Drawing.Point(1252, 730);
            this.btnUpdateMain.Name = "btnUpdateMain";
            this.btnUpdateMain.Size = new System.Drawing.Size(122, 40);
            this.btnUpdateMain.TabIndex = 17;
            this.btnUpdateMain.Text = "-";
            this.btnUpdateMain.UseVisualStyleBackColor = true;
            // 
            // btnUpdateColumn
            // 
            this.btnUpdateColumn.Enabled = false;
            this.btnUpdateColumn.Location = new System.Drawing.Point(253, 730);
            this.btnUpdateColumn.Name = "btnUpdateColumn";
            this.btnUpdateColumn.Size = new System.Drawing.Size(122, 40);
            this.btnUpdateColumn.TabIndex = 16;
            this.btnUpdateColumn.Text = "-";
            this.btnUpdateColumn.UseVisualStyleBackColor = true;
            this.btnUpdateColumn.Click += new System.EventHandler(this.btnUpdateColumn_Click);
            // 
            // lbColumnFKColumn
            // 
            this.lbColumnFKColumn.AutoScroll = true;
            this.lbColumnFKColumn.Controls.Add(this.cobColumnFKColumn);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnFKColumn);
            this.lbColumnFKColumn.Controls.Add(this.cobColumnFKTable);
            this.lbColumnFKColumn.Controls.Add(this.txtColumnNumberOfRows);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnNumberOfRows);
            this.lbColumnFKColumn.Controls.Add(this.chbColumnDisplay);
            this.lbColumnFKColumn.Controls.Add(this.chbColumnIsKey);
            this.lbColumnFKColumn.Controls.Add(this.cobColumnType);
            this.lbColumnFKColumn.Controls.Add(this.txtColumnName);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnFKTable);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnDisplay);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnIsKey);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnType);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnName);
            this.lbColumnFKColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColumnFKColumn.Location = new System.Drawing.Point(1, 465);
            this.lbColumnFKColumn.Name = "lbColumnFKColumn";
            this.lbColumnFKColumn.Size = new System.Drawing.Size(374, 259);
            this.lbColumnFKColumn.TabIndex = 15;
            // 
            // cobColumnFKColumn
            // 
            this.cobColumnFKColumn.DisplayMember = "Name";
            this.cobColumnFKColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobColumnFKColumn.FormattingEnabled = true;
            this.cobColumnFKColumn.Location = new System.Drawing.Point(179, 220);
            this.cobColumnFKColumn.Name = "cobColumnFKColumn";
            this.cobColumnFKColumn.Size = new System.Drawing.Size(183, 28);
            this.cobColumnFKColumn.TabIndex = 18;
            this.cobColumnFKColumn.ValueMember = "Name";
            // 
            // lblColumnFKColumn
            // 
            this.lblColumnFKColumn.AutoSize = true;
            this.lblColumnFKColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnFKColumn.Location = new System.Drawing.Point(18, 222);
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
            this.cobColumnFKTable.Location = new System.Drawing.Point(179, 184);
            this.cobColumnFKTable.Name = "cobColumnFKTable";
            this.cobColumnFKTable.Size = new System.Drawing.Size(183, 28);
            this.cobColumnFKTable.TabIndex = 16;
            this.cobColumnFKTable.ValueMember = "Name";
            this.cobColumnFKTable.SelectedIndexChanged += new System.EventHandler(this.cobColumnFKTable_SelectedIndexChanged);
            // 
            // txtColumnNumberOfRows
            // 
            this.txtColumnNumberOfRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnNumberOfRows.Location = new System.Drawing.Point(326, 81);
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
            this.lblColumnNumberOfRows.Location = new System.Drawing.Point(18, 82);
            this.lblColumnNumberOfRows.Name = "lblColumnNumberOfRows";
            this.lblColumnNumberOfRows.Size = new System.Drawing.Size(15, 20);
            this.lblColumnNumberOfRows.TabIndex = 14;
            this.lblColumnNumberOfRows.Text = "-";
            // 
            // chbColumnDisplay
            // 
            this.chbColumnDisplay.AutoSize = true;
            this.chbColumnDisplay.Location = new System.Drawing.Point(344, 155);
            this.chbColumnDisplay.Name = "chbColumnDisplay";
            this.chbColumnDisplay.Size = new System.Drawing.Size(18, 17);
            this.chbColumnDisplay.TabIndex = 13;
            this.chbColumnDisplay.UseVisualStyleBackColor = true;
            // 
            // chbColumnIsKey
            // 
            this.chbColumnIsKey.AutoSize = true;
            this.chbColumnIsKey.Location = new System.Drawing.Point(344, 120);
            this.chbColumnIsKey.Name = "chbColumnIsKey";
            this.chbColumnIsKey.Size = new System.Drawing.Size(18, 17);
            this.chbColumnIsKey.TabIndex = 8;
            this.chbColumnIsKey.UseVisualStyleBackColor = true;
            // 
            // cobColumnType
            // 
            this.cobColumnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobColumnType.FormattingEnabled = true;
            this.cobColumnType.Location = new System.Drawing.Point(179, 45);
            this.cobColumnType.Name = "cobColumnType";
            this.cobColumnType.Size = new System.Drawing.Size(183, 28);
            this.cobColumnType.TabIndex = 8;
            // 
            // txtColumnName
            // 
            this.txtColumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnName.Location = new System.Drawing.Point(179, 9);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(183, 27);
            this.txtColumnName.TabIndex = 0;
            this.txtColumnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnFKTable
            // 
            this.lblColumnFKTable.AutoSize = true;
            this.lblColumnFKTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnFKTable.Location = new System.Drawing.Point(18, 187);
            this.lblColumnFKTable.Name = "lblColumnFKTable";
            this.lblColumnFKTable.Size = new System.Drawing.Size(15, 20);
            this.lblColumnFKTable.TabIndex = 12;
            this.lblColumnFKTable.Text = "-";
            // 
            // lblColumnDisplay
            // 
            this.lblColumnDisplay.AutoSize = true;
            this.lblColumnDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnDisplay.Location = new System.Drawing.Point(18, 152);
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
            this.lblColumnIsKey.Name = "lblColumnIsKey";
            this.lblColumnIsKey.Size = new System.Drawing.Size(15, 20);
            this.lblColumnIsKey.TabIndex = 10;
            this.lblColumnIsKey.Text = "-";
            // 
            // lblColumnType
            // 
            this.lblColumnType.AutoSize = true;
            this.lblColumnType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnType.Location = new System.Drawing.Point(18, 48);
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
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(15, 20);
            this.lblColumnName.TabIndex = 8;
            this.lblColumnName.Text = "-";
            // 
            // lsbLines
            // 
            this.lsbLines.FormattingEnabled = true;
            this.lsbLines.ItemHeight = 16;
            this.lsbLines.Location = new System.Drawing.Point(381, 62);
            this.lsbLines.Name = "lsbLines";
            this.lsbLines.Size = new System.Drawing.Size(383, 660);
            this.lsbLines.TabIndex = 14;
            this.lsbLines.SelectedIndexChanged += new System.EventHandler(this.libLines_SelectedIndexChanged);
            // 
            // trvJsonFiles
            // 
            this.trvJsonFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvJsonFiles.HideSelection = false;
            this.trvJsonFiles.ImageIndex = 0;
            this.trvJsonFiles.ImageList = this.imlMain;
            this.trvJsonFiles.Location = new System.Drawing.Point(1, 32);
            this.trvJsonFiles.Name = "trvJsonFiles";
            this.trvJsonFiles.SelectedImageIndex = 0;
            this.trvJsonFiles.ShowNodeToolTips = true;
            this.trvJsonFiles.Size = new System.Drawing.Size(374, 428);
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
            // 
            // stsMain
            // 
            this.stsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslMain});
            this.stsMain.Location = new System.Drawing.Point(0, 781);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(1382, 22);
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
            this.tbcMain.Controls.Add(this.tbpStart);
            this.tbcMain.Location = new System.Drawing.Point(381, 32);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(993, 24);
            this.tbcMain.TabIndex = 20;
            // 
            // tbpStart
            // 
            this.tbpStart.Location = new System.Drawing.Point(4, 25);
            this.tbpStart.Name = "tbpStart";
            this.tbpStart.Padding = new System.Windows.Forms.Padding(3);
            this.tbpStart.Size = new System.Drawing.Size(985, 0);
            this.tbpStart.TabIndex = 0;
            this.tbpStart.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Location = new System.Drawing.Point(770, 62);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(604, 657);
            this.pnlMain.TabIndex = 21;
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
            this.mnsMain.Size = new System.Drawing.Size(1382, 28);
            this.mnsMain.TabIndex = 24;
            this.mnsMain.Text = "menuStrip1";
            // 
            // tmiFile
            // 
            this.tmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiNewJsonFiles,
            this.toolStripMenuItem3,
            this.tmiLoadJsonFiles,
            this.tmiScanJsonFiles,
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
            this.tmiNewJsonFiles.Size = new System.Drawing.Size(216, 26);
            this.tmiNewJsonFiles.Text = "X";
            this.tmiNewJsonFiles.Click += new System.EventHandler(this.tmiNewJsonFiles_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(213, 6);
            // 
            // tmiLoadJsonFiles
            // 
            this.tmiLoadJsonFiles.Name = "tmiLoadJsonFiles";
            this.tmiLoadJsonFiles.Size = new System.Drawing.Size(216, 26);
            this.tmiLoadJsonFiles.Text = "X";
            this.tmiLoadJsonFiles.Click += new System.EventHandler(this.tmiLoadJsonFiles_Click);
            // 
            // tmiScanJsonFiles
            // 
            this.tmiScanJsonFiles.Enabled = false;
            this.tmiScanJsonFiles.Name = "tmiScanJsonFiles";
            this.tmiScanJsonFiles.Size = new System.Drawing.Size(216, 26);
            this.tmiScanJsonFiles.Text = "X";
            this.tmiScanJsonFiles.Click += new System.EventHandler(this.tmiScanJsonFiles_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(213, 6);
            // 
            // tmiSaveJsonFiles
            // 
            this.tmiSaveJsonFiles.Enabled = false;
            this.tmiSaveJsonFiles.Name = "tmiSaveJsonFiles";
            this.tmiSaveJsonFiles.Size = new System.Drawing.Size(216, 26);
            this.tmiSaveJsonFiles.Text = "X";
            this.tmiSaveJsonFiles.Click += new System.EventHandler(this.tmiSaveJsonFiles_Click);
            // 
            // tmiSaveAsJsonFiles
            // 
            this.tmiSaveAsJsonFiles.Enabled = false;
            this.tmiSaveAsJsonFiles.Name = "tmiSaveAsJsonFiles";
            this.tmiSaveAsJsonFiles.Size = new System.Drawing.Size(216, 26);
            this.tmiSaveAsJsonFiles.Text = "X";
            this.tmiSaveAsJsonFiles.Click += new System.EventHandler(this.tmiSaveAsJsonFiles_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(213, 6);
            // 
            // tmiCloseAllFiles
            // 
            this.tmiCloseAllFiles.Enabled = false;
            this.tmiCloseAllFiles.Name = "tmiCloseAllFiles";
            this.tmiCloseAllFiles.Size = new System.Drawing.Size(216, 26);
            this.tmiCloseAllFiles.Text = "X";
            this.tmiCloseAllFiles.Click += new System.EventHandler(this.tmiCloseAllFiles_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // tmiExit
            // 
            this.tmiExit.Name = "tmiExit";
            this.tmiExit.Size = new System.Drawing.Size(216, 26);
            this.tmiExit.Text = "X";
            this.tmiExit.Click += new System.EventHandler(this.tmiExit_Click);
            // 
            // tmiLanguages
            // 
            this.tmiLanguages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiLanguageZHTW,
            this.tmiLanguageENUS});
            this.tmiLanguages.Name = "tmiLanguages";
            this.tmiLanguages.Size = new System.Drawing.Size(30, 24);
            this.tmiLanguages.Text = "X";
            // 
            // tmiLanguageZHTW
            // 
            this.tmiLanguageZHTW.Name = "tmiLanguageZHTW";
            this.tmiLanguageZHTW.Size = new System.Drawing.Size(216, 26);
            this.tmiLanguageZHTW.Text = "繁體中文(zh-TW)";
            this.tmiLanguageZHTW.Click += new System.EventHandler(this.tmiLanguageZNCH_Click);
            // 
            // tmiLanguageENUS
            // 
            this.tmiLanguageENUS.Name = "tmiLanguageENUS";
            this.tmiLanguageENUS.Size = new System.Drawing.Size(216, 26);
            this.tmiLanguageENUS.Text = "English(en-US)";
            this.tmiLanguageENUS.Click += new System.EventHandler(this.tmiLanguageENUS_Click);
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
            this.tmiBackup.Name = "tmiBackup";
            this.tmiBackup.Size = new System.Drawing.Size(69, 24);
            this.tmiBackup.Text = "Backup";
            this.tmiBackup.Click += new System.EventHandler(this.tmiBackup_Click);
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
            this.toolStripMenuItem6,
            this.tmiExpandAll,
            this.tmiCollapseAll});
            this.cmsJsonFiles.Name = "cmsMain";
            this.cmsJsonFiles.Size = new System.Drawing.Size(88, 82);
            // 
            // tmiNewJsonFile
            // 
            this.tmiNewJsonFile.Enabled = false;
            this.tmiNewJsonFile.Name = "tmiNewJsonFile";
            this.tmiNewJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiNewJsonFile.Text = "X";
            this.tmiNewJsonFile.Click += new System.EventHandler(this.tmiNewJsonFile_Click);
            // 
            // cmsJsonFileSelected
            // 
            this.cmsJsonFileSelected.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsJsonFileSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiOpenJsonFile,
            this.tmiRenameJsonFile,
            this.tmiCloseJsonFile,
            this.tmiDeleteJsonFile,
            this.toolStripMenuItem5,
            this.tmiAddColumn});
            this.cmsJsonFileSelected.Name = "cmsMain";
            this.cmsJsonFileSelected.Size = new System.Drawing.Size(211, 158);
            // 
            // tmiOpenJsonFile
            // 
            this.tmiOpenJsonFile.Name = "tmiOpenJsonFile";
            this.tmiOpenJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiOpenJsonFile.Text = "X";
            this.tmiOpenJsonFile.Click += new System.EventHandler(this.tmiOpenJsonFile_Click);
            // 
            // tmiRenameJsonFile
            // 
            this.tmiRenameJsonFile.Name = "tmiRenameJsonFile";
            this.tmiRenameJsonFile.Size = new System.Drawing.Size(210, 24);
            this.tmiRenameJsonFile.Text = "X";
            this.tmiRenameJsonFile.Click += new System.EventHandler(this.tmiRenameJsonFile_Click);
            // 
            // tmiCloseJsonFile
            // 
            this.tmiCloseJsonFile.Enabled = false;
            this.tmiCloseJsonFile.Name = "tmiCloseJsonFile";
            this.tmiCloseJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiCloseJsonFile.Text = "X";
            // 
            // tmiDeleteJsonFile
            // 
            this.tmiDeleteJsonFile.Name = "tmiDeleteJsonFile";
            this.tmiDeleteJsonFile.Size = new System.Drawing.Size(210, 24);
            this.tmiDeleteJsonFile.Text = "X";
            this.tmiDeleteJsonFile.Click += new System.EventHandler(this.tmiDeleteJsonFile_Click);
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
            // tmiExpandAll
            // 
            this.tmiExpandAll.Name = "tmiExpandAll";
            this.tmiExpandAll.Size = new System.Drawing.Size(87, 24);
            this.tmiExpandAll.Text = "X";
            this.tmiExpandAll.Click += new System.EventHandler(this.tmiExpandAll_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(84, 6);
            // 
            // tmiCollapseAll
            // 
            this.tmiCollapseAll.Name = "tmiCollapseAll";
            this.tmiCollapseAll.Size = new System.Drawing.Size(87, 24);
            this.tmiCollapseAll.Text = "X";
            this.tmiCollapseAll.Click += new System.EventHandler(this.tmiCollapseAll_Click);
            // 
            // cmsColumnSelected
            // 
            this.cmsColumnSelected.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsColumnSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiDeleteColumn});
            this.cmsColumnSelected.Name = "cmsMain";
            this.cmsColumnSelected.Size = new System.Drawing.Size(88, 28);
            // 
            // tmiDeleteColumn
            // 
            this.tmiDeleteColumn.Name = "tmiDeleteColumn";
            this.tmiDeleteColumn.Size = new System.Drawing.Size(87, 24);
            this.tmiDeleteColumn.Text = "X";
            this.tmiDeleteColumn.Click += new System.EventHandler(this.tmiDeleteColumn_Click);
            // 
            // btnNewLine
            // 
            this.btnNewLine.Enabled = false;
            this.btnNewLine.Location = new System.Drawing.Point(642, 730);
            this.btnNewLine.Name = "btnNewLine";
            this.btnNewLine.Size = new System.Drawing.Size(122, 40);
            this.btnNewLine.TabIndex = 26;
            this.btnNewLine.Text = "-";
            this.btnNewLine.UseVisualStyleBackColor = true;
            this.btnNewLine.Click += new System.EventHandler(this.btnNewLine_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 803);
            this.Controls.Add(this.btnNewLine);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.mnsMain);
            this.Controls.Add(this.lsbLines);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.btnClearColumn);
            this.Controls.Add(this.btnClearMain);
            this.Controls.Add(this.btnUpdateMain);
            this.Controls.Add(this.btnUpdateColumn);
            this.Controls.Add(this.lbColumnFKColumn);
            this.Controls.Add(this.trvJsonFiles);
            this.Controls.Add(this.stsMain);
            this.Name = "MainForm";
            this.lbColumnFKColumn.ResumeLayout(false);
            this.lbColumnFKColumn.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.tbcMain.ResumeLayout(false);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.cmsJsonFiles.ResumeLayout(false);
            this.cmsJsonFileSelected.ResumeLayout(false);
            this.cmsColumnSelected.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearColumn;
        private System.Windows.Forms.Button btnClearMain;
        private System.Windows.Forms.Button btnUpdateMain;
        private System.Windows.Forms.Button btnUpdateColumn;
        private System.Windows.Forms.Panel lbColumnFKColumn;
        private System.Windows.Forms.TextBox txtColumnNumberOfRows;
        private System.Windows.Forms.Label lblColumnNumberOfRows;
        private System.Windows.Forms.CheckBox chbColumnDisplay;
        private System.Windows.Forms.CheckBox chbColumnIsKey;
        private System.Windows.Forms.ComboBox cobColumnType;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Label lblColumnFKTable;
        private System.Windows.Forms.Label lblColumnDisplay;
        private System.Windows.Forms.Label lblColumnIsKey;
        private System.Windows.Forms.Label lblColumnType;
        private System.Windows.Forms.Label lblColumnName;
        private System.Windows.Forms.ListBox lsbLines;
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
        private System.Windows.Forms.TabPage tbpStart;
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
    }
}

