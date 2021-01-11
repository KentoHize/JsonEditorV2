using JsonEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public static class Var
    {
        public static List<JTable> Tables { get; set; }

        public static int PageIndex { get; set; }
        public static List<JTable> OpenedTable { get; set; }
        public static JTable SelectedTable { get { return OpenedTable[PageIndex]; } }

        public static JTable SelectedColumnParentTable { get; set; }
        public static JColumn SelectedColumn { get; set; }        
        
        public static List<JLine> Lines { get; set; }
        public static JLine SelectedLine { get { return Lines[PageIndex]; } }

        public static JFilesInfo JFI { get; set; }
        public static TreeNode RootNode { get; set; }
        public static bool DblClick { get; set; }

        public static ResourceManager RM { get; set; }
        public static CultureInfo CI { get; set; }
    }
}
