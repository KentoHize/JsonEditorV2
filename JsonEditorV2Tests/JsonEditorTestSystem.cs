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

        //In Form Variable
        public string InputText { get; set; }
        public string CurrentFileName { get; set; }
        public string CurrentColumnName { get; set; }
        public int SelectedLineIndex { get; set; }

        private EventArgs ea = new EventArgs();

        public JsonEditorTestSystem()
        {
            FileStream fs = new FileStream(OutputOverview, FileMode.Create);
            AdventurerAssociation.RegisterMembers(fs);
            AdventurerAssociation.Form_Start += AdventurerAssociation_Form_Start;
            MainForm = new MainForm();
            MainForm.StartPosition = FormStartPosition.Manual;
            MainForm.Left = 30000;
            MainForm.Top = 30000;
            MainForm.Shown += MainForm_Shown;
            TestThread = new Task(() => Application.Run(MainForm));
            TestThread.Start();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            MainForm.Visible = false;
            FormReady = true;
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

        public void OpenJsonFile(string fileName)
        {   
            ClickOnTreeView(MouseButtons.Right, fileName);

            DoEventsUntilFormReadyAndResetFormReady();

            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try { MainForm.tmiOpenJsonFile_Click(MainForm, ea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void UpdateMainValue()
        {
            DoEventsUntilFormReadyAndResetFormReady();

            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try { MainForm.btnUpdateMain_Click(MainForm, ea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public Control SelectColumnPanelValueControl(ColumnAttributeNames attributeName)
        {
            Control valueControl = MainForm.Controls.Find("pnlFileInfo", false)[0].Controls.Find(TestConst.ColumnAttributesInfo[attributeName].ValueControlName, false)[0];

            DoEventsUntilFormReadyAndResetFormReady();            
            
            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                { valueControl.Focus();
                  valueControl.Select(); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
            return valueControl;
        }

        public void ChangeColumnPanelControlValue(ColumnAttributeNames attributeName, object value)
        {
            Control valueControl = SelectColumnPanelValueControl(attributeName);

            DoEventsUntilFormReadyAndResetFormReady();
            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    if (valueControl is TextBox)
                        valueControl.Text = value.ToString();
                    else if (valueControl is CheckBox)
                        ((CheckBox)valueControl).Checked = (bool)value;
                    else
                        ((ComboBox)valueControl).SelectedItem = value;
                }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        //public void SetCurrentLineValue(string columnName, object value)
        //{
        //    if (CurrentFileName != fileName || CurrentColumnName != columnName)
        //        ClickOnTreeView(fileName, columnName);

        //    ChangeColumnPanelControlValue(attributeName, value);
        //}

        public void SetColumnAttribute(string fileName, string columnName, ColumnAttributeNames attributeName, object value)
        {
            if (CurrentFileName != fileName || CurrentColumnName != columnName)
                ClickOnTreeView(fileName, columnName);

            ChangeColumnPanelControlValue(attributeName, value);
        }

        public void ChangeMainPanelValueControlValue(string columnName, object value)
        {
            Control valueControl = SelectMainPanelValueControl(columnName);

            DoEventsUntilFormReadyAndResetFormReady();
            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    if (valueControl is TextBox)
                        valueControl.Text = value.ToString();
                    else if (valueControl is CheckBox)
                        ((CheckBox)valueControl).Checked = (bool)value;
                    else
                        ((ComboBox)valueControl).SelectedItem = value;
                }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public Control SelectMainPanelValueControl(string columnName)
        {
            Control[] ctls;
            ctls = MainForm.Controls.Find("pnlMain", false)[0].Controls.Find($"txt{columnName}", false);
            if(ctls.Length == 0)
            {
                ctls = MainForm.Controls.Find("pnlMain", false)[0].Controls.Find($"ckb{columnName}", false);
                if (ctls.Length == 0)
                    ctls = MainForm.Controls.Find("pnlMain", false)[0].Controls.Find($"cob{columnName}", false);
            }
            if (ctls.Length == 0)
                throw new ArgumentException();

            Control valueControl = ctls[0];

            DoEventsUntilFormReadyAndResetFormReady();

            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    valueControl.Focus();
                    valueControl.Select();
                }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
            return valueControl;
        }

        public void SelectLine(int index)
        {
            if (SelectedLineIndex == index)
                return;

            DoEventsUntilFormReadyAndResetFormReady();

            ListBox lsb = MainForm.Controls.Find("lsbLines", false)[0] as ListBox;
            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                { lsb.SelectedIndex = index; }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void NewLine()
        {
            DoEventsUntilFormReadyAndResetFormReady();

            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                { MainForm.btnNewLine_Click(MainForm, ea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void CloseJsonFiles(ResponseOptions saveFile = ResponseOptions.Yes)
        {
            DoEventsUntilFormReadyAndResetFormReady();

            Courier courier = new Courier(saveFile, "JE_RUN_SAVE_FILES_CHECK");
            AdventurerAssociation.RegisterMember(courier);
            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                { MainForm.tmiCloseAllFiles_Click(MainForm, ea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void UpdateCurrentColumn()
        {
            DoEventsUntilFormReadyAndResetFormReady();

            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                { MainForm.btnUpdateColumn_Click(MainForm, ea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void ClickOnTreeView(string fileName = "", string columnName = "")
            => ClickOnTreeView(MouseButtons.Left, fileName, columnName);

        public void ClickOnTreeView(MouseButtons button ,string fileName = "", string columnName = "")
        {   
            DoEventsUntilFormReadyAndResetFormReady();

            TreeNodeMouseClickEventArgs tea = null;
            TreeNode[] trs;

            if(string.IsNullOrEmpty(fileName))
                tea = new TreeNodeMouseClickEventArgs(Var.RootNode, button, 1, 0, 0);
            else if(string.IsNullOrEmpty(columnName))
            {
                trs = Var.RootNode.Nodes.Find(fileName, false);
                if (trs.Length != 0)
                    tea = new TreeNodeMouseClickEventArgs(trs[0], button, 1, 0, 0);
            }
            else
            {
                trs = Var.RootNode.Nodes.Find(fileName, false);
                if (trs.Length != 0)
                {
                    trs = trs[0].Nodes.Find(columnName, false);
                    if (trs.Length != 0)
                        tea = new TreeNodeMouseClickEventArgs(trs[0], button, 1, 0, 0);
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

            CurrentFileName = fileName;
            CurrentColumnName = columnName;

            EndInvokeAndThrowException(ar);
        }

        public void AddColumn(string filename, string columnName)
        {            
            ClickOnTreeView(MouseButtons.Right, filename);

            DoEventsUntilFormReadyAndResetFormReady();

            InputText = columnName;
            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {
                try
                { MainForm.tmiAddColumn_Click(MainForm, ea); }
                catch (Exception ex)
                { Exception = ex; }
            });

            EndInvokeAndThrowException(ar);
        }

        public void NewJsonFile(string fileName)
        {
            ClickOnTreeView(MouseButtons.Right);

            DoEventsUntilFormReadyAndResetFormReady();

            InputText = fileName;
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

        public void Exit(ResponseOptions saveFile = ResponseOptions.Yes)
        {
            DoEventsUntilFormReadyAndResetFormReady();

            Courier courier = new Courier(saveFile, "JE_RUN_SAVE_FILES_CHECK");
            AdventurerAssociation.RegisterMember(courier);
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
