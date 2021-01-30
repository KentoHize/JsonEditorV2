using Aritiafel.Characters;
using Aritiafel.Organizations;
using JsonEditorV2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditorV2Tests
{
    public class JsonEditorTestSystem
    {
        public const string OutputFolder = @"C:\Programs\Reports\Json Editor V2";
        public const string OutputOverview = @"C:\Programs\Reports\Json Editor V2\Overview.txt";

        public Task TestThread { get; set; }
        public Exception Exception { get; set; }

        public MainForm MainForm { get; set; }
        public bool FormReady { get; set; }

        public string InputText { get; set; }

        private EventArgs ea = new EventArgs();

        public JsonEditorTestSystem()
        {
            FileStream fs = new FileStream(OutputOverview, FileMode.Create);
            AdventurerAssociation.RegisterMembers(fs);
            AdventurerAssociation.Form_Start += AdventurerAssociation_Form_Start;
            MainForm = new MainForm();
            MainForm.Activated += MainForm_Activated;
            TestThread = new Task(() => Application.Run(MainForm));
            TestThread.Start();
        }

        private void DoEventsUntilFormReadyAndResetFormReady()
        {
            while (!FormReady)
                Application.DoEvents();

            AdventurerAssociation.RegisterMember(new Bard());
            AdventurerAssociation.RegisterMember(new Courier());
            FormReady = false;
        }

        private void EndInvokeAndThrowException(IAsyncResult ar)
        {
            while (!ar.IsCompleted)
                Application.DoEvents();

            MainForm.EndInvoke(ar);

            if (Exception != null)
                ExceptionDispatchInfo.Capture(Exception).Throw();

            FormReady = true;
        }

        private DialogResult AdventurerAssociation_Form_Start(Form newForm)
        {
            if (newForm is frmInputBox)
            {
                frmInputBox frmInputBox = newForm as frmInputBox;

                switch (frmInputBox.InputBoxType)
                {
                    case InputBoxTypes.NewFile:
                    case InputBoxTypes.RenameFile:
                    case InputBoxTypes.AddColumn:
                    case InputBoxTypes.RenameColumn:
                        //輸入值                        
                        (frmInputBox.Controls.Find("txtInput", false)[0] as TextBox).Text = InputText;
                        //按下OK                        
                        frmInputBox.btnConfirm_Click(frmInputBox, new EventArgs());
                        break;

                    default:
                        break;
                }
            }
            return newForm.DialogResult;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            MainForm.Visible = false;
            FormReady = true;
        }

        public void RightClickOnTreeView(string fileName = "", string columnName = "")
        {
            DoEventsUntilFormReadyAndResetFormReady();

            TreeNodeMouseClickEventArgs tea = null;
            TreeNode[] trs;

            if(string.IsNullOrEmpty(fileName))
                tea = new TreeNodeMouseClickEventArgs(Var.RootNode, MouseButtons.Right, 1, 0, 0);
            else if(string.IsNullOrEmpty(columnName))
            {
                trs = Var.RootNode.Nodes.Find(fileName, false);
                if (trs.Length != 0)
                    tea = new TreeNodeMouseClickEventArgs(trs[0], MouseButtons.Right, 1, 0, 0);
            }
            else
            {
                trs = Var.RootNode.Nodes.Find(fileName, false);
                if (trs.Length != 0)
                {
                    trs = trs[0].Nodes.Find(columnName, false);
                    if (trs.Length != 0)
                        tea = new TreeNodeMouseClickEventArgs(trs[0], MouseButtons.Right, 1, 0, 0);
                }   
            }

            if (tea == null)
                throw new ArgumentOutOfRangeException("TreeNode");

            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                { MainForm.trvJsonFiles_NodeMouseClick(MainForm, tea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void NewJsonFile(string fileName)
        {   
            InputText = fileName;
            RightClickOnTreeView();

            DoEventsUntilFormReadyAndResetFormReady();

            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                { MainForm.tmiNewJsonFile_Click(MainForm, ea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void SaveJsonFiles()
        {
            DoEventsUntilFormReadyAndResetFormReady();

            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                { MainForm.tmiSaveJsonFiles_Click(MainForm, ea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void Exit()
        {
            DoEventsUntilFormReadyAndResetFormReady();

            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                { MainForm.tmiExit_Click(MainForm, ea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void NewJsonFiles(string targetPath, ResponseOptions deleteFile = ResponseOptions.Yes)
        {
            DoEventsUntilFormReadyAndResetFormReady();

            Courier courier = new Courier(deleteFile, "JE_RUN_NEW_JSON_FILES_Q_1");
            Bard bard = new Bard("SelectedPath", targetPath);
            bard.InputInformation.Add("DialogResult", ResponseOptions.OK);
            AdventurerAssociation.RegisterMember(bard);
            AdventurerAssociation.RegisterMember(courier);
            
            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {   
                try
                { MainForm.tmiNewJsonFiles_Click(MainForm, ea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void PrintMessage(TestContext testContext)
        {
            while (!FormReady)
                Application.DoEvents();
            AdventurerAssociation.PrintMessageFromArchivist(testContext);
        }

        ~JsonEditorTestSystem()
        {
            AdventurerAssociation.Archivist.Stream.Close();
            TestThread.Dispose();
        }
    }
}
