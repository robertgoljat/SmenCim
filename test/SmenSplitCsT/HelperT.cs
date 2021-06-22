using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SmenSplitCs.T
{
    [TestClass]
    public class HelperT
    {
        [TestMethod]
        public void ProcessCs()
        {
            var file = "../../../GetMeterReadingsMessage.cs";
            Assert.IsTrue(File.Exists(file));

            var code = file.ProcessCs("CIM");
            Assert.IsNotNull(code);

            Assert.Fail();
        }
    }
}
