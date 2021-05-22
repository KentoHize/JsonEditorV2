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
using JsonEditor;

namespace JsonEditorV2
{
    public enum InputBoxTypes
    {
        NewFile = 0,
        RenameFile,
        AddColumn,
        RenameColumn,
        RenameDataBase
    }

    public partial class frmInputBox : Form
    {
        public InputBoxTypes InputBoxType { get; set; }
        public string ReturnValue { get; set; }

        public static string Show(IWin32Window owner, InputBoxTypes type, string defaultText = "")
        {            
            frmInputBox frmInputBox = new frmInputBox(type);
            frmInputBox.txtInput.Text = defaultText;
            frmInputBox.ShowDialogOrCallEvent(owner);
            return frmInputBox.ReturnValue;
        }

        public frmInputBox(InputBoxTypes type)
        {
            InitializeComponent();
            InputBoxType = type;
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
                case InputBoxTypes.RenameDataBase:
                    lblExtensionName.Visible = false;
                    lblDescirption.Text = Res.JE_INPUTBOX_DESCRIPTION_3;
                    Text = Res.JE_TMI_RENAME_DATABASE;
                    break;
                default:
                    lblExtensionName.Visible = false;
                    break;
            }
        }

        public void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnValue = null;
            DialogResult = DialogResult.Cancel;
        }

        public void btnConfirm_Click(object sender, EventArgs e)
        {   
            switch (InputBoxType)
            {
                case InputBoxTypes.NewFile:                
                    if (!Regex.IsMatch(txtInput.Text, JValidate.FileNameRegex))
                    {
                        RabbitCouriers.SentErrorMessageByResource("JE_INPUTBOX_WRONG_FILE_NAME", Res.JE_TMI_NEW_JSON_FILE);
                        return;
                    }
                    else if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")))
                    {
                        RabbitCouriers.SentErrorMessageByResource("JE_INPUTBOX_FILE_EXISTS", Res.JE_TMI_NEW_JSON_FILE, $"{Var.JFI.DirectoryPath}\\{txtInput.Text}.json");
                        return;
                    }                    
                    break;
                case InputBoxTypes.RenameFile:
                    if (!Regex.IsMatch(txtInput.Text, JValidate.FileNameRegex))
                    {
                        RabbitCouriers.SentErrorMessageByResource("JE_INPUTBOX_WRONG_FILE_NAME", Res.JE_TMI_RENAME_JSON_FILE);
                        return;
                    }
                    else if (File.Exists(Path.Combine(Var.JFI.DirectoryPath, $"{txtInput.Text}.json")))
                    {
                        RabbitCouriers.SentErrorMessageByResource("JE_INPUTBOX_FILE_EXISTS", Res.JE_TMI_RENAME_JSON_FILE, $"{Var.JFI.DirectoryPath}\\{txtInput.Text}.json");
                        return;
                    }
                    break;
                case InputBoxTypes.AddColumn:                    
                    if (!Regex.IsMatch(txtInput.Text, JValidate.ColumnNameRegex))
                    {
                        RabbitCouriers.SentErrorMessageByResource("JE_INPUTBOX_WRONG_COLUMN_NAME", Res.JE_TMI_ADD_COLUMN);
                        return;
                    }
                    break;
                case InputBoxTypes.RenameColumn:
                    if (!Regex.IsMatch(txtInput.Text, JValidate.ColumnNameRegex))
                    {
                        RabbitCouriers.SentErrorMessageByResource("JE_INPUTBOX_WRONG_COLUMN_NAME", Res.JE_TMI_RENAME_COLUMN);
                        return;
                    }
                    break;
                case InputBoxTypes.RenameDataBase:
                    if (!Regex.IsMatch(txtInput.Text, JValidate.DatabaseRegex))
                    {
                        RabbitCouriers.SentErrorMessageByResource("JE_INPUTBOX_WRONG_DATABASE_NAME", Res.JE_TMI_RENAME_DATABASE);
                        return;
                    }
                    break;
                default:                    
                    break;
            }
            ReturnValue = txtInput.Text;
            DialogResult = DialogResult.OK;
        }

        public void frmInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnConfirm_Click(this, new EventArgs());
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                btnCancel_Click(this, new EventArgs());
        }

        public void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmInputBox_KeyPress(this, e);
        }
    }
}
