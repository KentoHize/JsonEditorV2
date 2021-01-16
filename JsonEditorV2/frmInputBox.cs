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
            lblDescirption.Text = Main.JE_INPUTBOX_DESCRIPTION;
            btnConfirm.Text = Main.JE_INPUTBOX_BTN_CONFIRM;
            btnCancel.Text = Main.JE_INPUTBOX_BTN_CANCEL;

            switch (BoxType)
            {
                case "New File":
                    lblExtensionName.Visible = true;
                    lblDescirption.Text = Main.JE_INPUTBOX_DESCRIPTION;
                    Text = Main.JE_TMI_NEW_JSON_FILE;
                    break;
                case "Add Column":
                    lblExtensionName.Visible = false;
                    lblDescirption.Text = Main.JE_INPUTBOX_DESCRIPTION_2;
                    Text = Main.JE_TMI_ADD_COLUMN;
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
                    if (!Regex.IsMatch(txtInput.Text, @"^[\w\-. ]+$"))
                    {
                        MessageBox.Show(string.Format(Main.JE_INPUTBOX_FILE_EXISTS, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json"), Main.JE_INPUTBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error));
                        return;
                    }
                    else if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")))
                    {
                        MessageBox.Show(string.Format(Main.JE_INPUTBOX_FILE_EXISTS, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json"), Main.JE_INPUTBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error));
                        return;
                    }
                    break;
                case "Add Column":                    
                    if (!Regex.IsMatch(txtInput.Text, @"^[A-Za-z_][\w\-]{0,49}$"))
                    {                        
                        MessageBox.Show(Main.JE_INPUTBOX_WRONG_COLUMN_NAME, Main.JE_TMI_ADD_COLUMN, MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        return;
                    }
                    break;
                default:                    
                    break;
            }
            DialogResult = DialogResult.OK;
            
            
            
        }
    }
}
