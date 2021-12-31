using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonEditor;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public class SortListInputControlSet
    {
        public ComboBox ColumnComboBox { get; set; }
        public ComboBox DesendingComboBox { get; set; }
        public Button DeleteButton { get; set; }        
        public JTable ParentTable { get; set; }

        private frmSortList ownerWindow;
        public SortListInputControlSet(JTable parentTable, SortInfo sortInfo)
        {
            ParentTable = parentTable ?? throw new ArgumentNullException(nameof(parentTable));

            ColumnComboBox = new ComboBox
            {
                Left = 10,
                Width = 320,
                Height = 30,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            for (int i = 0; i < ParentTable.Columns.Count; i++)
                ColumnComboBox.Items.Add(ParentTable.Columns[i]);
            ColumnComboBox.ValueMember = "Name";
            ColumnComboBox.SelectedIndex = 0;            

            DesendingComboBox = new ComboBox
            {
                Left = 340,
                Width = 120,
                Height = 30,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            DesendingComboBox.Items.Add(Resources.Res.JE_COB_SORT_ASCENDING);
            DesendingComboBox.Items.Add(Resources.Res.JE_COB_SORT_DESCENDING);
            DesendingComboBox.SelectedIndex = 0;

            DeleteButton = new Button
            {
                Left = 470,
                Width = 80,
                Height = 30,
                Text = Resources.Res.JE_BTN_DELETE,                
            };
            DeleteButton.Click += DeleteButton_Click;

            if (sortInfo != null)
            {
                ColumnComboBox.SelectedItem = sortInfo.Column;
                DesendingComboBox.SelectedIndex = sortInfo.Descending ? 1 : 0;
            }   
        }

        public SortListInputControlSet(JTable parentTable)
            : this(parentTable, null)
        { }


        public void DrawControl(Panel pnlSortMain, int index)
        {
            ownerWindow = pnlSortMain.Parent as frmSortList;

            ColumnComboBox.Font = DesendingComboBox.Font =
            DeleteButton.Font = pnlSortMain.Font;
            ColumnComboBox.Top = DesendingComboBox.Top = 30 * index + 3;
            DeleteButton.Top = 30 * index;
            DeleteButton.Tag = index;

            pnlSortMain.Controls.Add(ColumnComboBox);
            pnlSortMain.Controls.Add(DesendingComboBox);
            pnlSortMain.Controls.Add(DeleteButton);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ownerWindow.DeleteSLI((Convert.ToInt16(((Button)sender).Tag)));
        }
    }
}
