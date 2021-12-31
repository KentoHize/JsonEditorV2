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
                Left = pnlSortMain.Width / 2 - 100,
                Width = 200,
                Height = 30,
                Top = i * 30 + 7,
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
            //確認重複欄位
            HashSet<JColumn> columnSet = new HashSet<JColumn>();            
            for(int i = 0; i < SLControlList.Count; i++)
            {
                if (!columnSet.Add(SLControlList[i].ColumnComboBox.SelectedItem as JColumn))
                {   
                    RabbitCouriers.SentErrorMessageByResource("JE_VAL_SORT_DUPLICATE_COLUMN",
                        Res.JE_TMI_EDIT_SORT_INFO, $"\n{(SLControlList[i].ColumnComboBox.SelectedItem as JColumn).Name}");
                    return;
                }   
            }

            //確認執行
            StringBuilder msg = new StringBuilder();            
            msg.AppendLine();
            for (int i = 0; i < SLControlList.Count; i++)
                msg.AppendFormat("{0}, {1}\n", (SLControlList[i].ColumnComboBox.SelectedItem as JColumn).Name, SLControlList[i].DesendingComboBox.SelectedItem);

            DialogResult dr = RabbitCouriers.SentNormalQuestionByResource("JE_RUN_SORT_M_1", Res.JE_TMI_EDIT_SORT_INFO, msg.ToString());
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
