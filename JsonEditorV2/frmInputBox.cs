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
using System.Text.RegularExpressions;

namespace JsonEditorV2
{
    public partial class frmInputBox : Form
    {
        public string InputValue { get; set; }
        public string BoxType { get; set; }

        public frmInputBox()
            : this("")
        {  }
    

        public frmInputBox(string boxType)
        {
            InitializeComponent();
            BoxType = boxType;            
            btnConfirm.Text = Res.JE_INPUTBOX_BTN_CONFIRM;
            btnCancel.Text = Res.JE_INPUTBOX_BTN_CANCEL;

            switch (BoxType)
            {
                case "New File":                
                    lblExtensionName.Visible = true;
                    lblDescirption.Text = Res.JE_INPUTBOX_DESCRIPTION;
                    Text = Res.JE_TMI_NEW_JSON_FILE;
                    break;
                case "Rename File":
                    lblExtensionName.Visible = true;
                    lblDescirption.Text = Res.JE_INPUTBOX_DESCRIPTION;
                    Text = Res.JE_TMI_RENAME_JSON_FILE;
                    break;
                case "Add Column":
                    lblExtensionName.Visible = false;
                    lblDescirption.Text = Res.JE_INPUTBOX_DESCRIPTION_2;
                    Text = Res.JE_TMI_ADD_COLUMN;
                    break;
                default:
                    lblExtensionName.Visible = false;
                    break;

            }
            DialogResult = DialogResult.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            InputValue = txtInput.Text;
            switch (BoxType)
            {
                case "New File":                
                    if (!Regex.IsMatch(txtInput.Text, Const.FileNameRegex))
                    {
                        MessageBox.Show(string.Format(Res.JE_INPUTBOX_WRONG_FILE_NAME, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")), Res.JE_TMI_NEW_JSON_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")))
                    {
                        MessageBox.Show(string.Format(Res.JE_INPUTBOX_FILE_EXISTS, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")), Res.JE_TMI_NEW_JSON_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                    
                    break;
                case "Rename File":
                    if (!Regex.IsMatch(txtInput.Text, Const.FileNameRegex))
                    {
                        MessageBox.Show(string.Format(Res.JE_INPUTBOX_WRONG_FILE_NAME, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")), Res.JE_TMI_RENAME_JSON_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")))
                    {
                        MessageBox.Show(string.Format(Res.JE_INPUTBOX_FILE_EXISTS, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")), Res.JE_TMI_RENAME_JSON_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "Add Column":                    
                    if (!Regex.IsMatch(txtInput.Text, Const.ColumnNameRegex))
                    {                        
                        MessageBox.Show(Res.JE_INPUTBOX_WRONG_COLUMN_NAME, Res.JE_TMI_ADD_COLUMN, MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        return;
                    }
                    break;
                default:                    
                    break;
            }
            DialogResult = DialogResult.OK;            
        }

        private void frmInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnConfirm_Click(this, new EventArgs());
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                btnCancel_Click(this, new EventArgs());
        }
    }
}
