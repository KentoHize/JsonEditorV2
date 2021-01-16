using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonEditorV2.Resources;

namespace JsonEditorV2
{
    public partial class frmInputBox : Form
    {
        public frmInputBox()
        {
            InitializeComponent();
            Text = Main.JE_INPUTBOX_TITLE;
            lblDescirption.Text = Main.JE_INPUTBOX_DESCRIPTION;
            btnConfirm.Text = Main.JE_INPUTBOX_BTN_CONFIRM;
            btnCancel.Text = Main.JE_INPUTBOX_BTN_CANCEL;
            DialogResult = DialogResult.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")))
            {
                MessageBox.Show(string.Format(Main.JE_INPUTBOX_FILE_EXISTS, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json"), Main.JE_INPUTBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error));
                return;
            }
            DialogResult = DialogResult.OK;
            Tag = txtInput.Text;
        }
    }
}
