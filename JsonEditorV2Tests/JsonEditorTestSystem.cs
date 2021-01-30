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
        private EventArgs eventArgs = new EventArgs();

        public bool FormReady { get; set; }

        public JsonEditorTestSystem()
        {
            FileStream fs = new FileStream(OutputOverview, FileMode.Create);
            AdventurerAssociation.RegisterMembers(fs);
            MainForm = new MainForm();
            MainForm.Activated += MainForm_Activated;
            TestThread = new Task(() => Application.Run(MainForm));
            TestThread.Start();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            MainForm.Visible = false;
            FormReady = true;
        }

        public void NewJsonFiles(string targetPath, DialogResult deleteFile = DialogResult.OK)
        {
            while (!FormReady)
                Application.DoEvents();

            Courier courier = new Courier(ResponseOptions.OK, "JE_RUN_NEW_JSON_FILES_Q_1");
            Bard bard = new Bard("SelectedPath", targetPath);
            bard.InputInformation.Add("DialogResult", deleteFile);            
            AdventurerAssociation.RegisterMember(bard);
            AdventurerAssociation.RegisterMember(courier);

            FormReady = false;

            IAsyncResult ar = MainForm.BeginInvoke((MethodInvoker)delegate
            {   
                try
                { MainForm.tmiNewJsonFiles_Click(MainForm, eventArgs); }
                catch (Exception ex)
                { Exception = ex; }
            });

            while (!ar.IsCompleted)
                Application.DoEvents();

            var o = MainForm.EndInvoke(ar);

            if (Exception != null)
                ExceptionDispatchInfo.Capture(Exception).Throw();
                
            FormReady = true;
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
