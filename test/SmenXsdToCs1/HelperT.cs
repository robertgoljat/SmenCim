using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            file = "../../UsagePointConfig/wsdl/xsd/GetUsagePointConfigMessage.xsd";
            Assert.IsTrue(File.Exists(file));
            code = Helper.ProcessXsd(file, "CIM");
            Assert.IsNotNull(code);

            file = "../../UsagePointConfig/wsdl/xsd/UsagePointConfigMessage.xsd";
            Assert.IsTrue(File.Exists(file));
            code = Helper.ProcessXsd(file, "CIM");
            Assert.IsNotNull(code);
        }
        [TestMethod()]
        public void WildcardSearch()
        {
            var list = new List<string>() { "Roberto1973", "Petrica1976", "1999Aljo", "2002Lukec", "2007Kaja", "2010Nika" };

            var result = list.WildcardSearch("Robi*").ToList();
            Assert.AreEqual(0, result.Count);

            result = list.WildcardSearch("Roberto*").ToList();
            Assert.AreEqual(1, result.Count);

            result = list.WildcardSearch("R*3").ToList();
            Assert.AreEqual(1, result.Count);

            result = list.WildcardSearch("*Roberto").ToList();
            Assert.AreEqual(0, result.Count);

            result = list.WildcardSearch("*Nika").ToList();
            Assert.AreEqual(1, result.Count);

            result = list.WildcardSearch("*tri*").ToList();
            Assert.AreEqual(1, result.Count);

            result = list.WildcardSearch("*a").ToList();
            Assert.AreEqual(2, result.Count);

        }
        [TestMethod()]
        public void NounFromWildcard()
        {
            var result = "GetMeterReadScheduleRequestMessage".NounFromWildcard("Get*RequestMessage");
            Assert.AreEqual("MeterReadSchedule", result);

        }
    }
}
