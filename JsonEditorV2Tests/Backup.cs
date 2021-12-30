using System;
using Aritiafel.Characters.Heroes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonEditorV2Tests
{
    [TestClass]
    public class Backup
    {

        [TestMethod]
        public void BackupProject()
        {
            Tina.SaveProject(ProjectChoice.JsonEditorV2);
        }
       
    }
}