using System;
using System.Resources;
using System.Windows.Forms;
using JsonEditorV2.Resources;

namespace JsonEditorV2
{
    public partial class MainForm : Form
    {
        ResourceManager rm = new ResourceManager("JsonEditorV2.Resources.Main",
            Type.GetType("JsonEditorV2.Resources.Main").Assembly);        

        public MainForm()
        {
            InitializeComponent();
            Main.Culture = new System.Globalization.CultureInfo("zh-TW");
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
            
        }

        private void libLines_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateColumn_Click(object sender, EventArgs e)
        {

        }
    }
}
