using JsonEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public static class Var
    {
        public static List<JTable> Tables { get; set; } = new List<JTable>();

        public static int PageIndex { get; set; }
        public static List<int> LineIndexes { get; set; } = new List<int>();

        public static int ClickedTabIndex { get; set; }
        public static bool CheckFailedFlag { get; set; }

        public static List<JTable> OpenedTable { get; set; } = new List<JTable>();
        public static JTable SelectedTable { get { if (OpenedTable == null || OpenedTable.Count == 0) return null; return OpenedTable[PageIndex]; } }
        public static JLine SelectedLine { get => SelectedTable[SelectedLineIndex]; }
        public static int SelectedLineIndex { get => LineIndexes[PageIndex]; set => LineIndexes[PageIndex] = value; }

        public static JTable SelectedColumnParentTable { get; set; }
        public static JColumn SelectedColumn { get; set; }
        public static int SelectedColumnIndex { get => SelectedColumnParentTable.Columns.IndexOf(SelectedColumn); }
        

        public static List<InputControlSet> InputControlSets { get; set; } = new List<InputControlSet>();       

        public static JFilesInfo JFI { get; set; }
        public static TreeNode RootNode { get; set; }
        public static bool DblClick { get; set; }

        public static bool Changed { get { if (Tables == null || JFI == null) return false; return Tables.Exists(m => m.Changed) || JFI.Changed; } }

        public static CultureInfo CI { get; set; }
    }
}
