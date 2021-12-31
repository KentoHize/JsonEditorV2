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
using JsonEditorV2.Resources;

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

            btnConfirm.Text = Res.JE_BTN_CONFIRM;
            btnCancel.Text = Res.JE_BTN_CANCEL;            
            Text = Res.JE_TMI_EDIT_SORT_INFO;
        }

        public static List<SortInfo> Show(IWin32Window owner, JTable table)
        {
            frmSortList frmSortList = new frmSortList(table);
            //frmInputBox.txtInput.Text = defaultText;
            frmSortList.LoadSortInfoList();            
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
                Text = Res.JE_BTN_NEW_SORT_INFO
            };

            btnNewSLI.Click += BtnNewSLI_Click;
            pnlSortMain.Controls.Add(btnNewSLI);
        }

        private void BtnNewSLI_Click(object sender, EventArgs e)
        {
            AddNewSLI();
            RefreshPnlSortMain();
        }

        private void LoadSortInfoList()
        {
            SLControlList = new List<SortListInputControlSet>();
            if (Table.SortInfoList == null)
                AddNewSLI();
            else
                for(int i = 0; i < Table.SortInfoList.Count; i++)
                    SLControlList.Add(new SortListInputControlSet(Table, Table.SortInfoList[i]));                        
            RefreshPnlSortMain();
        }

        private void AddNewSLI()
        {   
            SLControlList.Add(new SortListInputControlSet(Table));
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
            StringBuilder msgConfirm = new StringBuilder();
            msgConfirm.AppendLine();
            for (int i = 0; i < SLControlList.Count; i++)
                msgConfirm.AppendFormat("{0}, {1}\n", (SLControlList[i].ColumnComboBox.SelectedItem as JColumn).Name, SLControlList[i].DesendingComboBox.SelectedItem);

            DialogResult dr = RabbitCouriers.SentNormalQuestionByResource("JE_RUN_SORT_M_1", Resources.Res.JE_TMI_EDIT_SORT_INFO, msgConfirm.ToString());
            if (dr != DialogResult.OK)
                return;

            ReturnValue = new List<SortInfo>();
            for(int i = 0; i < SLControlList.Count; i++)
            {
                SortInfo slv = new SortInfo(
                    SLControlList[i].ColumnComboBox.SelectedItem as JColumn,
                    SLControlList[i].DesendingComboBox.SelectedIndex == 1);
                ReturnValue.Add(slv);
            }            
            DialogResult = DialogResult.OK;
        }
    }
}
