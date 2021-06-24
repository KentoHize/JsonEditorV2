using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aritiafel.Organizations;
using JsonEditorV2.Resources;

namespace JsonEditorV2
{
    public partial class frmDescription : Form
    {
        public string ReturnValue { get; set; }
        public static string ShowDialog(IWin32Window owner, string value = "")
        {
            frmDescription frmDescription = new frmDescription();
            frmDescription.txtDescription.Text = value;
            frmDescription.ShowDialogOrCallEvent(owner);
            return frmDescription.ReturnValue;
        }
        public frmDescription()
        {
            InitializeComponent();
            btnConfirm.Text = Res.JE_INPUTBOX_BTN_CONFIRM;
            btnCancel.Text = Res.JE_INPUTBOX_BTN_CANCEL;
            Text = Res.JE_TMI_EDIT_DATABASE_DESCRIPTION;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ReturnValue = txtDescription.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnValue = null;
            DialogResult = DialogResult.Cancel;
        }

        private void frmDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                btnCancel_Click(this, new EventArgs());
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmDescription_KeyPress(sender, e);
        }
    }
}
