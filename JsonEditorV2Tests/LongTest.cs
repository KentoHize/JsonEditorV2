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
using JsonEditorV2.Resources;

namespace JsonEditorV2Tests
{
    [TestClass]
    public class LongTest
    {
        public TestContext TestContext { get; set; }

        public string InputText { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            if(!AdventurerAssociation.Registered)
            { 
                AdventurerAssociation.RegisterMembers();
                AdventurerAssociation.Form_Start += AdventurerAssociation_Form_Start;
                //RabbitCouriers.RegisterRMAndCI(Res.ResourceManager, new )
            }
        }

        private DialogResult AdventurerAssociation_Form_Start(Form newForm)
        {
            if(newForm is frmInputBox)
            {   
                frmInputBox frmInputBox = newForm as frmInputBox;
                
                switch(frmInputBox.InputBoxType)
                {
                    case InputBoxTypes.NewFile:
                    case InputBoxTypes.RenameFile:
                    case InputBoxTypes.AddColumn:
                    case InputBoxTypes.RenameColumn:
                        //輸入值
                        string input = InputText;
                        TestContext.WriteLine($"Text = {input}");
                        (frmInputBox.Controls.Find("txtInput", false)[0] as TextBox).Text = input;
                        //按下OK
                        TestContext.WriteLine($"Confirm Button Clicked");
                        frmInputBox.btnConfirm_Click(frmInputBox, new EventArgs());
                        break;                    
                       
                    default:
                        break;
                }
                
                
            }
            return newForm.DialogResult;
        }

        [TestMethod]
        public void LongTest1()
        {
            MainForm mf = new MainForm();

            EventArgs e = new EventArgs();
            ApplicationContext ac = new ApplicationContext(mf);
            
            //Form_Load
            //mf.MainForm_Load(mf, e);

            //開新檔案庫
            AdventurerAssociation.RegisterMember(new Bard("SelectedPath", @"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\Test6"));
            mf.tmiNewJsonFiles_Click(mf, e);
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);

            //建立三個檔案
            InputText = "SetA";
            mf.tmiNewJsonFile_Click(mf, e);            
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);


            InputText = "SetB";
            mf.tmiNewJsonFile_Click(mf, e);
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);


            InputText = "SetC";
            mf.tmiNewJsonFile_Click(mf, e);
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);

            //Click Node
            TreeView tv = mf.Controls.Find("trvJsonFiles", false)[0] as TreeView;
            TreeNodeMouseClickEventArgs tnmc = new TreeNodeMouseClickEventArgs(tv.Nodes[0].Nodes[0], MouseButtons.Right, 1, 0, 0);
            mf.trvJsonFiles_NodeMouseClick(mf, tnmc);

            /*
            //Delete File
            mf.tmiDeleteJsonFile_Click(mf, e);
            */
            //Rename
            InputText = "SetA1";
            mf.tmiRenameJsonFile_Click(mf, e);

            //Add Column
            InputText = "AAAA_2";
            mf.tmiAddColumn_Click(mf, e);

            //Select Column


            //存檔
            //AdventurerAssociation.RegisterMember(new Bard("SelectedPath", ""))
            mf.tmiSaveJsonFiles_Click(mf, e);

            //關閉
            mf.tmiCloseAllFiles_Click(mf, e);
            AdventurerAssociation.PrintMessageFromArchivist(TestContext);
            ac.Dispose();
        }
    }
}
