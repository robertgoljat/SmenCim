using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmenXsdToCs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmenXsdToCs.T
{
    [TestClass()]
    public class ProcessorT
    {
        
        [TestMethod()]
        public void XsdToCs()
        {
            var fileS = "../../UsagePointConfig.xsd";
            var fileD = "UsagePointConfigIn.xsd";
            var fileDOut = "UsagePointConfig.xsd";
            var outp = "UsagePointConfig.cs";

            if (!File.Exists(fileD))
                File.Copy(fileS, fileD);

            //if (File.Exists(fileDOut))
            //    File.Delete(fileDOut);

            if (File.Exists(outp))
                File.Delete(outp);

            Assert.IsFalse(File.Exists(outp));

            //var isOk = Processor.CleanXsd(fileD, fileDOut);
            //Assert.IsTrue(isOk);

            //Processor.XsdToCs(fileDOut, "CIM", outp);

            Processor.XsdToCs(fileD, "CIM", outp);

            Assert.IsTrue(File.Exists(outp));

            fileS = "../../Message.xsd";
            fileD = "Message.xsd";
            outp = "Message.cs";

            if (!File.Exists(fileD))
                File.Copy(fileS, fileD);

            if (File.Exists(outp))
                File.Delete(outp);

            Assert.IsFalse(File.Exists(outp));

            Processor.XsdToCs(fileD, "CIM", outp);

            Assert.IsTrue(File.Exists(outp));

            fileS = "../../GetUsagePointConfigMessage.xsd";
            fileD = "GetUsagePointConfigMessage.xsd";
            outp = "GetUsagePointConfigMessage.cs";

            if (!File.Exists("UsagePointConfig.xsd"))
                File.Copy("../../UsagePointConfig.xsd", "UsagePointConfig.xsd");

            if (!File.Exists(fileD))
                File.Copy(fileS, fileD);

            if (File.Exists(outp))
                File.Delete(outp);

            Assert.IsFalse(File.Exists(outp));

            Processor.XsdToCs(fileD, "CIM", outp);

            Assert.IsTrue(File.Exists(outp));


            fileS = "../../GetMeterReadScheduleMessage.xsd";
            fileD = "GetMeterReadScheduleMessage.xsd";
            outp = "GetMeterReadScheduleMessage.cs";

            if (!File.Exists("MeterReadSchedule.xsd"))
                File.Copy("../../MeterReadSchedule.xsd", "MeterReadSchedule.xsd");

            if (!File.Exists(fileD))
                File.Copy(fileS, fileD);

            if (File.Exists(outp))
                File.Delete(outp);

            Assert.IsFalse(File.Exists(outp));

            Processor.XsdToCs(fileD, "CIM", outp);

            Assert.IsTrue(File.Exists(outp));

        }
    }
}