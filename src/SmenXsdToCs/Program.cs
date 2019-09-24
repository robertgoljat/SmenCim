using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmenXsdToCs
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                string targetnamespace, xsdfile;
                string[] deleteXsd = null;

                try
                {
                    targetnamespace = options.Namespace != "" ? (options.Extension != "" ? $"{options.Namespace}.{options.Extension}" : options.Namespace) : "CIM";
                    xsdfile = getXsdfile(options.XsdFile, out deleteXsd);

                    Console.Write(" Creating CS file...");
                    Processor.XsdToCs(xsdfile, targetnamespace, options.OutputFile, options.ServiceType);
                    Console.Write(" Created! {0}", options.OutputFile);
                    Console.WriteLine();
                }
                catch (Exception e1)
                {
                    LogError(e1.Message);
                }

                deleteXsd?.ToList().ForEach(_ => File.Delete(_));

                Console.WriteLine();

                if (!options.Continue)
                {
                    Console.Write("Press any key to continue!");
                    Console.ReadKey();
                }
            }
        }

        static void LogError(string Message, bool OverridePretext = false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OverridePretext ? $"{Message}" : $"Error! Message: {Message}");
            Console.ResetColor();
        }
        static string getXsdfile(string xsdFile, out string[] deleteXsd)
        {
            deleteXsd = null;

            if (!File.Exists(xsdFile))
                throw new Exception($"Xsd file doesn't exist! Path: {xsdFile}");

            if (!IsInBaseDirectory(xsdFile))
            {
                var newXsdFile = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(xsdFile));

                deleteXsd = Directory.GetFiles(Path.GetDirectoryName(xsdFile), "*.xsd").Select(_ => Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(_))).ToArray();

                foreach (var file in Directory.GetFiles(Path.GetDirectoryName(xsdFile), "*.xsd"))
                {
                    var f = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(file));

                    if (File.Exists(f))
                        File.Delete(f);

                    File.Copy(file, f);
                }
                
                return Path.GetFileName(newXsdFile);
            }
            else
            {
                return Path.GetFileName(xsdFile);
            }
        }
        static bool IsInBaseDirectory(string xsdFile)
        {
            if (Path.GetDirectoryName(xsdFile) == "")
                return true;

            return Directory.GetCurrentDirectory() == Path.GetDirectoryName(xsdFile);
        }
    }
}
