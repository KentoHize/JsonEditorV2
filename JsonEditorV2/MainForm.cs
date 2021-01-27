using Aritiafel.Items;
using Aritiafel.Organizations;
using JsonEditor;
using JsonEditorV2.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Setting.CI = new CultureInfo("en-US");
            Setting.UseQuickCheck = false;
            ChangeCulture();
            cobColumnType.DataSource =
                Enum.GetValues(typeof(JType)).OfType<JType>()
                .Except(new List<JType> { JType.None })
                .ToList();
            cobColumnType.SelectedIndex = -1;
            tbpStart.BackColor = this.BackColor;
#if !DEBUG
            tmiBackup.Visible = false;
#endif
        }

        private void ChangeCulture()
        {
            Res.Culture = Setting.CI;
            RabbitCouriers.RegisterRMAndCI(Res.ResourceManager, Res.Culture);
            RefreshTmiLanguages();
            PatchTextFromResource();
        }


        #region RESOURCES_TEXT_PATCH
        private void PatchTextFromResource()
        {
            Text = Res.JSON_FILE_EDITOR_TITLE;
            lblColumnName.Text = Res.JE_COLUMN_NAME;
            lblColumnType.Text = Res.JE_COLUMN_TYPE;
            lblColumnIsKey.Text = Res.JE_COLUMN_IS_KEY;
            lblColumnDisplay.Text = Res.JE_COLUMN_DISPLAY;
            lblColumnFKTable.Text = Res.JE_COLUMN_FK_TABLE;
            lblColumnFKColumn.Text = Res.JE_COLUMN_FK_COLUMN;
            lblColumnNumberOfRows.Text = Res.JE_COLUMN_NUM_OF_ROWS;
            lblColumnRegex.Text = Res.JE_COLUMN_REGEX;
            lblColumnlIsNullable.Text = Res.JE_COLUMN_IS_NULLABLE;
            lblColumnDescription.Text = Res.JE_COLUMN_DESCRIPTION;
            lblColumnMinValue.Text = Res.JE_COLUMN_MIN_VALUE;
            lblColumnMaxValue.Text = Res.JE_COLUMN_MAX_VALUE;
            lblColumnMaxLength.Text = Res.JE_COLUMN_MAX_LENGTH;
            lblColumnIsUnique.Text = Res.JE_COLUMN_IS_UNIQUE;
            btnClearMain.Text = Res.JE_BTN_CLEAR_MAIN;
            btnUpdateMain.Text = Res.JE_BTN_UPDATE_MAIN;
            btnUpdateColumn.Text = Res.JE_BTN_UPDATE_COLUMN;
            btnClearColumn.Text = Res.JE_BTN_CLEAR_COLUMN;
            btnNewLine.Text = Res.JE_BTN_NEW_LINE;
            btnDeleteLine.Text = Res.JE_BTN_DELETE_LINE;
            ckbQuickCheck.Text = Res.JE_CKB_QUICK_CEHCK;
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
            tmiViewJsonFile.Text = Res.JE_TMI_VIEW_JSON_FILE;
            tmiDeleteJsonFile.Text = Res.JE_TMI_DELETE_JSON_FILE;
            tmiCloseJsonFile.Text = Res.JE_TMI_CLOSE_JSON_FILE;
            tmiRenameJsonFile.Text = Res.JE_TMI_RENAME_JSON_FILE;
            tmiRenameColumn.Text = Res.JE_TMI_RENAME_COLUMN;
            tmiAddColumn.Text = Res.JE_TMI_ADD_COLUMN;
            tmiNewJsonFile.Text = Res.JE_TMI_NEW_JSON_FILE;
            tmiExpandAll.Text = Res.JE_TMI_EXPAND_ALL;
            tmiCollapseAll.Text = Res.JE_TMI_COLLAPSE_ALL;
            tmiOpenFolder.Text = Res.JE_TMI_OPEN_FOLDER;
            tmiViewJFIFile.Text = Res.JE_TMI_VIEW_JFI_FILE;
            tmiRefreshFiles.Text = Res.JE_TMI_REFRESH_FILES;
            tmiColumnMoveUp.Text = Res.JE_TMI_COLUMN_MOVE_UP;
            tmiColumnMoveDown.Text = Res.JE_TMI_COLUMN_MOVE_DOWN;
            tmiDeleteColumn.Text = Res.JE_TMI_DELETE_COLUMN;
            tmiCloseTab.Text = Res.JE_TMI_CLOSE_TAB;
        }
        #endregion

        private void lsbLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            Var.SelectedLineIndex = lsbLines.SelectedIndex;
            RefreshPnlMainValue();
        }

        //取消FK
        private void CancelFK(JTable sourceTable, JColumn sourceColumn = null)
        {
            foreach (JTable jt in Var.Tables)
                foreach (JColumn jc in jt.Columns)
                    if ((sourceColumn == null && jc.FKTable == sourceTable.Name) ||
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

        //確認FKType
        private void CheckFKType(JTable sourceTable, JColumn sourceColumn, JType newType)
        {
            foreach (JTable jt in Var.Tables)
            {
                List<int> columnIndexs = new List<int>();
                for (int i = 0; i < jt.Columns.Count; i++)
                    if (jt.Columns[i].FKTable == sourceTable.Name && jt.Columns[i].FKColumn == sourceColumn.Name)
                        columnIndexs.Add(i);

                object result;
                foreach (JLine jl in jt)
                {
                    for (int i = 0; i < columnIndexs.Count; i++)
                    {
                        jl[columnIndexs[i]].Value.TryParseJType(newType, out result);
                        jl[columnIndexs[i]].Value = result;
                    }
                }
            }
        }

        public bool CheckMinMaxValue(string content, JType type, bool isMaxValue = false)
        {
            if (string.IsNullOrEmpty(content))
                return false;
            if (type.IsNumber())
            {
                if (type == JType.Double)
                {
                    if (!double.TryParse(content, out double result))
                        return false;
                    if (isMaxValue)
                        return result <= Convert.ToDouble(type.GetMaxValue());
                    return result >= Convert.ToDouble(type.GetMinValue());
                }
                else
                {
                    if (!decimal.TryParse(content, out decimal result))
                        return false;
                    if (isMaxValue)
                        return result <= Convert.ToDecimal(type.GetMaxValue());
                    return result >= Convert.ToDecimal(type.GetMinValue());
                }
            }
            else if (type.IsDateTime())
            {
                DateTime result;
                if (!DateTime.TryParse(content, out result))
                    return false;
                if (type == JType.Time)
                    result = DateTime.MinValue.Add(result.TimeOfDay);
                if (isMaxValue)
                    return result <= (DateTime)type.GetMaxValue();
                return result >= (DateTime)type.GetMinValue();
            }
            return false;
        }

        public void btnUpdateColumn_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtColumnName.Text, Const.ColumnNameRegex))
            {
                //欄位名檢查
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_UPDATE_COLUMN_M_1", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                return;
            }
            else if (!Regex.IsMatch(txtColumnNumberOfRows.Text, Const.NumberOfRowsRegex))
            {
                //欄位行數檢查
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_UPDATE_COLUMN_M_2", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                return;
            }
            else if (!long.TryParse(txtColumnMaxLength.Text, out long r1) || r1 < 0)
            {
                //文字最大長度檢查
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_UPDATE_COLUMN_M_11", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                return;
            }
            else if (ckbColumnIsKey.Checked && ckbColumnIsNullable.Checked)
            {
                //Key和Nullable相斥檢查
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_UPDATE_COLUMN_M_7", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                ckbColumnIsKey.Checked = Var.SelectedColumn.IsKey;
                ckbColumnIsNullable.Checked = Var.SelectedColumn.IsNullable;
                return;
            }
            else if (cobColumnFKTable.SelectedIndex > 0 && cobColumnFKColumn.SelectedIndex == -1)
            {
                //欄位FK檢查
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_UPDATE_COLUMN_M_3", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                return;
            }

            JType newType = (JType)cobColumnType.SelectedValue;

            //確認最大、最小值正確
            if (!newType.IsNumber() && !newType.IsDateTime())
            {
                txtColumnMinValue.Text = "";
                txtColumnMaxValue.Text = "";
            }
            else
            {
                if (txtColumnMinValue.Text != "" && !CheckMinMaxValue(txtColumnMinValue.Text, newType))
                {
                    RabbitCouriers.SentErrorMessageByResource("JE_RUN_UPDATE_COLUMN_M_8", Res.JE_RUN_UPDATE_COLUMN_TITLE, txtColumnMinValue.Text);
                    txtColumnMinValue.Text = newType.GetMinValue().ToString();
                    return;
                }
                if (txtColumnMaxValue.Text != "" && !CheckMinMaxValue(txtColumnMaxValue.Text, newType, true))
                {
                    RabbitCouriers.SentErrorMessageByResource("JE_RUN_UPDATE_COLUMN_M_9", Res.JE_RUN_UPDATE_COLUMN_TITLE, txtColumnMaxValue.Text);
                    txtColumnMaxValue.Text = newType.GetMaxValue().ToString();
                    return;
                }
                if (txtColumnMinValue.Text != "" && txtColumnMaxValue.Text != "" &&
                txtColumnMinValue.Text.CompareTo(txtColumnMaxValue.Text, newType) == 1)
                {
                    RabbitCouriers.SentErrorMessageByResource("JE_RUN_UPDATE_COLUMN_M_10", Res.JE_RUN_UPDATE_COLUMN_TITLE, txtColumnMinValue.Text, txtColumnMaxValue.Text);
                    return;
                }
            }

            //確認Regex正確
            if (newType != JType.String)
                txtColumnRegex.Text = "";
            try
            {
                if (txtColumnRegex.Text != "")
                    Regex.IsMatch("__", txtColumnRegex.Text);
            }
            catch
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_UPDATE_COLUMN_M_4", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                return;
            }

            bool recheckTable = false;

            //讀檔
            if (!Var.SelectedColumnParentTable.Loaded)
                LoadJsonFile(Var.SelectedColumnParentTable);

            //如果有資料，並且需要改資料則秀出訊息視窗
            if (Var.SelectedColumnParentTable.Count != 0)
            {
                if ((Var.SelectedColumn.IsKey != ckbColumnIsKey.Checked && ckbColumnIsKey.Checked) ||
                   Var.SelectedColumn.Name != txtColumnName.Text ||
                   Var.SelectedColumn.Type != newType ||
                   (Var.SelectedColumn.IsNullable && !ckbColumnIsNullable.Checked))
                {
                    DialogResult dr = RabbitCouriers.SentNoramlQuestionByResource("JE_RUN_UPDATE_COLUMN_M_5", Res.JE_RUN_UPDATE_COLUMN_TITLE, Var.SelectedColumnParentTable.Count.ToString());
                    if (dr == DialogResult.Cancel)
                        return;
                }
            }

            //先改名
            if (Var.SelectedColumn.Name != txtColumnName.Text)
                if (!ChangeColumnName(Var.SelectedColumnParentTable, Var.SelectedColumn, txtColumnName.Text))
                    return;

            //輸入較無關值
            Var.SelectedColumnParentTable.Changed = true;
            Var.JFI.Changed = true;
            Var.SelectedColumn.Display = ckbColumnDisplay.Checked;
            Var.SelectedColumn.Description = txtColumnDescription.Text;
            Var.SelectedColumn.NumberOfRows = Convert.ToInt32(txtColumnNumberOfRows.Text);
            if (cobColumnFKTable.SelectedValue != null && cobColumnFKColumn.SelectedValue != null)
            {
                Var.SelectedColumn.FKTable = cobColumnFKTable.SelectedValue.ToString();
                Var.SelectedColumn.FKColumn = cobColumnFKColumn.SelectedValue.ToString();
                //設定FK為目前型態
                newType = Var.Tables.Find(m => m.Name == Var.SelectedColumn.FKTable)
                    .Columns.Find(m => m.Name == Var.SelectedColumn.FKColumn).Type;
            }
            else
                Var.SelectedColumn.FKTable = Var.SelectedColumn.FKColumn = null;

            //Key檢查，取消Key時同時取消所有相關FK            
            if (Var.SelectedColumn.IsKey && !ckbColumnIsKey.Checked)
                CancelFK(Var.SelectedColumnParentTable, Var.SelectedColumn);

            if (!Var.SelectedColumn.IsKey && ckbColumnIsKey.Checked)
                recheckTable = true;

            Var.SelectedColumn.IsKey = ckbColumnIsKey.Checked;

            //改型態檢查            
            if (Var.SelectedColumn.Type != newType)
            {
                Var.SelectedColumn.Type = newType;
                int index = Var.SelectedColumnIndex;
                //先檢查自己Table的值
                object result;
                foreach (JLine jl in Var.SelectedColumnParentTable)
                {
                    jl[index].Value.TryParseJType(newType, out result);
                    jl[index].Value = result;
                }

                //檢查FK的值
                CheckFKType(Var.SelectedColumnParentTable, Var.SelectedColumn, newType);
            }

            //改Unique
            if (!Var.SelectedColumn.IsUnique && ckbColumnIsUnique.Checked)
                recheckTable = true;

            Var.SelectedColumn.IsUnique = ckbColumnIsUnique.Checked;

            //改Nullable
            if (Var.SelectedColumn.IsNullable && !ckbColumnIsNullable.Checked)
            {
                int index = Var.SelectedColumnIndex;
                foreach (JLine jl in Var.SelectedColumnParentTable)
                    if (jl[index].Value == null)
                        jl[index].Value = jl[index].Value.ParseJType(newType);
            }
            Var.SelectedColumn.IsNullable = ckbColumnIsNullable.Checked;

            //改最大最小值 、最大長度 及 正則表達式
            if (Var.SelectedColumn.MinValue != txtColumnMinValue.Text ||
               Var.SelectedColumn.MaxValue != txtColumnMaxValue.Text ||
               Var.SelectedColumn.Regex != txtColumnRegex.Text ||
               Var.SelectedColumn.TextMaxLength != long.Parse(txtColumnMaxLength.Text))
            {
                Var.SelectedColumn.MinValue = txtColumnMinValue.Text;
                Var.SelectedColumn.MaxValue = txtColumnMaxValue.Text;
                Var.SelectedColumn.Regex = txtColumnRegex.Text;
                Var.SelectedColumn.TextMaxLength = long.Parse(txtColumnMaxLength.Text);
                recheckTable = true;
            }

            if (recheckTable)
                Var.SelectedColumnParentTable.CehckValid(Setting.UseQuickCheck);

            sslMain.Text = string.Format(Res.JE_RUN_UPDATE_COLUMN_M_6, Var.SelectedColumn.Name);
            RefreshTrvJsonFiles();
        }

        public void tmiAbout_Click(object sender, EventArgs e)
        {
            RabbitCouriers.SentInformation($"{Res.JE_ABOUT_MESSAGE}\n\n{Res.JE_ABOUT_MESSAGE_2}", Res.JE_ABOUT_TITLE);
        }

        public void tmiNewJsonFiles_Click(object sender, EventArgs e)
        {
            if (AskSaveFiles(Res.JE_TMI_NEW_JSON_FILE) == DialogResult.Cancel)
                return;
#if DEBUG
            fbdMain.SelectedPath = @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\";
#endif
            DialogResult dr = fbdMain.ShowDialogOrSetResult(this);
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
                            dr = RabbitCouriers.SentWarningQuestionByResource("JE_RUN_NEW_JSON_FILES_Q_1", Res.JE_RUN_NEW_JSON_FILES_TITLE, ChoiceOptions.YesNo, (jsonfiles.Length - 1).ToString());
                        else
                            dr = RabbitCouriers.SentWarningQuestionByResource("JE_RUN_NEW_JSON_FILES_Q_1", Res.JE_RUN_NEW_JSON_FILES_TITLE, ChoiceOptions.YesNo, jsonfiles.Length.ToString());
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
                RefreshTrvJsonFiles();
                sslMain.Text = string.Format(Res.JE_RUN_NEW_JSON_FILES_M_1, Var.JFI.DirectoryPath);
            }
        }

        public DialogResult AskSaveFiles(string title)
        {
            Var.AskSaveFlag = true;
            Var.CheckFailedFlag = false;
            if (Var.Changed)
            {
                DialogResult dr = RabbitCouriers.SentWarningQuestionByResource("JE_RUN_SAVE_FILES_CHECK", title, ChoiceOptions.YesNoCancel, Var.JFI.DirectoryPath);
                if (dr == DialogResult.Yes)
                    tmiSaveJsonFiles_Click(this, new EventArgs());
                if (Var.CheckFailedFlag)
                    return DialogResult.Cancel;
                return dr;
            }
            return DialogResult.No;
        }

        public void tmiExit_Click(object sender, EventArgs e)
        {
            if (AskSaveFiles(Res.JE_TMI_EXIT) == DialogResult.Cancel)
                return;
            Application.Exit();
        }

        public void tmiScanJsonFiles_Click(object sender, EventArgs e)
        {
            DialogResult dr = RabbitCouriers.SentWarningQuestionByResource("JE_RUN_SCAN_JSON_FILES_M_1", Res.JE_RUN_SCAN_JSON_FILES_TITLE);
            if (dr != DialogResult.OK)
                return;

            tmiCloseAllFiles_Click(this, e);
            Var.Tables = new List<JTable>();
            Var.JFI = new JFilesInfo(Var.JFI.DirectoryPath);
            string[] jsonfiles = Directory.GetFiles(Var.JFI.DirectoryPath, "*.json");
            foreach (string file in jsonfiles)
            {
                if (file == Var.JFI.FileInfoPath)
                {
                    LoadJFilesInfo(file);
                    Var.JFI.DirectoryPath = fbdMain.SelectedPath;
                }
                else
                {
                    JTable jt = new JTable(Path.GetFileNameWithoutExtension(file), true);
                    LoadJsonFile(jt, true);
                    Var.Tables.Add(jt);
                }
            }
            Var.JFI.Changed = true;
            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_SCAN_JSON_FILES_M_2, Var.Tables.Count);
        }

        public void tmiLoadJsonFiles_Click(object sender, EventArgs e)
        {
            if (AskSaveFiles(Res.JE_TMI_LOAD_JSON_FILES) == DialogResult.Cancel)
                return;
#if DEBUG
            fbdMain.SelectedPath = @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\Test1";
#endif
            DialogResult dr = fbdMain.ShowDialogOrSetResult(this);
            if (dr != DialogResult.OK)
                return;

            tmiCloseAllFiles_Click(this, e);
            Var.JFI = new JFilesInfo(fbdMain.SelectedPath);
            string[] jsonfiles = Directory.GetFiles(Var.JFI.DirectoryPath, "*.json");
            Var.Tables = new List<JTable>();
            JTable table;

            //檔案數為0
            if (jsonfiles.Length == 0)
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_LOAD_JSON_FILES_M_3", Res.JE_TMI_LOAD_JSON_FILES, fbdMain.SelectedPath);
                return;
            }

            //有JFI File，先讀取
            if (jsonfiles.Contains(Var.JFI.FileInfoPath))
            {
                LoadJFilesInfo(Var.JFI.FileInfoPath);
                Var.JFI.DirectoryPath = fbdMain.SelectedPath;

                //不合法，錯誤訊息之後扔出
                if (!Var.JFI.CheckValid())
                {
                    //錯誤訊息
                    Var.JFI.TablesInfo = null;
                }
            }

            //對於 其他檔案開始核對
            foreach (string file in jsonfiles)
            {
                FileInfo fi = new FileInfo(file);

                if (file == Var.JFI.FileInfoPath)
                    continue;
                else if (fi.Length < Const.DontLoadFileBytesThreshold)
                {
                    table = new JTable(Path.GetFileNameWithoutExtension(file), true);
                    if (Var.JFI.TablesInfo.Count != 0)
                    {
                        try
                        { 
                            table.LoadFileInfo(Var.JFI.TablesInfo.Find(m => m.Name == table.Name));
                        }
                        catch (Exception ex)
                        { ExceptionHandler.HandleException(ex); }

                        LoadJsonFile(table);
                    }
                    else
                        LoadJsonFile(table, true);
                    Var.Tables.Add(table);
                }
                else
                {
                    //有JFI跳過預讀
                    table = new JTable(Path.GetFileNameWithoutExtension(file));
                    if (Var.JFI.TablesInfo.Count != 0)
                    {
                        try
                        {
                            table.LoadFileInfo(Var.JFI.TablesInfo.Find(m => m.Name == table.Name));
                        }
                        catch (Exception ex)
                        { ExceptionHandler.HandleException(ex); }
                    }   
                    else
                        LoadPartialJsonFile(table);
                    Var.Tables.Add(table);
                }
            }

            // TO DO
            //JFICheck

            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_LOAD_JSON_FILES_M_1, Var.Tables.Count);
        }

        public string GetColumnNodeString(JColumn jc)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(jc.Name);
            if (!string.IsNullOrEmpty(jc.FKTable))
                sb.AppendFormat("[FK:{0}->{1}]", jc.FKTable, jc.FKColumn);
            sb.Append(":");
            sb.Append(jc.Type);
            return sb.ToString();
        }

        public string GetTableNodeString(JTable jt)
            => $"{jt.Name}{(jt.Changed ? "*" : "")}{(jt.Loaded ? "" : "(Unload)")}{(jt.Valid ? "" : "(Invalid)")}";


        private void RefreshTrvSelectedFileChange()
        {
            if (Var.Changed && Var.RootNode.Text.Last() != '*')
                Var.RootNode.Text += '*';

            foreach (TreeNode tr in Var.RootNode.Nodes)
                if (tr.Tag.ToString() == Var.SelectedTable.Name)
                    tr.Text = GetTableNodeString(Var.SelectedTable);
        }

        private void RefreshTrvJsonFiles()
        {
            trvJsonFiles.Nodes.Clear();
            tmiCloseAllFiles.Enabled = false;
            tmiScanJsonFiles.Enabled = false;
            tmiNewJsonFile.Enabled = false;
            tmiSaveJsonFiles.Enabled = false;
            tmiSaveAsJsonFiles.Enabled = false;
            Var.DblClick = false;
            if (Var.Tables == null)
                return;

            string fullName = $"{Var.JFI.Name}({Var.JFI.DirectoryPath})";
            Var.RootNode = new TreeNode($"{fullName.Substring(0, 25)}...", 0, 0);
            if (Var.Changed)
                Var.RootNode.Text += "*";
            Var.RootNode.ToolTipText = fullName;
            Var.RootNode.Expand();
            trvJsonFiles.Nodes.Add(Var.RootNode);
            TreeNode fileNode, tr;

            //Dictionary<string, string> fks = new Dictionary<string, string>();
            foreach (JTable jt in Var.Tables)
            {
                fileNode = new TreeNode { Text = GetTableNodeString(jt), Tag = jt.Name, ImageIndex = 1, SelectedImageIndex = 1 };
                fileNode.ToolTipText = fileNode.Text;
                Var.RootNode.Nodes.Add(fileNode);

                if (Var.SelectedColumnParentTable == jt)
                {
                    if (Var.SelectedColumn == null)
                        trvJsonFiles.SelectedNode = fileNode;
                }

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
                }

                //foreach (KeyValuePair<string, string> kvp in fks)
                //    fileNode.Nodes.Add(new TreeNode { Name = $"FK:{kvp.Key} -> {kvp.Value}", ImageIndex = 3, SelectedImageIndex = 3, ));

            }

            if (trvJsonFiles.SelectedNode == null || trvJsonFiles.SelectedNode == Var.RootNode)
                Var.RootNode.Expand();

            tmiCloseAllFiles.Enabled =
            tmiScanJsonFiles.Enabled =
            tmiNewJsonFile.Enabled =
            tmiOpenFolder.Enabled =
            tmiSaveAsJsonFiles.Enabled =
            tmiSaveJsonFiles.Enabled = true;
            RefreshPnlFileInfo();
            RefreshTbcMain();
        }

        private void RefreshPnlMainValue()
        {
            btnClearMain.Enabled =
            btnUpdateMain.Enabled =
            btnDeleteLine.Enabled =
            btnLineMoveUp.Enabled =
            btnLineMoveDown.Enabled =
            pnlMain.Enabled = false;
            foreach (Control ctls in pnlMain.Controls)
                if (ctls is TextBox)
                    ((TextBox)ctls).Text = "";

            if (Var.SelectedTable == null)
                return;

            if (Var.SelectedLineIndex == -1)
                return;

            for (int i = 0; i < Var.SelectedTable.Columns.Count; i++)
            {
                Var.InputControlSets[i].SetValueToString(Var.SelectedTable[Var.SelectedLineIndex][i].Value);
                Var.InputControlSets[i].CheckValid(Var.SelectedLineIndex);
            }

            if (Var.SelectedTable.Columns.Count != 0)
            {
                btnClearMain.Enabled =
                btnUpdateMain.Enabled =
                pnlMain.Enabled = true;
            }
            btnDeleteLine.Enabled = true;
            btnLineMoveDown.Enabled = Var.SelectedLineIndex != Var.SelectedTable.Count - 1;
            btnLineMoveUp.Enabled = Var.SelectedLineIndex != 0;
        }

        private void RefreshPnlMain()
        {
            int lines = 0;
            btnClearMain.Enabled =
            btnUpdateMain.Enabled =
            pnlMain.Enabled = false;
            pnlMain.Controls.Clear();

            Var.InputControlSets.Clear();
            if (Var.SelectedTable == null)
                return;

            for (int i = 0; i < Var.SelectedTable.Columns.Count; i++)
            {
                InputControlSet ics = new InputControlSet(Var.SelectedTable, Var.SelectedTable.Columns[i]);
                ics.DrawControl(pnlMain, lines);
                lines += Var.SelectedTable.Columns[i].NumberOfRows;
                Var.InputControlSets.Add(ics);
            }
        }

        private void RefreshLsbLines()
        {
            lsbLines.Items.Clear();
            btnNewLine.Enabled =
            btnDeleteLine.Enabled = false;
            if (Var.SelectedTable == null)
                return;

            Var.SelectedTable.CehckValid(Setting.UseQuickCheck);

            StringBuilder displayString;
            for (int i = 0; i < Var.SelectedTable.Count; i++)
            {
                displayString = new StringBuilder();
                for (int j = 0; j < Var.SelectedTable.Columns.Count; j++)
                {
                    if (Var.SelectedTable.Columns[j].Display)
                    {
                        if (Var.SelectedTable[i][j].Value == null)
                            continue;

                        string r = Var.SelectedTable[i][j].Value.ToString(Var.SelectedTable.Columns[j].Type);

                        //Can Improve to do(可改長度偵測)
                        if (r.Length > 12)
                            displayString.AppendFormat("{0}.. ", r.Substring(0, 10));
                        else
                            displayString.AppendFormat("{0} ", r);
                    }
                }
                if (Var.SelectedTable.InvalidRecords.ContainsKey(i))
                    displayString.Append("(Invalid)");
                lsbLines.Items.Add(displayString.ToString());
            }

            lsbLines.SelectedIndex = Var.SelectedLineIndex;
            btnNewLine.Enabled = true;
            btnDeleteLine.Enabled = Var.SelectedLineIndex != -1;
            RefreshTrvSelectedFileChange();
        }

        private void RefreshTbcMain()
        {
            while (Var.OpenedTable.Count > tbcMain.TabPages.Count)
                tbcMain.TabPages.Add(new TabPage());

            tbcMain.SelectedIndex = Var.PageIndex;

            while (Var.OpenedTable.Count < tbcMain.TabPages.Count && tbcMain.TabPages.Count != 1)
                tbcMain.TabPages.RemoveAt(tbcMain.TabPages.Count - 1);

            if (Var.OpenedTable.Count == 0)
                tbcMain.TabPages[0].Text = "";

            for (int i = 0; i < Var.OpenedTable.Count; i++)
                tbcMain.TabPages[i].Text = Var.OpenedTable[i].Name;

            RefreshPnlMain();
            RefreshLsbLines();
        }

        public void tmiCloseAllFiles_Click(object sender, EventArgs e)
        {
            if (!Var.AskSaveFlag && AskSaveFiles(Res.JE_TMI_CLOSE_ALL_FILES) == DialogResult.Cancel)
                return;
            Var.Tables = null;
            Var.OpenedTable.Clear();
            Var.LineIndexes.Clear();
            if (Var.JFI != null)
                Var.JFI.Dispose();
            Var.RootNode = null;
            Var.SelectedColumn = null;
            Var.SelectedColumnParentTable = null;
            Var.PageIndex = -1;
            Var.AskSaveFlag = false;
            RefreshTrvJsonFiles();
            RefreshTbcMain();
            sslMain.Text = "";
        }

        public void tmiSaveJsonFiles_Click(object sender, EventArgs e)
        {
            //確認所有檔案符合規則
            foreach (JTable jt in Var.Tables)
            {
                if (jt.Loaded)
                {
                    if (!jt.CehckValid())
                    {
                        //To Do
                        ExceptionHandler.SentTableInvalidMessage(jt);
                        //RabbitCouriers.SentErrorMessageByResource("JE_RUN_SAVE_JSON_FILES_M_1", Res.JE_TMI_SAVE_JSON_FILES, jt.Name);
                        Var.CheckFailedFlag = true;
                        return;
                    }
                }
            }

            Var.JFI.TablesInfo.Clear();
            foreach (JTable jt in Var.Tables)
                Var.JFI.TablesInfo.Add(jt.GetJTableInfo());

            //存JSONFilesInfo檔
            SaveJFilesInfo();

            //存JSONFiles(有讀出的)
            foreach (JTable jt in Var.Tables)
                if (jt.Loaded) //&& jt.Changed)
                    SaveJsonFile(jt);

            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_SAVE_JSON_FILES_M_2, Var.JFI.DirectoryPath);
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

        public void trvJsonFiles_MouseDown(object sender, MouseEventArgs e)
        {
            trvJsonFiles.ContextMenuStrip = null;
            Var.DblClick = e.Button == MouseButtons.Left && e.Clicks >= 2;
        }

        public void trvJsonFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == Var.RootNode)
            {
                Var.SelectedColumn = null;
                Var.SelectedColumnParentTable = null;
                trvJsonFiles.SelectedNode = e.Node;
                RefreshPnlFileInfo();

                trvJsonFiles.ContextMenuStrip = cmsJsonFiles;
                tmiViewJFIFile.Enabled = File.Exists(Var.JFI.FileInfoPath);
            }
            else if (e.Node.Parent == Var.RootNode)
            {
                Var.SelectedColumn = null;
                Var.SelectedColumnParentTable = Var.Tables.Find(m => m.Name == e.Node.Tag.ToString()); ;
                RefreshPnlFileInfo();

                //更新Open Close
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

                //更新View
                tmiViewJsonFile.Enabled = File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{Var.SelectedColumnParentTable.Name}.json"));

                if (e.Button == MouseButtons.Right)
                {
                    trvJsonFiles.SelectedNode = e.Node;
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
                ckbColumnDisplay.Checked = Var.SelectedColumn.Display;
                ckbColumnIsKey.Checked = Var.SelectedColumn.IsKey;
                ckbColumnIsNullable.Checked = Var.SelectedColumn.IsNullable;
                if (!string.IsNullOrEmpty(Var.SelectedColumn.FKTable))
                    cobColumnFKTable.SelectedValue = Var.SelectedColumn.FKTable;
                cobColumnFKTable_SelectedIndexChanged(this, new EventArgs());
                if (!string.IsNullOrEmpty(Var.SelectedColumn.FKColumn))
                    cobColumnFKColumn.SelectedValue = Var.SelectedColumn.FKColumn;
                txtColumnNumberOfRows.Text = Var.SelectedColumn.NumberOfRows.ToString();

                txtColumnRegex.Text = Var.SelectedColumn.Regex ?? "";
                txtColumnMinValue.Text = Var.SelectedColumn.MinValue ?? "";
                txtColumnMaxValue.Text = Var.SelectedColumn.MaxValue ?? "";
                txtColumnDescription.Text = Var.SelectedColumn.Description ?? "";
                txtColumnMaxLength.Text = Var.SelectedColumn.TextMaxLength.ToString();
                ckbColumnIsUnique.Checked = Var.SelectedColumn.IsUnique;
                btnUpdateColumn.Enabled = true;
            }
            else
            {
                btnClearColumn_Click(this, new EventArgs());
                btnUpdateColumn.Enabled = false;
            }
        }

        public void trvJsonFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == Var.RootNode)
            {
                if (tmiOpenJsonFile.Enabled)
                    tmiOpenJsonFile_Click(this, new EventArgs());

                //補足效果
                Var.DblClick = false;
                if (trvJsonFiles.SelectedNode.IsExpanded)
                    trvJsonFiles.SelectedNode.Collapse();
                else
                    trvJsonFiles.SelectedNode.Expand();
            }
        }

        public void tmiNewJsonFile_Click(object sender, EventArgs e)
        {
            string fileName = frmInputBox.Show(this, InputBoxTypes.NewFile);
            if (string.IsNullOrEmpty(fileName))
                return;
            try
            {
                string newFile = Path.Combine(Var.JFI.DirectoryPath, $"{fileName}.json");

                JTable jt = new JTable(fileName, true);
                Var.Tables.Add(jt);
                Var.JFI.Changed = true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, Res.JE_RUN_NEW_JSON_FILE_M_2, Res.JE_RUN_NEW_JSON_FILE_TITLE);
            }
            RefreshTrvJsonFiles();
        }

        public void tmiAddColumn_Click(object sender, EventArgs e)
        {
            string columnName = frmInputBox.Show(this, InputBoxTypes.AddColumn);
            if (string.IsNullOrEmpty(columnName))
                return;

            if (Var.SelectedColumnParentTable.Columns.Exists(m => m.Name == columnName))
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_ADD_COLUMN_M_1", Res.JE_TMI_ADD_COLUMN, columnName);
                return;
            }

            //To DO ??
            if (!Var.SelectedColumnParentTable.Loaded)
                LoadJsonFile(Var.SelectedColumnParentTable);

            if (Var.SelectedColumnParentTable.Count != 0)
            {
                foreach (JLine jl in Var.SelectedColumnParentTable)
                {
                    jl.Add(new JValue());
                }
            }

            JColumn jc = new JColumn(columnName);
            Var.SelectedColumnParentTable.Columns.Add(jc);
            Var.SelectedColumn = jc;
            Var.SelectedColumnParentTable.Changed = true;
            Var.JFI.Changed = true;
            RefreshTrvJsonFiles();
        }

        public void tmiBackup_Click(object sender, EventArgs e)
        {
            string BackupPath = @"E:\Backup\JsonEditorV2";
            string BackupPath2 = @"E:\Backup\Aritiafel";
            string ProjectPath = @"C:\Programs\WinForm\JsonEditorV2";
            string ProjectPath2 = @"C:\Programs\Standard\Aritiafel";
            string[] ProjectName = new string[] { "JsonEditorV2", "JsonEditorV2Tests" };
            string[] Project2Name = new string[] { "Aritiafel", "AritiafelTestForm", "AritiafelTestFormTests" };

            File.Copy(Path.Combine(ProjectPath, $"{ProjectName[0]}.sln"), Path.Combine(BackupPath, $"{ProjectName[0]}.sln"), true);
            File.Copy(Path.Combine(ProjectPath2, $"{Project2Name[0]}.sln"), Path.Combine(BackupPath2, $"{Project2Name[0]}.sln"), true);

            foreach (string pj in ProjectName)
            {
                if (!Directory.Exists(Path.Combine(BackupPath, pj)))
                    Directory.CreateDirectory(Path.Combine(BackupPath, pj));

                DirectoryCopy(Path.Combine(ProjectPath, pj), Path.Combine(BackupPath, pj));
                //else
                //{
                //    RabbitCouriers.SentInformation("Target backup drive or directory do not exist.");
                //    return;
                //}
            }

            foreach (string pj2 in Project2Name)
            {
                if (!Directory.Exists(Path.Combine(BackupPath2, pj2)))
                    Directory.CreateDirectory(Path.Combine(BackupPath2, pj2));
                DirectoryCopy(Path.Combine(ProjectPath2, pj2), Path.Combine(BackupPath2, pj2));
            }

            RabbitCouriers.SentInformation("OK");
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

        public void btnClearColumn_Click(object sender, EventArgs e)
        {
            txtColumnName.Text = "";
            cobColumnType.SelectedIndex = 0;
            ckbColumnDisplay.Checked = false;
            ckbColumnIsKey.Checked = false;
            cobColumnFKTable.SelectedIndex = -1; //聯動            
            txtColumnNumberOfRows.Text = "0";
        }

        public void cobColumnFKTable_SelectedIndexChanged(object sender, EventArgs e)
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

        public void RefreshTmiLanguages()
        {
            foreach (ToolStripItem tsi in tmiLanguages.DropDownItems)
            {
                ToolStripMenuItem tsmi = tsi as ToolStripMenuItem;
                if (tsmi != null)
                    tsmi.Checked = false;
                if (tsmi.Name.Contains(Setting.CI.Name.Remove(2, 1).ToUpper()))
                    tsmi.Checked = true;
            }
        }

        public void tmiLanguageZNCH_Click(object sender, EventArgs e)
        {
            Setting.CI = new CultureInfo("zh-TW");
            ChangeCulture();
        }

        public void tmiLanguageENUS_Click(object sender, EventArgs e)
        {
            Setting.CI = new CultureInfo("en-US");
            ChangeCulture();
        }

        public void tmiSaveAsJsonFiles_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbdMain.ShowDialogOrSetResult(this);
            if (dr != DialogResult.OK)
                return;

            string[] files = Directory.GetFiles(fbdMain.SelectedPath);
            if (files.Length != 0)
            {
                dr = RabbitCouriers.SentWarningQuestionByResource("JE_RUN_SAVE_AS_JSON_FILES_M_1", Res.JE_TMI_SAVE_AS_JSON_FILES);
                if (dr != DialogResult.OK)
                    return;
                try
                {
                    foreach (string s in files)
                        File.Delete(s);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex);
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
                ExceptionHandler.HandleException(ex);
            }
            Var.JFI.DirectoryPath = fbdMain.SelectedPath;
            tmiSaveJsonFiles_Click(this, e);
        }

        public void tmiOpenJsonFile_Click(object sender, EventArgs e)
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

            Var.OpenedTable.Add(Var.SelectedColumnParentTable);
            Var.LineIndexes.Add(-1);
            Var.PageIndex = Var.OpenedTable.Count - 1;

            RefreshTbcMain();
        }

        public static bool LoadJFilesInfo(string file)
        {
            string jsonString = "";
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);
                    jsonString = sr.ReadToEnd();
                    sr.Dispose();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.OpenJFIFileFailed(file, ex);
                return false;
            }

            try
            {
                Var.JFI = JsonConvert.DeserializeObject<JFilesInfo>(jsonString);
            }
            catch (Exception ex)
            {
                ExceptionHandler.JsonConvertDeserializeObjectFailed(JFilesInfo.FilesInfoName, ex);
                return false;
            }
            return true;
        }

        public static bool LoadJsonFile(JTable jt, bool produceColumnInfo = false)
        {
            string jsonString = "";
            object jsonObject;
            try
            {                
                using (FileStream fs = new FileStream(Path.Combine(Var.JFI.DirectoryPath, $"{jt.Name}.json"), FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);
                    jsonString = sr.ReadToEnd();
                    sr.Dispose();
                }                 
            }
            catch (Exception ex)
            {
                ExceptionHandler.OpenJsonFileFailed(Path.Combine(Var.JFI.DirectoryPath, $"{jt.Name}.json"), ex);
                return false;
            }

            try
            {
                jsonObject = JsonConvert.DeserializeObject(jsonString);
            }
            catch (Exception ex)
            {
                ExceptionHandler.JsonConvertDeserializeObjectFailed(jt.Name, ex);
                return false;
            }

            try
            {
                jt.LoadJson(jsonObject, produceColumnInfo);
            }
            catch (Exception ex)
            {
                ExceptionHandler.JTableLoadJsonFailed(jt, ex);
                return false;
            }

            jt.CehckValid(Setting.UseQuickCheck);
            return true;
        }

        //必產生Column Info
        public static void LoadPartialJsonFile(JTable jt)
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
                                        jt.Columns.Add(new JColumn(value.ToString(), JTypeExtentions.ToJType(reader.TokenType)));
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
                ExceptionHandler.HandleException(ex);
            }
        }

        public static bool SaveJsonFile(JTable jt)
        {
#if !DEBUG
            try
            {
#endif
            //檔案備份
            using (StreamWriter sw = File.CreateText(Const.BackupRecoverFile))
            {
                sw.WriteLine($"OriginFileName={Path.Combine(Var.JFI.DirectoryPath, $"{jt.Name}.json")}");
                sw.WriteLine($"CreateDateTime={DateTime.Now}");
            }
            if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{jt.Name}.json")))
                File.Copy(Path.Combine(Var.JFI.DirectoryPath, $"{jt.Name}.json"), Path.Combine(Const.BackupFolder, $"{jt.Name}.json"), true);

            using (FileStream fs = new FileStream(Path.Combine(Var.JFI.DirectoryPath, $"{jt.Name}.json"), FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(JsonConvert.SerializeObject(jt.GetJsonObject(), Formatting.Indented));
                sw.Close();

            }

            //備份檔案刪除(偵錯時不清空資料夾)
#if !DEBUG
                File.Delete(Path.Combine(Const.BackupFolder, $"{jt.Name}.json"));
#endif
            File.Delete(Const.BackupRecoverFile);

            jt.Changed = false;
            return true;
#if !DEBUG
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                return false;
            }
#endif 
        }

        public static bool SaveJFilesInfo()
        {
            try
            {
                //檔案備份
                using (StreamWriter sw = File.CreateText(Const.BackupRecoverFile))
                {
                    sw.WriteLine($"OriginFileName=\"{Var.JFI.FileInfoPath}\"");
                    sw.WriteLine($"CreateDateTime=\"{DateTime.Now}\"");
                }
                if (File.Exists(Var.JFI.FileInfoPath))
                    File.Copy(Var.JFI.FileInfoPath, Path.Combine(Const.BackupFolder, JFilesInfo.FilesInfoName), true);

                using (FileStream fs = new FileStream(Var.JFI.FileInfoPath, FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(JsonConvert.SerializeObject(Var.JFI, Formatting.Indented));
                    sw.Close();
                }

                //備份檔案刪除
                File.Delete(Path.Combine(Const.BackupFolder, JFilesInfo.FilesInfoName));
                File.Delete(Const.BackupRecoverFile);

                Var.JFI.Changed = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                return false;
            }
            return true;
        }

        public void tmiExpandAll_Click(object sender, EventArgs e)
        {
            Var.RootNode.ExpandAll();
        }

        public void tmiCollapseAll_Click(object sender, EventArgs e)
        {
            Var.RootNode.Collapse();
            Var.RootNode.Expand();
        }

        public void tmiDeleteColumn_Click(object sender, EventArgs e)
        {
            //讀檔            
            if (!Var.SelectedColumnParentTable.Loaded)
                LoadJsonFile(Var.SelectedColumnParentTable);

            //如果有資料秀出訊息視窗
            if (Var.SelectedColumnParentTable.Count != 0)
            {
                DialogResult dr = RabbitCouriers.SentNoramlQuestionByResource("JE_RUN_DELETE_COLUMN_M_1", Res.JE_TMI_DELETE_COLUMN, Var.SelectedColumnParentTable.Count.ToString());
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

            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_DELETE_COLUMN_M_2, removedName);
        }

        public void btnNewLine_Click(object sender, EventArgs e)
        {
            JLine jl = new JLine();
            foreach (JColumn jc in Var.SelectedTable.Columns)
                jl.Add(JValue.FromObject(jc.Type.InitialValue()));

            Var.SelectedTable.Changed = true;
            Var.SelectedTable.Lines.Add(jl);
            Var.SelectedLineIndex = lsbLines.Items.Count;
            sslMain.Text = string.Format(Res.JE_RUN_NEW_LINE_M_1, Var.SelectedTable.Name);
            RefreshLsbLines();
            RefreshPnlMainValue();
        }

        public void tmiRenameJsonFile_Click(object sender, EventArgs e)
        {
            string newName = frmInputBox.Show(this, InputBoxTypes.RenameFile);
            if (string.IsNullOrEmpty(newName))
                return;

            if (newName == Var.SelectedColumnParentTable.Name)
                return;

            if (Var.Tables.Exists(m => m.Name == newName))
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_RENAME_JSON_FILE_M_1", Res.JE_TMI_RENAME_JSON_FILE, newName);
                return;
            }
            try
            {
                if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{Var.SelectedColumnParentTable.Name}.json")))
                    File.Move(Path.Combine(Var.JFI.DirectoryPath, $"{Var.SelectedColumnParentTable.Name}.json"), Path.Combine(Var.JFI.DirectoryPath, $"{newName}.json"));
                RenewFK(Var.SelectedColumnParentTable, newName);
                Var.SelectedColumnParentTable.Name = newName;
                Var.SelectedColumnParentTable.Changed = true;
                Var.JFI.Changed = true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, Res.JE_RUN_NEW_JSON_FILE_M_2, Res.JE_RUN_NEW_JSON_FILE_TITLE);
            }
            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_RENAME_JSON_FILE_M_2, newName);
        }

        public void tmiDeleteJsonFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = RabbitCouriers.SentNoramlQuestionByResource("JE_RUN_DELETE_JSON_FILE_M_1", Res.JE_TMI_DELETE_JSON_FILE, ChoiceOptions.YesNo, Var.SelectedColumnParentTable.Name);
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
                ExceptionHandler.HandleException(ex);
            }
            Var.Tables.Remove(Var.SelectedColumnParentTable);

            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_DELETE_JSON_FILE_M_5, fileName);
        }

        private void CloseJsonFile(int index)
        {
            JTable jt = Var.SelectedTable;
            Var.OpenedTable.RemoveAt(index);
            Var.LineIndexes.RemoveAt(index);
            if (Var.PageIndex == index)
                Var.PageIndex = index == 0 ? Var.OpenedTable.Count - 1 : index - 1;
            else
                Var.PageIndex = Var.OpenedTable.IndexOf(jt);
            RefreshTbcMain();
        }

        public void tmiCloseJsonFile_Click(object sender, EventArgs e)
        {
            if (!Var.OpenedTable.Contains(Var.SelectedColumnParentTable))
                return;
            CloseJsonFile(Var.OpenedTable.IndexOf(Var.SelectedColumnParentTable));
        }

        public void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            Var.PageIndex = tbcMain.SelectedIndex;
            RefreshPnlMain();
            RefreshLsbLines();
        }

        public void btnClearMain_Click(object sender, EventArgs e)
        {
            TextBox tb;
            foreach (Control c in pnlMain.Controls)
            {
                if (c as TextBox == null)
                    continue;
                tb = c as TextBox;
                tb.Text = "";
            }
        }

        public void tmiCloseTab_Click(object sender, EventArgs e)
        {
            CloseJsonFile(Var.ClickedTabIndex);
        }

        public void tbcMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tbcMain.ContextMenuStrip = null;
                Var.ClickedTabIndex = -1;
                for (int i = 0; i < tbcMain.TabPages.Count; i++)
                    if (tbcMain.GetTabRect(i).Contains(e.Location))
                        Var.ClickedTabIndex = i;
                if (Var.ClickedTabIndex != -1 && Var.OpenedTable.Count != 0)
                    tbcMain.ContextMenuStrip = cmsTabSelected;
            }
        }

        public void btnDeleteLine_Click(object sender, EventArgs e)
        {
            if (Var.SelectedLineIndex == -1)
                return;
            Var.SelectedTable.Lines.RemoveAt(Var.SelectedLineIndex);
            if (Var.SelectedTable.Lines.Count == Var.SelectedLineIndex)
                Var.SelectedLineIndex--;
            Var.SelectedTable.Changed = true;
            sslMain.Text = string.Format(Res.JE_RUN_DELETE_LINE_M_1, Var.SelectedTable.Name);

            RefreshPnlMain();
            RefreshLsbLines();
        }

        public void btnUpdateMain_Click(object sender, EventArgs e)
        {
            if (Var.SelectedLineIndex == -1)
                return;

            //控制項驗證
            bool valid = true;
            for (int i = 0; i < Var.InputControlSets.Count; i++)
                if (!Var.InputControlSets[i].CheckValid(Var.SelectedLineIndex))
                    valid = false;

            if (!valid)
                return;

            for (int i = 0; i < Var.InputControlSets.Count; i++)
                Var.SelectedTable[Var.SelectedLineIndex][i].Value = Var.InputControlSets[i].GetValueValidated();

            sslMain.Text = string.Format(Res.JE_RUN_UPDATE_LINE_M_1, Var.SelectedTable.Name);
            Var.SelectedTable.Changed = true;
            RefreshLsbLines();
            RefreshPnlMainValue();
        }

        public void tmiColumnMoveUp_Click(object sender, EventArgs e)
        {
            int index = Var.SelectedColumnIndex;
            if (index == 0)
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_COLUMN_MOVE_UP_M_1", Res.JE_RUN_COLUMN_MOVE_TITLE, Var.SelectedColumn.Name);
                return;
            }

            if (!Var.SelectedColumnParentTable.Loaded)
                LoadJsonFile(Var.SelectedColumnParentTable);

            foreach (JLine jl in Var.SelectedColumnParentTable)
            {
                JValue jv = jl[index - 1];
                jl[index - 1] = jl[index];
                jl[index] = jv;
            }

            JColumn jc = Var.SelectedColumnParentTable.Columns[index - 1];
            Var.SelectedColumnParentTable.Columns[index - 1] = Var.SelectedColumnParentTable.Columns[index];
            Var.SelectedColumnParentTable.Columns[index] = jc;

            Var.SelectedColumnParentTable.Changed = true;
            Var.JFI.Changed = true;

            RefreshTrvJsonFiles();
            RefreshTbcMain();
        }

        public void tmiColumnMoveDown_Click(object sender, EventArgs e)
        {
            int index = Var.SelectedColumnIndex;
            if (index == Var.SelectedColumnParentTable.Columns.Count - 1)
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_COLUMN_MOVE_DOWN_M_1", Res.JE_RUN_COLUMN_MOVE_TITLE, Var.SelectedColumn.Name);
                return;
            }

            if (!Var.SelectedColumnParentTable.Loaded)
                LoadJsonFile(Var.SelectedColumnParentTable);

            foreach (JLine jl in Var.SelectedColumnParentTable)
            {
                JValue jv = jl[index + 1];
                jl[index + 1] = jl[index];
                jl[index] = jv;
            }

            JColumn jc = Var.SelectedColumnParentTable.Columns[index + 1];
            Var.SelectedColumnParentTable.Columns[index + 1] = Var.SelectedColumnParentTable.Columns[index];
            Var.SelectedColumnParentTable.Columns[index] = jc;

            Var.SelectedColumnParentTable.Changed = true;
            Var.JFI.Changed = true;

            RefreshTrvJsonFiles();
            RefreshTbcMain();
        }

        public void cobColumnFKColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool FKIsEmpty = cobColumnFKColumn.SelectedIndex == -1;
            cobColumnType.Enabled =
            txtColumnRegex.Enabled =
            txtColumnMaxLength.Enabled =
            txtColumnMinValue.Enabled =
            txtColumnMaxValue.Enabled = FKIsEmpty;
        }

        public void tmiOpenFolder_Click(object sender, EventArgs e)
        {
            if (Var.JFI != null)
                Process.Start(Var.JFI.DirectoryPath);
        }

        public void tmiViewJsonFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{Var.SelectedColumnParentTable.Name}.json")))
                Process.Start("notepad.exe", Path.Combine(Var.JFI.DirectoryPath, $"{Var.SelectedColumnParentTable.Name}.json"));
        }

        public void tmiViewJFIFile_Click(object sender, EventArgs e)
        {
            if (Var.JFI != null)
                if (File.Exists(Var.JFI.FileInfoPath))
                    Process.Start("notepad.exe", Var.JFI.FileInfoPath);
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            //確認Backup資料夾存在
            if (!Directory.Exists(Const.BackupFolder))
                Directory.CreateDirectory(Const.BackupFolder);

            //有Backup檔案存在
            string[] files = Directory.GetFiles(Const.BackupFolder);
            if (files.Length != 0)
            {
                if (File.Exists(Const.BackupRecoverFile) && files.Length > 1)
                {
                    StreamReader sr = File.OpenText(Const.BackupRecoverFile);
                    string originFileName = sr.ReadLine().ToString().Split('=')[1];
                    string createDate = sr.ReadLine().ToString().Split('=')[1];
                    sr.Close();

                    DialogResult dr = RabbitCouriers.SentWarningQuestionByResource("JE_ERR_RECOVER_FILE_M_1", Res.JSON_FILE_EDITOR_TITLE, ChoiceOptions.YesNoCancel, Path.GetFileName(originFileName), createDate);
                    if (dr == DialogResult.Cancel)
                    {
                        Application.Exit();
                        return;
                    }
                    else if (dr == DialogResult.Yes)
                        File.Copy(Path.Combine(Const.BackupFolder, Path.GetFileName(originFileName)), originFileName, true);
                }

                //無法處理的例外情況                
                foreach (string file in files)
                    File.Delete(file);
            }
        }

        public void cobColumnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobColumnType.SelectedIndex == -1)
                return;
            JType result = (JType)Enum.Parse(typeof(JType), cobColumnType.SelectedValue.ToString());
            txtColumnRegex.Enabled = cobColumnFKColumn.SelectedIndex == -1 &&
                 result == JType.String;
            txtColumnMaxLength.Enabled = cobColumnFKColumn.SelectedIndex == -1 &&
                (result == JType.String || result == JType.Uri);
            txtColumnMinValue.Enabled =
            txtColumnMaxValue.Enabled = cobColumnFKColumn.SelectedIndex == -1 &&
                (result.IsDateTime() || result.IsNumber());
        }

        public void tmiRefreshFiles_Click(object sender, EventArgs e)
        {
            RefreshTrvJsonFiles();
        }

        public bool ChangeColumnName(JTable sourceTable, JColumn sourceColumn, string newName)
        {
            if (newName == Var.SelectedColumn.Name)
                return false;

            //已存在同名欄位
            if (Var.SelectedColumnParentTable.Columns.Exists(m => m.Name == newName))
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_RENAME_COLUMN_M_1", Res.JE_RUN_RENAME_COLUMN_TITLE, newName);
                return false;
            }

            //刷新FK
            RenewFK(Var.SelectedColumnParentTable, Var.SelectedColumn, newName);

            //改名
            Var.SelectedColumn.Name = newName;
            Var.SelectedColumnParentTable.Changed = true;
            Var.JFI.Changed = true;
            return true;
        }

        public void tmiRenameColumn_Click(object sender, EventArgs e)
        {
            string newName = frmInputBox.Show(this, InputBoxTypes.RenameColumn);
            if (string.IsNullOrEmpty(newName))
                return;

            if (!ChangeColumnName(Var.SelectedColumnParentTable, Var.SelectedColumn, newName))
                return;

            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_RENAME_COLUMN_M_2, newName);
        }

        public void btnLineMoveUp_Click(object sender, EventArgs e)
        {
            int index = Var.SelectedLineIndex;
            if (index == -1)
                return;
            else if (index == 0)
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_LINE_MOVE_UP_M_1", Res.JE_RUN_LINE_MOVE_TITLE, lsbLines.Items[index].ToString());
                return;
            }

            JLine jl = Var.SelectedTable[index - 1];
            Var.SelectedTable[index - 1] = Var.SelectedTable[index];
            Var.SelectedTable[index] = jl;
            Var.SelectedLineIndex--;
            Var.SelectedTable.Changed = true;
            RefreshLsbLines();
        }

        public void btnLineMoveDown_Click(object sender, EventArgs e)
        {
            int index = Var.SelectedLineIndex;
            if (index == -1)
                return;
            else if (index == Var.SelectedTable.Count - 1)
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_LINE_MOVE_DOWN_M_1", Res.JE_RUN_LINE_MOVE_TITLE, lsbLines.Items[index].ToString());
                return;
            }

            JLine jl = Var.SelectedTable[index + 1];
            Var.SelectedTable[index + 1] = Var.SelectedTable[index];
            Var.SelectedTable[index] = jl;
            Var.SelectedLineIndex++;
            Var.SelectedTable.Changed = true;
            RefreshLsbLines();
        }

        private void ckbQuickCheck_CheckedChanged(object sender, EventArgs e)
        {
            Setting.UseQuickCheck = ckbQuickCheck.Checked;
        }
    }
}
