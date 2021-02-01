using JsonEditor;
using System;
using System.Collections.Generic;
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
        public static JDatabase Database { get; set; }
        public static List<JTable> Tables { get => Database.Tables; set => Database.Tables = value; }
        public static JFilesInfo JFI { get => Database.JFI; set => Database.JFI = value; }

        public static int PageIndex { get; set; }
        public static List<int> LineIndexes { get; set; } = new List<int>();

        public static int ClickedTabIndex { get; set; } //按下的TabIndex
        public static bool LockDgvLines { get; set; } //鎖定控制項不更新
        public static bool LockPnlMain { get; set; } //鎖定控制項不更新
        public static bool LockDgvMain { get; set; }  //鎖定控制項不更新
        public static bool CheckFailedFlag { get; set; } //存檔失敗Flag        
        public static bool NotOnlyClose { get; set; } //非單純關閉檔案Flag
        public static int ContinuousFindTimes { get; set; } //連續按下尋找鍵的次數

        public static List<JTable> OpenedTable { get; set; } = new List<JTable>();
        public static JTable SelectedTable { get { if (OpenedTable == null || OpenedTable.Count == 0) return null; return OpenedTable[PageIndex]; } }
        public static JLine SelectedLine { get => SelectedTable[SelectedLineIndex]; }
        public static int SelectedLineIndex { get => LineIndexes[PageIndex]; set => LineIndexes[PageIndex] = value; }

        public static JTable SelectedColumnParentTable { get; set; }
        public static JColumn SelectedColumn { get; set; }
        public static int SelectedColumnIndex { get => SelectedColumnParentTable.Columns.IndexOf(SelectedColumn); }        

        public static List<InputControlSet> InputControlSets { get; set; } = new List<InputControlSet>();       

        
        public static TreeNode RootNode { get; set; }
        public static bool DblClick { get; set; }

        //To Do
        public static bool Locked { get; set; }

        public static bool Changed { get { if ( Database.Tables == null || Database.JFI == null) return false; return Database.Tables.Exists(m => m.Changed) || Database.JFI.Changed; } }
    }
}
