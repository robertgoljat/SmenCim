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

            Processor.XsdToCs(fileD, "CIM", outp, 0);

            Assert.IsTrue(File.Exists(outp));

            fileS = "../../Message.xsd";
            fileD = "Message.xsd";
            outp = "Message.cs";

            if (!File.Exists(fileD))
                File.Copy(fileS, fileD);

            if (File.Exists(outp))
                File.Delete(outp);

            Assert.IsFalse(File.Exists(outp));

            Processor.XsdToCs(fileD, "CIM", outp, 0);

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

            Processor.XsdToCs(fileD, "CIM", outp, 0);

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

            Processor.XsdToCs(fileD, "CIM", outp, 0);

            Assert.IsTrue(File.Exists(outp));

        }
        [TestMethod()]
        public void XsdToCs_UsagePointConfig()
        {
            string fileS, fileD, outp;

            fileS = "../../UsagePointConfig/wsdl/xsd/GetUsagePointConfigMessage.xsd";
            fileD = "GetUsagePointConfigMessage.xsd";
            outp = "GetUsagePointConfigMessage.cs";
            TransformToCs(fileS, fileD, outp, SrvcType.Get);

            fileS = "../../UsagePointConfig/wsdl/xsd/UsagePointConfigMessage.xsd";
            fileD = "UsagePointConfigMessage.xsd";
            outp = "ReplyUsagePointConfigMessage.cs";
            TransformToCs(fileS, fileD, outp, SrvcType.Reply);

            fileS = "../../UsagePointConfig/wsdl/xsd/UsagePointConfigMessage.xsd";
            fileD = "UsagePointConfigMessage.xsd";
            outp = "RequestUsagePointConfigMessage.cs";
            TransformToCs(fileS, fileD, outp, SrvcType.Request);

        }
        [TestMethod()]
        public void XsdToCs_GetMeterReadScheduleMessage()
        {
            var fileS = "../../MeterReadSchedule/wsdl/xsd/GetMeterReadScheduleMessage.xsd";
            var fileD = "GetMeterReadScheduleMessage.xsd";
            var outp = "GetMeterReadScheduleMessage.cs";
            TransformToCs(fileS, fileD, outp, 0);

            //fileS = "../../UsagePointConfig/wsdl/xsd/UsagePointConfigMessage.xsd";
            //fileD = "UsagePointConfigMessage.xsd";
            //outp = "UsagePointConfigMessage.cs";
            //TransformToCs(fileS, fileD, outp);
        }

        private static void TransformToCs(string fileS, string fileD, string outp, SrvcType type)
        {
            if (File.Exists(fileD))
                File.Delete(fileD);

            if (File.Exists(outp))
                File.Delete(outp);

            if (!File.Exists(fileD))
                File.Copy(fileS, fileD);

            Assert.IsFalse(File.Exists(outp));
            Processor.XsdToCs(fileD, "CIM", outp, type);
            Assert.IsTrue(File.Exists(outp));
        }
    }
}