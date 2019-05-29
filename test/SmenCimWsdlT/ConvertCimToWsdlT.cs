using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SmenCimWsdl.T
{
    [TestClass()]
    public class ConvertCimToWsdlT
    {
        [TestMethod()]
        public void CreateArtifacts_Profile()
        {
            var converter = new ConvertCimToWsdl();

            var filepath = @"..\..\Resources\WorkRequests.xsd";
            var outXsdPath = @"xsd\";

            Assert.IsTrue(File.Exists(filepath));

            if (!Directory.Exists(outXsdPath))
                Directory.CreateDirectory(outXsdPath);

            Assert.IsTrue(Directory.Exists(outXsdPath));

            if (File.Exists(Path.Combine(outXsdPath, Path.GetFileName(filepath))))
                File.Delete(Path.Combine(outXsdPath, Path.GetFileName(filepath)));

            string noun2 = "";
            var outXsdPath2 = converter.CreateArtifacts_Profile(filepath, outXsdPath, out noun2);

            Assert.AreEqual(Path.Combine(outXsdPath, Path.GetFileName(filepath)), outXsdPath2);
            Assert.AreEqual("WorkRequests", noun2);

            Assert.IsTrue(File.Exists(outXsdPath2));

            filepath = @"..\..\Resources\UsagePointconfig.xsd";
            outXsdPath = @"xsd\";

            Assert.IsTrue(File.Exists(filepath));

            if (!Directory.Exists(outXsdPath))
                Directory.CreateDirectory(outXsdPath);

            Assert.IsTrue(Directory.Exists(outXsdPath));

            if (File.Exists(Path.Combine(outXsdPath, Path.GetFileName(filepath))))
                File.Delete(Path.Combine(outXsdPath, Path.GetFileName(filepath)));

            noun2 = "";
            outXsdPath2 = converter.CreateArtifacts_Profile(filepath, outXsdPath, out noun2);

            Assert.AreEqual(Path.Combine(outXsdPath, Path.GetFileName(filepath)), outXsdPath2);
            Assert.AreEqual("UsagePointConfig#", noun2);

            Assert.IsTrue(File.Exists(outXsdPath2));
        }
                
    }
}
