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

        public string FileName { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            AdventurerAssociation.RegisterMembers();
            AdventurerAssociation.Form_Start += AdventurerAssociation_Form_Start;
        }

        private DialogResult AdventurerAssociation_Form_Start(Form newForm)
        {
            if(newForm is frmInputBox)
            {   
                frmInputBox frmInputBox = newForm as frmInputBox;
                //輸入值
                string input = FileName;
                TestContext.WriteLine($"Text = {input}");
                (frmInputBox.Controls.Find("txtInput", false)[0] as TextBox).Text = input;
                //按下OK
                TestContext.WriteLine($"Confirm Button Clicked");
                frmInputBox.btnConfirm_Click(frmInputBox, new EventArgs());
            }
            return newForm.DialogResult;
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
            FileName = "SetA";
            mf.tmiNewJsonFile_Click(mf, new EventArgs());            
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);


            FileName = "SetB";
            mf.tmiNewJsonFile_Click(mf, new EventArgs());
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);


            FileName = "SetC";
            mf.tmiNewJsonFile_Click(mf, new EventArgs());
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);
        }
    }
}
