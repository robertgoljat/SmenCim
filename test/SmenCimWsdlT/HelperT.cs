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

        [TestMethod()]
        public void ReplaceInformationObjectName()
        {
            var data = @"..\..\Resources\GetReplyMessage.xsd".ReadDataFromFile();

            var newdata = data.ReplaceInformationObjectName("UsagePointConfig", "UsagePointConfig");
            Assert.IsTrue(newdata.StartsWith("<?xml version=\"1.0\" encoding=\"utf-8\"?> \n<xs:schema \n  xmlns:tns=\"http://iec.ch/TC57/2011/GetUsagePointConfigMessage\" \n  xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" \n  xmlns:msg=\"http://iec.ch/TC57/2011/schema/message\" \n  xmlns:obj1=\"http://iec.ch/TC57/2011/UsagePointConfig\""));

            newdata = data.ReplaceInformationObjectName("UsagePointConfig", "UsagePointConfig#");
            Assert.IsTrue(newdata.StartsWith("<?xml version=\"1.0\" encoding=\"utf-8\"?> \n<xs:schema \n  xmlns:tns=\"http://iec.ch/TC57/2011/GetUsagePointConfigMessage\" \n  xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" \n  xmlns:msg=\"http://iec.ch/TC57/2011/schema/message\" \n  xmlns:obj1=\"http://iec.ch/TC57/2011/UsagePointConfig#\""));

        }

        [TestMethod()]
        public void GetProfilesNamespace()
        {
            var converter = new ConvertCimToWsdl();

            var filepath = @"..\..\Resources\WorkRequests.xsd";

            Assert.IsTrue(File.Exists(filepath));

            var data = filepath.ReadDataFromFile();

            var nmspc = data.GetProfilesNamespace();

            Assert.AreEqual("el", nmspc);

            filepath = @"..\..\Resources\SomeData.txt";

            Assert.IsTrue(File.Exists(filepath));

            data = filepath.ReadDataFromFile();

            nmspc = data.GetProfilesNamespace();

            Assert.AreEqual("", nmspc);

            filepath = @"..\..\Resources\UsagePointconfig.xsd";

            Assert.IsTrue(File.Exists(filepath));

            data = filepath.ReadDataFromFile();

            nmspc = data.GetProfilesNamespace();

            Assert.AreEqual("a", nmspc);
        }
        [TestMethod()]
        public void GetTargetNamespace()
        {
            var converter = new ConvertCimToWsdl();

            var filepath = @"..\..\Resources\UsagePointconfig.xsd";

            Assert.IsTrue(File.Exists(filepath));

            var data = filepath.ReadDataFromFile();

            var nmspc = data.GetTargetNamespace();

            Assert.AreEqual("http://iec.ch/TC57/2011/UsagePointConfig#", nmspc);

            filepath = @"..\..\Resources\WorkRequests.xsd";

            Assert.IsTrue(File.Exists(filepath));

            data = filepath.ReadDataFromFile();

            nmspc = data.GetTargetNamespace();

            Assert.AreEqual("http://iec.ch/TC57/2011/WorkRequests", nmspc);
        }
        [TestMethod()]
        public void GetNounFromTargetNamespace()
        {
            Assert.AreEqual("UsagePointConfig#", "http://iec.ch/TC57/2011/UsagePointConfig#".GetNounFromTargetNamespace());
            Assert.AreEqual("WorkRequests", "http://iec.ch/TC57/2011/WorkRequests".GetNounFromTargetNamespace());
        }
    }
}