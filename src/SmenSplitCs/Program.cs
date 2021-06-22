using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmenSplitCs
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                string targetnamespace, csfile;
                string[] deleteCs = null;

                targetnamespace = options.Namespace != "" ? options.Namespace : "CIM";

                if (options.InputFile != "" && options.OutputFile != "")
                {
                    csfile = getCsfile(options.InputFile, out deleteCs);

                    //
                }
            }
        }

        static void LogError(string Message, bool OverridePretext = false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OverridePretext ? $"{Message}" : $"Error! Message: {Message}");
            Console.ResetColor();
        }
        static bool IsInBaseDirectory(string file)
        {
            if (Path.GetDirectoryName(file) == "")
                return true;

            return Directory.GetCurrentDirectory() == Path.GetDirectoryName(file);
        }
        static string getCsfile(string csFile, out string[] deleteCs)
        {
            deleteCs = null;

            if (!File.Exists(csFile))
                throw new Exception($"Cs file doesn't exist! Path: {csFile}");

            if (!IsInBaseDirectory(csFile))
            {
                var newXsdFile = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(csFile));

                deleteCs = Directory.GetFiles(Path.GetDirectoryName(csFile), "*.cs").Select(_ => Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(_))).ToArray();

                foreach (var file in Directory.GetFiles(Path.GetDirectoryName(csFile), "*.cs"))
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
                return Path.GetFileName(csFile);
            }
        }
    }
}
