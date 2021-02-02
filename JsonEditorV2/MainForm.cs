using Aritiafel.Items;
using Aritiafel.Organizations;
using JsonEditor;
using JsonEditorV2.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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
            Var.Database = new JDatabase();
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
            Text = $"{Res.JSON_FILE_EDITOR_TITLE} - {Const.VersionString}";
            lblColumnName.Text = Res.JE_COLUMN_NAME;
            lblColumnType.Text = Res.JE_COLUMN_TYPE;
            lblColumnChoices.Text = Res.JE_COLUMN_CHOICES;
            lblColumnChoiceName.Text = Res.JE_LBL_CHOICE_NAME;
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
            lblAutoGenerateKey.Text = Res.JE_COLUMN_AUTO_GENERATE_KEY;
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
            tmiAddColumn.Text = Res.JE_TMI_ADD_COLUMN;
            tmiNewJsonFile.Text = Res.JE_TMI_NEW_JSON_FILE;
            tmiRenameDatabase.Text = Res.JE_TMI_RENAME_DATABASE;
            tmiExpandAll.Text = Res.JE_TMI_EXPAND_ALL;
            tmiCollapseAll.Text = Res.JE_TMI_COLLAPSE_ALL;
            tmiOpenFolder.Text = Res.JE_TMI_OPEN_FOLDER;
            tmiViewJFIFile.Text = Res.JE_TMI_VIEW_JFI_FILE;
            tmiRefreshFiles.Text = Res.JE_TMI_REFRESH_FILES;
            tmiRenameColumn.Text = Res.JE_TMI_RENAME_COLUMN;
            tmiColumnShowOnList.Text = Res.JE_TMI_COLUMN_SHOW_ON_LIST;
            tmiColumnMoveUp.Text = Res.JE_TMI_COLUMN_MOVE_UP;
            tmiColumnMoveDown.Text = Res.JE_TMI_COLUMN_MOVE_DOWN;
            tmiDeleteColumn.Text = Res.JE_TMI_DELETE_COLUMN;
            tmiCloseTab.Text = Res.JE_TMI_CLOSE_TAB;
        }
        #endregion

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

                foreach (JLine jl in jt)
                {
                    for (int i = 0; i < columnIndexs.Count; i++)
                    {
                        jl[columnIndexs[i]].TryParseJType(newType, out object result);
                        jl[columnIndexs[i]] = result;
                    }
                }
            }
        }

        public static bool CheckMinMaxValue(string content, JType type)
        {
            if (string.IsNullOrEmpty(content))
                return false;
            if (type.IsNumber())
                if (type == JType.Double)
                    return double.TryParse(content, out double result);
                else
                    return content.TryParseJType(type, out object result);
            else if (type.IsDateTime())
            {
                if (!DateTime.TryParse(content, out DateTime result))
                    return false;
                else if (type == JType.Date)
                    return result.TimeOfDay.TotalSeconds == 0;
                else
                    return true;
            }
            return false;
        }

        public void btnUpdateColumn_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtColumnName.Text, Const.ColumnNameRegex))
            {
                //欄位名檢查
                RabbitCouriers.SentErrorMessageByResource("JE_VAL_COLUMN_ILLEGAL_NAME", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                txtColumnName.SelectAll();
                txtColumnName.Focus();
                return;
            }
            else if (!Regex.IsMatch(txtColumnNumberOfRows.Text, Const.NumberOfRowsRegex))
            {
                //欄位行數檢查
                RabbitCouriers.SentErrorMessageByResource("JE_VAL_COLUMN_NUMBER_OF_ROWS_IS_NEGATIVE_OR_TOO_BIG", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                txtColumnNumberOfRows.SelectAll();
                txtColumnNumberOfRows.Focus();
                return;
            }
            else if (!long.TryParse(txtColumnMaxLength.Text, out long r1) || r1 < 0)
            {
                //文字最大長度檢查
                RabbitCouriers.SentErrorMessageByResource("JE_VAL_COLUMN_MAX_LEGNTH_IS_NEGATIVE", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                txtColumnMaxLength.SelectAll();
                txtColumnMaxLength.Focus();
                return;
            }
            else if (ckbColumnIsKey.Checked && ckbColumnIsNullable.Checked)
            {
                //Key和Nullable相斥檢查
                RabbitCouriers.SentErrorMessageByResource("JE_VAL_COLUMN_IS_KEY_AND_IS_NULL", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                ckbColumnIsKey.Checked = Var.SelectedColumn.IsKey;
                ckbColumnIsNullable.Checked = Var.SelectedColumn.IsNullable;
                return;
            }
            else if (cobColumnFKTable.SelectedIndex > 0 && cobColumnFKColumn.SelectedIndex == -1)
            {
                //欄位FK檢查
                RabbitCouriers.SentErrorMessageByResource("JE_VAL_COLUMN_FK_COLUMN_MISSING", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                return;
            }

            JType newType = (JType)cobColumnType.SelectedValue;

            //自動產生值時取消最大、最小、長度、正則表達式條件
            if (ckbColumnAutoGenerateKey.Checked)
            {
                txtColumnMaxLength.Text = "0";
                txtColumnRegex.Text = "";
                txtColumnMinValue.Text = "";
                txtColumnMaxValue.Text = "";
            }   

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
                    RabbitCouriers.SentErrorMessageByResource("JE_VAL_COLUMN_MIN_VALUE_CAST_FAILED", Res.JE_RUN_UPDATE_COLUMN_TITLE, txtColumnMinValue.Text);
                    txtColumnMinValue.SelectAll();
                    txtColumnMinValue.Focus();
                    return;
                }
                if (txtColumnMaxValue.Text != "" && !CheckMinMaxValue(txtColumnMaxValue.Text, newType))
                {
                    RabbitCouriers.SentErrorMessageByResource("JE_VAL_COLUMN_MAX_VALUE_CAST_FAILED", Res.JE_RUN_UPDATE_COLUMN_TITLE, txtColumnMaxValue.Text);
                    txtColumnMaxValue.SelectAll();
                    txtColumnMaxValue.Focus();
                    return;
                }
                if (txtColumnMinValue.Text != "" && txtColumnMaxValue.Text != "" &&
                txtColumnMinValue.Text.CompareTo(txtColumnMaxValue.Text, newType) == 1)
                {
                    RabbitCouriers.SentErrorMessageByResource("JE_VAL_COLUMN_MIN_VALUE_GREATER_THAN_MAX_VALUE", Res.JE_RUN_UPDATE_COLUMN_TITLE, txtColumnMinValue.Text, txtColumnMaxValue.Text);
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
                RabbitCouriers.SentErrorMessageByResource("JE_VAL_COLUMN_ILLEGAL_REGULAR_EXPRESSION", Res.JE_RUN_UPDATE_COLUMN_TITLE);
                txtColumnRegex.SelectAll();
                txtColumnRegex.Focus();
                return;
            }

            bool recheckTable = false;

            //讀檔
            if (!Var.SelectedColumnParentTable.Loaded)
                if(!LoadOrScanJsonFile(Var.SelectedColumnParentTable))
                    return;

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
            Var.SelectedColumn.AutoGenerateKey = ckbColumnAutoGenerateKey.Checked;
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

            //不能選擇的型別，清除選擇值
            if (newType == JType.Boolean || newType == JType.Array || newType == JType.Object)
                Var.SelectedColumn.Choices.Clear();

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
                foreach (JLine jl in Var.SelectedColumnParentTable)
                {
                    jl[index].TryParseJType(newType, out object result);
                    if (result == null && !Var.SelectedColumn.IsNullable)
                        result = newType.InitialValue();
                    jl[index] = result;
                }

                //檢查FK的值                
                CheckFKType(Var.SelectedColumnParentTable, Var.SelectedColumn, newType);
            }

            //改Unique
            if (Var.SelectedColumn.IsUnique != ckbColumnIsUnique.Checked)
                recheckTable = true;

            Var.SelectedColumn.IsUnique = ckbColumnIsUnique.Checked;

            //改Nullable
            if (Var.SelectedColumn.IsNullable && !ckbColumnIsNullable.Checked)
            {
                int index = Var.SelectedColumnIndex;
                foreach (JLine jl in Var.SelectedColumnParentTable)
                    if (jl[index] == null)
                        jl[index] = newType.InitialValue();
            }
            Var.SelectedColumn.IsNullable = ckbColumnIsNullable.Checked;

            //改最大最小值 、最大長度 及 正則表達式
            if (Var.SelectedColumn.MinValue != txtColumnMinValue.Text ||
               Var.SelectedColumn.MaxValue != txtColumnMaxValue.Text ||
               Var.SelectedColumn.RegularExpression != txtColumnRegex.Text ||
               Var.SelectedColumn.MaxLength != long.Parse(txtColumnMaxLength.Text))
            {

                Var.SelectedColumn.MinValue = txtColumnMinValue.Text != "" ? (txtColumnMinValue.Text.ParseJType(newType) ?? "").ToString(newType) : "";
                Var.SelectedColumn.MaxValue = txtColumnMaxValue.Text != "" ? (txtColumnMaxValue.Text.ParseJType(newType) ?? "").ToString(newType) : "";
                Var.SelectedColumn.RegularExpression = txtColumnRegex.Text;
                Var.SelectedColumn.MaxLength = long.Parse(txtColumnMaxLength.Text);
                recheckTable = true;
            }

            if (recheckTable)
                Var.Database.CheckTableValid(Var.SelectedColumnParentTable, Setting.UseQuickCheck);

            sslMain.Text = string.Format(Res.JE_RUN_UPDATE_COLUMN_M_6, Var.SelectedColumn.Name);
            RefreshTrvJsonFiles();
        }

        public void tmiAbout_Click(object sender, EventArgs e)
        {
            RabbitCouriers.SentInformation($"{Res.JE_ABOUT_MESSAGE}  {Const.VersionString}\n\n{Res.JE_ABOUT_MESSAGE_2}", Res.JE_ABOUT_TITLE);
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

                Var.NotOnlyClose = true;
                tmiCloseAllFiles_Click(this, e);
                Var.Tables = new List<JTable>();
                Var.JFI.DirectoryPath = fbdMain.SelectedPath;
                RefreshTrvJsonFiles();
                sslMain.Text = string.Format(Res.JE_RUN_NEW_JSON_FILES_M_1, Var.JFI.DirectoryPath);
            }
        }

        public DialogResult AskSaveFiles(string title)
        {
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
            Close();
        }

        public void tmiScanJsonFiles_Click(object sender, EventArgs e)
        {
            if (AskSaveFiles(Res.JE_TMI_SCAN_JSON_FILES) == DialogResult.Cancel)
                return;
#if DEBUG
            fbdMain.SelectedPath = @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestData\";
#endif

            DialogResult dr = fbdMain.ShowDialogOrSetResult(this);
            if (dr != DialogResult.OK)
                return;

            Var.NotOnlyClose = true;
            tmiCloseAllFiles_Click(this, e);
            Var.JFI = new JFilesInfo(fbdMain.SelectedPath);
            string[] jsonfiles = Directory.GetFiles(Var.JFI.DirectoryPath, "*.json");
            Var.Tables = new List<JTable>();

            //檔案數為0，丟出訊息後離開
            if (jsonfiles.Length == 0)
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_LOAD_JSON_FILES_M_3", Res.JE_TMI_LOAD_JSON_FILES, fbdMain.SelectedPath);
                return;
            }

            //JFI檔案存在，詢問是否繼續
            if (jsonfiles.Contains(Var.JFI.FileInfoPath))
            {
                dr = RabbitCouriers.SentWarningQuestionByResource("JE_RUN_SCAN_JSON_FILES_M_1", Res.JE_RUN_SCAN_JSON_FILES_TITLE, Var.JFI.DirectoryPath);
                if (dr != DialogResult.OK)
                    return;
            }

            //全部讀取
            foreach (string file in jsonfiles)
            {
                if (file == Var.JFI.FileInfoPath)
                    continue;

                //讀取失敗依然添加
                JTable table = new JTable(Path.GetFileNameWithoutExtension(file));
                LoadOrScanJsonFile(table, true);
                Var.Tables.Add(table);
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

            //關閉檔案
            Var.NotOnlyClose = true;
            tmiCloseAllFiles_Click(this, e);
            Var.JFI = new JFilesInfo(fbdMain.SelectedPath);
            string[] jsonfiles = Directory.GetFiles(Var.JFI.DirectoryPath, "*.json");
            Var.Tables = new List<JTable>();

            //檔案數為0，丟出訊息後離開
            if (jsonfiles.Length == 0)
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_LOAD_JSON_FILES_M_3", Res.JE_TMI_LOAD_JSON_FILES, fbdMain.SelectedPath);
                return;
            }

            //JFI檔案不存在，離開
            if (!jsonfiles.Contains(Var.JFI.FileInfoPath))
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_LOAD_JSON_FILES_M_2", Res.JE_TMI_LOAD_JSON_FILES);
                return;
            }

            //讀取JFI失敗跳出
            if (!LoadJFilesInfo(Var.JFI.FileInfoPath))
                return;
            Var.JFI.DirectoryPath = fbdMain.SelectedPath;

            //開始讀檔
            foreach (string file in jsonfiles)
            {
                if (file == Var.JFI.FileInfoPath)
                    continue;

                FileInfo fi = new FileInfo(file);
                JTable table = new JTable(Path.GetFileNameWithoutExtension(file));

                //設置欄位訊息
                JTableInfo jti = Var.JFI.TablesInfo.Find(m => m.Name == table.Name);
                if (jti == null)
                {
                    //沒找到相關資料，錯誤訊息後跳過檔案
                    RabbitCouriers.SentErrorMessageByResource("JE_RUN_LOAD_JSON_FILES_M_4", Res.JE_TMI_LOAD_JSON_FILES, table.Name);
                    return;
                }
                table.Columns = jti.Columns;

                //小檔案直接讀取 - 失敗時關閉
                if (fi.Length < Setting.DontLoadFileBytesThreshold)
                    if(!LoadOrScanJsonFile(table))
                    {
                        tmiCloseAllFiles_Click(this, e);
                        return;
                    }
                Var.Tables.Add(table);
            }
            
            Var.Database.CheckAllTablesValid();

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
                fileNode = new TreeNode { Name = jt.Name, Text = GetTableNodeString(jt), Tag = jt.Name, ImageIndex = 1, SelectedImageIndex = 1 };
                fileNode.ToolTipText = fileNode.Text;
                Var.RootNode.Nodes.Add(fileNode);

                if (Var.SelectedColumnParentTable == jt)
                {
                    if (Var.SelectedColumn == null)
                        trvJsonFiles.SelectedNode = fileNode;
                }

                foreach (JColumn jc in jt.Columns)
                {
                    tr = new TreeNode { Name = jc.Name, Text = GetColumnNodeString(jc), Tag = jc.Name };
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
            tmiNewJsonFile.Enabled =
            tmiOpenFolder.Enabled =
            tmiSaveAsJsonFiles.Enabled =
            tmiSaveJsonFiles.Enabled = true;
            RefreshPnlFileInfo();
            RefreshTbcMain();
        }

        private void RefreshPnlMainValue()
        {
            if (Var.LockPnlMain)
                return;

            btnClearMain.Enabled =
            btnUpdateMain.Enabled =
            btnDeleteLine.Enabled =
            pnlMain.Enabled = false;

            for (int i = 0; i < Var.SelectedTable.Columns.Count; i++)
                Var.InputControlSets[i].ClearValue();

            if (Var.SelectedTable == null)
                return;

            if (Var.SelectedLineIndex == -1)
                return;

            for (int i = 0; i < Var.SelectedTable.Columns.Count; i++)
            {
                Var.InputControlSets[i].SetValueToString(Var.SelectedTable[Var.SelectedLineIndex][i]);
                Var.InputControlSets[i].CheckValid(Var.SelectedLineIndex);
            }

            if (Var.SelectedTable.Columns.Count != 0)
            {
                btnClearMain.Enabled =
                btnUpdateMain.Enabled =
                pnlMain.Enabled = true;
            }
            btnDeleteLine.Enabled = true;
        }

        private void RefreshPnlMain()
        {
            if (Var.LockDgvLines)
                return;
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
                if (Var.SelectedTable.Columns[i].NumberOfRows < 1)
                    lines++;
                else
                    lines += Var.SelectedTable.Columns[i].NumberOfRows;
                Var.InputControlSets.Add(ics);
            }

            if (Var.SelectedLineIndex != -1)
                RefreshPnlMainValue();
        }

        private void RefreshDgvLines()
        {
            if (Var.LockDgvLines)
                return;

            Var.LockPnlMain = true;
            dgvLines.DataSource = null;
            btnNewLine.Enabled =
            cobFindColumnName.Enabled =
            btnLineMoveUp.Enabled =
            btnLineMoveDown.Enabled =
            btnFindConfirm.Enabled =
            btnDeleteLine.Enabled = false;
            if (Var.SelectedTable == null)
                return;

            DataTable dt = new DataTable();
            for (int j = 0; j < Var.SelectedTable.Columns.Count; j++)
                if (Var.SelectedTable.Columns[j].Display)
                    dt.Columns.Add(Var.SelectedTable.Columns[j].Name);

            dt.Columns.Add(new DataColumn { ColumnName = Const.HiddenColumnItemIndex, DataType = typeof(int) });
            dt.Columns.Add(Const.HiddenColumnStat);

            for (int i = 0; i < Var.SelectedTable.Count; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < Var.SelectedTable.Columns.Count; j++)
                {
                    if (Var.SelectedTable.Columns[j].Display)
                    {
                        if (Var.SelectedTable[i][j] == null)
                            continue;

                        string r = Var.SelectedTable[i][j].ToString(Var.SelectedTable.Columns[j].Type);
                        if (r.Length > Setting.DgvLinesStringMaxLength)
                            r = string.Format("{0}.. ", r.Substring(0, Setting.DgvLinesStringMaxLength - 2));
                        else
                            r = string.Format("{0} ", r);
                        dr[Var.SelectedTable.Columns[j].Name] = r;
                    }
                }

                dr[Const.HiddenColumnItemIndex] = i;
                if (Var.SelectedTable.InvalidRecords.ContainsKey(i))
                    dr[Const.HiddenColumnStat] = "R";

                dt.Rows.Add(dr);
            }

            dgvLines.DataSource = dt;
            if (dgvLines.Rows.Count != 0)
            {
                if (Var.SelectedLineIndex == -1)
                    Var.SelectedLineIndex = dgvLines.SelectedRows[0].Index;

                dgvLines.Rows[Var.SelectedLineIndex].Selected = true;
                if (!dgvLines.Rows[Var.SelectedLineIndex].Displayed)
                    dgvLines.FirstDisplayedScrollingRowIndex = Var.SelectedLineIndex;
            }
            
            cobFindColumnName.DataSource = null;
            cobFindColumnName.ValueMember = "Name";
            cobFindColumnName.DisplayMember = "Name";
            cobFindColumnName.DataSource = Var.SelectedTable.Columns;
            
            Var.LockPnlMain = false;

            btnNewLine.Enabled =
            cobFindColumnName.Enabled =
            btnFindConfirm.Enabled = true;
            btnLineMoveDown.Enabled = Var.SelectedLineIndex != Var.SelectedTable.Count - 1;
            btnLineMoveUp.Enabled = Var.SelectedLineIndex != 0;
            btnDeleteLine.Enabled = Var.SelectedLineIndex != -1;
            RefreshTrvSelectedFileChange();
        }

        private void RefreshTbcMain()
        {
            Var.LockDgvLines = true;
            while (Var.OpenedTable.Count > tbcMain.TabPages.Count)
                tbcMain.TabPages.Add(new TabPage());

            tbcMain.SelectedIndex = Var.PageIndex;

            while (Var.OpenedTable.Count < tbcMain.TabPages.Count && tbcMain.TabPages.Count != 1)
                tbcMain.TabPages.RemoveAt(tbcMain.TabPages.Count - 1);

            if (Var.OpenedTable.Count == 0)
                tbcMain.TabPages[0].Text = "";

            for (int i = 0; i < Var.OpenedTable.Count; i++)
                tbcMain.TabPages[i].Text = Var.OpenedTable[i].Name;

            Var.LockDgvLines = false;
            RefreshDgvLines();
            RefreshPnlMain();
        }

        public void tmiCloseAllFiles_Click(object sender, EventArgs e)
        {
            if (!Var.NotOnlyClose && AskSaveFiles(Res.JE_TMI_CLOSE_ALL_FILES) == DialogResult.Cancel)
                return;

            btnClearColumn_Click(this, e);
            Var.Tables = null;
            Var.OpenedTable.Clear();
            Var.LineIndexes.Clear();
            if (Var.JFI != null)
                Var.JFI.Dispose();
            Var.RootNode = null;
            Var.SelectedColumn = null;
            Var.SelectedColumnParentTable = null;
            Var.PageIndex = -1;

            if (!Var.NotOnlyClose)
            {
                RefreshTrvJsonFiles();
                RefreshTbcMain();
            }
            Var.NotOnlyClose = false;
            sslMain.Text = "";
        }

        public void tmiSaveJsonFiles_Click(object sender, EventArgs e)
        {
            //確認所有開啟過的檔案符合規則
            foreach (JTable jt in Var.Tables)
            {
                if (jt.Loaded)
                {
                    if (!Var.Database.CheckTableValid(jt))
                    {
                        ExceptionHandler.SentTableInvalidMessage(jt);
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

            //刪除需要刪除檔案
            foreach (string file in Var.DeleteFiles)
                if (File.Exists(file))
                    File.Delete(file);
            Var.DeleteFiles.Clear();

            //存JSONFiles(有讀出的)
            foreach (JTable jt in Var.Tables)
                if (jt.Loaded) //&& jt.Changed)
                    SaveJsonFile(jt);

            //刪除更名後的檔案
            foreach (string file in Var.RenamedFiles)
                if (File.Exists(file))
                    File.Delete(file);
            Var.RenamedFiles.Clear();

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
                    tmiColumnShowOnList.Checked = Var.SelectedColumn.Display;
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
                lblColumnChoicesCount.Text = Var.SelectedColumn.Choices.Count.ToString();
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
                txtColumnRegex.Text = Var.SelectedColumn.RegularExpression ?? "";
                txtColumnMinValue.Text = Var.SelectedColumn.MinValue ?? "";
                txtColumnMaxValue.Text = Var.SelectedColumn.MaxValue ?? "";
                txtColumnDescription.Text = Var.SelectedColumn.Description ?? "";
                txtColumnMaxLength.Text = Var.SelectedColumn.MaxLength.ToString();
                ckbColumnIsUnique.Checked = Var.SelectedColumn.IsUnique;
                ckbColumnAutoGenerateKey.Checked = Var.SelectedColumn.AutoGenerateKey;
                btnUpdateColumn.Enabled = true;
                btnColumnEditChoices.Enabled = true;
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
                //補足效果
                Var.SelectedColumnParentTable = Var.Tables.Find(m => m.Name == e.Node.Tag.ToString());
                Var.DblClick = false;
                if (tmiOpenJsonFile.Enabled)
                    tmiOpenJsonFile_Click(this, new EventArgs());
                else
                {
                    Var.PageIndex = Var.OpenedTable.FindIndex(m => m.Name == e.Node.Tag.ToString());
                    RefreshTbcMain();
                }   
            }
        }

        public void tmiNewJsonFile_Click(object sender, EventArgs e)
        {
            string fileName = frmInputBox.Show(this, InputBoxTypes.NewFile);
            if (string.IsNullOrEmpty(fileName))
                return;

            JTable jt = new JTable(fileName, true);
            Var.Tables.Add(jt);
            Var.JFI.Changed = true;
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
            
            if (!Var.SelectedColumnParentTable.Loaded)
                if (!LoadOrScanJsonFile(Var.SelectedColumnParentTable))
                    return;

            if (Var.SelectedColumnParentTable.Count != 0)
                foreach (JLine jl in Var.SelectedColumnParentTable)
                    jl.Add("");

            JColumn jc = new JColumn(columnName);
            Var.SelectedColumnParentTable.Columns.Add(jc);
            Var.SelectedColumn = jc;
            Var.SelectedColumnParentTable.Changed = true;
            Var.JFI.Changed = true;
            RefreshTrvJsonFiles();
        }

        #region DirectoryCopy
        private static void DirectoryCopy(string sourceDirName, string destDirName, string[] ignoreDirName = null, bool copySubDirs = true)
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

            if (ignoreDirName == null || !ignoreDirName.Contains(Path.GetFileName(destDirName)))
            {
                Directory.CreateDirectory(destDirName);
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string tempPath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(tempPath, true);
                }

                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string tempPath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, tempPath, ignoreDirName, copySubDirs);
                    }
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
            ckbColumnAutoGenerateKey.Checked = false;            
            cobColumnFKTable.SelectedIndex = -1; //聯動
            txtColumnNumberOfRows.Text = "0";
        }

        public void cobColumnFKTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool autoGenerateKey = ckbColumnAutoGenerateKey.Checked;
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
            ckbColumnAutoGenerateKey.Checked = autoGenerateKey;
        }

        public void RefreshTmiLanguages()
        {
            foreach (ToolStripItem tsi in tmiLanguages.DropDownItems)
            {
                ToolStripMenuItem tsmi = tsi as ToolStripMenuItem;
                if (tsmi != null)
                    tsmi.Checked = false;
                else
                    continue;

                if (tsmi.Name.Contains(Setting.CI.Name.Remove(2, 1).ToUpper()))
                    tsmi.Checked = true;
            }
        }

        private void tmiLanguageZHCN_Click(object sender, EventArgs e)
        {
            Setting.CI = new CultureInfo("zh-CN");
            ChangeCulture();
        }

        public void tmiLanguageZHTW_Click(object sender, EventArgs e)
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
                if (!LoadOrScanJsonFile(Var.SelectedColumnParentTable))
                   return;
                
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
                Var.JFI = JsonConvert.DeserializeObject<JFilesInfo>(jsonString, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Error });
            }
            catch (Exception ex)
            {
                ExceptionHandler.JsonConvertDeserializeJFIFailed(ex);
                return false;
            }

            if (Var.JFI.CheckValid() != JColumnInvalidReasons.None)
            {
                ExceptionHandler.JFIFileIsInvalid(Var.JFI);
                return false;
            }
            return true;
        }

        public static bool LoadOrScanJsonFile(JTable jt, bool scan = false)
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
                if (scan)
                    jt.ScanJson(jsonObject, Setting.NumberOfRowsMaxValue);
                else
                    jt.LoadJson(jsonObject);
            }
            catch (JFileInvalidException ex)
            {
                ExceptionHandler.JTableLoadOrScanJsonFailed(jt, ex, scan);
                return false;
            }

            if (!jt.Valid)
                Var.Database.CheckTableValid(jt, Setting.UseQuickCheck);
            return true;
        }

        #region TempClosed
        //暫時用不到
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
                                    jl.Add(reader.Value);
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
        #endregion

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
                if (!LoadOrScanJsonFile(Var.SelectedColumnParentTable))
                    return;

            //如果有資料秀出訊息視窗
            if (Var.SelectedColumnParentTable.Count != 0)
            {
                DialogResult dr = RabbitCouriers.SentNoramlQuestionByResource("JE_RUN_DELETE_COLUMN_M_1", Res.JE_TMI_DELETE_COLUMN, Var.SelectedColumnParentTable.Count.ToString());
                if (dr == DialogResult.Cancel)
                    return;
            }

            Var.SelectedColumnParentTable.Changed = true;
            Var.JFI.Changed = true;

            //資料全部抓出來砍掉
            foreach (JLine jl in Var.SelectedColumnParentTable)
                jl.RemoveAt(Var.SelectedColumnParentTable.Columns.IndexOf(Var.SelectedColumn));

            //取消FK
            CancelFK(Var.SelectedColumnParentTable, Var.SelectedColumn);

            string removedName = Var.SelectedColumn.Name;
            Var.SelectedColumnParentTable.Columns.Remove(Var.SelectedColumn);
            Var.SelectedColumn = null;

            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_DELETE_COLUMN_M_2, removedName);
        }

        public void btnNewLine_Click(object sender, EventArgs e)
        {
            if (Var.SelectedTable.Columns.Count == 0)
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_NEW_LINE_M_2", Res.JE_BTN_NEW_LINE);
                return;
            }

            Var.SelectedTable.GenerateNewLine();
            Var.SelectedTable.Changed = true;
            Var.SelectedLineIndex = dgvLines.Rows.Count;

            sslMain.Text = string.Format(Res.JE_RUN_NEW_LINE_M_1, Var.SelectedTable.Name);

            Var.Database.CheckTableValid(Var.SelectedTable, Setting.UseQuickCheck);
            RefreshDgvLines();
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
                Var.RenamedFiles.Add(Path.Combine(Var.JFI.DirectoryPath, $"{Var.SelectedColumnParentTable.Name}.json"));
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
            Var.DeleteFiles.Add(Path.Combine(Var.JFI.DirectoryPath, $"{fileName}.json"));
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
            RefreshDgvLines();
            RefreshPnlMain();
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

            Var.Database.CheckTableValid(Var.SelectedTable, Setting.UseQuickCheck);

            RefreshDgvLines();
            RefreshPnlMainValue();
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
                if(Var.SelectedTable.Columns[i].Type != JType.Array && Var.SelectedTable.Columns[i].Type != JType.Object)
                    Var.SelectedTable[Var.SelectedLineIndex][i] = Var.InputControlSets[i].GetValueValidated();

            sslMain.Text = string.Format(Res.JE_RUN_UPDATE_LINE_M_1, Var.SelectedTable.Name);

            Var.SelectedTable.Changed = true;
            Var.Database.CheckTableValid(Var.SelectedTable, Setting.UseQuickCheck);
            RefreshDgvLines();
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
                if (!LoadOrScanJsonFile(Var.SelectedColumnParentTable))
                    return;

            foreach (JLine jl in Var.SelectedColumnParentTable)
            {
                object jv = jl[index - 1];
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
                if(!LoadOrScanJsonFile(Var.SelectedColumnParentTable))
                    return;

            foreach (JLine jl in Var.SelectedColumnParentTable)
            {
                object jv = jl[index + 1];
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
            ckbColumnAutoGenerateKey.Enabled = FKIsEmpty;
            if (!FKIsEmpty)
                ckbColumnAutoGenerateKey.Checked = false;
            cobColumnType_SelectedIndexChanged(sender, e);
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
            //預讀預設值
            Setting.CI = new CultureInfo("en-US");
            Setting.UseQuickCheck = false;
            Setting.DontLoadFileBytesThreshold = 10000;
            Setting.NumberOfRowsMaxValue = 30;
            Setting.InvalidLineBackColor = Color.FromArgb(255, 211, 211);
            Setting.DgvLinesStringMaxLength = 20;

            //讀取Setting
            if (File.Exists(Path.Combine(Const.ApplicationDataFolder, "Setting.ini")))
            {
                using (FileStream fs = new FileStream(Path.Combine(Const.ApplicationDataFolder, "Setting.ini"), FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        PropertyInfo[] pis = typeof(Setting).GetProperties();
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            PropertyInfo pi = typeof(Setting).GetProperty(line.Split('=')[0]);
                            if (pi.PropertyType == typeof(CultureInfo))
                                pi.SetValue(null, new CultureInfo(line.Split('=')[1]));
                            else if (pi.PropertyType == typeof(Color))
                            {
                                string[] value = line.Split('=');
                                pi.SetValue(null, Color.FromArgb(int.Parse(value[2].Split(',')[0]),
                                    int.Parse(value[3].Split(',')[0]), int.Parse(value[4].Split(',')[0]),
                                    int.Parse(value[5].Split(']')[0])));
                            }
                            else
                                pi.SetValue(null, Convert.ChangeType(line.Split('=')[1], pi.PropertyType));
                        }
                    }
                }
            }

            ckbQuickCheck.Checked = Setting.UseQuickCheck;
            ChangeCulture();
            cobColumnType.DataSource =
                Enum.GetValues(typeof(JType)).OfType<JType>()
                .Except(new List<JType> { JType.None })
                .ToList();
            cobColumnType.SelectedIndex = 0;
            tbpStart.BackColor = this.BackColor;
#if !DEBUG
            tmiBackup.Visible = false;
#endif
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

            //Test Area

            // Get secret click event key
            //FieldInfo eventClick = typeof(Control).GetField("EventClick", BindingFlags.NonPublic | BindingFlags.Static);
            //object secret = eventClick.GetValue(null);
            //// Retrieve the click event
            //PropertyInfo eventsProp = typeof(Button).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            //EventHandlerList events = (EventHandlerList)eventsProp.GetValue(btnClearMain, null);
            //Delegate click = events[secret];
            // Remove it from button1, add it to button2
            //events.RemoveHandler(secret, click);
            //events = (EventHandlerList)eventsProp.GetValue(btnClearMain, null);
            //events.AddHandler(secret, click);

        }



        public void cobColumnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobColumnType.SelectedIndex == -1)
                return;
            JType result = (JType)cobColumnType.SelectedItem;

            lblColumnChoicesCount.Text = result != JType.Choice ? "-" : "0";            
            ckbColumnAutoGenerateKey.Enabled = cobColumnFKColumn.SelectedIndex == -1;
            if (!(result.IsNumber() || result == JType.Guid || result == JType.String))
                ckbColumnAutoGenerateKey.Checked = ckbColumnAutoGenerateKey.Enabled = false;
            txtColumnRegex.Enabled =
            txtColumnMaxLength.Enabled = !ckbColumnAutoGenerateKey.Checked &&
                cobColumnFKColumn.SelectedIndex == -1 &&
                result == JType.String || result == JType.Uri;
            txtColumnMinValue.Enabled =
            txtColumnMaxValue.Enabled = !ckbColumnAutoGenerateKey.Checked && cobColumnFKColumn.SelectedIndex == -1 &&
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
            if (!Var.SelectedColumnParentTable.Loaded)
                if(!LoadOrScanJsonFile(Var.SelectedColumnParentTable))
                    return;

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
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_LINE_MOVE_UP_M_1", Res.JE_RUN_LINE_MOVE_TITLE, index);
                return;
            }

            JLine jl = Var.SelectedTable[index - 1];
            Var.SelectedTable[index - 1] = Var.SelectedTable[index];
            Var.SelectedTable[index] = jl;
            Var.SelectedLineIndex--;
            Var.SelectedTable.Changed = true;

            //更新Invalid Stats
            Dictionary<int, JValueInvalidReasons> dic = null;
            if (Var.SelectedTable.InvalidRecords.ContainsKey(index - 1))
                dic = Var.SelectedTable.InvalidRecords[index - 1];
            if (Var.SelectedTable.InvalidRecords.ContainsKey(index))
                Var.SelectedTable.InvalidRecords[index - 1] = Var.SelectedTable.InvalidRecords[index];
            else if (Var.SelectedTable.InvalidRecords.ContainsKey(index - 1))
                Var.SelectedTable.InvalidRecords.Remove(index - 1);
            if (dic != null)
                Var.SelectedTable.InvalidRecords[index] = dic;
            else if (Var.SelectedTable.InvalidRecords.ContainsKey(index))
                Var.SelectedTable.InvalidRecords.Remove(index);

            RefreshDgvLines();
        }

        public void btnLineMoveDown_Click(object sender, EventArgs e)
        {
            int index = Var.SelectedLineIndex;
            if (index == -1)
                return;
            else if (index == Var.SelectedTable.Count - 1)
            {
                RabbitCouriers.SentErrorMessageByResource("JE_RUN_LINE_MOVE_DOWN_M_1", Res.JE_RUN_LINE_MOVE_TITLE, index);
                return;
            }

            JLine jl = Var.SelectedTable[index + 1];
            Var.SelectedTable[index + 1] = Var.SelectedTable[index];
            Var.SelectedTable[index] = jl;
            Var.SelectedLineIndex++;
            Var.SelectedTable.Changed = true;

            //更新Invalid Stats
            Dictionary<int, JValueInvalidReasons> dic = null;
            if (Var.SelectedTable.InvalidRecords.ContainsKey(index + 1))
                dic = Var.SelectedTable.InvalidRecords[index + 1];
            if (Var.SelectedTable.InvalidRecords.ContainsKey(index))
                Var.SelectedTable.InvalidRecords[index + 1] = Var.SelectedTable.InvalidRecords[index];
            else if (Var.SelectedTable.InvalidRecords.ContainsKey(index + 1))
                Var.SelectedTable.InvalidRecords.Remove(index + 1);
            if (dic != null)
                Var.SelectedTable.InvalidRecords[index] = dic;
            else if (Var.SelectedTable.InvalidRecords.ContainsKey(index))
                Var.SelectedTable.InvalidRecords.Remove(index);

            RefreshDgvLines();
        }

        private void ckbQuickCheck_CheckedChanged(object sender, EventArgs e)
        {
            Setting.UseQuickCheck = ckbQuickCheck.Checked;
        }

        private void tmiJsonEditorBackup_Click(object sender, EventArgs e)
        {
            string BackupPath = @"E:\Backup\JsonEditorV2";
            string ProjectPath = @"C:\Programs\WinForm\JsonEditorV2";
            string[] IgnoreDirName = new string[] { "TestArea", "TestData", "bin", "obj" };
            string[] ProjectName = new string[] { "JsonEditorV2", "JsonEditorV2Tests" };

            foreach (string pj in ProjectName)
            {
                if (!Directory.Exists(Path.Combine(BackupPath, pj)))
                    Directory.CreateDirectory(Path.Combine(BackupPath, pj));

                DirectoryCopy(Path.Combine(ProjectPath, pj), Path.Combine(BackupPath, pj), IgnoreDirName);
            }

            File.Copy(Path.Combine(ProjectPath, $"{ProjectName[0]}.sln"), Path.Combine(BackupPath, $"{ProjectName[0]}.sln"), true);
            RabbitCouriers.SentInformation("OK");
        }

        private void tmiTestDataBackup_Click(object sender, EventArgs e)
        {
            string BackupPath = @"E:\Backup\JsonEditorV2\JsonEditorV2";
            string ProjectPath = @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2";
            string[] ProjectName = new string[] { "TestArea", "TestData" };

            foreach (string pj in ProjectName)
            {
                if (!Directory.Exists(Path.Combine(BackupPath, pj)))
                    Directory.CreateDirectory(Path.Combine(BackupPath, pj));

                DirectoryCopy(Path.Combine(ProjectPath, pj), Path.Combine(BackupPath, pj));
            }
            RabbitCouriers.SentInformation("OK");
        }

        private void tmiAritiafelBackup_Click(object sender, EventArgs e)
        {
            string BackupPath = @"E:\Backup\Aritiafel";
            string ProjectPath = @"C:\Programs\Standard\Aritiafel";
            string[] IgnoreDirName = new string[] { "bin", "obj" };
            string[] ProjectName = new string[] { "Aritiafel", "AritiafelTestForm", "AritiafelTestFormTests" };


            foreach (string pj in ProjectName)
            {
                if (!Directory.Exists(Path.Combine(BackupPath, pj)))
                    Directory.CreateDirectory(Path.Combine(BackupPath, pj));

                DirectoryCopy(Path.Combine(ProjectPath, pj), Path.Combine(BackupPath, pj), IgnoreDirName);
            }

            File.Copy(Path.Combine(ProjectPath, $"{ProjectName[0]}.sln"), Path.Combine(BackupPath, $"{ProjectName[0]}.sln"), true);

            RabbitCouriers.SentInformation("OK");
        }

        private void tmiRunSomething_Click(object sender, EventArgs e)
        {
            //string ProjectPath = @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2";
            //string[] ProjectName = new string[] { "TestArea", "TestData" };

            //foreach (string pj in ProjectName)
            //    ChangeRegex(Path.Combine(ProjectPath, pj));
            //RabbitCouriers.SentInformation("OK");
        }

        private void ChangeRegex(string folderName)
        {
            //string[] files = Directory.GetFiles(folderName, "JFilesInfo.json.bak");
            //foreach (string file in files)
            //    File.Delete(file);

            //string[] folders = Directory.GetDirectories(folderName);

            //foreach (string folder in folders)
            //    ChangeRegex(folder);

            //return;

            string[] files = Directory.GetFiles(folderName, "JFilesInfo.json");
            string s;
            foreach (string file in files)
            {
                using (FileStream fs1 = new FileStream(file, FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs1);
                    s = sr.ReadToEnd();
                    sr.Close();
                }

                File.Move(file, $"{file}.bak");

                using (FileStream fs2 = new FileStream(file, FileMode.Create))
                {
                    StreamWriter sw = new StreamWriter(fs2);
                    sw.Write(s.Replace("TextMaxLength", "MaxLength"));
                    sw.Close();
                }
            }

            string[] folders = Directory.GetDirectories(folderName);

            foreach (string folder in folders)
                ChangeRegex(folder);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AskSaveFiles(Res.JE_TMI_EXIT) == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            //Setting.ini存取
            try
            {
                using (FileStream fs = new FileStream(Path.Combine(Const.ApplicationDataFolder, "Setting.ini"), FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        PropertyInfo[] pis = typeof(Setting).GetProperties();
                        foreach (var pi in pis)
                            sw.WriteLine($"{pi.Name}={pi.GetValue(null)}");
                    }
                    //Process.Start("Notepad.exe", fs.Name);
                }
            }
            catch { }

        }

        private void ckbAutoGenerateKey_CheckedChanged(object sender, EventArgs e)
        {
            cobColumnType_SelectedIndexChanged(sender, e);
        }

        private void dgvLines_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLines.Rows.Count != 0 && !Var.LockPnlMain)
            {
                Var.SelectedLineIndex = Convert.ToInt32(dgvLines.SelectedRows[0].Cells[Const.HiddenColumnItemIndex].Value);                
                btnLineMoveDown.Enabled = Var.SelectedLineIndex != Var.SelectedTable.Count - 1;
                btnLineMoveUp.Enabled = Var.SelectedLineIndex != 0;
                RefreshPnlMainValue();
            }
        }

        private void dgvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvLines.Columns[dgvLines.Columns.Count - 1].Visible = false;
            if (dgvLines.Columns.Count == 2)
            {
                dgvLines.Columns[0].HeaderText = "(Item Index)";
                dgvLines.Columns[0].Visible = true;
            }
            else
                dgvLines.Columns[dgvLines.Columns.Count - 2].Visible = false;
            dgvLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            int totalColumnWidth = 0;
            for (int i = 0; i < dgvLines.Columns.Count - 2; i++)
                totalColumnWidth += dgvLines.Columns[i].Width + dgvLines.Columns[i].DividerWidth;

            if (dgvLines.Columns.Count > 2 && dgvLines.Width - totalColumnWidth > 0)
                dgvLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < dgvLines.Rows.Count; i++)
                if (dgvLines.Rows[i].Cells[dgvLines.Columns.Count - 1].Value != DBNull.Value)
                    dgvLines.Rows[i].DefaultCellStyle.BackColor = Setting.InvalidLineBackColor;
        }

        private void dgvLines_Sorted(object sender, EventArgs e)
        {

        }

        private int FindItemIndexFromSelectedTable(int columnIndex, int startIndex = 0)
        {
            if (Var.SelectedTable.Columns[columnIndex].Type == JType.String || Var.SelectedTable.Columns[columnIndex].Type == JType.Uri)
                return Var.SelectedTable.Lines.FindIndex(startIndex, m => (m.Values[columnIndex] ?? "").ToString(Var.SelectedTable.Columns[columnIndex].Type).Contains(txtFindValue.Text));
            else
                return Var.SelectedTable.Lines.FindIndex(startIndex, m => (m.Values[columnIndex] ?? "").ToString(Var.SelectedTable.Columns[columnIndex].Type) == txtFindValue.Text.ToString(Var.SelectedTable.Columns[columnIndex].Type));
        }

        public void btnFindConfirm_Click(object sender, EventArgs e)
        {
            if (txtFindValue.Text == "" || Var.SelectedTable == null)
                return;

            int columnIndex = Var.SelectedTable.Columns.FindIndex(m => m.Name == cobFindColumnName.SelectedValue.ToString());
            if (columnIndex == -1)
                return;

            int itemIndex = FindItemIndexFromSelectedTable(columnIndex, Var.SelectedLineIndex + 1);
            if (itemIndex == -1)
                itemIndex = FindItemIndexFromSelectedTable(columnIndex);

            if (itemIndex != -1)
            {                
                Var.SelectedLineIndex = itemIndex;
                dgvLines.Rows[Var.SelectedLineIndex].Selected = true;
                if (!dgvLines.SelectedRows[0].Displayed)
                    dgvLines.FirstDisplayedScrollingRowIndex = dgvLines.SelectedRows[0].Index;
            }
            else
                RabbitCouriers.SentWarningMessageByResource("JE_RUN_FIND_NO_ITEM_FOUND", Res.JE_RUN_FIND_TITLE, Var.SelectedTable.Columns[columnIndex].Name, txtFindValue.Text);
        }

        private void tmiColumnShowOnList_Click(object sender, EventArgs e)
        {
            Var.SelectedColumn.Display = !Var.SelectedColumn.Display;
            Var.JFI.Changed = true;
            RefreshPnlFileInfo();
            RefreshTbcMain();
        }

        private void dgvLines_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == DBNull.Value)
            {
                e.Value = Const.NullString;
                e.CellStyle.Font = new Font(Font, FontStyle.Italic);
            }
        }

        private void txtFindValue_Click(object sender, EventArgs e)
        {
            txtFindValue.SelectAll();
        }

        private void tmiRenameDatabase_Click(object sender, EventArgs e)
        {
            string newName = frmInputBox.Show(this, InputBoxTypes.RenameDataBase);
            if (string.IsNullOrEmpty(newName))
                return;

            if (newName == Var.JFI.Name)
                return;

            Var.JFI.Name = newName;
            Var.JFI.Changed = true;
           
            RefreshTrvJsonFiles();
            sslMain.Text = string.Format(Res.JE_RUN_RENAME_DATABASE_M_1, newName);
        }

        private void btnColumnEditChoices_Click(object sender, EventArgs e)
        {
            if (Var.SelectedColumn == null)
                return;
            List<string> result = frmChoices.ShowDialog(this, Var.SelectedColumn.Choices);
            if (result != null)
            { 
                Var.SelectedColumn.Choices = result;
                Var.JFI.Changed = true;
                RefreshTbcMain();
            }
            lblColumnChoicesCount.Text = Var.SelectedColumn.Choices.Count.ToString();
        }
    }
}
 