using JsonEditor;
using JsonEditorV2.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Var.RM = new ResourceManager("JsonEditorV2.Resources.Main", Type.GetType("JsonEditorV2.Resources.Main").Assembly);
            Var.CI = new CultureInfo("zh-TW");
            PatchTextFromResource(Var.CI);
            cobColumnType.DataSource = Enum.GetValues(typeof(JType));
            cobColumnType.SelectedIndex = -1;
            tbpStart.BackColor = this.BackColor;
        }

        #region RESOURCES_TEXT_PATCH
        private void PatchTextFromResource(CultureInfo ci)
        {
            Main.Culture = ci;
            Text = Main.JSON_FILE_EDITOR_TITLE;
            lblColumnName.Text = Main.JE_COLUMN_NAME;
            lblColumnType.Text = Main.JE_COLUMN_TYPE;
            lblColumnIsKey.Text = Main.JE_COLUMN_IS_KEY;
            lblColumnDisplay.Text = Main.JE_COLUMN_DISPLAY;
            lblCloumnFK.Text = Main.JE_COLUMN_FK;
            lblColumnNumberOfRows.Text = Main.JE_COLUMN_NUM_OF_ROWS;
            btnClearMain.Text = Main.JE_BTN_CLEAR_MAIN;
            btnUpdateMain.Text = Main.JE_BTN_UPDATE_MAIN;
            btnUpdateColumn.Text = Main.JE_BTN_UPDATE_COLUMN;
            btnDeleteColumn.Text = Main.JE_BTN_DELETE_COLUMN;
            tmiFile.Text = Main.JE_TMI_FILE;
            tmiAbout.Text = Main.JE_TMI_ABOUT;
            tmiNewJsonFiles.Text = Main.JE_TMI_NEW_JSON_FILES;
            tmiLoadJsonFiles.Text = Main.JE_TMI_LOAD_JSON_FILES;
            tmiSaveJsonFiles.Text = Main.JE_TMI_SAVE_JSON_FILES;
            tmiCloseAllFiles.Text = Main.JE_TMI_CLOSE_ALL_FILES;
            tmiExit.Text = Main.JE_TMI_EXIT;
            tmiOpenJsonFile.Text = Main.JE_TMI_OPEN_JSON_FILE;
            tmiDeleteJsonFile.Text = Main.JE_TMI_DELETE_JSON_FILE;
            tmiCloseJsonFile.Text = Main.JE_TMI_CLOSE_JSON_FILE;
            tmiRenameJsonFile.Text = Main.JE_TMI_RENAME_JSON_FILE;
            tmiAddColumn.Text = Main.JE_TMI_ADD_COLUMN;
            tmiNewJsonFile.Text = Main.JE_TMI_NEW_JSON_FILE;
        }
        #endregion

        private void libLines_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateColumn_Click(object sender, EventArgs e)
        {

        }

        private void tmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Main.JE_ABOUT_MESSAGE}\n\n{Main.JE_ABOUT_MESSAGE_2}", Main.JE_ABOUT_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tmiNewJsonFiles_Click(object sender, EventArgs e)
        {
#if DEBUG
            fbdMain.SelectedPath = @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\";
#endif      
            DialogResult dr = fbdMain.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                dr = MessageBox.Show(string.Format(Main.JE_RUN_NEW_JSON_FILES_Q_1, 1), Main.JE_RUN_NEW_JSON_FILES_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                //    jfi = new JFilesInfo(fbdMain.SelectedPath.Substring(fbdMain.SelectedPath.LastIndexOf("\\") + 1), fbdMain.SelectedPath);
                //    string[] jsonfiles = Directory.GetFiles(fbdMain.SelectedPath, "*.json");
                //    if (jsonfiles.Length > 0)
                //    {
                //        if (jsonfiles.Length == 1 && jsonfiles[0] == Path.Combine(fbdMain.SelectedPath, linkFileName))
                //            File.Delete(jsonfiles[0]);
                //        else
                //        {
                //            if (File.Exists(Path.Combine(fbdMain.SelectedPath, linkFileName)))
                //                dr = MessageBox.Show($"此文件已有現存{jsonfiles.Length - 1} JSON檔案，是否要清空資料夾", "清空Json檔案", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //            else
                //                dr = MessageBox.Show($"此文件已有現存{jsonfiles.Length} JSON檔案，是否要清空資料夾", "清空Json檔案", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //            if (dr == DialogResult.Yes)
                //            {
                //                foreach (string s in jsonfiles)
                //                    File.Delete(s);
                //            }
                //            else
                //                return;
                //        }
                //    }

                //    tmiCloseAllJsonFiles_Click(this, e);
                //    tables = new Dictionary<string, JTable>();
                //    jfi.DirectoryPath = fbdMain.SelectedPath;
                //    tmiCloseAllJsonFiles.Enabled = true;
                //    RefreshJsonFilesUI();
                //    sslMain.Text = $"已在\"{jfi.DirectoryPath}\"新建檔案資料夾";
            }
        }

        private void tmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
