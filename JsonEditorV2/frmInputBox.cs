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
using Aritiafel.Organizations;

namespace JsonEditorV2
{
    public enum InputBoxTypes
    {
        NewFile = 0,
        RenameFile,
        AddColumn,
        RenameColumn,
    }

    public partial class frmInputBox : Form
    {
        private InputBoxTypes i_type;
        private string returnValue;

        public static string Show(IWin32Window owner, InputBoxTypes type)
        {            
            frmInputBox frmInputBox = new frmInputBox(type);            
            frmInputBox.ShowDialog(owner);
            return frmInputBox.returnValue;
        }

        public frmInputBox(InputBoxTypes type)
        {
            InitializeComponent();
            i_type = type;
            btnConfirm.Text = Res.JE_INPUTBOX_BTN_CONFIRM;
            btnCancel.Text = Res.JE_INPUTBOX_BTN_CANCEL;

            switch (type)
            {
                case  InputBoxTypes.NewFile:                
                    lblExtensionName.Visible = true;
                    lblDescirption.Text = Res.JE_INPUTBOX_DESCRIPTION;
                    Text = Res.JE_TMI_NEW_JSON_FILE;
                    break;
                case InputBoxTypes.RenameFile:
                    lblExtensionName.Visible = true;
                    lblDescirption.Text = Res.JE_INPUTBOX_DESCRIPTION;
                    Text = Res.JE_TMI_RENAME_JSON_FILE;
                    break;
                case InputBoxTypes.AddColumn:
                    lblExtensionName.Visible = false;
                    lblDescirption.Text = Res.JE_INPUTBOX_DESCRIPTION_2;
                    Text = Res.JE_TMI_ADD_COLUMN;
                    break;
                case InputBoxTypes.RenameColumn:
                    lblExtensionName.Visible = false;
                    lblDescirption.Text = Res.JE_INPUTBOX_DESCRIPTION_2;
                    Text = Res.JE_TMI_RENAME_COLUMN;
                    break;
                default:
                    lblExtensionName.Visible = false;
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            returnValue = null;
            Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {   
            switch (i_type)
            {
                case InputBoxTypes.NewFile:                
                    if (!Regex.IsMatch(txtInput.Text, Const.FileNameRegex))
                    {
                        RabbitCouriers.SentErrorMessage(string.Format(Res.JE_INPUTBOX_WRONG_FILE_NAME, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")), Res.JE_TMI_NEW_JSON_FILE);
                        return;
                    }
                    else if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")))
                    {
                        RabbitCouriers.SentErrorMessage(string.Format(Res.JE_INPUTBOX_FILE_EXISTS, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")), Res.JE_TMI_NEW_JSON_FILE);
                        return;
                    }                    
                    break;
                case InputBoxTypes.RenameFile:
                    if (!Regex.IsMatch(txtInput.Text, Const.FileNameRegex))
                    {
                        RabbitCouriers.SentErrorMessage(string.Format(Res.JE_INPUTBOX_WRONG_FILE_NAME, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")), Res.JE_TMI_RENAME_JSON_FILE);
                        return;
                    }
                    else if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")))
                    {
                        RabbitCouriers.SentErrorMessage(string.Format(Res.JE_INPUTBOX_FILE_EXISTS, Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")), Res.JE_TMI_RENAME_JSON_FILE);
                        return;
                    }
                    break;
                case InputBoxTypes.AddColumn:                    
                    if (!Regex.IsMatch(txtInput.Text, Const.ColumnNameRegex))
                    {
                        RabbitCouriers.SentErrorMessage(Res.JE_INPUTBOX_WRONG_COLUMN_NAME, Res.JE_TMI_ADD_COLUMN);                        
                        return;
                    }
                    break;
                case InputBoxTypes.RenameColumn:
                    if (!Regex.IsMatch(txtInput.Text, Const.ColumnNameRegex))
                    {
                        RabbitCouriers.SentErrorMessage(Res.JE_INPUTBOX_WRONG_COLUMN_NAME, Res.JE_TMI_RENAME_COLUMN);
                        return;
                    }
                    break;
                default:                    
                    break;
            }
            returnValue = txtInput.Text;
            Hide();
        }

        private void frmInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnConfirm_Click(this, new EventArgs());
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                btnCancel_Click(this, new EventArgs());
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmInputBox_KeyPress(this, e);
        }
    }
}
