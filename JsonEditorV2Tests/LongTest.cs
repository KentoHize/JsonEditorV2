using Aritiafel.Characters;
using Aritiafel.Organizations;
using JsonEditor;
using JsonEditorV2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace JsonEditorV2Tests
{
    [TestClass]
    public class LongTest
    {
        public TestContext TestContext { get; set; }

        public JsonEditorTestSystem JETS { get; set; }

        [TestMethod]
        public void SystemTest()
        {
            JETS = new JsonEditorTestSystem();
            JETS.SetNewCulture("zh-TW");
            JETS.NewJsonFiles(@"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\AutoTest");
            JETS.NewJsonFile("A");
            JETS.AddColumn("A", "DDD");
            JETS.SetColumnAttribute("A", "DDD", ColumnAttributeNames.ColumnDisplay, true);
            JETS.SetColumnAttribute("A", "DDD", ColumnAttributeNames.ColumnType, JType.Integer);
            JETS.UpdateCurrentColumn();
            JETS.AddColumn("A", "BB");
            JETS.SetColumnAttribute("A", "BB", ColumnAttributeNames.ColumnType, JType.Guid);
            JETS.UpdateCurrentColumn();
            JETS.OpenJsonFile("A");
            for (int i = 0; i < 100; i++)
            {
                JETS.NewLine();
                //JETS.SelectLine(i);
                JETS.ChangeMainPanelValueControlValue("DDD", i);
                //JETS.ClearMainPanel();
                JETS.ClickMainPanelNewButton("BB");
                JETS.UpdateMainValue();
                //JETS.SelectLine(i * 2 + 1);
                //JETS.ChangeMainPanelValueControlValue("DDD", i - 5);
                //JETS.UpdateMainValue();
            }
            JETS.SaveJsonFiles();
            JETS.CloseJsonFiles();
            JETS.Exit();

            JETS.PrintMessage(TestContext);

            //Process.Start(@"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\AutoTest");            
            Process.Start("notepad.exe", @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\AutoTest\A.json");
        }

        [TestMethod]
        public void LoadJFITest()
        {
            string JFITestFolder = @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestData\Bad JFI File";
            JETS = new JsonEditorTestSystem();

            string[] dirs = Directory.GetDirectories(JFITestFolder);
            foreach (string dir in dirs)
            {
                try
                {
                    JETS.LoadJsonFiles(dir);
                }
                catch
                {
                    MessageBox.Show(dir);
                }
            }
            JETS.Exit();

            Process.Start(@"C:\Programs\Reports\Json Editor V2\Overview.txt");
        }
    }
}
