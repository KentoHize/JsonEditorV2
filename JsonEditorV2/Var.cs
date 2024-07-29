﻿using JsonEditor;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static bool LockCobCheckMethod { get; set; } //鎖定控制項不更新
        public static bool CheckFailedFlag { get; set; } //存檔失敗Flag
        public static bool NotOnlyClose { get; set; } //非單純關閉檔案Flag
        public static bool AutoFlag { get; set; } //自動執行Flag
        public static string DirectLoadFolder { get; set; } //直接讀取資料庫
        public static List<string> RenamedFiles { get; set; } = new List<string>(); //被改名檔案
        public static List<string> DeleteFiles { get; set; } = new List<string>(); //被刪除檔案
        public static DataTable PrintTable { get; set; } //待列印字串
        public static List<int> PrintFittedList { get; set; } = new List<int>(); //已印多少字
        public static int PrintLineIndex { get; set; } //列印中的索引
        public static int PrintPageIndex { get; set; } //列印中的頁數
        public static List<JTable> OpenedTable { get; set; } = new List<JTable>();
        public static JTable SelectedTable { get { if (OpenedTable == null || OpenedTable.Count == 0) return null; return OpenedTable[PageIndex]; } }
        public static JLine SelectedLine { get => SelectedTable[SelectedLineIndex]; }
        public static int SelectedLineIndex { get => LineIndexes[PageIndex]; set => LineIndexes[PageIndex] = value; }

        public static JTable SelectedColumnParentTable { get; set; }
        public static JColumn SelectedColumn { get; set; }
        public static int SelectedColumnIndex { get => SelectedColumnParentTable.Columns.IndexOf(SelectedColumn); }

        public static List<InputControlSet> InputControlSets { get; set; } = new List<InputControlSet>();
        public static TextBox BindingTextbox { get; set; }

        public static TreeNode RootNode { get; set; }
        public static bool DblClick { get; set; }

        //To Do
        public static bool Locked { get; set; }

        public static bool Changed { get { if (Database.Tables == null || Database.JFI == null) return false; return Database.Tables.Exists(m => m.Changed) || Database.JFI.Changed; } }

        public static string PreloadDatabase { get; set; }
    }
}
