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
            this.lblColumnDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtMaxValue = new System.Windows.Forms.TextBox();
            this.txtMinValue = new System.Windows.Forms.TextBox();
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
            this.lsbLines = new System.Windows.Forms.ListBox();
            this.trvJsonFiles = new System.Windows.Forms.TreeView();
            this.imlMain = new System.Windows.Forms.ImageList(this.components);
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.sslMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.cmsTabSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiCloseTab = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsJsonFileSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiOpenJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiViewJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRenameJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCloseJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDeleteJsonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiAddColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsColumnSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiColumnMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiColumnMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiDeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewLine = new System.Windows.Forms.Button();
            this.btnDeleteLine = new System.Windows.Forms.Button();
            this.epvMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbColumnFKColumn.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.cmsTabSelected.SuspendLayout();
            this.mnsMain.SuspendLayout();
            this.cmsJsonFiles.SuspendLayout();
            this.cmsJsonFileSelected.SuspendLayout();
            this.cmsColumnSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epvMain)).BeginInit();
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
            this.btnClearMain.Location = new System.Drawing.Point(818, 764);
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
            this.btnUpdateMain.Location = new System.Drawing.Point(1378, 764);
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
            // lbColumnFKColumn
            // 
            this.lbColumnFKColumn.AutoScroll = true;
            this.lbColumnFKColumn.Controls.Add(this.lblColumnDescription);
            this.lbColumnFKColumn.Controls.Add(this.txtDescription);
            this.lbColumnFKColumn.Controls.Add(this.txtMaxValue);
            this.lbColumnFKColumn.Controls.Add(this.txtMinValue);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnMaxValue);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnMinValue);
            this.lbColumnFKColumn.Controls.Add(this.ckbColumnIsNullable);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnlIsNullable);
            this.lbColumnFKColumn.Controls.Add(this.txtColumnRegex);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnRegex);
            this.lbColumnFKColumn.Controls.Add(this.cobColumnFKColumn);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnFKColumn);
            this.lbColumnFKColumn.Controls.Add(this.cobColumnFKTable);
            this.lbColumnFKColumn.Controls.Add(this.txtColumnNumberOfRows);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnNumberOfRows);
            this.lbColumnFKColumn.Controls.Add(this.ckbColumnDisplay);
            this.lbColumnFKColumn.Controls.Add(this.ckbColumnIsKey);
            this.lbColumnFKColumn.Controls.Add(this.cobColumnType);
            this.lbColumnFKColumn.Controls.Add(this.txtColumnName);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnFKTable);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnDisplay);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnIsKey);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnType);
            this.lbColumnFKColumn.Controls.Add(this.lblColumnName);
            this.lbColumnFKColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbColumnFKColumn.Location = new System.Drawing.Point(1, 434);
            this.lbColumnFKColumn.Margin = new System.Windows.Forms.Padding(4);
            this.lbColumnFKColumn.Name = "lbColumnFKColumn";
            this.lbColumnFKColumn.Size = new System.Drawing.Size(420, 324);
            this.lbColumnFKColumn.TabIndex = 15;
            // 
            // lblColumnDescription
            // 
            this.lblColumnDescription.AutoSize = true;
            this.lblColumnDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnDescription.Location = new System.Drawing.Point(18, 397);
            this.lblColumnDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnDescription.Name = "lblColumnDescription";
            this.lblColumnDescription.Size = new System.Drawing.Size(15, 20);
            this.lblColumnDescription.TabIndex = 28;
            this.lblColumnDescription.Text = "-";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(207, 394);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(184, 27);
            this.txtDescription.TabIndex = 27;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaxValue
            // 
            this.txtMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxValue.Location = new System.Drawing.Point(207, 254);
            this.txtMaxValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaxValue.Name = "txtMaxValue";
            this.txtMaxValue.Size = new System.Drawing.Size(184, 27);
            this.txtMaxValue.TabIndex = 26;
            this.txtMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMinValue
            // 
            this.txtMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinValue.Location = new System.Drawing.Point(207, 219);
            this.txtMinValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtMinValue.Name = "txtMinValue";
            this.txtMinValue.Size = new System.Drawing.Size(184, 27);
            this.txtMinValue.TabIndex = 25;
            this.txtMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblColumnMaxValue
            // 
            this.lblColumnMaxValue.AutoSize = true;
            this.lblColumnMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnMaxValue.Location = new System.Drawing.Point(18, 257);
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
            this.lblColumnMinValue.Location = new System.Drawing.Point(18, 222);
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
            this.txtColumnRegex.Location = new System.Drawing.Point(207, 289);
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
            this.lblColumnRegex.Location = new System.Drawing.Point(18, 292);
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
            this.cobColumnFKColumn.Location = new System.Drawing.Point(207, 358);
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
            this.lblColumnFKColumn.Location = new System.Drawing.Point(18, 362);
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
            this.cobColumnFKTable.Location = new System.Drawing.Point(207, 323);
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
            this.txtColumnNumberOfRows.Location = new System.Drawing.Point(353, 79);
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
            this.lblColumnNumberOfRows.Location = new System.Drawing.Point(18, 82);
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
            this.lblColumnFKTable.Location = new System.Drawing.Point(18, 327);
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
            this.lblColumnIsKey.Location = new System.Drawing.Point(18, 116);
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
            // lsbLines
            // 
            this.lsbLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbLines.FormattingEnabled = true;
            this.lsbLines.ItemHeight = 20;
            this.lsbLines.Location = new System.Drawing.Point(429, 61);
            this.lsbLines.Margin = new System.Windows.Forms.Padding(4);
            this.lsbLines.Name = "lsbLines";
            this.lsbLines.Size = new System.Drawing.Size(384, 684);
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
            // 
            // stsMain
            // 
            this.stsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslMain});
            this.stsMain.Location = new System.Drawing.Point(0, 810);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(1507, 22);
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
            this.tbcMain.Location = new System.Drawing.Point(429, 32);
            this.tbcMain.Margin = new System.Windows.Forms.Padding(4);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1071, 24);
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
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(818, 61);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(682, 697);
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
            this.mnsMain.Size = new System.Drawing.Size(1507, 28);
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
            this.tmiNewJsonFiles.Size = new System.Drawing.Size(93, 26);
            this.tmiNewJsonFiles.Text = "X";
            this.tmiNewJsonFiles.Click += new System.EventHandler(this.tmiNewJsonFiles_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(90, 6);
            // 
            // tmiLoadJsonFiles
            // 
            this.tmiLoadJsonFiles.Name = "tmiLoadJsonFiles";
            this.tmiLoadJsonFiles.Size = new System.Drawing.Size(93, 26);
            this.tmiLoadJsonFiles.Text = "X";
            this.tmiLoadJsonFiles.Click += new System.EventHandler(this.tmiLoadJsonFiles_Click);
            // 
            // tmiScanJsonFiles
            // 
            this.tmiScanJsonFiles.Enabled = false;
            this.tmiScanJsonFiles.Name = "tmiScanJsonFiles";
            this.tmiScanJsonFiles.Size = new System.Drawing.Size(93, 26);
            this.tmiScanJsonFiles.Text = "X";
            this.tmiScanJsonFiles.Click += new System.EventHandler(this.tmiScanJsonFiles_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(90, 6);
            // 
            // tmiSaveJsonFiles
            // 
            this.tmiSaveJsonFiles.Enabled = false;
            this.tmiSaveJsonFiles.Name = "tmiSaveJsonFiles";
            this.tmiSaveJsonFiles.Size = new System.Drawing.Size(93, 26);
            this.tmiSaveJsonFiles.Text = "X";
            this.tmiSaveJsonFiles.Click += new System.EventHandler(this.tmiSaveJsonFiles_Click);
            // 
            // tmiSaveAsJsonFiles
            // 
            this.tmiSaveAsJsonFiles.Enabled = false;
            this.tmiSaveAsJsonFiles.Name = "tmiSaveAsJsonFiles";
            this.tmiSaveAsJsonFiles.Size = new System.Drawing.Size(93, 26);
            this.tmiSaveAsJsonFiles.Text = "X";
            this.tmiSaveAsJsonFiles.Click += new System.EventHandler(this.tmiSaveAsJsonFiles_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(90, 6);
            // 
            // tmiCloseAllFiles
            // 
            this.tmiCloseAllFiles.Enabled = false;
            this.tmiCloseAllFiles.Name = "tmiCloseAllFiles";
            this.tmiCloseAllFiles.Size = new System.Drawing.Size(93, 26);
            this.tmiCloseAllFiles.Text = "X";
            this.tmiCloseAllFiles.Click += new System.EventHandler(this.tmiCloseAllFiles_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(90, 6);
            // 
            // tmiExit
            // 
            this.tmiExit.Name = "tmiExit";
            this.tmiExit.Size = new System.Drawing.Size(93, 26);
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
            this.tmiLanguageZHTW.Size = new System.Drawing.Size(195, 26);
            this.tmiLanguageZHTW.Text = "繁體中文(zh-TW)";
            this.tmiLanguageZHTW.Click += new System.EventHandler(this.tmiLanguageZNCH_Click);
            // 
            // tmiLanguageENUS
            // 
            this.tmiLanguageENUS.Name = "tmiLanguageENUS";
            this.tmiLanguageENUS.Size = new System.Drawing.Size(195, 26);
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
            this.tmiCollapseAll,
            this.toolStripMenuItem8,
            this.tmiOpenFolder});
            this.cmsJsonFiles.Name = "cmsMain";
            this.cmsJsonFiles.Size = new System.Drawing.Size(88, 112);
            // 
            // tmiNewJsonFile
            // 
            this.tmiNewJsonFile.Enabled = false;
            this.tmiNewJsonFile.Name = "tmiNewJsonFile";
            this.tmiNewJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiNewJsonFile.Text = "X";
            this.tmiNewJsonFile.Click += new System.EventHandler(this.tmiNewJsonFile_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(84, 6);
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
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(84, 6);
            // 
            // tmiOpenFolder
            // 
            this.tmiOpenFolder.Enabled = false;
            this.tmiOpenFolder.Name = "tmiOpenFolder";
            this.tmiOpenFolder.Size = new System.Drawing.Size(87, 24);
            this.tmiOpenFolder.Text = "X";
            this.tmiOpenFolder.Click += new System.EventHandler(this.tmiOpenFolder_Click);
            // 
            // cmsJsonFileSelected
            // 
            this.cmsJsonFileSelected.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsJsonFileSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiOpenJsonFile,
            this.tmiViewJsonFile,
            this.tmiRenameJsonFile,
            this.tmiCloseJsonFile,
            this.tmiDeleteJsonFile,
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
            // tmiCloseJsonFile
            // 
            this.tmiCloseJsonFile.Enabled = false;
            this.tmiCloseJsonFile.Name = "tmiCloseJsonFile";
            this.tmiCloseJsonFile.Size = new System.Drawing.Size(87, 24);
            this.tmiCloseJsonFile.Text = "X";
            this.tmiCloseJsonFile.Click += new System.EventHandler(this.tmiCloseJsonFile_Click);
            // 
            // tmiDeleteJsonFile
            // 
            this.tmiDeleteJsonFile.Name = "tmiDeleteJsonFile";
            this.tmiDeleteJsonFile.Size = new System.Drawing.Size(87, 24);
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
            // cmsColumnSelected
            // 
            this.cmsColumnSelected.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsColumnSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiColumnMoveUp,
            this.tmiColumnMoveDown,
            this.toolStripMenuItem7,
            this.tmiDeleteColumn});
            this.cmsColumnSelected.Name = "cmsMain";
            this.cmsColumnSelected.Size = new System.Drawing.Size(88, 82);
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
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(84, 6);
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
            this.btnNewLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLine.Location = new System.Drawing.Point(691, 764);
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
            // epvMain
            // 
            this.epvMain.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 832);
            this.Controls.Add(this.btnDeleteLine);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.lbColumnFKColumn.ResumeLayout(false);
            this.lbColumnFKColumn.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.tbcMain.ResumeLayout(false);
            this.cmsTabSelected.ResumeLayout(false);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.cmsJsonFiles.ResumeLayout(false);
            this.cmsJsonFileSelected.ResumeLayout(false);
            this.cmsColumnSelected.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epvMain)).EndInit();
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
        private System.Windows.Forms.CheckBox ckbColumnDisplay;
        private System.Windows.Forms.CheckBox ckbColumnIsKey;
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
        private System.Windows.Forms.ErrorProvider epvMain;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem tmiOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tmiViewJsonFile;
        private System.Windows.Forms.Label lblColumnDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtMaxValue;
        private System.Windows.Forms.TextBox txtMinValue;
        private System.Windows.Forms.Label lblColumnMaxValue;
        private System.Windows.Forms.Label lblColumnMinValue;
    }
}

