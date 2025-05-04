using Aritiafel.Organizations;
using JsonEditorV2.Resources;
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

namespace JsonEditorV2
{
    public partial class frmCorporation : Form
    {
        public string CorporationName
        {
            get { return txtCorporationName.Text; }
            set { txtCorporationName.Text = value; }
        }

        public string CorporationID
        {
            get { return txtCorporationID.Text; }
            set { txtCorporationID.Text = value; }
        }

        public string OutputFolderPath
        {
            get { return txtOutputFolder.Text; }
            set { txtOutputFolder.Text = value; }
        }

        public frmCorporation()
        {
            InitializeComponent();
            btnConfirm.Text = Res.JE_BTN_CONFIRM;
            btnCancel.Text = Res.JE_BTN_CANCEL;
            lblCorporationName.Text = Res.JE_CORPBOX_CORP_NAME;
            lblCorporationID.Text = Res.JE_CORPBOX_CORP_ID;
            lblConvertTo.Text = Res.JE_LBL_CONVERT_TO;            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OutputFolderPath))
            {
                RabbitCouriers.SentWarningMessageByResource("JE_CORPBOX_VAL_OUTPUT_FOLDER_EMPTY", Text);
                return;
            }
            DialogResult = DialogResult.OK;
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fbdMain.SelectedPath = Path.GetDirectoryName(Var.JFI.DirectoryPath);
            DialogResult dr = fbdMain.ShowDialogOrSetResult(this);
            if (dr != DialogResult.OK)
                return;

            if(!string.IsNullOrEmpty(fbdMain.SelectedPath))
                txtOutputFolder.Text = fbdMain.SelectedPath;
        }
    }
}
