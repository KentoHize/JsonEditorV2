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
        public JTable Table;
        public List<SortInfo> ReturnValue { get; private set; }
        public List<SortListInputControlSet> SLControlList { get; set; }
        public frmSortList(JTable table)
        {
            InitializeComponent();
            Table = table;
        }

        public static List<SortInfo> Show(IWin32Window owner, JTable table)
        {
            frmSortList frmSortList = new frmSortList(table);
            //frmInputBox.txtInput.Text = defaultText;
            frmSortList.SLControlList = new List<SortListInputControlSet>();

            frmSortList.AddNewSLI();
            frmSortList.RefreshPnlSortMain();
            frmSortList.ShowDialogOrCallEvent(owner);
            return frmSortList.ReturnValue;
        }

        public void RefreshPnlSortMain()
        {
            pnlSortMain.Controls.Clear();
            int i;
            for (i = 0; i < SLControlList.Count; i++)
                SLControlList[i].DrawControl(pnlSortMain, i);

            Button btnNewSLI = new Button
            {
                Name = "btnNewSLI",
                Left = 5,
                Top = i * 30,
                Text = "New"
            };

            btnNewSLI.Click += BtnNewSLI_Click;
            pnlSortMain.Controls.Add(btnNewSLI);
        }

        private void BtnNewSLI_Click(object sender, EventArgs e)
        {
            AddNewSLI();
            RefreshPnlSortMain();
        }

        private void AddNewSLI()
        {
            SortListInputControlSet sli = new SortListInputControlSet(Table);
            SLControlList.Add(sli);
        }

        public void DeleteSLI(int index)
        {
            SLControlList.RemoveAt(index);
            RefreshPnlSortMain();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnValue = null;
            DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ReturnValue = new List<SortInfo>();
            for(int i = 0; i < SLControlList.Count; i++)
            {
                SortInfo slv = new SortInfo(
                    SLControlList[i].ColumnComboBox.SelectedItem as JColumn,
                    SLControlList[i].DesendingComboBox.SelectedIndex == 1);
                ReturnValue.Add(slv);
            }

            string msgConfirm = Resources.Res.JE_ABOUT_CONTACT_US;
                
            //確認            
            //DialogResult dr = RabbitCouriers.SentNormalQuestionByResource("JE_RUN_RESET_VALUE_M_1", Res.JE_BTN_RESET_VALUE, Var.SelectedColumn.Name);
            //if (dr != DialogResult.OK)
            //    return;
            //
            DialogResult = DialogResult.OK;
        }
    }
}
