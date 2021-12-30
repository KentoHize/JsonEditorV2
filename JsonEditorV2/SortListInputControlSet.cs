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
        //public JColumn JColumn { get; set; }
        public JTable ParentTable { get; set; }

        public void DrawControl(Panel pnlSortMain, int lineIndex)
        {

        }
    }
}
