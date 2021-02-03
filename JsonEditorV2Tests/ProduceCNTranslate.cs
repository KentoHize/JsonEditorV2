using System;
using Aritiafel.Organizations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonEditorV2Tests
{
    [TestClass]
    public class ProduceCNTranslate
    {

        [TestMethod]
        public void ProduceSimplifiedChineseResourceFile()
        {
            WizardGuild.ProduceSimplifiedChineseResourceFile(@"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\Resources\Res.resx");

            //JETS = new JsonEditorTestSystem();
            //JETS.NewJsonFiles(@"C:\Programs\WinForm\JsonEditorV2\JsonEditorV2\TestArea\AutoTest");
            //JETS.Exit();
        }
    }
}
