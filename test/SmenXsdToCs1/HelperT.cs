using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SmenXsdToCs.T
{
    [TestClass()]
    public class HelperT
    {
        [TestMethod()]
        public void ProcessXsd()
        {
            var file = "../../UsagePointConfig.xsd";

            Assert.IsTrue(File.Exists(file));

            var code = Helper.ProcessXsd(file, "CIM");

            Assert.IsNotNull(code);
        }
    }
}
