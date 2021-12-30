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
using JsonEditor;

namespace JsonEditorV2
{
    public partial class frmSortList : Form
    {

        private JTable table;
        public List<SortListVar> ReturnValue { get; private set; }
        public List<SortListInputControlSet> SLControlList { get; set; }
        public frmSortList()
        {
            InitializeComponent();
        }

        public static List<SortListVar> Show(IWin32Window owner, JTable table)
        {
            frmSortList frmSortList = new frmSortList();
            //frmInputBox.txtInput.Text = defaultText;
            frmSortList.SLControlList = new List<SortListInputControlSet>();

            //設定第一個
            frmSortList.RefreshPnlSortMain();
            frmSortList.ShowDialogOrCallEvent(owner);
            return frmSortList.ReturnValue;
        }

        public void RefreshPnlSortMain()
        {
            pnlSortMain.Controls.Clear();
            for(int i = 0; i < SLControlList.Count; i++)
            {
                SLControlList[i].DrawControl(pnlSortMain, i * 10);
            }
        }

        private void AddNewSLI()
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnValue = null;            
            DialogResult = DialogResult.Cancel;
        }
    }
}
