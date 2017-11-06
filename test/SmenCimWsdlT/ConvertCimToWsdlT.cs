using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmenCimWsdl.T
{
    [TestClass()]
    public class ConvertCimToWsdlT
    {
        [TestMethod()]
        public void ConvertCimToWsdlCreateArtifacts_Profile()
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

            var outXsdPath2 = converter.CreateArtifacts_Profile(filepath, outXsdPath);

            Assert.AreEqual(Path.Combine(outXsdPath, Path.GetFileName(filepath)), outXsdPath2);

            Assert.IsTrue(File.Exists(outXsdPath2));
        }
        [TestMethod()]
        public void ConvertCimToWsdlGetProfilesNamespace()
        {
            var converter = new ConvertCimToWsdl();

            var filepath = @"..\..\Resources\WorkRequests.xsd";

            Assert.IsTrue(File.Exists(filepath));

            var data = filepath.ReadDataFromFile();

            var nmspc = converter.GetProfilesNamespace(data);

            Assert.AreEqual("el", nmspc);

            filepath = @"..\..\Resources\SomeData.txt";

            Assert.IsTrue(File.Exists(filepath));

            data = filepath.ReadDataFromFile();

            nmspc = converter.GetProfilesNamespace(data);

            Assert.AreEqual("", nmspc);
        }
    }
}
