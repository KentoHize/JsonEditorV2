using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aritiafel.Organizations;
using Aritiafel.Characters;
using System.Windows.Forms;
using JsonEditorV2;

namespace JsonEditorV2Tests
{
    [TestClass]
    public class LongTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            AdventurerAssociation.RegisterMembers();
        }

        [TestMethod]
        public void LongTest1()
        {
            MainForm mf = new MainForm();

            //開新檔案庫
            AdventurerAssociation.RegisterMember(new Bard("SelectedPath", @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\Test6"));
            mf.tmiNewJsonFiles_Click(mf, new EventArgs());
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);


            //建立三個檔案            
            mf.tmiNewJsonFile_Click(mf, new EventArgs());

            mf.
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);
        }
    }
}
