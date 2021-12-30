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
        public SortListInputControlSet(JTable parentTable)
        {
            ParentTable = parentTable ?? throw new ArgumentNullException(nameof(parentTable));
        }

        public ComboBox ColumnComboBox { get; set; }
        public ComboBox DesendingComboBox { get; set; }
        public Button DeleteButton { get; set; }
        //public JColumn JColumn { get; set; }
        public JTable ParentTable { get; set; }

        private frmSortList ownerWindow;

        public void DrawControl(Panel pnlSortMain, int index)
        {
            ownerWindow = pnlSortMain.Parent as frmSortList;
            if (ColumnComboBox == null)
            {
                ColumnComboBox = new ComboBox
                {
                    //Name = $"cobColumn{index}",
                    Left = 10,
                    Width = 300,
                    Height = 20,
                    Font = pnlSortMain.Font
                };

                for (int i = 0; i < ParentTable.Columns.Count; i++)
                    ColumnComboBox.Items.Add(ParentTable.Columns[i]);
                ColumnComboBox.ValueMember = "Name";
                ColumnComboBox.SelectedIndex = 0;

                DesendingComboBox = new ComboBox
                {
                    //Name = $"cobDesnding{index}",
                    Left = 320,
                    Width = 100,
                    Height = 20,
                    Font = pnlSortMain.Font
                };

                DesendingComboBox.Items.Add("Ascsending");
                DesendingComboBox.Items.Add("Desending");
                DesendingComboBox.SelectedIndex = 0;

                DeleteButton = new Button
                {
                    //Name = $"btnDelete{index}",
                    Left = 430,
                    Width = 50,
                    Height = 20,                    
                    Font = pnlSortMain.Font
                };

                DeleteButton.Click += DeleteButton_Click;
            }
            ColumnComboBox.Top = DesendingComboBox.Top =
            DeleteButton.Top = 30 * index + 5;
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
