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

namespace JsonEditorV2.Tests
{
    [TestClass]
    public class MainFormTests
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            AdventurerAssociation.RegisterMembers();
        }

        [TestMethod]
        public void tmiLoadJsonFiles_ClickTest()
        {
            MainForm mf = new MainForm();

            AdventurerAssociation.RegisterMember(new Bard("SelectedPath", @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\Test2"));
            AdventurerAssociation.RegisterMember(new Courier(InputResponseOptions.Cancel));
            mf.tmiLoadJsonFiles_Click(mf, new EventArgs());
            AdventurerAssociation.PrintMessageFromBard(TestContext);
            AdventurerAssociation.PrintMessageFromCourier(TestContext);

        }
    }
}