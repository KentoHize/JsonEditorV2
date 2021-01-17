using JsonEditor;
using JsonEditorV2.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
            Var.CI = new CultureInfo("zh-TW");
            ChangeCulture();
            cobColumnType.DataSource = Enum.GetValues(typeof(JType));
            cobColumnType.SelectedIndex = -1;
            tbpStart.BackColor = this.BackColor;
#if !DEBUG
            tmiBackup.Visible = false;
#endif
        }

        private void ChangeCulture()
        {
            Res.Culture = Var.CI;
            RefreshTmiLanguages();
            PatchTextFromResource();
        }


        #region RESOURCES_TEXT_PATCH
        private void PatchTextFromResource()
        {
            Res.Culture = Var.CI;
            Text = Res.JSON_FILE_EDITOR_TITLE;
            lblColumnName.Text = Res.JE_COLUMN_NAME;
            lblColumnType.Text = Res.JE_COLUMN_TYPE;
            lblColumnIsKey.Text = Res.JE_COLUMN_IS_KEY;
            lblColumnDisplay.Text = Res.JE_COLUMN_DISPLAY;
            lblColumnFKTable.Text = Res.JE_COLUMN_FK_TABLE;
            lblColumnFKColumn.Text = Res.JE_COLUMN_FK_COLUMN;
            lblColumnNumberOfRows.Text = Res.JE_COLUMN_NUM_OF_ROWS;
            btnClearMain.Text = Res.JE_BTN_CLEAR_MAIN;
            btnUpdateMain.Text = Res.JE_BTN_UPDATE_MAIN;
            btnUpdateColumn.Text = Res.JE_BTN_UPDATE_COLUMN;
            btnClearColumn.Text = Res.JE_BTN_CLEAR_COLUMN;
            btnNewLine.Text = Res.JE_BTN_NEW_LINE;
            tmiFile.Text = Res.JE_TMI_FILE;
            tmiAbout.Text = Res.JE_TMI_ABOUT;
            tmiNewJsonFiles.Text = Res.JE_TMI_NEW_JSON_FILES;
            tmiLoadJsonFiles.Text = Res.JE_TMI_LOAD_JSON_FILES;
            tmiScanJsonFiles.Text = Res.JE_TMI_SCAN_JSON_FILES;
            tmiSaveJsonFiles.Text = Res.JE_TMI_SAVE_JSON_FILES;
            tmiSaveAsJsonFiles.Text = Res.JE_TMI_SAVE_AS_JSON_FILES;
            tmiCloseAllFiles.Text = Res.JE_TMI_CLOSE_ALL_FILES;
            tmiLanguages.Text = Res.JE_TMI_LANGUAGES;
            tmiExit.Text = Res.JE_TMI_EXIT;
            tmiOpenJsonFile.Text = Res.JE_TMI_OPEN_JSON_FILE;
            tmiDeleteJsonFile.Text = Res.JE_TMI_DELETE_JSON_FILE;
            tmiCloseJsonFile.Text = Res.JE_TMI_CLOSE_JSON_FILE;
            tmiRenameJsonFile.Text = Res.JE_TMI_RENAME_JSON_FILE;
            tmiAddColumn.Text = Res.JE_TMI_ADD_COLUMN;
            tmiNewJsonFile.Text = Res.JE_TMI_NEW_JSON_FILE;
            tmiExpandAll.Text = Res.JE_TMI_EXPAND_ALL;
            tmiCollapseAll.Text = Res.JE_TMI_COLLAPSE_ALL;
            tmiDeleteColumn.Text = Res.JE_TMI_DELETE_COLUMN;
        }
        #endregion

        private void libLines_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //取消FK
        private void CancelFK(JTable sourceTable, JColumn sourceColumn = null)
        {
            foreach (JTable jt in Var.Tables)
                foreach (JColumn jc in jt.Columns)
                    if((sourceColumn == null && jc.FKTable == sourceTable.Name) ||                        
                       (sourceColumn != null && jc.FKColumn == sourceColumn.Name && jc.FKTable == sourceTable.Name))
                        jc.FKTable = jc.FKColumn = null;
        }

        //刷新FK - Table
        private void RenewFK(JTable sourceTable, string newTableName)
        {
            foreach (JTable jt in Var.Tables)
                foreach (JColumn jc in jt.Columns)
                    if (jc.FKTable == sourceTable.Name)
                        jc.FKTable = newTableName;
        }

        //刷新FK - Column
        private void RenewFK(JTable sourceTable, JColumn sourceColumn, string newColumnName)
        {
            foreach (JTable jt in Var.Tables)
                foreach (JColumn jc in jt.Columns)
                    if (jc.FKTable == sourceTable.Name && jc.FKColumn == sourceColumn.Name)
                        jc.FKColumn = newColumnName;
        }

        private void btnUpdateColumn_Click(object sender, EventArgs e)
        {
            //確認資料正確
            if (!Regex.IsMatch(txtColumnName.Text, Const.ColumnNameRegex))
            {
                MessageBox.Show(Res.JE_RUN_UPDATE_COLUMN_M_1, Res.JE_RUN_UPDATE_COLUMN_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Regex.IsMatch(txtColumnNumberOfRows.Text, Const.NumberOfRowsRegex))
            {
                MessageBox.Show(Res.JE_RUN_UPDATE_COLUMN_M_2, Res.JE_RUN_UPDATE_COLUMN_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cobColumnFKTable.SelectedIndex > 0 && cobColumnFKColumn.SelectedIndex == -1)
            {
                MessageBox.Show(Res.JE_RUN_UPDATE_COLUMN_M_3, Res.JE_RUN_UPDATE_COLUMN_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //讀檔
            if (!Var.SelectedColumnParentTable.Loaded)
                LoadJsonFile(Var.SelectedColumnParentTable);

            //如果有資料秀出訊息視窗
            if (Var.SelectedColumnParentTable.Count != 0)
            {
                DialogResult dr = MessageBox.Show(string.Format(Res.JE_RUN_UPDATE_COLUMN_M_4, Var.SelectedColumnParentTable.Count), Res.JE_RUN_UPDATE_COLUMN_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                    return;
            }

            Var.SelectedColumnParentTable.Changed = true;
            Var.JFI.Changed = true;
            Var.SelectedColumn.Display = chbColumnDisplay.Checked;
            Var.SelectedColumn.NumberOfRows = Convert.ToInt32(txtColumnNumberOfRows.Text);
            if (cobColumnFKTable.SelectedValue != null && cobColumnFKColumn.SelectedValue != null)
            {
                Var.SelectedColumn.FKTable = cobColumnFKTable.SelectedValue.ToString();
                Var.SelectedColumn.FKColumn = cobColumnFKColumn.SelectedValue.ToString();
            }
            else
                Var.SelectedColumn.FKTable = Var.SelectedColumn.FKColumn = null;

            //Key檢查，取消Key時同時取消所有相關FK            
            if (Var.SelectedColumn.IsKey && !chbColumnIsKey.Checked)
                CancelFK(Var.SelectedColumnParentTable, Var.SelectedColumn);
            Var.SelectedColumn.IsKey = chbColumnIsKey.Checked;

            //需要存檔
            JType newType = (JType)cobColumnType.SelectedValue;
            if (Var.SelectedColumn.Name != txtColumnName.Text ||
               Var.SelectedColumn.Type != newType)
            {
                //改名
                RenewFK(Var.SelectedColumnParentTable, Var.SelectedColumn, txtColumnName.Text);
                Var.SelectedColumn.Name = txtColumnName.Text;

                //改型態檢查            
                if (Var.SelectedColumn.Type != newType)
                {
                    Var.SelectedColumn.Type = newType;
                    int index = Var.SelectedColumnIndex;
                    foreach (JLine jl in Var.SelectedColumnParentTable)
                        jl[index].Value = jl[index].ParseJType(newType);
                }
                SaveJsonFile(Var.SelectedColumnParentTable);
            }

            sslMain.Text = string.Format(Res.JE_RUN_UPDATE_COLUMN_M_5, Var.SelectedColumn.Name);
            RefreshTrvJsonFiles();

            //RefreshLibLinesUI();
            //RefreshPnlMainUI();
            //RefreshPnlMainValue();
        }

        private void tmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Res.JE_ABOUT_MESSAGE}\n\n{Res.JE_ABOUT_MESSAGE_2}", Res.JE_ABOUT_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tmiNewJsonFiles_Click(object sender, EventArgs e)
        {
            if (AskSaveFiles(Res.JE_TMI_NEW_JSON_FILE) == DialogResult.Cancel)
                return;
#if DEBUG
            fbdMain.SelectedPath = @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\";
#endif
            DialogResult dr = fbdMain.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                Var.JFI = new JFilesInfo(fbdMain.SelectedPath);
                string[] jsonfiles = Directory.GetFiles(fbdMain.SelectedPath, "*.json");
                if (jsonfiles.Length > 0)
                {
                    if (jsonfiles.Length == 1 && jsonfiles[0] == Var.JFI.FileInfoPath)
                        File.Delete(jsonfiles[0]);
                    else
                    {
                        if (File.Exists(Var.JFI.FileInfoPath))
                            dr = MessageBox.Show(string.Format(Res.JE_RUN_NEW_JSON_FILES_Q_1, jsonfiles.Length - 1), Res.JE_RUN_NEW_JSON_FILES_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        else
                            dr = MessageBox.Show(string.Format(Res.JE_RUN_NEW_JSON_FILES_Q_1, jsonfiles.Length), Res.JE_RUN_NEW_JSON_FILES_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            foreach (string s in jsonfiles)
                                File.Delete(s);
                        }
                        else
                            return;
                    }
                }

                tmiCloseAllFiles_Click(this, e);
                Var.Tables = new List<JTable>();
                Var.JFI.DirectoryPath = fbdMain.SelectedPath;
                tmiCloseAllFiles.Enabled = true;
                tmiScanJsonFiles.Enabled = true;
                tmiNewJsonFile.Enabled = true;
                RefreshTrvJsonFiles();
                sslMain.Text = string.Format(Res.JE_RUN_NEW_JSON_FILES_M_1, Var.JFI.DirectoryPath);
            }
        }

        private DialogResult AskSaveFiles(string title)
        {
            if (Var.Changed)
            {
                DialogResult dr = MessageBox.Show(string.Format(Res.JE_RUN_SAVE_FILES_CHECK, Var.JFI.DirectoryPath), title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    tmiSaveJsonFiles_Click(this, new EventArgs());
                return dr;
            }
            return DialogResult.No;
        }

        private void tmiExit_Click(object sender, EventArgs e)
        {       
            if (AskSaveFiles(Res.JE_TMI_EXIT) == DialogResult.Cancel)
                return;
            Application.Exit();
        }

        private void tmiScanJsonFiles_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(Res.JE_RUN_SCAN_JSON_FILES_M_1, Res.JE_RUN_SCAN_JSON_FILES_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr != DialogResult.OK)
                return;

            tmiCloseAllFiles_Click(this, e);
            Var.Tables = new List<JTable>();
            Var.JFI = new JFilesInfo(Var.JFI.DirectoryPath);
            string[] jsonfiles = Directory.GetFiles(Var.JFI.DirectoryPath, "*.json");
            foreach (string file in jsonfiles)
            {
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);
                    if (file == Var.JFI.FileInfoPath)
                    {
                        Var.JFI = JsonConvert.DeserializeObject<JFilesInfo>(sr.ReadToEnd());
                        Var.JFI.DirectoryPath = fbdMain.SelectedPath;
                    }
                    else
                    {
                        JTable jt = new JTable(Path.GetFileNameWithoutExtension(file), JsonConvert.DeserializeObject(sr.ReadToEnd()), true);
                        Var.Tables.Add(jt);
                    }
                }
            }
            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_SCAN_JSON_FILES_M_2, Var.Tables.Count);
        }

        private void tmiLoadJsonFiles_Click(object sender, EventArgs e)
        {
            if (AskSaveFiles(Res.JE_TMI_LOAD_JSON_FILES) == DialogResult.Cancel)
                return;
#if DEBUG
            fbdMain.SelectedPath = @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\Test1";
#endif
            DialogResult dr = fbdMain.ShowDialog(this);
            if (dr != DialogResult.OK)
                return;

            tmiCloseAllFiles_Click(this, e);
            Var.JFI = new JFilesInfo(fbdMain.SelectedPath);
            string[] jsonfiles = Directory.GetFiles(Var.JFI.DirectoryPath, "*.json");
            Var.Tables = new List<JTable>();
            JTable table;

            foreach (string file in jsonfiles)
            {
                FileInfo fi = new FileInfo(file);

                if (file == Var.JFI.FileInfoPath)
                {
                    LoadJFilesInfo(file);
                    Var.JFI.DirectoryPath = fbdMain.SelectedPath;
                }
                else if (fi.Length < 10)
                {
                    table = new JTable(Path.GetFileNameWithoutExtension(file), true);
                    LoadJsonFile(table);
                    Var.Tables.Add(table);
                }
                else
                {
                    table = new JTable(Path.GetFileNameWithoutExtension(file));
                    LoadPartialJsonFile(table);
                    Var.Tables.Add(table);
                }
            }

            //有JFileInfo的話相連
            try
            {
                if (Var.JFI.TablesInfo.Count != 0)
                    foreach (JTable jt in Var.Tables)
                        jt.LoadFileInfo(Var.JFI.TablesInfo.Find(m => m.Name == jt.Name));
            }
            catch (Exception ex)
            {
                HandleException(ex, Res.JE_RUN_LOAD_JSON_FILES_M_2, Res.JE_RUN_LOAD_JSON_FILES_TITLE);
            }
            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_LOAD_JSON_FILES_M_1, Var.Tables.Count);

        }



        private string GetColumnNodeString(JColumn jc)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(jc.Name);
            if (!string.IsNullOrEmpty(jc.FKTable))
                sb.AppendFormat("[FK:{0}]", jc.FKTable);
            sb.Append(":");
            sb.Append(jc.Type);
            return sb.ToString();
        }


        private string GetTableNodeString(JTable jt)
            => $"{jt.Name}{(jt.Changed ? "*" : "")}{(jt.Loaded ? "" : "(Unload)")}";

        private void RefreshTrvJsonFiles()
        {
            trvJsonFiles.Nodes.Clear();
            tmiCloseAllFiles.Enabled = false;
            tmiScanJsonFiles.Enabled = false;
            tmiNewJsonFile.Enabled = false;
            tmiSaveJsonFiles.Enabled = false;
            tmiSaveAsJsonFiles.Enabled = false;
            if (Var.Tables == null)
                return;

            string fullName = $"{Var.JFI.Name}({Var.JFI.DirectoryPath})";
            Var.RootNode = new TreeNode($"{fullName.Substring(0, 25)}...", 0, 0);
            if (Var.Changed)
                Var.RootNode.Text += "*";
            Var.RootNode.ToolTipText = fullName;
            trvJsonFiles.Nodes.Add(Var.RootNode);
            TreeNode fileNode, tr;

            //Dictionary<string, string> fks = new Dictionary<string, string>();
            foreach (JTable jt in Var.Tables)
            {
                fileNode = new TreeNode { Text = GetTableNodeString(jt), Tag = jt.Name, ImageIndex = 1, SelectedImageIndex = 1 };
                fileNode.ToolTipText = fileNode.Text;

                Var.RootNode.Nodes.Add(fileNode);
                if (Var.SelectedColumnParentTable == jt && Var.SelectedColumn == null)
                    trvJsonFiles.SelectedNode = fileNode;
                foreach (JColumn jc in jt.Columns)
                {
                    tr = new TreeNode { Text = GetColumnNodeString(jc), Tag = jc.Name };
                    if (jc.IsKey)
                        tr.ImageIndex = tr.SelectedImageIndex = 3;
                    else
                        tr.ImageIndex = tr.SelectedImageIndex = 2;
                    tr.ToolTipText = tr.Text;
                    fileNode.Nodes.Add(tr);
                    if (Var.SelectedColumn == jc)
                        trvJsonFiles.SelectedNode = tr;
                    //if (!string.IsNullOrEmpty(jc.FKTable))
                    //    fks.Add(jc.Name, jc.FKTable);
                }

                //foreach (KeyValuePair<string, string> kvp in fks)
                //    fileNode.Nodes.Add(new TreeNode { Name = $"FK:{kvp.Key} -> {kvp.Value}", ImageIndex = 3, SelectedImageIndex = 3, ));

            }

            if (trvJsonFiles.SelectedNode == null || trvJsonFiles.SelectedNode == Var.RootNode)
                Var.RootNode.Expand();

            tmiCloseAllFiles.Enabled = true;
            tmiScanJsonFiles.Enabled = true;
            tmiNewJsonFile.Enabled = true;
            tmiSaveAsJsonFiles.Enabled = true;
            tmiSaveJsonFiles.Enabled = true;
            RefreshPnlFileInfo();
        }

        private void RefreshTbcMain()
        {
            //TBCMain
            while (Var.OpenedTable.Count > tbcMain.TabPages.Count)
                tbcMain.TabPages.Add(new TabPage());

            while (Var.OpenedTable.Count < tbcMain.TabPages.Count && tbcMain.TabPages.Count != 1)
                tbcMain.TabPages.RemoveAt(tbcMain.TabPages.Count - 1);

            if (Var.OpenedTable.Count == 0)
                tbcMain.TabPages[0].Text = "";

            for(int i = 0; i < Var.OpenedTable.Count; i++)
                tbcMain.TabPages[i].Text = Var.OpenedTable[i].Name;

            tbcMain.SelectedIndex = Var.PageIndex;
            
            //LSBLine
            lsbLines.Items.Clear();
            if (Var.SelectedTable == null)
                return;

            StringBuilder displayString;
            foreach (JLine jl in Var.SelectedTable)
            {
                displayString = new StringBuilder();
                for (int i = 0; i < Var.SelectedTable.Columns.Count; i++)
                {
                    if (Var.SelectedTable.Columns[i].Display)
                        displayString.Append(jl[i].Value);
                }
                lsbLines.Items.Add(displayString.ToString());
            }
            //if (selectedLine != null)
            //    libLines.SelectedIndex = selectedTable.Lines.FindIndex(m => m == selectedLine);
        }

        private void tmiCloseAllFiles_Click(object sender, EventArgs e)
        {
            if (AskSaveFiles(Res.JE_TMI_CLOSE_ALL_FILES) == DialogResult.Cancel)
                return;
            Var.Tables = null;
            Var.OpenedTable.Clear();
            if (Var.JFI != null)
                Var.JFI.Dispose();
            Var.RootNode = null;
            Var.SelectedColumn = null;
            Var.SelectedColumnParentTable = null;            
            Var.PageIndex = -1;
            //Var.Lines.Clear();
            RefreshTrvJsonFiles();
            RefreshTbcMain();
            //RefreshLibLinesUI();
            //RefreshPnlMainUI();
            sslMain.Text = "";
        }

        private void tmiSaveJsonFiles_Click(object sender, EventArgs e)
        {
            Var.JFI.TablesInfo.Clear();
            foreach (JTable jt in Var.Tables)
                Var.JFI.TablesInfo.Add(jt.GetJTableInfo());

            //存JSONFilesInfo檔
            SaveJFilesInfo();

            //存JSONFiles
            foreach (JTable jt in Var.Tables)
                if (jt.Loaded)
                    SaveJsonFile(jt);

            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_SAVE_JSON_FILES_M_1, Var.JFI.DirectoryPath);            
        }

        private void trvJsonFiles_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (Var.DblClick)
                e.Cancel = true;
        }

        private void trvJsonFiles_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (Var.DblClick)
                e.Cancel = true;
        }

        private void trvJsonFiles_MouseDown(object sender, MouseEventArgs e)
        {
            trvJsonFiles.ContextMenuStrip = null;
            Var.DblClick = e.Button == MouseButtons.Left && e.Clicks >= 2;
        }

        private void trvJsonFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == Var.RootNode)
            {
                trvJsonFiles.ContextMenuStrip = cmsJsonFiles;
            }
            else if (e.Node.Parent == Var.RootNode)
            {
                Var.SelectedColumn = null;
                Var.SelectedColumnParentTable = Var.Tables.Find(m => m.Name == e.Node.Tag.ToString()); ;
                RefreshPnlFileInfo();

                if (e.Button == MouseButtons.Right)
                {
                    trvJsonFiles.SelectedNode = e.Node;
                    if (Var.OpenedTable.Exists(m => m.Name == e.Node.Tag.ToString()))
                    {
                        tmiOpenJsonFile.Enabled = false;
                        tmiCloseJsonFile.Enabled = true;
                    }
                    else
                    {
                        tmiOpenJsonFile.Enabled = true;
                        tmiCloseJsonFile.Enabled = false;
                    }
                    trvJsonFiles.ContextMenuStrip = cmsJsonFileSelected;
                }
            }
            else
            {
                Var.SelectedColumnParentTable = Var.Tables.Find(m => m.Name == e.Node.Parent.Tag.ToString());
                Var.SelectedColumn = Var.SelectedColumnParentTable.Columns.Find(t => t.Name == e.Node.Tag.ToString());
                RefreshPnlFileInfo();
                if (e.Button == MouseButtons.Right)
                {
                    trvJsonFiles.SelectedNode = e.Node;
                    trvJsonFiles.ContextMenuStrip = cmsColumnSelected;
                }
            }
        }

        private void RefreshPnlFileInfo()
        {
            var ds = (from t in Var.Tables
                      where t.HasKey
                      select new { t.Name }).ToList();
            ds.Insert(0, new { Name = (string)null });
            cobColumnFKTable.DataSource = ds;
            if (Var.SelectedColumn != null)
            {
                cobColumnType.SelectedIndex = cobColumnType.Items.IndexOf(Var.SelectedColumn.Type);
                txtColumnName.Text = Var.SelectedColumn.Name;
                chbColumnDisplay.Checked = Var.SelectedColumn.Display;
                chbColumnIsKey.Checked = Var.SelectedColumn.IsKey;
                if (!string.IsNullOrEmpty(Var.SelectedColumn.FKTable))
                    cobColumnFKTable.SelectedValue = Var.SelectedColumn.FKTable;
                cobColumnFKTable_SelectedIndexChanged(this, new EventArgs());
                if (!string.IsNullOrEmpty(Var.SelectedColumn.FKColumn))
                    cobColumnFKColumn.SelectedValue = Var.SelectedColumn.FKColumn;
                txtColumnNumberOfRows.Text = Var.SelectedColumn.NumberOfRows.ToString();
                btnUpdateColumn.Enabled = true;
            }
            else
            {
                btnClearColumn_Click(this, new EventArgs());
                btnUpdateColumn.Enabled = false;
            }
            RefreshTbcMain();
        }

        private void RefreshCloseFileState()
        {

        }

        private void trvJsonFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == Var.RootNode)
            { }
            else if (e.Node.Parent == Var.RootNode)
            {
                tmiOpenJsonFile_Click(this, new EventArgs());
            }
        }

        private void tmiNewJsonFile_Click(object sender, EventArgs e)
        {
            frmInputBox fib = new frmInputBox("New File");
            DialogResult dr = fib.ShowDialog(this);
            if (dr == DialogResult.Cancel)
                return;
            try
            {
                string newFile = Path.Combine(Var.JFI.DirectoryPath, $"{fib.InputValue}.json");
                using (FileStream fs = new FileStream(newFile, FileMode.Create))
                { }

                JTable jt = new JTable(fib.InputValue, true);
                Var.Tables.Add(jt);
                Var.JFI.Changed = true;
                
                //TreeNode tr = new TreeNode { Text = GetTableNodeString(jt), ImageIndex = 1, SelectedImageIndex = 1, Tag = jt.Name };
                //tr.ToolTipText = tr.Text;
                //Var.RootNode.Nodes.Add(tr); 
            }
            catch (Exception ex)
            {
                HandleException(ex, Res.JE_RUN_NEW_JSON_FILE_M_2, Res.JE_RUN_NEW_JSON_FILE_TITLE);
            }
            RefreshTrvJsonFiles();
        }

        private void HandleException(Exception ex, string content = null, string title = null)
        {
            if (string.IsNullOrEmpty(content))
                content = Res.JE_ERROR_DEFAULT_MESSAGE;
            if (string.IsNullOrEmpty(title))
                title = Res.JE_ERROR_DEFAULT_TITLE;
            MessageBox.Show(string.Format(content, ex.Message), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tmiAddColumn_Click(object sender, EventArgs e)
        {
            frmInputBox fib = new frmInputBox("Add Column");
            DialogResult dr = fib.ShowDialog(this);
            if (dr == DialogResult.Cancel)
                return;

            if (Var.SelectedColumnParentTable.Columns.Exists(m => m.Name == fib.InputValue))
            {
                MessageBox.Show(string.Format(Res.JE_RUN_ADD_COLUMN_M_1, fib.InputValue), Res.JE_TMI_ADD_COLUMN, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            JColumn jc = new JColumn(fib.InputValue);
            Var.SelectedColumnParentTable.Columns.Add(jc);
            Var.SelectedColumn = jc;
            Var.SelectedColumnParentTable.Changed = true;
            Var.JFI.Changed = true;
            RefreshTrvJsonFiles();
        }

        private void tmiBackup_Click(object sender, EventArgs e)
        {
            string BackupPath = @"E:\Backup\JsonEditorV2";
            string ProjectPath = @"C:\Programs\WinForm\JsonEditorV2";
            string ProjectName = "JsonEditorV2";

            File.Copy(Path.Combine(ProjectPath, $"{ProjectName}.sln"), Path.Combine(BackupPath, $"{ProjectName}.sln"), true);

            if (Directory.Exists(Path.Combine(BackupPath, ProjectName)))
                DirectoryCopy(Path.Combine(ProjectPath, ProjectName), Path.Combine(BackupPath, ProjectName));
            else
            {
                MessageBox.Show("Target backup drive or directory do not exist.");
                return;
            }
            MessageBox.Show("OK");
        }
        #region DirectoryCopy
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs = true)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
        #endregion

        private void btnClearColumn_Click(object sender, EventArgs e)
        {
            txtColumnName.Text = "";
            cobColumnType.SelectedIndex = 0;
            chbColumnDisplay.Checked = false;
            chbColumnIsKey.Checked = false;
            cobColumnFKTable.SelectedIndex = -1; //聯動            
            txtColumnNumberOfRows.Text = "0";
        }

        private void cobColumnFKTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobColumnFKTable.SelectedIndex < 1)
                cobColumnFKColumn.DataSource = null;
            else
            {
                var ds = (from c in Var.Tables.Find(m => m.Name == cobColumnFKTable.SelectedValue.ToString()).Columns
                          where c.IsKey && c != Var.SelectedColumn
                          select new { c.Name }).ToList();
                cobColumnFKColumn.DataSource = ds;
                cobColumnFKColumn.DisplayMember = "Name";
                cobColumnFKColumn.ValueMember = "Name";
                cobColumnFKColumn.SelectedIndex = -1;
            }
        }

        private void RefreshTmiLanguages()
        {
            foreach (ToolStripItem tsi in tmiLanguages.DropDownItems)
            {
                ToolStripMenuItem tsmi = tsi as ToolStripMenuItem;
                if (tsmi != null)
                    tsmi.Checked = false;
                if (tsmi.Name.Contains(Var.CI.Name.Remove(2, 1).ToUpper()))
                    tsmi.Checked = true;
            }
        }

        private void tmiLanguageZNCH_Click(object sender, EventArgs e)
        {
            Var.CI = new CultureInfo("zh-TW");
            ChangeCulture();
        }

        private void tmiLanguageENUS_Click(object sender, EventArgs e)
        {
            Var.CI = new CultureInfo("en-US");
            ChangeCulture();
        }

        private void tmiSaveAsJsonFiles_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbdMain.ShowDialog(this);
            if (dr != DialogResult.OK)
                return;

            string[] files = Directory.GetFiles(fbdMain.SelectedPath);
            if (files.Length != 0)
            {
                dr = MessageBox.Show(Res.JE_RUN_SAVE_AS_JSON_FILES_M_1, Res.JE_TMI_SAVE_AS_JSON_FILES, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr != DialogResult.OK)
                    return;
                try
                {
                    foreach (string s in files)
                        File.Delete(s);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            files = Directory.GetFiles(Var.JFI.DirectoryPath, "*.json");
            try
            {
                foreach (string s in files)
                    File.Copy(s, Path.Combine(fbdMain.SelectedPath, Path.GetFileName(s)));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            Var.JFI.DirectoryPath = fbdMain.SelectedPath;
            tmiSaveJsonFiles_Click(this, e);
        }

        private void tmiOpenJsonFile_Click(object sender, EventArgs e)
        {
            if (Var.OpenedTable.Contains(Var.SelectedColumnParentTable))
                return;

            if (!Var.SelectedColumnParentTable.Loaded)
            {
                LoadJsonFile(Var.SelectedColumnParentTable);
                /* 特殊 */
                trvJsonFiles.SelectedNode.Text = GetTableNodeString(Var.SelectedColumnParentTable);
                trvJsonFiles.SelectedNode.ToolTipText = trvJsonFiles.SelectedNode.Text;
                /* 結束 */
            }

            //補足效果
            Var.DblClick = false; 
            if (trvJsonFiles.SelectedNode.IsExpanded)
                trvJsonFiles.SelectedNode.Collapse();
            else
                trvJsonFiles.SelectedNode.Expand();

            Var.OpenedTable.Add(Var.SelectedColumnParentTable);            
            Var.PageIndex = Var.OpenedTable.Count - 1;

            RefreshTbcMain();
        }

        private void LoadJFilesInfo(string file)
        {
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);
                    Var.JFI = JsonConvert.DeserializeObject<JFilesInfo>(sr.ReadToEnd());
                    sr.Dispose();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void LoadJsonFile(JTable jt)
        {
            try
            {
                using (FileStream fs = new FileStream(Path.Combine(Var.JFI.DirectoryPath, $"{jt.Name}.json"), FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);
                    jt.LoadJson(JsonConvert.DeserializeObject(sr.ReadToEnd()));
                    sr.Dispose();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void LoadPartialJsonFile(JTable jt)
        {
            //讀5行之後結束
            int pflag = 0;
            object value = "";
            try
            {
                using (FileStream fs = new FileStream(Path.Combine(Var.JFI.DirectoryPath, $"{jt.Name}.json"), FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);
                    JsonTextReader reader = new JsonTextReader(sr);
                    reader.Skip();//StartArray

                    for (int i = 0; i < 5; i++)
                    {
                        JLine jl = new JLine();
                        reader.Skip();//StartObject

                        while (reader.TokenType != JsonToken.EndObject)
                        {
                            reader.Read();
                            if (reader.TokenType == JsonToken.PropertyName)
                            {
                                pflag = 1;
                                value = reader.Value;
                            }
                            else if (pflag == 1)
                            {
                                if (reader.TokenType == JsonToken.StartObject ||
                                    reader.TokenType == JsonToken.StartArray)
                                {
                                    //直接跳出
                                    int skipFlag = 1;
                                    while (skipFlag == 0)
                                    {
                                        reader.Read();
                                        if (reader.TokenType == JsonToken.StartObject)
                                            skipFlag++;
                                        else if (reader.TokenType == JsonToken.EndObject)
                                            skipFlag--;
                                    }
                                }
                                else
                                {
                                    if (i == 0)
                                        jt.Columns.Add(new JColumn(value.ToString(), Extentions.ToJType(reader.TokenType)));
                                    jl.Add(JValue.FromObject(reader.Value));
                                }
                                pflag = 0;
                            }
                        }
                    }
                    sr.Dispose();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void SaveJsonFile(JTable jt)
        {
            try
            {
                using (FileStream fs = new FileStream(Path.Combine(Var.JFI.DirectoryPath, $"{jt.Name}.json"), FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(JsonConvert.SerializeObject(jt.GetJsonObject(), Formatting.Indented));
                    sw.Close();
                }
                jt.Changed = false;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void SaveJFilesInfo()
        {
            try
            {
                using (FileStream fs = new FileStream(Var.JFI.FileInfoPath, FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(JsonConvert.SerializeObject(Var.JFI, Formatting.Indented));
                    sw.Close();
                }
                Var.JFI.Changed = false;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void tmiExpandAll_Click(object sender, EventArgs e)
        {
            Var.RootNode.ExpandAll();
        }

        private void tmiCollapseAll_Click(object sender, EventArgs e)
        {
            Var.RootNode.Collapse();
            Var.RootNode.Expand();
        }

        private void tmiDeleteColumn_Click(object sender, EventArgs e)
        {
            //讀檔            
            if (!Var.SelectedColumnParentTable.Loaded)
                LoadJsonFile(Var.SelectedColumnParentTable);

            //如果有資料秀出訊息視窗
            if (Var.SelectedColumnParentTable.Count != 0)
            {
                DialogResult dr = MessageBox.Show(string.Format(Res.JE_RUN_DELETE_COLUMN_M_1, Var.SelectedColumnParentTable.Count), Res.JE_TMI_DELETE_COLUMN, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                    return;
            }

            Var.SelectedColumnParentTable.Changed = true;
            Var.JFI.Changed = true;

            //取消FK
            CancelFK(Var.SelectedColumnParentTable, Var.SelectedColumn);

            //資料全部抓出來砍掉
            foreach (JLine jl in Var.SelectedColumnParentTable)
                jl.RemoveAt(Var.SelectedColumnParentTable.Columns.IndexOf(Var.SelectedColumn));

            string removedName = Var.SelectedColumn.Name;
            Var.SelectedColumnParentTable.Columns.Remove(Var.SelectedColumn);
            Var.SelectedColumn = null;

            //存檔
            SaveJsonFile(Var.SelectedColumnParentTable);
            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_DELETE_COLUMN_M_2, removedName);
        }

        private void btnNewLine_Click(object sender, EventArgs e)
        {

        }

        private void tmiRenameJsonFile_Click(object sender, EventArgs e)
        {
            frmInputBox fib = new frmInputBox("Rename File");            
            DialogResult dr = fib.ShowDialog(this);
            if (dr == DialogResult.Cancel)
                return;

            if (fib.InputValue == Var.SelectedColumnParentTable.Name)
                return;

            if(Var.Tables.Exists(m => m.Name == fib.InputValue))
            {   
                MessageBox.Show(string.Format(Res.JE_RUN_RENAME_JSON_FILE_M_1, fib.InputValue), Res.JE_TMI_RENAME_JSON_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                File.Move(Path.Combine(Var.JFI.DirectoryPath, $"{Var.SelectedColumnParentTable.Name}.json"), Path.Combine(Var.JFI.DirectoryPath, $"{fib.InputValue}.json"));
                RenewFK(Var.SelectedColumnParentTable, fib.InputValue);
                Var.SelectedColumnParentTable.Name = fib.InputValue;                
                Var.SelectedColumnParentTable.Changed = true;
                Var.JFI.Changed = true;
            }
            catch (Exception ex)
            {
                HandleException(ex, Res.JE_RUN_NEW_JSON_FILE_M_2, Res.JE_RUN_NEW_JSON_FILE_TITLE);
            }
            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_RENAME_JSON_FILE_M_2, fib.InputValue);
        }

        private void tmiDeleteJsonFile_Click(object sender, EventArgs e)
        {   
            DialogResult dr = MessageBox.Show(string.Format(Res.JE_RUN_DELETE_JSON_FILE_M_1, Var.SelectedColumnParentTable.Name), Res.JE_TMI_DELETE_JSON_FILE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;

            CancelFK(Var.SelectedColumnParentTable);
            Var.JFI.Changed = true;
            string fileName = Var.SelectedColumnParentTable.Name;
            try
            {
                File.Delete(Path.Combine(Var.JFI.DirectoryPath, $"{fileName}.json"));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }            
            Var.Tables.Remove(Var.SelectedColumnParentTable);

            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_DELETE_JSON_FILE_M_5, fileName);
        }
    }
}
