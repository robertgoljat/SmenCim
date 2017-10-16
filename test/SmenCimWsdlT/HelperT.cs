using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SmenCimWsdl.T
{
    [TestClass()]
    public class HelperT
    {
        [TestMethod()]
        public void HelperReadDataFromFile()
        {
            var filepath = @"..\..\SomeData.txt";

            Assert.IsTrue(File.Exists(filepath));

            var data = filepath.ReadDataFromFile();

            Assert.AreEqual("Od jutra do mraka sonce vas čaka.", data);
        }

        [TestMethod()]
        public void HelperReadDataFromEmbeddedResource()
        {
            var filepath = "Message.xsd";

            var data = filepath.ReadDataFromEmbeddedResource();

            Assert.IsTrue(data.StartsWith("<?xml version="));
        }

        [TestMethod()]
        public void HelperWriteDataToDisk()
        {
            var filepath = "SomeData.txt";

            if (File.Exists(filepath))
                File.Delete(filepath);

            var data = "Od jutra do mraka sonce vas čaka.";

            Assert.IsFalse(File.Exists(filepath));

            var filepath2 = data.WriteDataToDisk(filepath);

            Assert.IsTrue(File.Exists(filepath));

            Assert.AreEqual(filepath, filepath2);
        }

        [TestMethod()]
        public void HelperUppercaseFirst()
        {
            Assert.AreEqual("Get", "get".UppercaseFirst());
            Assert.AreEqual("Get", "GET".UppercaseFirst());
            Assert.AreEqual("Get", "geT".UppercaseFirst());
            Assert.AreEqual("Get", "Get".UppercaseFirst());
        }
    }
}