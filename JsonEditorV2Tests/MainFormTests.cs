using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonEditorV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aritiafel.Organizations;
using Aritiafel.Characters;
using System.Windows.Forms;
using System.IO;

namespace JsonEditorV2.Tests
{
    [TestClass]
    public class MainFormTests
    {
        public TestContext TestContext { get; set; }

        static FileStream fs;

        [TestInitialize]
        public void TestInitialize()
        {
            if(!AdventurerAssociation.Registered)
            {
                fs = new FileStream(@"C:\Programs\TestArea\Output_Test.txt", FileMode.Create);
                AdventurerAssociation.RegisterMembers(fs);
                AdventurerAssociation.Form_Start += AdventurerAssociation_Form_Start;
            }
        }

        private DialogResult AdventurerAssociation_Form_Start(Form newForm)
        {
            return newForm.DialogResult;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            fs.Close();
        }

        [TestMethod]
        public void tmiLoadJsonFiles_ClickTest()
        {
            MainForm mf = new MainForm();
            Bard bard = new Bard();
            bard.InputInformation.Add("FolderBrowserDialog.SelectedPath", @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\Test2");
            bard.InputInformation.Add("FolderBrowserDialog.DialogResult", DialogResult.Cancel);
            
            AdventurerAssociation.RegisterMember(bard);
            //AdventurerAssociation.RegisterMember(new Courier(InputResponseOptions.Cancel));
            mf.tmiLoadJsonFiles_Click(mf, new EventArgs());            
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);
        }

        [TestMethod]
        public void tmiLoadJsonFiles_ClickTest2()
        {
            MainForm mf = new MainForm();
            Bard bard = new Bard();
            bard.InputInformation.Add("SelectedPath", @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\Test5");
            bard.InputInformation.Add("DialogResult", DialogResult.OK);
            AdventurerAssociation.RegisterMember(bard);
            //AdventurerAssociation.RegisterMember(new Courier(InputResponseOptions.Cancel));
            mf.tmiLoadJsonFiles_Click(mf, new EventArgs());
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);
        }
    }
}