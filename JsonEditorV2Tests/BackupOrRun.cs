using System;
using Aritiafel.Characters.Heroes;
using Aritiafel.Locations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonEditorV2Tests
{
    [TestClass]
    public class BackupOrRun
    {

        [TestMethod]
        public void BackupProject()
        {
            Tina.SaveProject(ProjectChoice.JsonEditorV2);
        }

        [TestMethod]

        public void ResetIniFile()
        {
            //SettingShop.ResetIniFile();
        }
    }
}